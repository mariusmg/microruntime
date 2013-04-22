using System;
using System.Collections.Generic;
using System.Data.Metadata.Edm;
using System.Data.Objects.DataClasses;
using System.Linq;


namespace voidsoft.MicroRuntime.EntityFramework
{
    public static class EntityFrameworkExtender
    {
        #region MetadataWorkspace extender
        public static EntityType[] GetDomainEntityTypes(this MetadataWorkspace workspace)
        {
            GlobalItem[] items = (from meta in workspace.GetItems(DataSpace.CSpace).Where(m => m.BuiltInTypeKind == BuiltInTypeKind.EntityType)
                                  select meta).ToArray();


            EntityType[] types = new EntityType[items.Length];

            for (int i = 0; i < items.Length; i++)
            {
                types[i] = (EntityType)items[i];
            }


            return types;
        }

        public static EntityTypeData[] GetDomainEntities(this MetadataWorkspace workspace)
        {
            EntityType[] types = workspace.GetDomainEntityTypes();


            EntityTypeData[] typeDatas = new EntityTypeData[types.Length];

            for (int i = 0; i < typeDatas.Length; i++)
            {
                typeDatas[i] = new EntityTypeData() { EntityName = types[i].Name, Members = types[i].Members };
            }

            return typeDatas;
        }
        #endregion

        #region EntityCollection extenders
        public static TEntity GetByIndex<TEntity>(this EntityCollection<TEntity> e, int index) where TEntity : class, IEntityWithRelationships
        {
            IEnumerator<TEntity> enumerator = e.GetEnumerator();

            if (index < 0 || index > e.Count)
            {
                throw new ArgumentException("Invalid index");
            }

            int currentIndex = -1;

            while (enumerator.MoveNext())
            {
                ++currentIndex;

                if (currentIndex == index)
                {
                    return enumerator.Current;
                }
            }

            return null;
        }
        #endregion
    }
}