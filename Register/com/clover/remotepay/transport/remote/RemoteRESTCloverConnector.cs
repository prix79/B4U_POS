// ***********************************************************************
// Assembly         : Register
// Author           : Seungkeun
// Created          : 02-08-2017
//
// Last Modified By : Seungkeun
// Last Modified On : 09-15-2017
// ***********************************************************************
// <copyright file="RemoteRESTCloverConnector.cs" company="Beauty4u">
//     Copyright © Beauty4u 2009
// </copyright>
// <summary></summary>
// ***********************************************************************

using com.clover.remotepay.sdk;
using com.clover.remote.order;
using com.clover.remotepay.sdk.service.client;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.IO;
using System.Drawing.Imaging;
using com.clover.sdk.v3.payments;

/// <summary>
/// The remote namespace.
/// </summary>
namespace com.clover.remotepay.transport.remote
{
    /// <summary>
    /// Custom ICloverConnector that talks to the 
    /// Clover Connector REST Service. This wouldn't normally
    /// be used because it is in .NET, and it would normally
    /// make more sense to use the DLL directly in .NET
    /// </summary>
    /// <summary>
    /// Class RemoteRESTCloverConnector.
    /// </summary>
    /// <seealso cref="com.clover.remotepay.sdk.ICloverConnector" />
    public class RemoteRESTCloverConnector : ICloverConnector
    {
        /// <summary>
        /// Gets or sets a value indicating whether this instance is ready.
        /// </summary>
        /// <value><c>true</c> if this instance is ready; otherwise, <c>false</c>.</value>
        public bool IsReady
        {
            get { return true; }
            set { }
        }
        /// <summary>
        /// The rest client
        /// </summary>
        RestClient restClient = new RestClient("http://localhost:8181/Clover");
        /// <summary>
        /// The configuration
        /// </summary>
        CloverDeviceConfiguration Config;
        /// <summary>
        /// Gets or sets the callback service.
        /// </summary>
        /// <value>The callback service.</value>
        CallbackController callbackService { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="RemoteRESTCloverConnector"/> class.
        /// </summary>
        /// <param name="config">The configuration.</param>
        public RemoteRESTCloverConnector(CloverDeviceConfiguration config)
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.Load("CloverConnector");
            _SDKInfo = AssemblyUtils.GetAssemblyAttribute<System.Reflection.AssemblyDescriptionAttribute>(assembly).Description + ":"
                + (AssemblyUtils.GetAssemblyAttribute<System.Reflection.AssemblyFileVersionAttribute>(assembly)).Version
                + (AssemblyUtils.GetAssemblyAttribute<System.Reflection.AssemblyInformationalVersionAttribute>(assembly)).InformationalVersion;
            Config = config;
        }
        /// <summary>
        /// Initializes the connection.
        /// </summary>
        public void InitializeConnection()
        {
            if (callbackService == null)
            {
                callbackService = new CallbackController(this);
                callbackService.init(restClient);

                CardEntryMethod = CloverConnector.CARD_ENTRY_METHOD_ICC_CONTACT | CloverConnector.CARD_ENTRY_METHOD_MAG_STRIPE | CloverConnector.CARD_ENTRY_METHOD_NFC_CONTACTLESS;

                listeners.ForEach(listener => callbackService.AddListener(listener));
            }
        }
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
        /// Gets or sets the card entry method.
        /// </summary>
        /// <value>The card entry method.</value>
        public int CardEntryMethod { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [disable printing].
        /// </summary>
        /// <value><c>true</c> if [disable printing]; otherwise, <c>false</c>.</value>
        public bool DisablePrinting { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [disable cash back].
        /// </summary>
        /// <value><c>true</c> if [disable cash back]; otherwise, <c>false</c>.</value>
        public bool DisableCashBack { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [disable tip].
        /// </summary>
        /// <value><c>true</c> if [disable tip]; otherwise, <c>false</c>.</value>
        public bool DisableTip { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [disable restart transaction on fail].
        /// </summary>
        /// <value><c>true</c> if [disable restart transaction on fail]; otherwise, <c>false</c>.</value>
        public bool DisableRestartTransactionOnFail { get; set; }

        /// <summary>
        /// The listeners
        /// </summary>
        List<ICloverConnectorListener> listeners = new List<ICloverConnectorListener>();
        /// <summary>
        /// The configuration
        /// </summary>
        private CloverDeviceConfiguration config;

        /// <summary>
        /// Adds the clover connector listener.
        /// </summary>
        /// <param name="connectorListener">The connector listener.</param>
        public void AddCloverConnectorListener(ICloverConnectorListener connectorListener)
        {
            listeners.Add(connectorListener);
            if (callbackService != null)
            {
                callbackService.AddListener(connectorListener);
            }
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
        /// Sales the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        public void Sale(SaleRequest request)
        {
            Send("/Sale", request);
        }

        /// <summary>
        /// Accepts the signature.
        /// </summary>
        /// <param name="request">The request.</param>
        public void AcceptSignature(VerifySignatureRequest request)
        {
            Send("/AcceptSignature", request);
        }

        /// <summary>
        /// Rejects the signature.
        /// </summary>
        /// <param name="request">The request.</param>
        public void RejectSignature(VerifySignatureRequest request)
        {
            Send("/RejectSignature", request);
        }

        /// <summary>
        /// Authentications the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        public void Auth(AuthRequest request)
        {
            Send("/Auth", request);
        }

        /// <summary>
        /// Pres the authentication.
        /// </summary>
        /// <param name="request">The request.</param>
        public void PreAuth(PreAuthRequest request)
        {
            Send("/PreAuth", request);
        }

        /// <summary>
        /// Captures the pre authentication.
        /// </summary>
        /// <param name="request">The request.</param>
        public void CapturePreAuth(CapturePreAuthRequest request)
        {
            Send("/CapturePreAuth", request);
        }

        /// <summary>
        /// Tips the adjust authentication.
        /// </summary>
        /// <param name="request">The request.</param>
        public void TipAdjustAuth(TipAdjustAuthRequest request)
        {
            Send("/TipAdjustAuth", request);
        }

        /// <summary>
        /// Voids the payment.
        /// </summary>
        /// <param name="request">The request.</param>
        public void VoidPayment(VoidPaymentRequest request)
        {
            Send("/VoidPayment", request);
        }

        /// <summary>
        /// Refunds the payment.
        /// </summary>
        /// <param name="request">The request.</param>
        public void RefundPayment(RefundPaymentRequest request)
        {
            Send("/RefundPayment", request);
        }

        /// <summary>
        /// Manuals the refund.
        /// </summary>
        /// <param name="request">The request.</param>
        public void ManualRefund(ManualRefundRequest request)
        {
            Send("/ManualRefund", request);
        }

        /// <summary>
        /// Vaults the card.
        /// </summary>
        /// <param name="CardEntryMethods">The card entry methods.</param>
        public void VaultCard(int? CardEntryMethods)
        {
            VaultCard vc = new VaultCard();
            vc.CardEntryMethods = CardEntryMethods;
            Send("/VaultCard", vc);
        }

        /// <summary>
        /// Reads the card data.
        /// </summary>
        /// <param name="request">The request.</param>
        public void ReadCardData(ReadCardDataRequest request)
        {
            Send("/ReadCardData", request);
        }

        /// <summary>
        /// Starts the custom activity.
        /// </summary>
        /// <param name="request">The request.</param>
        public void StartCustomActivity(CustomActivityRequest request)
        {
            Send("/StartCustomActivity", request);
        }

        /// <summary>
        /// Closeouts the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        public void Closeout(CloseoutRequest request)
        {
            Send("/Closeout", request);
        }

        /// <summary>
        /// Resets the device.
        /// </summary>
        public void ResetDevice()
        {
            Send("/ResetDevice", null);
        }

        /// <summary>
        /// Cancels this instance.
        /// </summary>
        public void Cancel()
        {
            Send("/Cancel", null);
        }

        /// <summary>
        /// Prints the text.
        /// </summary>
        /// <param name="messages">The messages.</param>
        public void PrintText(List<string> messages)
        {
            PrintText pt = new PrintText();
            pt.Messages = messages;
            Send("/PrintText", pt);
        }

        /// <summary>
        /// Prints the image.
        /// </summary>
        /// <param name="bitmap">The bitmap.</param>
        public void PrintImage(System.Drawing.Bitmap bitmap)
        {
            MemoryStream ms = new MemoryStream();
            bitmap.Save(ms, ImageFormat.Png);
            byte[] imgBytes = ms.ToArray();
            string base64Image = Convert.ToBase64String(imgBytes);

            PrintImage pi = new PrintImage();
            pi.Bitmap = base64Image;
            Send("/PrintImage", pi);
        }

        /// <summary>
        /// Shows the message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void ShowMessage(string message)
        {
            ShowMessage msg = new ShowMessage();
            msg.Message = message;
            Send("/ShowMessage", msg);
        }

        /// <summary>
        /// Shows the welcome screen.
        /// </summary>
        public void ShowWelcomeScreen()
        {
            Send("/ShowWelcomeScreen", null);
        }

        /// <summary>
        /// Shows the thank you screen.
        /// </summary>
        public void ShowThankYouScreen()
        {
            Send("/ShowThankYouScreen", null);
        }

        /// <summary>
        /// Retrieves the pending payments.
        /// </summary>
        public void RetrievePendingPayments()
        {
            Send("/RetrievePendingPayments", null);
        }

        /// <summary>
        /// Displays the payment receipt options.
        /// </summary>
        /// <param name="orderId">The order identifier.</param>
        /// <param name="paymentId">The payment identifier.</param>
        public void DisplayPaymentReceiptOptions(String orderId, String paymentId)
        {
            DisplayPaymentReceiptOptionsRequest req = new DisplayPaymentReceiptOptionsRequest();
            req.OrderID = orderId;
            req.PaymentID = paymentId;
            Send("/DisplayPaymentReceiptOptions", req);
        }

        /// <summary>
        /// Opens the cash drawer.
        /// </summary>
        /// <param name="reason">The reason.</param>
        public void OpenCashDrawer(string reason)
        {
            OpenCashDrawer ocd = new OpenCashDrawer();
            ocd.Reason = reason;
            Send("/OpenCashDrawer", ocd);
        }

        /// <summary>
        /// Shows the display order.
        /// </summary>
        /// <param name="order">The order.</param>
        public void ShowDisplayOrder(DisplayOrder order)
        {
            Send("/DisplayOrder", order);
        }

        /// <summary>
        /// Lines the item added to display order.
        /// </summary>
        /// <param name="order">The order.</param>
        /// <param name="lineItem">The line item.</param>
        public void LineItemAddedToDisplayOrder(DisplayOrder order, DisplayLineItem lineItem)
        {
            LineItemAddedToDisplayOrder dolia = new LineItemAddedToDisplayOrder();
            dolia.DisplayOrder = order;
            dolia.DisplayLineItem = lineItem;
            Send("/LineItemAddedToDisplayOrder", dolia);
        }

        /// <summary>
        /// Lines the item removed from display order.
        /// </summary>
        /// <param name="order">The order.</param>
        /// <param name="lineItem">The line item.</param>
        public void LineItemRemovedFromDisplayOrder(DisplayOrder order, DisplayLineItem lineItem)
        {
            LineItemRemovedFromDisplayOrder dolia = new LineItemRemovedFromDisplayOrder();
            dolia.DisplayOrder = order;
            dolia.DisplayLineItem = lineItem;
            Send("/LineItemRemovedFromDisplayOrder", dolia);
        }

        /// <summary>
        /// Discounts the added to display order.
        /// </summary>
        /// <param name="order">The order.</param>
        /// <param name="discount">The discount.</param>
        public void DiscountAddedToDisplayOrder(DisplayOrder order, DisplayDiscount discount)
        {
            DiscountAddedToDisplayOrder doda = new DiscountAddedToDisplayOrder();
            doda.DisplayOrder = order;
            doda.DisplayDiscount = discount;
            Send("/DiscountAddedToDisplayOrder", doda);
        }

        /// <summary>
        /// Discounts the removed from display order.
        /// </summary>
        /// <param name="order">The order.</param>
        /// <param name="discount">The discount.</param>
        public void DiscountRemovedFromDisplayOrder(DisplayOrder order, DisplayDiscount discount)
        {
            DiscountRemovedFromDisplayOrder doda = new DiscountRemovedFromDisplayOrder();
            doda.DisplayOrder = order;
            doda.DisplayDiscount = discount;
            Send("/DiscountRemovedFromDisplayOrder", doda);
        }


        /// <summary>
        /// Disposes this instance.
        /// </summary>
        public void Dispose()
        {
            callbackService.Shutdown();
        }

        /// <summary>
        /// Invokes the input option.
        /// </summary>
        /// <param name="io">The io.</param>
        public void InvokeInputOption(global::com.clover.remotepay.transport.InputOption io)
        {
            Send("/InvokeInputOption", io);
        }

        /// <summary>
        /// Sends the specified target.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="payload">The payload.</param>
        public void Send(string target, object payload)
        {
            IRestRequest restRequest = new RestRequest(target, Method.POST);
            string payloadMessage = JsonUtils.serialize(payload);
#if DEBUG
            Console.WriteLine("Sending: " + target + " JSON: " + payloadMessage);
#endif
            restRequest.AddParameter("application/json", payloadMessage, ParameterType.RequestBody);
            restClient.ExecuteAsync(restRequest, response =>
            {
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    Console.WriteLine(response.ResponseStatus + " : " + response.StatusCode + " : " + response.ErrorMessage + " => " + response.Content);
                }
            });
        }

        /// <summary>
        /// Prints the image from URL.
        /// </summary>
        /// <param name="ImgURL">The img URL.</param>
        public void PrintImageFromURL(string ImgURL)
        {
            PrintImage pi = new PrintImage();
            pi.Url = ImgURL;
            Send("/PrintImageFromURL", pi);
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
        /// Accepts the payment.
        /// </summary>
        /// <param name="payment">The payment.</param>
        public void AcceptPayment(Payment payment)
        {
            Send("/AcceptPayment", payment);
        }

        /// <summary>
        /// Rejects the payment.
        /// </summary>
        /// <param name="payment">The payment.</param>
        /// <param name="challenge">The challenge.</param>
        public void RejectPayment(Payment payment, Challenge challenge)
        {
            RejectPaymentObject rejectPayment = new RejectPaymentObject();
            rejectPayment.Payment = payment;
            rejectPayment.Challenge = challenge;
            Send("/RejectPayment", rejectPayment);
        }

        /// <summary>
        /// Sends the message to activity.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        public void SendMessageToActivity(MessageToActivity msg)
        {
            Send("/SendMessageToActivity", msg);
        }

        /// <summary>
        /// Retrieves the device status.
        /// </summary>
        /// <param name="request">The request.</param>
        public void RetrieveDeviceStatus(RetrieveDeviceStatusRequest request)
        {
            Send("/RetrieveDeviceStatus", request);
        }

        /// <summary>
        /// Retrieves the payment.
        /// </summary>
        /// <param name="request">The request.</param>
        public void RetrievePayment(RetrievePaymentRequest request)
        {
            Send("/RetrievePayment", request);
        }

        /// <summary>
        /// Class RESTSigVerRequestHandler.
        /// </summary>
        /// <seealso cref="com.clover.remotepay.sdk.VerifySignatureRequest" />
        public class RESTSigVerRequestHandler : VerifySignatureRequest
        {
            /// <summary>
            /// The SVR
            /// </summary>
            VerifySignatureRequest svr;
            /// <summary>
            /// The rest clover connector
            /// </summary>
            RemoteRESTCloverConnector restCloverConnector;
            /// <summary>
            /// Initializes a new instance of the <see cref="RESTSigVerRequestHandler"/> class.
            /// </summary>
            /// <param name="cloverConnector">The clover connector.</param>
            /// <param name="request">The request.</param>
            public RESTSigVerRequestHandler(RemoteRESTCloverConnector cloverConnector, VerifySignatureRequest request)
            {
                restCloverConnector = cloverConnector;
                svr = request;
                Payment = request.Payment;
                Signature = request.Signature;
            }
            /// <summary>
            /// Accepts this instance.
            /// </summary>
            public override void Accept()
            {
                restCloverConnector.Send("/AcceptSignature", svr);
            }

            /// <summary>
            /// Rejects this instance.
            /// </summary>
            public override void Reject()
            {
                restCloverConnector.Send("/RejectSignature", svr);
            }
        }
    }
}
