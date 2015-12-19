﻿namespace formulate.app.Persistence.Internal
{

    // Namespaces.
    using Entities;
    using Resolvers;
    using System;
    using System.Collections.Generic;
    using FormsConstants = formulate.app.Constants.Trees.Forms;
    using Helpers;
    using System.Linq;
    using LayoutsConstants = formulate.app.Constants.Trees.Layouts;


    /// <summary>
    /// Handles persistence of entities.
    /// </summary>
    internal class DefaultEntityPersistence : IEntityPersistence
    {

        #region Properties

        /// <summary>
        /// Folder persistence.
        /// </summary>
        private IFolderPersistence Folders
        {
            get
            {
                return FolderPersistence.Current.Manager;
            }
        }


        /// <summary>
        /// Form persistence.
        /// </summary>
        private IFormPersistence Forms
        {
            get
            {
                return FormPersistence.Current.Manager;
            }
        }


        /// <summary>
        /// Layout persistence.
        /// </summary>
        private ILayoutPersistence Layouts
        {
            get
            {
                return LayoutPersistence.Current.Manager;
            }
        }

        #endregion


        #region Constructors

        /// <summary>
        /// Default constructor.
        /// </summary>
        public DefaultEntityPersistence()
        {
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Gets the entity with the specified ID.
        /// </summary>
        /// <param name="entityId">The ID of the entity.</param>
        /// <returns>
        /// The entity.
        /// </returns>
        public IEntity Retrieve(Guid entityId)
        {

            // Root-level folders.
            var roots = new[]
            {
                GuidHelper.GetGuid(FormsConstants.Id),
                GuidHelper.GetGuid(LayoutsConstants.Id)
            };
            if (roots.Any(x => x == entityId))
            {
                return new EntityRoot()
                {
                    Id = entityId,
                    Path = new[] { entityId }
                };
            }
            else
            {

                // Specific entities (e.g., forms or layouts).
                return Folders.Retrieve(entityId) as IEntity
                    ?? Forms.Retrieve(entityId) as IEntity
                    ?? Layouts.Retrieve(entityId) as IEntity;

            }

        }


        /// <summary>
        /// Gets all the forms that are the children of the folder with the specified ID.
        /// </summary>
        /// <param name="parentId">The parent ID.</param>
        /// <returns>
        /// The forms.
        /// </returns>
        /// <remarks>
        /// You can specify a parent ID of null to get the root forms.
        /// </remarks>
        public IEnumerable<IEntity> RetrieveChildren(Guid? parentId)
        {
            var children = new List<IEntity>();
            children.AddRange(Folders.RetrieveChildren(parentId));
            children.AddRange(Forms.RetrieveChildren(parentId));
            children.AddRange(Layouts.RetrieveChildren(parentId));
            return children;
        }

        #endregion

    }

}