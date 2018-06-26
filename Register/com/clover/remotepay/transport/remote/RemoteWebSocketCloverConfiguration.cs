// ***********************************************************************
// Assembly         : Register
// Author           : Seungkeun
// Created          : 02-08-2017
//
// Last Modified By : Seungkeun
// Last Modified On : 09-15-2017
// ***********************************************************************
// <copyright file="RemoteWebSocketCloverConfiguration.cs" company="Beauty4u">
//     Copyright © Beauty4u 2009
// </copyright>
// <summary></summary>
// ***********************************************************************

/// <summary>
/// The remote namespace.
/// </summary>
namespace com.clover.remotepay.transport.remote
{
    /// <summary>
    /// Configuration object used for initializing the
    /// RemoteWebSocketCloverConnector, which is primarly
    /// used as an example and for testing and validation
    /// </summary>
    /// <summary>
    /// Class RemoteWebSocketCloverConfiguration.
    /// </summary>
    /// <seealso cref="com.clover.remotepay.transport.WebSocketCloverDeviceConfiguration" />
    class RemoteWebSocketCloverConfiguration : WebSocketCloverDeviceConfiguration
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RemoteWebSocketCloverConfiguration"/> class.
        /// </summary>
        /// <param name="endpoint">The endpoint.</param>
        /// <param name="remoteApplicationId">The remote application identifier.</param>
        public RemoteWebSocketCloverConfiguration(string endpoint, string remoteApplicationId) : base(endpoint, remoteApplicationId, "", "", "")
        {
        }
    }
}
