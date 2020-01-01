using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace NoRe.Database.Core.Models
{
    /// <summary>
    /// Is used to return the result of a database reader
    /// </summary>
    public class Table
    {
        /// <summary>
        /// The rows of the table
        /// </summary>
        public List<Row> Rows { get; set; } = new List<Row>();

        /// <summary>
        /// Original data table of the database reader
        /// </summary>
        public DataTable DataTable { get; set; }

        /// <summary>
        /// Returns the value of a row and its column
        /// </summary>
        /// <typeparam name="T">The type of the value</typeparam>
        /// <param name="index">The row index</param>
        /// <param name="columnKey">The name of the column</param>
        /// <returns>The value of T</returns>
        public T GetValue<T>(int index, string columnKey) => (T)Rows[index].Columns.First(x => x.Key == columnKey).Value;
    }
}
