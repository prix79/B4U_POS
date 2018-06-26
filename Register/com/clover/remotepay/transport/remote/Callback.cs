// ***********************************************************************
// Assembly         : Register
// Author           : Seungkeun
// Created          : 02-08-2017
//
// Last Modified By : Seungkeun
// Last Modified On : 09-15-2017
// ***********************************************************************
// <copyright file="Callback.cs" company="Beauty4u">
//     Copyright © Beauty4u 2009
// </copyright>
// <summary></summary>
// ***********************************************************************

using com.clover.remotepay.sdk;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Windows.Forms;

/// <summary>
/// The remote namespace.
/// </summary>
namespace com.clover.remotepay.transport.remote
{
    /// <summary>
    /// manages/start/stops the REST server used
    /// to listen for callback messages
    /// </summary>
    /// <summary>
    /// Class CallbackController.
    /// </summary>
    class CallbackController
    {

        /// <summary>
        /// Gets or sets the connector.
        /// </summary>
        /// <value>The connector.</value>
        ICloverConnector connector { get; set; }
        /// <summary>
        /// The rest server
        /// </summary>
        CloverRESTServer restServer;
        /// <summary>
        /// The listeners
        /// </summary>
        List<ICloverConnectorListener> listeners = new List<ICloverConnectorListener>();

        /// <summary>
        /// Initializes a new instance of the <see cref="CallbackController"/> class.
        /// </summary>
        /// <param name="cloverConnector">The clover connector.</param>
        public CallbackController(ICloverConnector cloverConnector)
        {
            connector = cloverConnector;
        }
        /// <summary>
        /// Initializes the specified rest client.
        /// </summary>
        /// <param name="restClient">The rest client.</param>
        public void init(RestClient restClient)
        {
            restServer = new CloverRESTServer("localhost", "8182", "http");
            restServer.CloverConnector = connector;
            listeners.ForEach(listener => restServer.AddCloverConnectorListener(listener));
            listeners.Clear();
            {

                try
                {
                    restServer.Start();
                }
                catch(Exception)
                {
                    MessageBox.Show("Couldn't open callback listener service. Are you running as administrator?");
                }


                IRestRequest restRequest = new RestRequest("/Status", Method.GET);
                restClient.ExecuteAsync(restRequest, response =>
                {
                    if (response.StatusCode != HttpStatusCode.OK)
                    {

                        Console.WriteLine(response.ResponseStatus + " : " + response.StatusCode + " : " + response.ErrorMessage);
                    }
                    else
                    {
                        // response is ok, so should process
                    }
                });

            }
        }

        /// <summary>
        /// Adds the listener.
        /// </summary>
        /// <param name="connectorListener">The connector listener.</param>
        internal void AddListener(ICloverConnectorListener connectorListener)
        {
            
            if(restServer != null)
            {
                restServer.AddCloverConnectorListener(connectorListener);
            }
            else
            {
                listeners.Add(connectorListener);
            }
        }

        /// <summary>
        /// Shutdowns this instance.
        /// </summary>
        internal void Shutdown()
        {
            try
            {
                restServer.Stop();
                restServer = null;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
