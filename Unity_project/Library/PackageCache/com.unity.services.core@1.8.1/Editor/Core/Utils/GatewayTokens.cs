using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UnityEditor;
using Unity.Services.Core.Scheduler.Internal;

namespace Unity.Services.Core.Editor
{
    class GatewayTokens : IGatewayTokens
    {
        const string k_CacheKey = "Core.GatewayTokens.Cache";
        static readonly TimeSpan k_RefreshGracePeriod = TimeSpan.FromMinutes(30);

        readonly TokenExchange m_TokenExchange;
        readonly ITimeProvider m_Time;

        internal GatewayTokens(TokenExchange tokenExchange, ITimeProvider time)
        {
            m_TokenExchange = tokenExchange;
            m_Time = time;
        }

        public async Task<string> GetGatewayTokenAsync(string genesisToken)
        {
            var cachedTokens = LoadCache();

            var nextRefreshTime = GetNextRefreshTime(cachedTokens.GatewayToken);
            if (genesisToken != cachedTokens.GenesisToken || m_Time.Now.ToUniversalTime() >= nextRefreshTime)
            {
                if (!string.IsNullOrEmpty(genesisToken))
                {
                    cachedTokens.GatewayToken = await m_TokenExchange.ExchangeServicesGatewayTokenAsync(genesisToken);
                }
                else
                {
                    cachedTokens.GatewayToken = null;
                }
                cachedTokens.GenesisToken = genesisToken;
            }

            SaveCache(cachedTokens);
            return cachedTokens.GatewayToken;
        }

        public static void ClearCache()
        {
            SessionState.EraseString(k_CacheKey);
        }

        static CachedTokens LoadCache()
        {
            var serialized = SessionState.GetString(k_CacheKey, string.Empty);
            try
            {
                return JsonConvert.DeserializeObject<CachedTokens>(serialized);
            }
            catch (JsonException)
            {
                return new CachedTokens();
            }
        }

        static void SaveCache(CachedTokens tokens)
        {
            var serialized = JsonConvert.SerializeObject(tokens);
            SessionState.SetString(k_CacheKey, serialized);
        }

        static DateTime GetNextRefreshTime(string gatewayToken)
        {
            if (string.IsNullOrEmpty(gatewayToken))
            {
                return new DateTime();
            }

            var jwt = JsonWebToken.Decode(gatewayToken);
            return jwt.Expiration - k_RefreshGracePeriod;
        }

        struct CachedTokens
        {
            public string GatewayToken;
            public string GenesisToken;
        }
    }
}
