namespace TransportSystems.Frontend.Core.Domain.Core
{
    public enum RequestPriority
    {
        /// <summary>
        /// The speculative.
        /// </summary>
        Speculative = 10,

        /// <summary>
        /// The user initiated.
        /// </summary>
        UserInitiated = 100,

        /// <summary>
        /// The background.
        /// </summary>
        Background = 20,

        /// <summary>
        /// The explicit.
        /// </summary>
        Explicit = 0
    }
}
