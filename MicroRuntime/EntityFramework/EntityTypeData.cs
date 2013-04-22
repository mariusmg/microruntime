using System.Data.Metadata.Edm;

namespace voidsoft.MicroRuntime.EntityFramework
{
    /// <summary>
    /// Represents a EF entity and its members
    /// </summary>
    public class EntityTypeData
    {
        private string entityName;

        private ReadOnlyMetadataCollection<EdmMember> members;


        /// <summary>
        /// Gets or sets the name of the entity.
        /// </summary>
        /// <value>The name of the entity.</value>
        public string EntityName
        {
            get
            {
                return entityName;
            }
            set
            {
                entityName = value;
            }
        }

        /// <summary>
        /// Gets or sets the members.
        /// </summary>
        /// <value>The members.</value>
        public ReadOnlyMetadataCollection<EdmMember> Members
        {
            get
            {
                return members;
            }
            set
            {
                members = value;
            }
        }
    }
}