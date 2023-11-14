using System.Threading.Tasks;

namespace Unity.Services.Core.Editor
{
    /// <summary>
    /// Helper class to get access to gateway tokens
    /// </summary>
    interface IGatewayTokens
    {
        Task<string> GetGatewayTokenAsync(string genesisToken);
    }
}
