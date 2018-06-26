using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Globalization;
using System.Threading;
using System.Drawing.Printing;
using System.Linq;
using System.Threading.Tasks;
using com.clover.remotepay.transport;
using com.clover.remotepay.sdk;
using com.clover.remote.order;
using com.clover.sdk.v3.payments;
using Microsoft.Win32;
using System.Diagnostics;

namespace WindowsFormsApplication1
{
    public partial class CloverConnection : Form, ICloverConnectorListener
    {
        public CloverDeviceConfiguration USBConfig = new USBCloverDeviceConfiguration("__deviceID__", "Register", false, 1);
        public ICloverConnector cloverConnector;
        public SynchronizationContext uiThread;

        public CloverConnection()
        {
            InitializeComponent();
        }

        private void CloverConnection_Load(object sender, EventArgs e)
        {
            Application.ApplicationExit += new EventHandler(this.AppShutdown);
            uiThread = WindowsFormsSynchronizationContext.Current;
        }

        private void btnUSBConnect_Click(object sender, EventArgs e)
        {
            InitializeConnector(USBConfig);
        }

        public void InitializeConnector(CloverDeviceConfiguration config)
        {
            if (cloverConnector != null)
            {
                cloverConnector.RemoveCloverConnectorListener(this);

                OnDeviceDisconnected(); // for any disabling, messaging, etc.
                //SaleButton.Enabled = false; // everything can work except Pay
                cloverConnector.Dispose();
            }

            cloverConnector = new CloverConnector(config);
            cloverConnector.InitializeConnection();

            cloverConnector.AddCloverConnectorListener(this);
        }

        public void OnDeviceConnected()
        {
            uiThread.Send(delegate(object state)
            {
            }, null);
        }

        public void OnDeviceReady(MerchantInfo merchantInfo)
        {
            uiThread.Send(delegate(object state)
            {
                MessageBox.Show("Device has been connected!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnUSBConnect.Enabled = false;
                btnStartRegister.Enabled = true;
            }, null);
        }

        public void OnDeviceDisconnected()
        {
            try
            {
                uiThread.Send(delegate(object state)
                {
                }, null);

            }
            catch (Exception)
            {
                // uiThread is gone on shutdown
            }
        }

        public void OnDeviceActivityStart(CloverDeviceEvent deviceEvent)
        {
            uiThread.Send(delegate(object state)
            {
            }, null);
        }

        public void OnDeviceActivityEnd(CloverDeviceEvent deviceEvent)
        {
            try
            {
                uiThread.Send(delegate(object state)
                {

                }, null);
            }
            catch (Exception)
            {
                // if UI goes away, uiThread may be disposed
            }
        }

        public void OnDeviceError(CloverDeviceErrorEvent deviceErrorEvent)
        {
            uiThread.Send(delegate(object state)
            {
            }, null);
        }

        public void OnConfirmPaymentRequest(ConfirmPaymentRequest request)
        {
        }

        public void OnSaleResponse(SaleResponse response)
        {
            if (response.Success)
            {
                uiThread.Send(delegate(object state)
                {
                }, null);
            }
            else if (response.Result.Equals(ResponseCode.FAIL))
            {
                uiThread.Send(delegate(object state)
                {
                }, null);
            }
            else if (response.Result.Equals(ResponseCode.CANCEL))
            {
                uiThread.Send(delegate(object state)
                {
                }, null);
            }
        }

        public void OnVerifySignatureRequest(VerifySignatureRequest request)
        {
        }

        public void OnVoidPaymentResponse(VoidPaymentResponse response)
        {
            if (response.Success)
            {
                uiThread.Send(delegate(object state)
                {

                }, null);
            }
            else if (response.Result.Equals(ResponseCode.FAIL))
            {
                uiThread.Send(delegate(object state)
                {
                }, null);
            }
        }

        public void OnRefundPaymentResponse(RefundPaymentResponse response)
        {
            if (response.Success)
            {
                uiThread.Send(delegate(object state)
                {
                }, null);
            }
            else if (response.Result.Equals(ResponseCode.FAIL))
            {
                uiThread.Send(delegate(object state)
                {
                }, null);
            }
        }

        public void OnManualRefundResponse(ManualRefundResponse response)
        {
            if (response.Success)
            {
                uiThread.Send(delegate(object state)
                {

                }, null);
            }
            else if (response.Result.Equals(ResponseCode.FAIL))
            {
                uiThread.Send(delegate(object state)
                {
                    MessageBox.Show(this, response.Reason, response.Message);
                }, null);
            }
            else if (response.Result.Equals(ResponseCode.CANCEL))
            {
                uiThread.Send(delegate(object state)
                {
                    MessageBox.Show(this, response.Reason, response.Message);
                }, null);
            }
        }

        public void OnCloseoutResponse(CloseoutResponse response)
        {
            if (response != null && response.Success)
            {
                uiThread.Send(delegate(object state)
                {
                    //AlertForm.Show(this, "Batch Closed", "Batch " + response.Batch.id + " was successfully processed.");
                }, null);

            }
            if (response != null && response.Result.Equals(ResponseCode.FAIL))
            {
                uiThread.Send(delegate(object state)
                {
                    //AlertForm.Show(this, "Close Attempt Failed", "Reason: " + response.Reason + ".");
                }, null);

            }
        }

        public void OnVaultCardResponse(VaultCardResponse vcResponse)
        {
        }

        public void OnAuthResponse(AuthResponse response)
        {
        }

        public void OnCapturePreAuthResponse(CapturePreAuthResponse response)
        {
        }

        public void OnTipAdded(TipAddedMessage message)
        {
        }

        public void OnTipAdjustAuthResponse(TipAdjustAuthResponse response)
        {
        }

        public void OnPreAuthResponse(PreAuthResponse response)
        {
        }

        public void OnRetrievePendingPaymentsResponse(RetrievePendingPaymentsResponse response)
        {
            uiThread.Send(delegate(object state)
            {
            }, null);
        }

        public virtual void OnPrintManualRefundReceipt(PrintManualRefundReceiptMessage printManualRefundReceiptMessage)
        {
            uiThread.Send(delegate(object state)
            {
                //AlertForm.Show(this, "Print ManualRefund Receipt", (printManualRefundReceiptMessage.Credit.amount / 100.0).ToString("C2"));
            }, null);
        }

        public virtual void OnPrintManualRefundDeclineReceipt(PrintManualRefundDeclineReceiptMessage printManualRefundDeclineReceiptMessage)
        {
            uiThread.Send(delegate(object state)
            {
                //AlertForm.Show(this, "Print ManualRefund Declined Receipt", printManualRefundDeclineReceiptMessage.Reason);
            }, null);
        }

        public virtual void OnPrintPaymentReceipt(PrintPaymentReceiptMessage printPaymentReceiptMessage)
        {
            uiThread.Send(delegate(object state)
            {
                //AlertForm.Show(this, "Print Payment Receipt", (printPaymentReceiptMessage.Payment.amount / 100.0).ToString("C2"));
            }, null);
        }

        public virtual void OnPrintPaymentDeclineReceipt(PrintPaymentDeclineReceiptMessage printPaymentDeclineReceiptMessage)
        {
            uiThread.Send(delegate(object state)
            {
                //AlertForm.Show(this, "Print Payment Declined Receipt", printPaymentDeclineReceiptMessage.Reason);
            }, null);
        }

        public virtual void OnPrintPaymentMerchantCopyReceipt(PrintPaymentMerchantCopyReceiptMessage printPaymentMerchantCopyReceiptMessage)
        {
            uiThread.Send(delegate(object state)
            {
                //AlertForm.Show(this, "Print Merchant Payment Copy Receipt", (printPaymentMerchantCopyReceiptMessage.Payment.amount / 100.0).ToString("C2"));
            }, null);
        }

        public virtual void OnPrintRefundPaymentReceipt(PrintRefundPaymentReceiptMessage printRefundPaymentReceiptMessage)
        {
            uiThread.Send(delegate(object state)
            {
                //AlertForm.Show(this, "Print Refund Payment Receipt", (printRefundPaymentReceiptMessage.Refund.amount / 100.0).ToString("C2"));
            }, null);
        }

        public void OnReadCardDataResponse(ReadCardDataResponse rcdResponse)
        {
            String screenResponseMsg = "";
            if (rcdResponse.Success && rcdResponse.CardData != null &&
                (rcdResponse.CardData.Track1 != null ||
                 rcdResponse.CardData.Track2 != null ||
                 rcdResponse.CardData.Pan != null))
            {

                uiThread.Send(delegate(object state)
                {
                    if (rcdResponse.CardData.Track1 != null)
                    {
                        screenResponseMsg = "Track1: " + rcdResponse.CardData.Track1;
                    }
                    else
                    {
                        if (rcdResponse.CardData.Track2 != null)
                        {
                            screenResponseMsg = "Track2: " + rcdResponse.CardData.Track2;
                        }
                        else
                        {
                            screenResponseMsg = "Pan: " + rcdResponse.CardData.Pan;
                        }
                    }
                    //AlertForm.Show(this, "Card Data Info", screenResponseMsg);
                }, null);
            }
            else
            {
                uiThread.Send(delegate(object state)
                {
                    if (rcdResponse.Success)
                    {
                        screenResponseMsg = "Card track and pan information was blank.";
                    }
                    else
                    {
                        screenResponseMsg = "Card was not successfully read";
                    }
                    //AlertForm.Show(this, rcdResponse.Reason, screenResponseMsg);
                }, null);
            }
        }

        private void AppShutdown(object sender, EventArgs e)
        {
            if (cloverConnector != null)
            {
                try
                {
                    cloverConnector.Dispose();
                }
                catch (Exception)
                {
                    cloverConnector = null;
                }
            }
        }

        private void btnStartRegister_Click(object sender, EventArgs e)
        {
            Application.Exit();

            //var p = new Process();
            //p.StartInfo.FileName = @".\LaunchingRegisterClient.cmd";  // just for example, you can use yours.
            //p.Start();
            try
            {
                ProcessStartInfo procInfo = new ProcessStartInfo();
                procInfo.UseShellExecute = true;
                procInfo.FileName = @"LaunchingRegisterClient.cmd";  //The file in that DIR.
                procInfo.Verb = "runas";
                Process.Start(procInfo);  //Start that process.
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        public virtual void OnCustomActivityResponse(CustomActivityResponse response)
        {
            uiThread.Send(delegate (object state)
            {
                /*try
                {
                    dynamic parsedPayload = JsonConvert.DeserializeObject(response.Payload);
                    string formattedPayload = JsonConvert.SerializeObject(parsedPayload, Formatting.Indented);
                    Console.WriteLine(formattedPayload);

                    AlertForm.Show(this, "Custom Activity Response" + (response.Success ? "" : ": Canceled"), formattedPayload);
                }
                catch (Exception e)
                {
                    AlertForm.Show(this, "Custom Activity Response" + (response.Success ? "" : ": Canceled"), response.Payload);
                }*/
            }, null);
        }

        public void OnMessageFromActivity(MessageFromActivity message)
        {
            /*PayloadMessage payloadMessage = JsonConvert.DeserializeObject<PayloadMessage>(message.Payload);
            switch (payloadMessage.messageType)
            {
                case MessageType.REQUEST_RATINGS:
                    handleRequestRatings();
                    break;
                case MessageType.RATINGS:
                    handleRatings(message.Payload);
                    break;
                case MessageType.PHONE_NUMBER:
                    handleCustomerLookup(message.Payload);
                    break;
                case MessageType.CONVERSATION_RESPONSE:
                    handleJokeResponse(message.Payload);
                    break;
                default:
                    break;
            }*/
        }

        public virtual void OnRetrieveDeviceStatusResponse(RetrieveDeviceStatusResponse response)
        {
            uiThread.Send(delegate (object state)
            {
                //AlertForm.Show(this, "OnRetrieveDeviceStatusResponse: ", response.State + ":" + JsonUtils.serialize(response.Data));
            }, null);
        }

        public virtual void OnResetDeviceResponse(ResetDeviceResponse response)
        {
            uiThread.Send(delegate (object state)
            {
                //AlertForm.Show(this, "OnResetDeviceResponse", response.State.ToString());
            }, null);
        }

        public void OnRetrievePaymentResponse(RetrievePaymentResponse response)
        {
            /*if (response.Success)
            {
                uiThread.Send(delegate (object state)
                {
                    String details = "No matching payment";
                    Payment payment = response.Payment;
                    if (payment != null)
                    {
                        details = "Created:" + dateFormat(payment.createdTime) + "\nResult: " + payment.result
                       + "\nPaymentId: " + payment.id + "\nOrderId: " + payment.order.id
                        + "\nAmount: " + currencyFormat(payment.amount) + " Tip: " + currencyFormat(payment.tipAmount) + " Tax: " + currencyFormat(payment.taxAmount);
                    }
                    AlertForm.Show(this, response.QueryStatus.ToString(), details);
                }, null);
            }
            else if (response.Result.Equals(ResponseCode.FAIL))
            {
                uiThread.Send(delegate (object state)
                {
                    AlertForm.Show(this, response.Reason, response.Message);
                }, null);
            }
            else if (response.Result.Equals(ResponseCode.CANCEL))
            {
                uiThread.Send(delegate (object state)
                {
                    AlertForm.Show(this, response.Reason, response.Message);
                }, null);
            }*/
        }
    }
}
