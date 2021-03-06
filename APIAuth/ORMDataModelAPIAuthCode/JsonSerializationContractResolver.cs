//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using APIAuth.Database;
namespace APIAuth.Database
{
    public class DatabaseJsonSerializationContractResolver : Newtonsoft.Json.Serialization.DefaultContractResolver
    {
        public bool SerializeCollections { get; set; } = false;
        public bool SerializeReferences { get; set; } = true;
        public bool SerializeByteArrays { get; set; } = true;
        readonly XPDictionary dictionary;

        public DatabaseJsonSerializationContractResolver()
        {
            dictionary = new ReflectionDictionary();
            dictionary.GetDataStoreSchema(new Type[] {
                typeof(APIAUT),
                typeof(APISMS_CL01),
                typeof(TraceLog)
            });
        }

        protected override List<MemberInfo> GetSerializableMembers(Type objectType)
        {
            XPClassInfo classInfo = dictionary.QueryClassInfo(objectType);
            if (classInfo != null && classInfo.IsPersistent)
            {
                var allSerializableMembers = base.GetSerializableMembers(objectType);
                var serializableMembers = new List<MemberInfo>(allSerializableMembers.Count);
                foreach (MemberInfo member in allSerializableMembers)
                {
                    XPMemberInfo mi = classInfo.FindMember(member.Name);
                    if (!(mi.IsPersistent || mi.IsAliased || mi.IsCollection || mi.IsManyToManyAlias)
                        || ((mi.IsCollection || mi.IsManyToManyAlias) && !SerializeCollections)
                        || (mi.ReferenceType != null && !SerializeReferences)
                        || (mi.MemberType == typeof(byte[]) && !SerializeByteArrays))
                    {
                        continue;
                    }
                    serializableMembers.Add(member);
                }
                return serializableMembers;
            }
            return base.GetSerializableMembers(objectType);
        }
    }
}
namespace Microsoft.Extensions.DependencyInjection
{
    public static class DatabaseJsonMvcBuilderExtensions
    {
        public static IMvcBuilder AddDatabaseJsonOptions(this IMvcBuilder builder, Action<DatabaseJsonSerializationContractResolver> setupAction = null)
        {
            return builder.AddJsonOptions(opt =>
            {
                var resolver = new DatabaseJsonSerializationContractResolver();
                //opt.SerializerSettings.ContractResolver = resolver;
                //opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                setupAction?.Invoke(resolver);
            });
        }
    }
}
