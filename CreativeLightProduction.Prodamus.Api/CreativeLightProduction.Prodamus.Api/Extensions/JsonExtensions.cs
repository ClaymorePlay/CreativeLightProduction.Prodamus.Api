using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativeLightProduction.Prodamus.Api.Extensions
{
    public static class JsonExtensions
    {
        public static string ToUrlEncodedQueryString(this JContainer container)
        {
            return container.ToQueryStringKeyValuePairs().ToUrlEncodedQueryString();
        }

        public static IEnumerable<KeyValuePair<string, string>> ToQueryStringKeyValuePairs(this JContainer container)
        {
            return container.Descendants()
                .OfType<JValue>()
                .Select(v => new KeyValuePair<string, string>(v.ToQueryStringParameterName(), (string)v));
        }

        public static string ToUrlEncodedQueryString(this IEnumerable<KeyValuePair<string, string>> pairs)
        {
            return string.Join("&", pairs.Where(c => !String.IsNullOrWhiteSpace(c.Value)).Select(p => /*HttpUtility.UrlEncode*/(p.Key) + "=" + /*HttpUtility.UrlEncode*/(p.Value)));

        }

        public static string ToQueryStringParameterName(this JToken token)
        {
            if (token == null || token.Parent == null)
                return string.Empty;
            var positions = new List<string>();
            for (JToken previous = null, current = token; current != null; previous = current, current = current.Parent)
            {
                switch (current)
                {
                    case JProperty property:
                        positions.Add(property.Name);
                        break;
                    case JArray array:
                    case JConstructor constructor:
                        if (previous != null)
                            positions.Add(((IList<JToken>)current).IndexOf(previous).ToString(CultureInfo.InvariantCulture));
                        break;
                }
            }
            var sb = new StringBuilder();
            for (var i = positions.Count - 1; i >= 0; i--)
            {
                var name = positions[i];
                if (sb.Length == 0)
                    sb.Append(name);
                else
                    sb.Append('[').Append(name).Append(']');
            }

            return sb.ToString();
        }
    }


    class PrimitiveToStringConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType.IsPrimitive;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value is decimal || value is double && value != null)
                writer.WriteValue(String.Format("{0:0.00}", value).ToLower().Replace(',', '.'));

            else if (value != null)
                writer.WriteValue(value.ToString().ToLower());
        }

        public override bool CanRead
        {
            get { return false; }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
}
