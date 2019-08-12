namespace WebApp.Models
{
    /// <summary>
    /// Order different states
    /// </summary>
    public enum OrderStatus
    {
        /// <summary>
        /// Order was created but still hasnt been closed
        /// </summary>
        InProgress,
        /// <summary>
        /// Order was executed and closed
        /// </summary>
        Complete
    }
}
