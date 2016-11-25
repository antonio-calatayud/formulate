﻿namespace formulate.app.Configuration
{

    // Namespaces.
    using System.Configuration;


    /// <summary>
    /// A "fileStorage" configuration element.
    /// </summary>
    public class FileStorageElement : ConfigurationElement
    {

        #region Properties

        /// <summary>
        /// The base path property of this element.
        /// </summary>
        [ConfigurationProperty("basePath", IsRequired = true,
            DefaultValue = "~/App_Data/Formulate/FileStorage/Files/")]
        [RegexStringValidator("^~.*/$")]
        public string BasePath
        {
            get
            {
                return this["basePath"] as string;
            }
            set
            {
                this["basePath"] = value;
            }
        }

        #endregion

    }

}