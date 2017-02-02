using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace PactNet.Configuration.Json
{
    internal static class JsonConfig
    {
        private static JsonSerializerSettings _serializerSettings;
        internal static JsonSerializerSettings PactFileSerializerSettings 
        {
            get
            {
                _serializerSettings = _serializerSettings ?? new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    Formatting = Formatting.Indented,
                    //TypeNameHandling = TypeNameHandling.Auto,
                    //Binder = new TypeNameSerializationBinder("PactNet.{0}, PactNet")
                };
                return _serializerSettings;
            }
        }

        private static JsonSerializerSettings _apiRequestSerializerSettings;
        internal static JsonSerializerSettings ApiSerializerSettings
        {
            get
            {
                _apiRequestSerializerSettings = _apiRequestSerializerSettings ?? new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    Formatting = Formatting.None,
                    //TypeNameHandling = TypeNameHandling.Auto,
                    //Binder = new TypeNameSerializationBinder("PactNet.Mocks.MockHttpService.Matchers.Regex.{0}, PactNet")
                };
                return _apiRequestSerializerSettings;
            }
            set { _apiRequestSerializerSettings = value; }
        }
    }

    public class TypeNameSerializationBinder : SerializationBinder
    {
        public string TypeFormat { get; private set; }

        public TypeNameSerializationBinder(string typeFormat)
        {
            TypeFormat = typeFormat;
        }

        public override void BindToName(Type serializedType, out string assemblyName, out string typeName)
        {
            assemblyName = null;
            typeName = serializedType.Name;
        }

        public override Type BindToType(string assemblyName, string typeName)
        {
            string resolvedTypeName = string.Format(TypeFormat, typeName);

            return Type.GetType(resolvedTypeName, true);
        }
    }
}
