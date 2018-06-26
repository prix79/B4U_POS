﻿// ***********************************************************************
// Assembly         : Register
// Author           : Seungkeun
// Created          : 09-07-2016
//
// Last Modified By : Seungkeun
// Last Modified On : 09-07-2016
// ***********************************************************************
// <copyright file="Settings.Designer.cs" company="Beauty4u">
//     Copyright © Beauty4u 2009
// </copyright>
// <summary></summary>
// ***********************************************************************

/// <summary>
/// The Properties namespace.
/// </summary>
namespace Register.Properties {


    /// <summary>
    /// Class Settings. This class cannot be inherited.
    /// </summary>
    /// <seealso cref="System.Configuration.ApplicationSettingsBase" />
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "12.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {

        /// <summary>
        /// The default instance
        /// </summary>
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));

        /// <summary>
        /// Gets the default.
        /// </summary>
        /// <value>The default.</value>
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }

        /// <summary>
        /// Gets the oxon hill connection string.
        /// </summary>
        /// <value>The oxon hill connection string.</value>
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=BEAUTY4U-SEUNG;Initial Catalog=OxonHill;Integrated Security=True")]
        public string OxonHillConnectionString {
            get {
                return ((string)(this["OxonHillConnectionString"]));
            }
        }
    }
}
