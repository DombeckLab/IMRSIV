using System;

namespace UnityEngine.Advertisements
{
    /// <summary>
    /// A collection of options that you can pass to <c>Advertisement.Show</c>, to modify ad behaviour.
    /// </summary>
    public class ShowOptions
    {
        /// <summary>
        /// Add a string to specify an identifier for a specific user in the game.
        /// </summary>
        public string gamerSid { get; set; }
    }
}
