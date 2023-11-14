using System.Threading.Tasks;
using Unity.Services.Core.Scheduler.Internal;
using UnityEditor;

namespace Unity.Services.Core.Editor
{
    /// <summary>
    /// Helper class to get the different kind of tokens used by services at editor time.
    /// </summary>
    public class AccessTokens : IAccessTokens
    {
        readonly IGatewayTokens m_GatewayTokens;

        internal AccessTokens(IGatewayTokens gatewayTokens)
        {
            m_GatewayTokens = gatewayTokens;
        }

        /// <summary>
        /// Initialize a new instance of the <see cref="AccessTokens"/> class.
        /// </summary>
        public AccessTokens()
        {
            var env = new CloudEnvironmentConfigProvider();
            ITokenExchangeUrls urls;
            if (env.IsStaging())
            {
                urls = new StagingTokenExchangeUrls();
            }
            else
            {
                urls = new ProductionTokenExchangeUrls();
            }

            m_GatewayTokens = new GatewayTokens(new TokenExchange(urls), new UtcTimeProvider());
        }

        /// <inheritdoc cref="IAccessTokens.GetGenesisToken"/>
        public static string GetGenesisToken() => CloudProjectSettings.accessToken;

        /// <inheritdoc cref="IAccessTokens.GetServicesGatewayTokenAsync"/>
        public Task<string> GetServicesGatewayTokenAsync()
        {
            return m_GatewayTokens.GetGatewayTokenAsync(GetGenesisToken());
        }

        /// <inheritdoc/>
        string IAccessTokens.GetGenesisToken() => GetGenesisToken();
    }
}
