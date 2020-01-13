using System.Collections.Generic;
using System.Linq;

namespace NoRe.Database.Core.Models
{
    /// <summary>
    /// One row of the Table class
    /// </summary>
    public class Row
    {
        /// <summary>
        /// The columns of the row
        /// </summary>
        public List<Column> Columns { get; set; } = new List<Column>();

        /// <summary>
        /// Returns the value of a column
        /// </summary>
        /// <typeparam name="T">The type of the value</typeparam>
        /// <param name="columnKey">The name of the column</param>
        /// <returns>The value of T</returns>
        public T GetValue<T>(string columnKey) => (T)Columns.First(x => x.Key == columnKey).Value;
    }
}
