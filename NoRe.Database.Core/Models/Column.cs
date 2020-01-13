namespace NoRe.Database.Core.Models
{
    /// <summary>
    /// One column of a row
    /// </summary>
    public class Column
    {
        /// <summary>
        /// The table column title of the reader result
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// The value of the column
        /// </summary>
        public object Value { get; set; }

        /// <summary>
        /// Returns the value as T
        /// </summary>
        /// <typeparam name="T">Datatype to return</typeparam>
        /// <returns>The value as T</returns>
        public T GetValue<T>() => (T)Value;

        public Column(string key, object value)
        {
            Key = key;
            Value = value;
        }

        public Column() { }
    }
}
