using System.Threading.Tasks;

namespace Unity.Services.Core.Editor
{
    /// <summary>
    /// Helper class to get the different kind of tokens used by services at editor time.
    /// </summary>
    public interface IAccessTokens
    {
        /// <summary>
        /// The access token used by Genesis.
        /// </summary>
        /// <returns>
        /// Genesis Access Token.
        /// </returns>
        string GetGenesisToken();

        /// <summary>
        /// Task that represents an asynchronous operation to get services gateway token.
        /// </summary>
        /// <returns>
        /// Task with a result that represents the services gateway token.
        /// </returns>
        Task<string> GetServicesGatewayTokenAsync();
    }
}
