using System.Collections.Generic;

namespace TranscribeMe.API.Data.Queries
{
    public class ObjectsList<T> 
    {
        public ObjectsList()
        {
        }

        /// <summary>
        /// Gets or sets the total number of items in collection.
        /// </summary>
        /// <value>
        /// The total.
        /// </value>
        public long Total { get; set; }

        /// <summary>
        /// Gets or sets the for the list.
        /// </summary>
        /// <value>
        /// The items.
        /// </value>
        public IEnumerable<T> Data { get; set; }
    }
}