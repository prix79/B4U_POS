// ***********************************************************************
// Assembly         : Register
// Author           : Seungkeun
// Created          : 02-08-2017
//
// Last Modified By : Seungkeun
// Last Modified On : 09-15-2017
// ***********************************************************************
// <copyright file="CloverCallbackListenerService.cs" company="Beauty4u">
//     Copyright © Beauty4u 2009
// </copyright>
// <summary></summary>
// ***********************************************************************

using com.clover.remotepay.sdk;
using System;
using System.IO;
using System.Collections.Generic;
using Grapevine.Server;
using System.Net;
using Newtonsoft.Json.Converters;

/// <summary>
/// The remote namespace.
/// </summary>
namespace com.clover.remotepay.transport.remote
{
    /// <summary>
    /// Is the subclass of RESTServer for adding CloverConnectorListeners
    /// </summary>
    /// <summary>
    /// Class CloverRESTServer.
    /// </summary>
    /// <seealso cref="Grapevine.Server.RESTServer" />
    public class CloverRESTServer : RESTServer
    {
        /// <summary>
        /// The clover connector listeners
        /// </summary>
        public List<ICloverConnectorListener> cloverConnectorListeners = new List<ICloverConnectorListener>();
        /// <summary>
        /// Initializes a new instance of the <see cref="CloverRESTServer"/> class.
        /// </summary>
        /// <param name="host">The host.</param>
        /// <param name="port">The port.</param>
        /// <param name="protocol">The protocol.</param>
        /// <param name="dirindex">The dirindex.</param>
        /// <param name="webroot">The webroot.</param>
        /// <param name="maxthreads">The maxthreads.</param>
        public CloverRESTServer(string host = "localhost", string port = "1234", string protocol = "http", string dirindex = "index.html", string webroot = null, int maxthreads = 1) : base(host, port, protocol, dirindex, webroot, maxthreads)
        {

        }

        /// <summary>
        /// Adds the clover connector listener.
        /// </summary>
        /// <param name="listener">The listener.</param>
        public void AddCloverConnectorListener(ICloverConnectorListener listener)
        {
            cloverConnectorListeners.Add(listener);
        }

        /// <summary>
        /// Gets or sets the clover connector.
        /// </summary>
        /// <value>The clover connector.</value>
        public ICloverConnector CloverConnector { get; set; }

    }

    /// <summary>
    /// Contains the restpoint definitions for the listening
    /// service that listens for callbacks from 
    /// the Clover Conector Windows REST Service. This class should
    /// parallel ICloverConnectorListener
    /// </summary>
    /// <summary>
    /// Class CloverCallbackListenerService. This class cannot be inherited.
    /// </summary>
    /// <seealso cref="Grapevine.Server.RESTResource" />
    sealed class CloverCallbackListenerService : RESTResource
    {
        /// <summary>
        /// Gets the connector listener.
        /// </summary>
        /// <value>The connector listener.</value>
        public List<ICloverConnectorListener> connectorListener
        {
            get {
                return (Server as CloverRESTServer).cloverConnectorListeners;
            }
        }
        /// <summary>
        /// Gets the clover connector.
        /// </summary>
        /// <value>The clover connector.</value>
        public ICloverConnector cloverConnector
        {
            get
            {
                return (Server as CloverRESTServer).CloverConnector;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloverCallbackListenerService"/> class.
        /// </summary>
        public CloverCallbackListenerService()
        {
            //
        }

        /// <summary>
        /// Called when [device activity start].
        /// </summary>
        /// <param name="context">The context.</param>
        [RESTRoute(Method = Grapevine.HttpMethod.POST, PathInfo = @"^/CloverCallback/DeviceActivityStart$")]
        public void OnDeviceActivityStart(HttpListenerContext context)
        {
            try
            {
                CloverDeviceEvent deviceEvent = ParseResponse<CloverDeviceEvent>(context);
                if (deviceEvent != null)
                {
                    connectorListener.ForEach(listener => listener.OnDeviceActivityStart(deviceEvent));
                }
                SendTextResponse(context, "");
            }
            catch (Exception e)
            {
                context.Response.StatusCode = 400;
                context.Response.StatusDescription = e.Message;
                SendTextResponse(context, "error processing request");
            }

        }

        /// <summary>
        /// Called when [device activity end].
        /// </summary>
        /// <param name="context">The context.</param>
        [RESTRoute(Method = Grapevine.HttpMethod.POST, PathInfo = @"^/CloverCallback/DeviceActivityEnd$")]
        public void OnDeviceActivityEnd(HttpListenerContext context)
        {
            try
            {
                CloverDeviceEvent deviceEvent = ParseResponse<CloverDeviceEvent>(context);
                if (deviceEvent != null)
                {
                    connectorListener.ForEach(listener => listener.OnDeviceActivityEnd(deviceEvent));
                }
                SendTextResponse(context, "");
            }
            catch (Exception e)
            {
                context.Response.StatusCode = 400;
                context.Response.StatusDescription = e.Message;
                SendTextResponse(context, "error processing request");
            }

        }

        /// <summary>
        /// Called when [device error].
        /// </summary>
        /// <param name="context">The context.</param>
        [RESTRoute(Method = Grapevine.HttpMethod.POST, PathInfo = @"^/CloverCallback/DeviceError$")]
        public void OnDeviceError(HttpListenerContext context)
        {
            try
            {
                CloverDeviceErrorEvent deviceErrorEvent = ParseResponse<CloverDeviceErrorEvent>(context);
                if (deviceErrorEvent != null)
                {
                    connectorListener.ForEach(listener => listener.OnDeviceError(deviceErrorEvent));
                }
                SendTextResponse(context, "");
            }
            catch (Exception e)
            {
                context.Response.StatusCode = 400;
                context.Response.StatusDescription = e.Message;
                SendTextResponse(context, "error processing request");
            }

        }

        /// <summary>
        /// Called when [device connected].
        /// </summary>
        /// <param name="context">The context.</param>
        [RESTRoute(Method = Grapevine.HttpMethod.POST, PathInfo = @"^/CloverCallback/DeviceConnected$")]
        public void OnDeviceConnected(HttpListenerContext context)
        {
            connectorListener.ForEach(listener => listener.OnDeviceConnected());
            SendTextResponse(context, "");
        }

        /// <summary>
        /// Called when [device disconnected].
        /// </summary>
        /// <param name="context">The context.</param>
        [RESTRoute(Method = Grapevine.HttpMethod.POST, PathInfo = @"^/CloverCallback/DeviceDisconnected$")]
        public void OnDeviceDisconnected(HttpListenerContext context)
        {
            connectorListener.ForEach(listener => listener.OnDeviceDisconnected());
            SendTextResponse(context, "");
        }

        /// <summary>
        /// Called when [device ready].
        /// </summary>
        /// <param name="context">The context.</param>
        [RESTRoute(Method = Grapevine.HttpMethod.POST, PathInfo = @"^/CloverCallback/DeviceReady$")]
        public void OnDeviceReady(HttpListenerContext context)
        {
            try
            {
                MerchantInfo merchantInfo = ParseResponse<MerchantInfo>(context);
                if (merchantInfo != null)
                {
                    connectorListener.ForEach(listener => listener.OnDeviceReady(merchantInfo));
                }
                SendTextResponse(context, "");
            }
            catch (Exception e)
            {
                context.Response.StatusCode = 400;
                context.Response.StatusDescription = e.Message;
                SendTextResponse(context, "error processing request");
            }

        }

        /// <summary>
        /// Called when [tip added].
        /// </summary>
        /// <param name="context">The context.</param>
        [RESTRoute(Method = Grapevine.HttpMethod.POST, PathInfo = @"^/CloverCallback/TipAdded$")]
        public void OnTipAdded(HttpListenerContext context)
        {
            try
            {
                TipAddedMessage tipAddedEvent = ParseResponse<TipAddedMessage>(context);
                if (tipAddedEvent != null)
                {
                    connectorListener.ForEach(listener => listener.OnTipAdded(tipAddedEvent));
                }
                SendTextResponse(context, "");
            }
            catch (Exception e)
            {
                context.Response.StatusCode = 400;
                context.Response.StatusDescription = e.Message;
                SendTextResponse(context, "error processing request");
            }

        }

        /// <summary>
        /// Authentications the response.
        /// </summary>
        /// <param name="context">The context.</param>
        [RESTRoute(Method = Grapevine.HttpMethod.POST, PathInfo = @"^/CloverCallback/AuthResponse$")]
        public void AuthResponse(HttpListenerContext context)
        {
            try
            {
                AuthResponse response = ParseResponse<AuthResponse>(context);
                if (response != null)
                {
                    connectorListener.ForEach(listener => listener.OnAuthResponse(response));
                }
                SendTextResponse(context, "");
            }
            catch (Exception e)
            {
                context.Response.StatusCode = 400;
                context.Response.StatusDescription = e.Message;
                SendTextResponse(context, "error processing request");
            }

        }

        /// <summary>
        /// Pres the authentication response.
        /// </summary>
        /// <param name="context">The context.</param>
        [RESTRoute(Method = Grapevine.HttpMethod.POST, PathInfo = @"^/CloverCallback/PreAuthResponse$")]
        public void PreAuthResponse(HttpListenerContext context)
        {
            try
            {
                PreAuthResponse response = ParseResponse<PreAuthResponse>(context);
                if (response != null)
                {
                    connectorListener.ForEach(listener => listener.OnPreAuthResponse(response));
                }
                SendTextResponse(context, "");
            }
            catch (Exception e)
            {
                context.Response.StatusCode = 400;
                context.Response.StatusDescription = e.Message;
                SendTextResponse(context, "error processing request");
            }

        }

        /// <summary>
        /// Sales the response.
        /// </summary>
        /// <param name="context">The context.</param>
        [RESTRoute(Method = Grapevine.HttpMethod.POST, PathInfo = @"^/CloverCallback/SaleResponse$")]
        public void SaleResponse(HttpListenerContext context)
        {
            try
            {
                SaleResponse response = ParseResponse<SaleResponse>(context);
                if (response != null)
                {
                    connectorListener.ForEach(listener => listener.OnSaleResponse(response));
                }
                SendTextResponse(context, "");
            }
            catch (Exception e)
            {
                context.Response.StatusCode = 400;
                context.Response.StatusDescription = e.Message;
                SendTextResponse(context, "error processing request");
            }


        }

        /// <summary>
        /// Vaults the card response.
        /// </summary>
        /// <param name="context">The context.</param>
        [RESTRoute(Method = Grapevine.HttpMethod.POST, PathInfo = @"^/CloverCallback/VaultCardResponse$")]
        public void VaultCardResponse(HttpListenerContext context)
        {
            try
            {
                VaultCardResponse response = ParseResponse<VaultCardResponse>(context);
                if (response != null)
                {
                    connectorListener.ForEach(listener => listener.OnVaultCardResponse(response));
                }
                SendTextResponse(context, "");
            }
            catch (Exception e)
            {
                context.Response.StatusCode = 400;
                context.Response.StatusDescription = e.Message;
                SendTextResponse(context, "error processing request");
            }
        }

        /// <summary>
        /// Reads the card data response.
        /// </summary>
        /// <param name="context">The context.</param>
        [RESTRoute(Method = Grapevine.HttpMethod.POST, PathInfo = @"^/CloverCallback/ReadCardDataResponse$")]
        public void ReadCardDataResponse(HttpListenerContext context)
        {
            try
            {
                ReadCardDataResponse response = ParseResponse<ReadCardDataResponse>(context);
                if (response != null)
                {
                    connectorListener.ForEach(listener => listener.OnReadCardDataResponse(response));
                }
                SendTextResponse(context, "");
            }
            catch (Exception e)
            {
                context.Response.StatusCode = 400;
                context.Response.StatusDescription = e.Message;
                SendTextResponse(context, "error processing request");
            }

        }

        /// <summary>
        /// Refunds the payment response.
        /// </summary>
        /// <param name="context">The context.</param>
        [RESTRoute(Method = Grapevine.HttpMethod.POST, PathInfo = @"^/CloverCallback/RefundPaymentResponse$")]
        public void RefundPaymentResponse(HttpListenerContext context)
        {
            try
            {
                RefundPaymentResponse response = ParseResponse<RefundPaymentResponse>(context);
                if (response != null)
                {
                    connectorListener.ForEach(listener => listener.OnRefundPaymentResponse(response));
                }
                SendTextResponse(context, "");
            }
            catch (Exception e)
            {
                context.Response.StatusCode = 400;
                context.Response.StatusDescription = e.Message;
                SendTextResponse(context, "error processing request");
            }

        }

        /// <summary>
        /// Voids the payment response.
        /// </summary>
        /// <param name="context">The context.</param>
        [RESTRoute(Method = Grapevine.HttpMethod.POST, PathInfo = @"^/CloverCallback/VoidPaymentResponse$")]
        public void VoidPaymentResponse(HttpListenerContext context)
        {

            try
            {
                VoidPaymentResponse response = ParseResponse<VoidPaymentResponse>(context);
                if (response != null)
                {
                    connectorListener.ForEach(listener => listener.OnVoidPaymentResponse(response));
                }
                SendTextResponse(context, "");
            }
            catch (Exception e)
            {
                context.Response.StatusCode = 400;
                context.Response.StatusDescription = e.Message;
                SendTextResponse(context, "error processing request");
            }

        }

        /// <summary>
        /// Manuals the refund response.
        /// </summary>
        /// <param name="context">The context.</param>
        [RESTRoute(Method = Grapevine.HttpMethod.POST, PathInfo = @"^/CloverCallback/ManualRefundResponse$")]
        public void ManualRefundResponse(HttpListenerContext context)
        {
            try
            {
                ManualRefundResponse response = ParseResponse<ManualRefundResponse>(context);
                if (response != null)
                {
                    connectorListener.ForEach(listener => listener.OnManualRefundResponse(response));
                }
                SendTextResponse(context, "");
            }
            catch (Exception e)
            {
                context.Response.StatusCode = 400;
                context.Response.StatusDescription = e.Message;
                SendTextResponse(context, "error processing request");
            }

        }

        /// <summary>
        /// Captures the pre authentication response.
        /// </summary>
        /// <param name="context">The context.</param>
        [RESTRoute(Method = Grapevine.HttpMethod.POST, PathInfo = @"^/CloverCallback/CapturePreAuthResponse$")]
        public void CapturePreAuthResponse(HttpListenerContext context)
        {
            try
            {
                CapturePreAuthResponse response = ParseResponse<CapturePreAuthResponse>(context);
                if (response != null)
                {
                    connectorListener.ForEach(listener => listener.OnCapturePreAuthResponse(response));
                }
                SendTextResponse(context, "");
            }
            catch (Exception e)
            {
                context.Response.StatusCode = 400;
                context.Response.StatusDescription = e.Message;
                SendTextResponse(context, "error processing request");
            }

        }

        /// <summary>
        /// Tips the adjust authentication response.
        /// </summary>
        /// <param name="context">The context.</param>
        [RESTRoute(Method = Grapevine.HttpMethod.POST, PathInfo = @"^/CloverCallback/TipAdjustAuthResponse")]
        public void TipAdjustAuthResponse(HttpListenerContext context)
        {
            try
            {
                TipAdjustAuthResponse response = ParseResponse<TipAdjustAuthResponse>(context);
                if (response != null)
                {
                    connectorListener.ForEach(listener => listener.OnTipAdjustAuthResponse(response));
                }
                SendTextResponse(context, "");
            }
            catch (Exception e)
            {
                context.Response.StatusCode = 400;
                context.Response.StatusDescription = e.Message;
                SendTextResponse(context, "error processing request");
            }
        }

        /// <summary>
        /// Closeouts the response.
        /// </summary>
        /// <param name="context">The context.</param>
        [RESTRoute(Method = Grapevine.HttpMethod.POST, PathInfo = @"^/CloverCallback/CloseoutResponse$")]
        public void CloseoutResponse(HttpListenerContext context)
        {
            try
            {
                CloseoutResponse response = ParseResponse<CloseoutResponse>(context);
                if (response != null)
                {
                    connectorListener.ForEach(listener => listener.OnCloseoutResponse(response));
                }
                SendTextResponse(context, "");
            }
            catch (Exception e)
            {
                context.Response.StatusCode = 400;
                context.Response.StatusDescription = e.Message;
                SendTextResponse(context, "error processing request");
            }
        }

        /// <summary>
        /// Verifies the signature request.
        /// </summary>
        /// <param name="context">The context.</param>
        [RESTRoute(Method = Grapevine.HttpMethod.POST, PathInfo = @"^/CloverCallback/VerifySignatureRequest$")]
        public void VerifySignatureRequest(HttpListenerContext context)
        {
            try
            {
                VerifySignatureRequest request = ParseResponse<VerifySignatureRequest>(context);
                RemoteRESTCloverConnector.RESTSigVerRequestHandler sigVerRequest =
                    new RemoteRESTCloverConnector.RESTSigVerRequestHandler((RemoteRESTCloverConnector)cloverConnector, request);
                connectorListener.ForEach(listener => listener.OnVerifySignatureRequest(sigVerRequest));
                SendTextResponse(context, "");
            }
            catch (Exception e)
            {
                context.Response.StatusCode = 400;
                context.Response.StatusDescription = e.Message;
                SendTextResponse(context, "error processing request");
            }
        }

        /// <summary>
        /// Confirms the payment request.
        /// </summary>
        /// <param name="context">The context.</param>
        [RESTRoute(Method = Grapevine.HttpMethod.POST, PathInfo = @"^/CloverCallback/ConfirmPaymentRequest$")]
        public void ConfirmPaymentRequest(HttpListenerContext context)
        {
            try
            {
                ConfirmPaymentRequest request = ParseResponse<ConfirmPaymentRequest>(context);
                connectorListener.ForEach(listener => listener.OnConfirmPaymentRequest(request));
                SendTextResponse(context, "");
            }
            catch (Exception e)
            {
                context.Response.StatusCode = 400;
                context.Response.StatusDescription = e.Message;
                SendTextResponse(context, "error processing request");
            }
        }

        /// <summary>
        /// Retrieves the pending payments.
        /// </summary>
        /// <param name="context">The context.</param>
        [RESTRoute(Method = Grapevine.HttpMethod.POST, PathInfo = @"^/CloverCallback/RetrievePendingPaymentsResponse$")]
        public void RetrievePendingPayments(HttpListenerContext context)
        {
            try
            {
                RetrievePendingPaymentsResponse response = ParseResponse<RetrievePendingPaymentsResponse>(context);
                connectorListener.ForEach(listener => listener.OnRetrievePendingPaymentsResponse(response));
                SendTextResponse(context, "");
            }
            catch (Exception e)
            {
                context.Response.StatusCode = 400;
                context.Response.StatusDescription = e.Message;
                SendTextResponse(context, "error processing request");
            }
        }

        /// <summary>
        /// Retrieves the payment response.
        /// </summary>
        /// <param name="context">The context.</param>
        [RESTRoute(Method = Grapevine.HttpMethod.POST, PathInfo = @"^/CloverCallback/RetrievePaymentResponse$")]
        public void RetrievePaymentResponse(HttpListenerContext context)
        {
            try
            {
                RetrievePaymentResponse response = ParseResponse<RetrievePaymentResponse>(context);
                connectorListener.ForEach(listener => listener.OnRetrievePaymentResponse(response));
                SendTextResponse(context, "");
            }
            catch (Exception e)
            {
                context.Response.StatusCode = 400;
                context.Response.StatusDescription = e.Message;
                SendTextResponse(context, "error processing request");
            }
        }

        /// <summary>
        /// Customs the activity response.
        /// </summary>
        /// <param name="context">The context.</param>
        [RESTRoute(Method = Grapevine.HttpMethod.POST, PathInfo = @"^/CloverCallback/CustomActivityResponse$")]
        public void CustomActivityResponse(HttpListenerContext context)
        {
            try
            {
                CustomActivityResponse response = ParseResponse<CustomActivityResponse>(context);
                connectorListener.ForEach(listener => listener.OnCustomActivityResponse(response));
                SendTextResponse(context, "");
            }
            catch (Exception e)
            {
                context.Response.StatusCode = 400;
                context.Response.StatusDescription = e.Message;
                SendTextResponse(context, "error processing request");
            }
        }

        /// <summary>
        /// Prints the manual refund receipt.
        /// </summary>
        /// <param name="context">The context.</param>
        [RESTRoute(Method = Grapevine.HttpMethod.POST, PathInfo = @"^/CloverCallback/PrintManualRefundReceipt$")]
        public void PrintManualRefundReceipt(HttpListenerContext context)
        {
            try
            {
                PrintManualRefundReceiptMessage printManualRefundReceiptMessage = ParseResponse<PrintManualRefundReceiptMessage>(context);
                connectorListener.ForEach(listener => listener.OnPrintManualRefundReceipt(printManualRefundReceiptMessage));
                SendTextResponse(context, "");
            }
            catch (Exception e)
            {
                context.Response.StatusCode = 400;
                context.Response.StatusDescription = e.Message;
                SendTextResponse(context, "error processing request");
            }
        }

        /// <summary>
        /// Prints the manual refund decline receipt.
        /// </summary>
        /// <param name="context">The context.</param>
        [RESTRoute(Method = Grapevine.HttpMethod.POST, PathInfo = @"^/CloverCallback/PrintManualRefundDeclineReceipt$")]
        public void PrintManualRefundDeclineReceipt(HttpListenerContext context)
        {
            try
            {
                PrintManualRefundDeclineReceiptMessage printManualRefundDeclineReceiptMessage = ParseResponse<PrintManualRefundDeclineReceiptMessage>(context);
                connectorListener.ForEach(listener => listener.OnPrintManualRefundDeclineReceipt(printManualRefundDeclineReceiptMessage));
            }
            catch (Exception e)
            {
                context.Response.StatusCode = 400;
                context.Response.StatusDescription = e.Message;
                SendTextResponse(context, "error processing request");
            }
        }

        /// <summary>
        /// Prints the payment receipt.
        /// </summary>
        /// <param name="context">The context.</param>
        [RESTRoute(Method = Grapevine.HttpMethod.POST, PathInfo = @"^/CloverCallback/PrintPaymentReceipt$")]
        public void PrintPaymentReceipt(HttpListenerContext context)
        {
            try
            {
                PrintPaymentReceiptMessage printPaymentReceiptMessage = ParseResponse<PrintPaymentReceiptMessage>(context);
                connectorListener.ForEach(listener => listener.OnPrintPaymentReceipt(printPaymentReceiptMessage));
            }
            catch (Exception e)
            {
                context.Response.StatusCode = 400;
                context.Response.StatusDescription = e.Message;
                SendTextResponse(context, "error processing request");
            }
        }

        /// <summary>
        /// Prints the payment decline receipt.
        /// </summary>
        /// <param name="context">The context.</param>
        [RESTRoute(Method = Grapevine.HttpMethod.POST, PathInfo = @"^/CloverCallback/PrintPaymentDeclineReceipt$")]
        public void PrintPaymentDeclineReceipt(HttpListenerContext context)
        {
            try
            {
                PrintPaymentDeclineReceiptMessage printPaymentDeclineReceiptMessage = ParseResponse<PrintPaymentDeclineReceiptMessage>(context);
                connectorListener.ForEach(listener => listener.OnPrintPaymentDeclineReceipt(printPaymentDeclineReceiptMessage));
            }
            catch (Exception e)
            {
                context.Response.StatusCode = 400;
                context.Response.StatusDescription = e.Message;
                SendTextResponse(context, "error processing request");
            }
        }

        /// <summary>
        /// Prints the payment merchant copy receipt.
        /// </summary>
        /// <param name="context">The context.</param>
        [RESTRoute(Method = Grapevine.HttpMethod.POST, PathInfo = @"^/CloverCallback/PrintPaymentMerchantCopyReceipt$")]
        public void PrintPaymentMerchantCopyReceipt(HttpListenerContext context)
        {
            try
            {
                PrintPaymentMerchantCopyReceiptMessage printPaymentMerchantCopyReceiptMessage = ParseResponse<PrintPaymentMerchantCopyReceiptMessage>(context);
                connectorListener.ForEach(listener => listener.OnPrintPaymentMerchantCopyReceipt(printPaymentMerchantCopyReceiptMessage));
            }
            catch (Exception e)
            {
                context.Response.StatusCode = 400;
                context.Response.StatusDescription = e.Message;
                SendTextResponse(context, "error processing request");
            }
        }

        /// <summary>
        /// Prints the refund payment receipt.
        /// </summary>
        /// <param name="context">The context.</param>
        [RESTRoute(Method = Grapevine.HttpMethod.POST, PathInfo = @"^/CloverCallback/PrintRefundPaymentReceipt$")]
        public void PrintRefundPaymentReceipt(HttpListenerContext context)
        {
            try
            {
                PrintRefundPaymentReceiptMessage printRefundPaymentReceiptMessage = ParseResponse<PrintRefundPaymentReceiptMessage>(context);
                connectorListener.ForEach(listener => listener.OnPrintRefundPaymentReceipt(printRefundPaymentReceiptMessage));
            }
            catch (Exception e)
            {
                context.Response.StatusCode = 400;
                context.Response.StatusDescription = e.Message;
                SendTextResponse(context, "error processing request");
            }
        }

        /// <summary>
        /// Retrieves the device status response.
        /// </summary>
        /// <param name="context">The context.</param>
        [RESTRoute(Method = Grapevine.HttpMethod.POST, PathInfo = @"^/CloverCallback/RetrieveDeviceStatusResponse$")]
        public void RetrieveDeviceStatusResponse(HttpListenerContext context)
        {
            try
            {
                RetrieveDeviceStatusResponse rdsr = ParseResponse<RetrieveDeviceStatusResponse>(context);
                connectorListener.ForEach(listener => listener.OnRetrieveDeviceStatusResponse(rdsr));
            }
            catch (Exception e)
            {
                context.Response.StatusCode = 400;
                context.Response.StatusDescription = e.Message;
                SendTextResponse(context, "error processing request");
            }
        }

        /// <summary>
        /// Resets the device response.
        /// </summary>
        /// <param name="context">The context.</param>
        [RESTRoute(Method = Grapevine.HttpMethod.POST, PathInfo = @"^/CloverCallback/ResetDeviceResponse$")]
        public void ResetDeviceResponse(HttpListenerContext context)
        {
            try
            {
                ResetDeviceResponse rdr = ParseResponse<ResetDeviceResponse>(context);
                connectorListener.ForEach(listener => listener.OnResetDeviceResponse(rdr));
            }
            catch (Exception e)
            {
                context.Response.StatusCode = 400;
                context.Response.StatusDescription = e.Message;
                SendTextResponse(context, "error processing request");
            }
        }


        /// <summary>
        /// Messages from activity.
        /// </summary>
        /// <param name="context">The context.</param>
        [RESTRoute(Method = Grapevine.HttpMethod.POST, PathInfo = @"^/CloverCallback/MessageFromActivity")]
        public void MessageFromActivity(HttpListenerContext context)
        {
            try
            {
                MessageFromActivity mfa = ParseResponse<MessageFromActivity>(context);
                connectorListener.ForEach(listener => listener.OnMessageFromActivity(mfa));
            }
            catch (Exception e)
            {
                context.Response.StatusCode = 400;
                context.Response.StatusDescription = e.Message;
                SendTextResponse(context, "error processing request");
            }
        }

        /// <summary>
        /// Parses the response.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="context">The context.</param>
        /// <returns>T.</returns>
        /// <exception cref="System.Net.HttpListenerException">500 - Unexpected Content Type. Expecting 'application/json'</exception>
        private T ParseResponse<T>(HttpListenerContext context)
        {
            if (context.Request.ContentType != "application/json")
            {
                throw new HttpListenerException(500, "Unexpected Content Type. Expecting 'application/json'");
            }


            StreamReader stream = new StreamReader(context.Request.InputStream);
            string x = stream.ReadToEnd();  // added to view content of input stream

            T message = default(T);
            try
            {
                message = JsonUtils.deserialize<T>(x, new Newtonsoft.Json.JsonConverter[] { new StringEnumConverter() });
                if (message == null && x.Trim().Length > 0)
                {
                    Console.WriteLine("Error parsing " + typeof(T) + " from: " + x);
                }
            }
            finally
            {
                // return the default...
            }
            return message;
        }
    }
}
