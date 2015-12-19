﻿namespace formulate.app.Forms
{

    // Namespaces.
    using Entities;
    using System;


    /// <summary>
    /// A form.
    /// </summary>
    public class Form : IEntity
    {

        #region Properties

        /// <summary>
        /// The unique ID of this form.
        /// </summary>
        public Guid Id { get; set; }


        /// <summary>
        /// The entity path to this form.
        /// </summary>
        /// <remarks>
        /// This path excludes the root, but includes the form ID.
        /// </remarks>
        public Guid[] Path { get; set; }


        /// <summary>
        /// The alias of this form.
        /// </summary>
        public string Alias { get; set; }


        /// <summary>
        /// The name of this form.
        /// </summary>
        public string Name { get; set; }


        /// <summary>
        /// The fields on this form.
        /// </summary>
        public IFormField[] Fields { get; set; }


        /// <summary>
        /// Information about this form.
        /// </summary>
        public IFormMetaInfo[] MetaInfo { get; set; }

        #endregion


        #region Constructors

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Form()
        {
        }

        #endregion

    }

}