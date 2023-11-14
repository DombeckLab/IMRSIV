using System;
using System.Text;
using Newtonsoft.Json;

namespace Unity.Services.Core.Editor
{
    struct JsonWebToken
    {
        static readonly char[] k_JwtSeparator = { '.' };
        static readonly DateTime k_UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

        public DateTime Expiration { get; }

        [JsonConstructor]
        public JsonWebToken(long exp)
        {
            Expiration = k_UnixEpoch.AddSeconds(exp);
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static JsonWebToken Decode(string token)
        {
            var parts = token.Split(k_JwtSeparator);
            if (parts.Length != 3)
            {
                throw new InvalidJwtException("JWT has an invalid number of sections", token);
            }

            var payload = parts[1];
            var payloadJson = Encoding.UTF8.GetString(Base64UrlDecode(payload));
            return JsonConvert.DeserializeObject<JsonWebToken>(payloadJson);
        }

        static byte[] Base64UrlDecode(string input)
        {
            var output = input;
            output = output.Replace('-', '+'); // 62nd char of encoding
            output = output.Replace('_', '/'); // 63rd char of encoding

            var mod4 = input.Length % 4;
            if (mod4 > 0)
            {
                output += new string('=', 4 - mod4);
            }

            return Convert.FromBase64String(output);
        }
    }
}
