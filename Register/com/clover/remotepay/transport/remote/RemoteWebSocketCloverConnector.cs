// ***********************************************************************
// Assembly         : Register
// Author           : Seungkeun
// Created          : 02-08-2017
//
// Last Modified By : Seungkeun
// Last Modified On : 09-15-2017
// ***********************************************************************
// <copyright file="RemoteWebSocketCloverConnector.cs" company="Beauty4u">
//     Copyright © Beauty4u 2009
// </copyright>
// <summary></summary>
// ***********************************************************************.

using com.clover.remotepay.sdk;
using com.clover.remote.order;
using com.clover.sdk.remote.websocket;
using com.clover.remotepay.sdk.service.client;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using System.Threading;
using System.ComponentModel;
using WebSocket4Net;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using com.clover.sdk.v3.payments;

/// <summary>
/// The remote namespace.
/// </summary>
namespace com.clover.remotepay.transport.remote
{

    /// <summary>
    /// Custom ICloverConnector that talks to the
    /// Clover Connector WebSocket Service. This wouldn't normally
    /// be used because it is in .NET, and it would normally
    /// make more sense to use the DLL directly in .NET
    /// </summary>
    /// <seealso cref="com.clover.remotepay.sdk.ICloverConnector" />
    public class RemoteWebSocketCloverConnector : ICloverConnector
    {
        /// <summary>
        /// The is ready
        /// </summary>
        private bool _isReady = false;

        /// <summary>
        /// Gets or sets a value indicating whether this instance is ready.
        /// </summary>
        /// <value><c>true</c> if this instance is ready; otherwise, <c>false</c>.</value>
        public bool IsReady
        {
            get { return _isReady; }
            set { }
        }
        /// <summary>
        /// Gets or sets the card entry method.
        /// </summary>
        /// <value>The card entry method.</value>
        public int CardEntryMethod { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [disable cash back].
        /// </summary>
        /// <value><c>true</c> if [disable cash back]; otherwise, <c>false</c>.</value>
        public bool DisableCashBack { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [disable printing].
        /// </summary>
        /// <value><c>true</c> if [disable printing]; otherwise, <c>false</c>.</value>
        public bool DisablePrinting { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [disable restart transaction on fail].
        /// </summary>
        /// <value><c>true</c> if [disable restart transaction on fail]; otherwise, <c>false</c>.</value>
        public bool DisableRestartTransactionOnFail { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [disable tip].
        /// </summary>
        /// <value><c>true</c> if [disable tip]; otherwise, <c>false</c>.</value>
        public bool DisableTip { get; set; }
        /// <summary>
        /// The SDK information
        /// </summary>
        string _SDKInfo;
        /// <summary>
        /// Gets the SDK information.
        /// </summary>
        /// <value>The SDK information.</value>
        public string SDKInfo
        {
            get
            {
                return this._SDKInfo;
            }
        }

        /// <summary>
        /// The listeners
        /// </summary>
        List<ICloverConnectorListener> listeners = new List<ICloverConnectorListener>();
        /// <summary>
        /// The configuration
        /// </summary>
        private CloverDeviceConfiguration config;

        /// <summary>
        /// The websocket
        /// </summary>
        WebSocket websocket;
        /// <summary>
        /// The endpoint
        /// </summary>
        string endpoint = "ws://localhost:8889";

        /// <summary>
        /// Initializes a new instance of the <see cref="RemoteWebSocketCloverConnector"/> class.
        /// </summary>
        public RemoteWebSocketCloverConnector()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RemoteWebSocketCloverConnector"/> class.
        /// </summary>
        /// <param name="config">The configuration.</param>
        public RemoteWebSocketCloverConnector(CloverDeviceConfiguration config)
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.Load("CloverConnector");
            _SDKInfo = AssemblyUtils.GetAssemblyAttribute<System.Reflection.AssemblyDescriptionAttribute>(assembly).Description + ":"
                + (AssemblyUtils.GetAssemblyAttribute<System.Reflection.AssemblyFileVersionAttribute>(assembly)).Version
                + (AssemblyUtils.GetAssemblyAttribute<System.Reflection.AssemblyInformationalVersionAttribute>(assembly)).InformationalVersion;
            this.config = config;
            endpoint = ((RemoteWebSocketCloverConfiguration)config).endpoint;
        }
        /// <summary>
        /// Initializes the connection.
        /// </summary>
        public void InitializeConnection()
        {
            CardEntryMethod = CloverConnector.CARD_ENTRY_METHOD_ICC_CONTACT | CloverConnector.CARD_ENTRY_METHOD_MAG_STRIPE | CloverConnector.CARD_ENTRY_METHOD_NFC_CONTACTLESS;
            websocket = new WebSocket(endpoint);
            websocket.Opened += new EventHandler(websocket_Opened);
            websocket.Error += new EventHandler<SuperSocket.ClientEngine.ErrorEventArgs>(websocket_Error);
            websocket.Closed += new EventHandler(websocket_Closed);
            websocket.MessageReceived += new EventHandler<MessageReceivedEventArgs>(websocket_MessageReceived);
            websocket.Open();
        }

        /// <summary>
        /// Handles the Opened event of the websocket control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void websocket_Opened(object sender, EventArgs e)
        {
            Console.WriteLine("WebSocket connection open");
            _isReady = true;
            websocket.Send(JsonUtils.serialize(new StatusRequestMessage()));
        }

        /// <summary>
        /// Handles the Error event of the websocket control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void websocket_Error(object sender, EventArgs e)
        {
            Console.WriteLine("WebSocket error");
        }

        /// <summary>
        /// Handles the Closed event of the websocket control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void websocket_Closed(object sender, EventArgs e)
        {
            Console.WriteLine("WebSocket connection closed");
#if DEBUG
            System.GC.Collect();
#endif
            _isReady = false;
            BackgroundWorker bg = new BackgroundWorker();
            bg.DoWork += (object s, DoWorkEventArgs dwea) =>
            {
                Thread.Sleep(100);
                websocket.Open();
                Console.WriteLine("Done trying to open");
            };
            bg.RunWorkerAsync();
        }


        /// <summary>
        /// Handles the MessageReceived event of the websocket control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MessageReceivedEventArgs"/> instance containing the event data.</param>
        private void websocket_MessageReceived(object sender, MessageReceivedEventArgs e)
        {
            // do the parsing of the message, targeted for the callback listener
            JObject jsonObj = null;
            try
            {
                jsonObj = (JObject)JsonConvert.DeserializeObject(e.Message);
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message + " => " + e.Message);
                listeners.ForEach(listener => listener.OnDeviceError(new CloverDeviceErrorEvent(CloverDeviceErrorEvent.CloverDeviceErrorType.EXCEPTION, 0, exc.Message + " => " + e.Message)));
                return;
            }

            JToken method = jsonObj.GetValue(ServicePayloadConstants.PROP_METHOD);
            if (method == null)
            {
                listeners.ForEach(listener => listener.OnDeviceError(new CloverDeviceErrorEvent(CloverDeviceErrorEvent.CloverDeviceErrorType.VALIDATION_ERROR, 0, "Invalid message: " + e.Message)));
                return;
            }
            JObject payload = (JObject)jsonObj.GetValue(ServicePayloadConstants.PROP_PAYLOAD);
            WebSocketMethod wsm = (WebSocketMethod)Enum.Parse(typeof(WebSocketMethod), method.ToString());

            try
            {
                switch (wsm)
                {
                    case WebSocketMethod.DeviceActivityStart:
                        {
                            CloverDeviceEvent deviceEvent = JsonUtils.deserialize<CloverDeviceEvent>(payload.ToString());
                            listeners.ForEach(listener => listener.OnDeviceActivityStart(deviceEvent));
                            break;
                        }
                    case WebSocketMethod.DeviceActivityEnd:
                        {
                            CloverDeviceEvent deviceEvent = JsonUtils.deserialize<CloverDeviceEvent>(payload.ToString());
                            listeners.ForEach(listener => listener.OnDeviceActivityEnd(deviceEvent));
                            break;
                        }
                    case WebSocketMethod.DeviceError:
                        {
                            CloverDeviceErrorEvent deviceErrorEvent = JsonUtils.deserialize<CloverDeviceErrorEvent>(payload.ToString());
                            listeners.ForEach(listener => listener.OnDeviceError(deviceErrorEvent));
                            break;
                        }
                    case WebSocketMethod.DeviceConnected:
                        {
                            listeners.ForEach(listener => listener.OnDeviceConnected());
                            break;
                        }
                    case WebSocketMethod.DeviceDisconnected:
                        {
                            listeners.ForEach(listener => listener.OnDeviceDisconnected());
                            break;
                        }
                    case WebSocketMethod.DeviceReady:
                        {
                            MerchantInfo merchantInfo = JsonUtils.deserialize<MerchantInfo>(payload.ToString());
                            listeners.ForEach(listener => listener.OnDeviceReady(merchantInfo));
                            break;
                        }
                    case WebSocketMethod.VerifySignatureRequest:
                        {
                            VerifySignatureRequest svr = JsonUtils.deserialize<VerifySignatureRequest>(payload.ToString());
                            WebSocketSigVerRequestHandler handler = new WebSocketSigVerRequestHandler(this, svr);
                            listeners.ForEach(listener => listener.OnVerifySignatureRequest(handler));
                            break;
                        }
                    case WebSocketMethod.SaleResponse:
                        {
                            SaleResponse sr = JsonUtils.deserialize<SaleResponse>(payload.ToString());
                            listeners.ForEach(listener => listener.OnSaleResponse(sr));
                            break;
                        }
                    case WebSocketMethod.PreAuthResponse:
                        {
                            PreAuthResponse pr = JsonUtils.deserialize<PreAuthResponse>(payload.ToString());
                            listeners.ForEach(listener => listener.OnPreAuthResponse(pr));
                            break;
                        }
                    case WebSocketMethod.AuthResponse:
                        {
                            AuthResponse ar = JsonUtils.deserialize<AuthResponse>(payload.ToString());
                            listeners.ForEach(listener => listener.OnAuthResponse(ar));
                            break;
                        }
                    case WebSocketMethod.CapturePreAuthResponse:
                        {
                            CapturePreAuthResponse ar = JsonUtils.deserialize<CapturePreAuthResponse>(payload.ToString());
                            listeners.ForEach(listener => listener.OnCapturePreAuthResponse(ar));
                            break;
                        }
                    case WebSocketMethod.RefundPaymentResponse:
                        {
                            RefundPaymentResponse sr = JsonUtils.deserialize<RefundPaymentResponse>(payload.ToString());
                            listeners.ForEach(listener => listener.OnRefundPaymentResponse(sr));
                            break;
                        }
                    case WebSocketMethod.VoidPaymentResponse:
                        {
                            VoidPaymentResponse sr = JsonUtils.deserialize<VoidPaymentResponse>(payload.ToString());
                            listeners.ForEach(listener => listener.OnVoidPaymentResponse(sr));
                            break;
                        }
                    case WebSocketMethod.ManualRefundResponse:
                        {
                            ManualRefundResponse sr = JsonUtils.deserialize<ManualRefundResponse>(payload.ToString());
                            listeners.ForEach(listener => listener.OnManualRefundResponse(sr));
                            break;
                        }
                    case WebSocketMethod.TipAdjustAuthResponse:
                        {
                            TipAdjustAuthResponse taar = JsonUtils.deserialize<TipAdjustAuthResponse>(payload.ToString());
                            listeners.ForEach(listener => listener.OnTipAdjustAuthResponse(taar));
                            break;
                        }
                    case WebSocketMethod.VaultCardResponse:
                        {
                            VaultCardResponse vcr = JsonUtils.deserialize<VaultCardResponse>(payload.ToString());
                            listeners.ForEach(listener => listener.OnVaultCardResponse(vcr));
                            break;
                        }
                    case WebSocketMethod.ReadCardDataResponse:
                        {
                            ReadCardDataResponse rcdr = JsonUtils.deserialize<ReadCardDataResponse>(payload.ToString());
                            listeners.ForEach(listener => listener.OnReadCardDataResponse(rcdr));
                            break;
                        }
                    case WebSocketMethod.CloseoutResponse:
                        {
                            CloseoutResponse cr = JsonUtils.deserialize<CloseoutResponse>(payload.ToString());
                            listeners.ForEach(listener => listener.OnCloseoutResponse(cr));
                            break;
                        }
                    case WebSocketMethod.ConfirmPaymentRequest:
                        {
                            ConfirmPaymentRequest cpr = JsonUtils.deserialize<ConfirmPaymentRequest>(payload.ToString());
                            listeners.ForEach(listener => listener.OnConfirmPaymentRequest(cpr));
                            break;
                        }
                    case WebSocketMethod.RetrievePendingPaymentsResponse:
                        {
                            RetrievePendingPaymentsResponse rppr = JsonUtils.deserialize<RetrievePendingPaymentsResponse>(payload.ToString());
                            listeners.ForEach(listener => listener.OnRetrievePendingPaymentsResponse(rppr));
                            break;
                        }
                    case WebSocketMethod.PrintManualRefundDeclinedReceipt:
                        {
                            PrintManualRefundDeclineReceiptMessage pmrdrm = JsonUtils.deserialize<PrintManualRefundDeclineReceiptMessage>(payload.ToString());
                            listeners.ForEach(listener => listener.OnPrintManualRefundDeclineReceipt(pmrdrm));
                            break;
                        }
                    case WebSocketMethod.PrintManualRefundReceipt:
                        {
                            PrintManualRefundReceiptMessage pmrrm = JsonUtils.deserialize<PrintManualRefundReceiptMessage>(payload.ToString());
                            listeners.ForEach(listener => listener.OnPrintManualRefundReceipt(pmrrm));
                            break;
                        }
                    case WebSocketMethod.PrintPaymentDeclinedReceipt:
                        {
                            PrintPaymentDeclineReceiptMessage ppdrm = JsonUtils.deserialize<PrintPaymentDeclineReceiptMessage>(payload.ToString());
                            listeners.ForEach(listener => listener.OnPrintPaymentDeclineReceipt(ppdrm));
                            break;
                        }
                    case WebSocketMethod.PrintPaymentMerchantCopyReceipt:
                        {
                            PrintPaymentMerchantCopyReceiptMessage ppmcrm = JsonUtils.deserialize<PrintPaymentMerchantCopyReceiptMessage>(payload.ToString());
                            listeners.ForEach(listener => listener.OnPrintPaymentMerchantCopyReceipt(ppmcrm));
                            break;
                        }
                    case WebSocketMethod.PrintPaymentReceipt:
                        {
                            PrintPaymentReceiptMessage pprm = JsonUtils.deserialize<PrintPaymentReceiptMessage>(payload.ToString());
                            listeners.ForEach(listener => listener.OnPrintPaymentReceipt(pprm));
                            break;
                        }
                    case WebSocketMethod.PrintPaymentRefundReceipt:
                        {
                            PrintRefundPaymentReceiptMessage prprm = JsonUtils.deserialize<PrintRefundPaymentReceiptMessage>(payload.ToString());
                            listeners.ForEach(listener => listener.OnPrintRefundPaymentReceipt(prprm));
                            break;
                        }
                    case WebSocketMethod.CustomActivityResponse:
                        {
                            CustomActivityResponse car = JsonUtils.deserialize<CustomActivityResponse>(payload.ToString());
                            listeners.ForEach(listener => listener.OnCustomActivityResponse(car));
                            break;
                        }
                    case WebSocketMethod.MessageFromActivity:
                        {
                            MessageFromActivity mta = JsonUtils.deserialize<MessageFromActivity>(payload.ToString());
                            listeners.ForEach(listener => listener.OnMessageFromActivity(mta));
                            break;
                        }
                    case WebSocketMethod.RetrieveDeviceStatusResponse:
                        {
                            RetrieveDeviceStatusResponse rdsr = JsonUtils.deserialize<RetrieveDeviceStatusResponse>(payload.ToString());
                            listeners.ForEach(listener => listener.OnRetrieveDeviceStatusResponse(rdsr));
                            break;
                        }
                    case WebSocketMethod.ResetDeviceResponse:
                        {
                            ResetDeviceResponse rdr = JsonUtils.deserialize<ResetDeviceResponse>(payload.ToString());
                            listeners.ForEach(listener => listener.OnResetDeviceResponse(rdr));
                            break;
                        }
                    case WebSocketMethod.RetrievePaymentResponse:
                        {
                            RetrievePaymentResponse rpr = JsonUtils.deserialize<RetrievePaymentResponse>(payload.ToString());
                            listeners.ForEach(listener => listener.OnRetrievePaymentResponse(rpr));
                            break;
                        }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Adds the clover connector listener.
        /// </summary>
        /// <param name="connectorListener">The connector listener.</param>
        public void AddCloverConnectorListener(ICloverConnectorListener connectorListener)
        {
            listeners.Add(connectorListener);
        }

        /// <summary>
        /// Removes the clover connector listener.
        /// </summary>
        /// <param name="connectorListener">The connector listener.</param>
        public void RemoveCloverConnectorListener(ICloverConnectorListener connectorListener)
        {
            listeners.Remove(connectorListener);
        }

        /// <summary>
        /// Accepts the signature.
        /// </summary>
        /// <param name="request">The request.</param>
        public void AcceptSignature(VerifySignatureRequest request)
        {
            if (websocket != null)
            {
                AcceptSignatureRequestMessage message = new AcceptSignatureRequestMessage();
                message.payload = request;
                websocket.Send(JsonUtils.serialize(message));
            }
        }

        /// <summary>
        /// Rejects the signature.
        /// </summary>
        /// <param name="request">The request.</param>
        public void RejectSignature(VerifySignatureRequest request)
        {
            if (websocket != null)
            {
                RejectSignatureRequestMessage message = new RejectSignatureRequestMessage();
                message.payload = request;
                websocket.Send(JsonUtils.serialize(message));
            }
        }

        /// <summary>
        /// Authentications the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        public void Auth(AuthRequest request)
        {
            if (websocket != null)
            {
                AuthRequestMessage message = new AuthRequestMessage();
                message.payload = request;
                websocket.Send(JsonUtils.serialize(message));
            }
        }

        /// <summary>
        /// Pres the authentication.
        /// </summary>
        /// <param name="request">The request.</param>
        public void PreAuth(PreAuthRequest request)
        {
            if (websocket != null)
            {
                PreAuthRequestMessage message = new PreAuthRequestMessage();
                message.payload = request;
                websocket.Send(JsonUtils.serialize(message));
            }
        }

        /// <summary>
        /// Cancels this instance.
        /// </summary>
        public void Cancel()
        {
            if (websocket != null)
            {
                websocket.Send(JsonUtils.serialize(new CancelRequestMessage()));
            }
        }

        /// <summary>
        /// Captures the pre authentication.
        /// </summary>
        /// <param name="request">The request.</param>
        public void CapturePreAuth(CapturePreAuthRequest request)
        {
            if (websocket != null)
            {
                CapturePreAuthRequestMessage message = new CapturePreAuthRequestMessage();
                message.payload = request;
                websocket.Send(JsonUtils.serialize(message));
            }
        }

        /// <summary>
        /// Vaults the card.
        /// </summary>
        /// <param name="CardEntryMethods">The card entry methods.</param>
        public void VaultCard(int? CardEntryMethods)
        {
            if (websocket != null)
            {
                VaultCardRequestMessage message = new VaultCardRequestMessage();
                message.payload = new VaultCardMessage(CardEntryMethods);
                websocket.Send(JsonUtils.serialize(message));
            }
        }

        /// <summary>
        /// Reads the card data.
        /// </summary>
        /// <param name="request">The request.</param>
        public void ReadCardData(ReadCardDataRequest request)
        {
            if (websocket != null)
            {
                ReadCardDataRequestMessage message = new ReadCardDataRequestMessage();
                message.payload = request;
                websocket.Send(JsonUtils.serialize(message));
            }
        }

        /// <summary>
        /// Starts the custom activity.
        /// </summary>
        /// <param name="request">The request.</param>
        public void StartCustomActivity(CustomActivityRequest request)
        {
            if (websocket != null)
            {
                CustomActivityRequestMessage message = new CustomActivityRequestMessage();
                message.payload = request;
                websocket.Send(JsonUtils.serialize(message));
            }
        }

        /// <summary>
        /// Closeouts the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        public void Closeout(CloseoutRequest request)
        {
            if (websocket != null)
            {
                CloseoutRequestMessage message = new CloseoutRequestMessage();
                websocket.Send(JsonUtils.serialize(message));
            }
        }

        /// <summary>
        /// Shows the display order.
        /// </summary>
        /// <param name="order">The order.</param>
        public void ShowDisplayOrder(DisplayOrder order)
        {
            if (websocket != null)
            {
                DisplayOrderRequestMessage message = new DisplayOrderRequestMessage();
                message.payload = order;
                websocket.Send(JsonUtils.serialize(message));
            }
        }

        /// <summary>
        /// Discounts the added to display order.
        /// </summary>
        /// <param name="order">The order.</param>
        /// <param name="discount">The discount.</param>
        public void DiscountAddedToDisplayOrder(DisplayOrder order, DisplayDiscount discount)
        {
            if (websocket != null)
            {
                DiscountAddedToDisplayOrderRequestMessage message = new DiscountAddedToDisplayOrderRequestMessage();
                DiscountAddedToDisplayOrder payload = new DiscountAddedToDisplayOrder();
                payload.DisplayDiscount = discount;
                payload.DisplayOrder = order;
                message.payload = payload;
                websocket.Send(JsonUtils.serialize(message));
            }
        }

        /// <summary>
        /// Discounts the removed from display order.
        /// </summary>
        /// <param name="order">The order.</param>
        /// <param name="discount">The discount.</param>
        public void DiscountRemovedFromDisplayOrder(DisplayOrder order, DisplayDiscount discount)
        {
            if (websocket != null)
            {
                DiscountRemovedFromDisplayOrderRequestMessage message = new DiscountRemovedFromDisplayOrderRequestMessage();
                DiscountRemovedFromDisplayOrder payload = new DiscountRemovedFromDisplayOrder();
                payload.DisplayDiscount = discount;
                payload.DisplayOrder = order;
                message.payload = payload;
                websocket.Send(JsonUtils.serialize(message));
            }
        }

        /// <summary>
        /// Lines the item added to display order.
        /// </summary>
        /// <param name="order">The order.</param>
        /// <param name="lineItem">The line item.</param>
        public void LineItemAddedToDisplayOrder(DisplayOrder order, DisplayLineItem lineItem)
        {
            if (websocket != null)
            {
                LineItemAddedToDisplayOrderRequestMessage message = new LineItemAddedToDisplayOrderRequestMessage();
                LineItemAddedToDisplayOrder payload = new LineItemAddedToDisplayOrder();
                payload.DisplayLineItem = lineItem;
                payload.DisplayOrder = order;
                message.payload = payload;
                websocket.Send(JsonUtils.serialize(message));
            }
        }

        /// <summary>
        /// Lines the item removed from display order.
        /// </summary>
        /// <param name="order">The order.</param>
        /// <param name="lineItem">The line item.</param>
        public void LineItemRemovedFromDisplayOrder(DisplayOrder order, DisplayLineItem lineItem)
        {
            if (websocket != null)
            {
                LineItemRemovedFromDisplayOrderRequestMessage message = new LineItemRemovedFromDisplayOrderRequestMessage();
                LineItemRemovedFromDisplayOrder payload = new LineItemRemovedFromDisplayOrder();
                payload.DisplayLineItem = lineItem;
                payload.DisplayOrder = order;
                message.payload = payload;
                websocket.Send(JsonUtils.serialize(message));
            }
        }

        /// <summary>
        /// Removes the display order.
        /// </summary>
        /// <param name="displayOrder">The display order.</param>
        public void RemoveDisplayOrder(DisplayOrder displayOrder)
        {
            ShowWelcomeScreen();
        }

        /// <summary>
        /// Displays the payment receipt options.
        /// </summary>
        /// <param name="orderId">The order identifier.</param>
        /// <param name="paymentId">The payment identifier.</param>
        public void DisplayPaymentReceiptOptions(String orderId, String paymentId)
        {
            if (websocket != null)
            {
                DisplayPaymentReceiptOptionsRequestMessage message = new DisplayPaymentReceiptOptionsRequestMessage();
                DisplayPaymentReceiptOptionsRequest req = new DisplayPaymentReceiptOptionsRequest();
                req.OrderID = orderId;
                req.PaymentID = paymentId;
                message.payload = req;
                websocket.Send(JsonUtils.serialize(message));
            }
        }

        /// <summary>
        /// Disposes this instance.
        /// </summary>
        public void Dispose()
        {
            websocket.Close();
        }

        /// <summary>
        /// Gets the merchant information.
        /// </summary>
        /// <exception cref="System.NotImplementedException"></exception>
        public void GetMerchantInfo()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Invokes the input option.
        /// </summary>
        /// <param name="io">The io.</param>
        public void InvokeInputOption(InputOption io)
        {
            if (websocket != null)
            {
                InvokeInputOptionRequestMessage message = new InvokeInputOptionRequestMessage();
                message.payload = io;
                websocket.Send(JsonUtils.serialize(message));
            }
        }

        /// <summary>
        /// Manuals the refund.
        /// </summary>
        /// <param name="request">The request.</param>
        public void ManualRefund(ManualRefundRequest request)
        {
            if (websocket != null)
            {
                ManualRefundRequestMessage message = new ManualRefundRequestMessage();
                message.payload = request;
                websocket.Send(JsonUtils.serialize(message));
            }
        }

        /// <summary>
        /// Opens the cash drawer.
        /// </summary>
        /// <param name="reason">The reason.</param>
        public void OpenCashDrawer(string reason)
        {
            if (websocket != null)
            {
                OpenCashDrawerRequestMessage message = new OpenCashDrawerRequestMessage();
                websocket.Send(JsonUtils.serialize(message));
            }
        }

        /// <summary>
        /// Prints the image.
        /// </summary>
        /// <param name="bitmap">The bitmap.</param>
        public void PrintImage(Bitmap bitmap)
        {
            if (websocket != null)
            {
                PrintImageRequestMessage message = new PrintImageRequestMessage();
                PrintImage pi = new PrintImage();

                MemoryStream ms = new MemoryStream();
                bitmap.Save(ms, ImageFormat.Png);
                byte[] imgBytes = ms.ToArray();
                string base64Image = Convert.ToBase64String(imgBytes);

                pi.Bitmap = base64Image; // serialize image to string..
                message.payload = pi;
                websocket.Send(JsonUtils.serialize(message));
            }
        }

        /// <summary>
        /// Prints the text.
        /// </summary>
        /// <param name="messages">The messages.</param>
        public void PrintText(List<string> messages)
        {
            if (websocket != null)
            {
                PrintTextRequestMessage message = new PrintTextRequestMessage();
                PrintText pt = new PrintText();
                pt.Messages = messages;
                message.payload = pt;
                websocket.Send(JsonUtils.serialize(message));
            }
        }

        /// <summary>
        /// Refunds the payment.
        /// </summary>
        /// <param name="request">The request.</param>
        public void RefundPayment(RefundPaymentRequest request)
        {
            if (websocket != null)
            {
                RefundPaymentRequestMessage message = new RefundPaymentRequestMessage();
                message.payload = request;
                websocket.Send(JsonUtils.serialize(message));
            }
        }

        /// <summary>
        /// Sales the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        public void Sale(SaleRequest request)
        {
            if (websocket != null)
            {
                SaleRequestMessage message = new SaleRequestMessage();
                message.payload = request;
                websocket.Send(JsonUtils.serialize(message));

            }
        }

        /// <summary>
        /// Shows the message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void ShowMessage(string message)
        {
            if (websocket != null)
            {
                ShowMessageRequestMessage msg = new ShowMessageRequestMessage();
                sdk.service.client.ShowMessage payload = new sdk.service.client.ShowMessage();
                payload.Message = message;
                msg.payload = payload;

                websocket.Send(JsonUtils.serialize(msg));
            }
        }

        /// <summary>
        /// Shows the thank you screen.
        /// </summary>
        public void ShowThankYouScreen()
        {
            if (websocket != null)
            {
                websocket.Send(JsonUtils.serialize(new ShowThankYouScreenRequestMessage()));
            }
        }

        /// <summary>
        /// Shows the welcome screen.
        /// </summary>
        public void ShowWelcomeScreen()
        {
            if (websocket != null)
            {
                websocket.Send(JsonUtils.serialize(new ShowWelcomeScreenRequestMessage()));
            }
        }


        /// <summary>
        /// Retrieves the pending payments.
        /// </summary>
        public void RetrievePendingPayments()
        {
            if (websocket != null)
            {
                websocket.Send(JsonUtils.serialize(new RetrievePendingPaymentsRequestMessage()));
            }
        }

        /// <summary>
        /// Tips the adjust authentication.
        /// </summary>
        /// <param name="request">The request.</param>
        public void TipAdjustAuth(TipAdjustAuthRequest request)
        {
            if (websocket != null)
            {
                TipAdjustAuthRequestMessage message = new TipAdjustAuthRequestMessage();
                message.payload = request;
                websocket.Send(JsonUtils.serialize(message));
            }
        }

        /// <summary>
        /// Voids the payment.
        /// </summary>
        /// <param name="request">The request.</param>
        public void VoidPayment(VoidPaymentRequest request)
        {
            if (websocket != null)
            {
                VoidPaymentRequestMessage message = new VoidPaymentRequestMessage();
                message.payload = request;
                websocket.Send(JsonUtils.serialize(message));

            }
        }

        /// <summary>
        /// Resets the device.
        /// </summary>
        public void ResetDevice()
        {
            if (websocket != null)
            {
                //websocket.Send(JsonUtils.serialize(new BreakRequestMessage())); // deprecated
                websocket.Send(JsonUtils.serialize(new ResetDeviceMessage()));
            }
        }

        /// <summary>
        /// Initializes the connection.
        /// </summary>
        /// <exception cref="System.NotImplementedException"></exception>
        public void initializeConnection()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Prints the image from URL.
        /// </summary>
        /// <param name="ImgURL">The img URL.</param>
        public void PrintImageFromURL(string ImgURL)
        {
            if (websocket != null)
            {
                PrintImageFromURLRequestMessage msg = new PrintImageFromURLRequestMessage();
                sdk.service.client.PrintImage payload = new sdk.service.client.PrintImage();
                payload.Url = ImgURL;
                msg.payload = payload;

                websocket.Send(JsonUtils.serialize(msg));
            }
        }

        /// <summary>
        /// Accepts the payment.
        /// </summary>
        /// <param name="payment">The payment.</param>
        public void AcceptPayment(Payment payment)
        {
            if (websocket != null)
            {
                AcceptPaymentRequestMessage msg = new AcceptPaymentRequestMessage();
                sdk.AcceptPayment ap = new sdk.AcceptPayment();
                ap.Payment = payment;
                msg.payload = ap;
                websocket.Send(JsonUtils.serialize(msg));

            }
        }

        /// <summary>
        /// Rejects the payment.
        /// </summary>
        /// <param name="payment">The payment.</param>
        /// <param name="challenge">The challenge.</param>
        public void RejectPayment(Payment payment, Challenge challenge)
        {
            if (websocket != null)
            {
                RejectPaymentRequestMessage msg = new RejectPaymentRequestMessage();
                sdk.RejectPayment rp = new sdk.RejectPayment();
                rp.Payment = payment;
                rp.Challenge = challenge;
                msg.payload = rp;
                websocket.Send(JsonUtils.serialize(msg));

            }
        }

        /// <summary>
        /// Sends the message to activity.
        /// </summary>
        /// <param name="mta">The MTA.</param>
        public void SendMessageToActivity(MessageToActivity mta)
        {
            if (websocket != null)
            {
                MessageToActivityMessage msg = new MessageToActivityMessage();
                msg.payload = mta;
                websocket.Send(JsonUtils.serialize(msg));
            }
        }

        /// <summary>
        /// Retrieves the device status.
        /// </summary>
        /// <param name="rdsr">The RDSR.</param>
        public void RetrieveDeviceStatus(RetrieveDeviceStatusRequest rdsr)
        {
            if (websocket != null)
            {
                RetrieveDeviceStatusMessage msg = new RetrieveDeviceStatusMessage();
                msg.payload = rdsr;
                websocket.Send(JsonUtils.serialize(msg));
            }
        }

        /// <summary>
        /// Retrieves the payment.
        /// </summary>
        /// <param name="rpr">The RPR.</param>
        public void RetrievePayment(RetrievePaymentRequest rpr)
        {
            if (websocket != null)
            {
               RetrievePaymentRequestMessage msg = new RetrievePaymentRequestMessage();
                msg.payload = rpr;
                websocket.Send(JsonUtils.serialize(msg));
            }
        }

        /// <summary>
        /// Class WebSocketSigVerRequestHandler.
        /// </summary>
        /// <seealso cref="com.clover.remotepay.sdk.VerifySignatureRequest" />
        public class WebSocketSigVerRequestHandler : VerifySignatureRequest
        {
            /// <summary>
            /// The SVR
            /// </summary>
            VerifySignatureRequest svr;
            /// <summary>
            /// The ws clover connector
            /// </summary>
            RemoteWebSocketCloverConnector WSCloverConnector;
            /// <summary>
            /// Initializes a new instance of the <see cref="WebSocketSigVerRequestHandler"/> class.
            /// </summary>
            /// <param name="cloverConnector">The clover connector.</param>
            /// <param name="request">The request.</param>
            public WebSocketSigVerRequestHandler(RemoteWebSocketCloverConnector cloverConnector, VerifySignatureRequest request)
            {
                WSCloverConnector = cloverConnector;
                svr = request;
                Payment = request.Payment;
                Signature = request.Signature;
            }
            /// <summary>
            /// Accepts this instance.
            /// </summary>
            public override void Accept()
            {
                WSCloverConnector.AcceptSignature(svr);
            }

            /// <summary>
            /// Rejects this instance.
            /// </summary>
            public override void Reject()
            {
                WSCloverConnector.RejectSignature(svr);
            }
        }
    }
}
