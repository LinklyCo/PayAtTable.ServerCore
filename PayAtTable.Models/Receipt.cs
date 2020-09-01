using System.Collections.Generic;

namespace PayAtTable.Server.Models
{
    /// <summary>
    /// Wraps an EFTPOS receipt
    /// </summary>
    public class Receipt
    {
        /// <summary>
        /// Lines of the receipt
        /// </summary>
        public List<string> Lines { get; set; } = new List<string>();
    }
}