// ***********************************************************************
// Assembly         : Register
// Author           : Seungkeun
// Created          : 02-08-2017
//
// Last Modified By : Seungkeun
// Last Modified On : 09-15-2017
// ***********************************************************************
// <copyright file="RemoteRESTCloverConfiguration.cs" company="Beauty4u">
//     Copyright © Beauty4u 2009
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;

/// <summary>
/// The remote namespace.
/// </summary>
namespace com.clover.remotepay.transport.remote
{
    /// <summary>
    /// Configuration object used for initializing the
    /// RemoteRESTCloverConnector, which is primarly
    /// used as an example and for testing and validation
    /// </summary>
    /// <summary>
    /// Class RemoteRESTCloverConfiguration.
    /// </summary>
    /// <seealso cref="com.clover.remotepay.transport.CloverDeviceConfiguration" />
    class RemoteRESTCloverConfiguration : CloverDeviceConfiguration
    {
        /// <summary>
        /// The hostname
        /// </summary>
        private string hostname;
        /// <summary>
        /// The port
        /// </summary>
        private int port;
        /// <summary>
        /// The remote application identifier
        /// </summary>
        private string remoteApplicationID;
        /// <summary>
        /// The enable logging
        /// </summary>
        private bool enableLogging = false;
        /// <summary>
        /// The ping sleep seconds
        /// </summary>
        private int pingSleepSeconds = 1;

        /// <summary>
        /// Initializes a new instance of the <see cref="RemoteRESTCloverConfiguration"/> class.
        /// </summary>
        /// <param name="host">The host.</param>
        /// <param name="port">The port.</param>
        /// <param name="remoteApplicationId">The remote application identifier.</param>
        public RemoteRESTCloverConfiguration(string host, int port, String remoteApplicationId) : this(host, port, remoteApplicationId, false, 1)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RemoteRESTCloverConfiguration"/> class.
        /// </summary>
        /// <param name="host">The host.</param>
        /// <param name="port">The port.</param>
        /// <param name="remoteApplicationID">The remote application identifier.</param>
        /// <param name="enableLogging">if set to <c>true</c> [enable logging].</param>
        /// <param name="pingSleepSeconds">The ping sleep seconds.</param>
        /// <exception cref="System.ArgumentException">remoteApplicatoinID is required</exception>
        public RemoteRESTCloverConfiguration(string host, int port, string remoteApplicationID, bool enableLogging, int pingSleepSeconds)
        {
            this.hostname = host;
            this.port = port;
            if (remoteApplicationID == null || remoteApplicationID.Trim().Equals(""))
            {
                throw new ArgumentException("remoteApplicatoinID is required");
            }
            this.remoteApplicationID = remoteApplicationID;
            this.enableLogging = enableLogging;
            this.pingSleepSeconds = pingSleepSeconds;
        }

        /// <summary>
        /// Gets the name of the clover device type.
        /// </summary>
        /// <returns>System.String.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public string getCloverDeviceTypeName()
        {
 	        throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the name of the message package.
        /// </summary>
        /// <returns>System.String.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public string getMessagePackageName()
        {
 	        throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <returns>System.String.</returns>
        public string getName()
        {
            return "REST Service Mini";
        }

        /// <summary>
        /// Gets the clover transport.
        /// </summary>
        /// <returns>CloverTransport.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public CloverTransport getCloverTransport()
        {
 	        throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the enable logging.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool getEnableLogging()
        {
            return enableLogging;
        }

        /// <summary>
        /// Gets the ping sleep seconds.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public int getPingSleepSeconds()
        {
            return pingSleepSeconds;
        }

        /// <summary>
        /// Gets the remote application identifier.
        /// </summary>
        /// <returns>System.String.</returns>
        public string getRemoteApplicationID()
        {
            return remoteApplicationID;
        }
    }
}
