namespace NoRe.Database.Core.Models
{
    /// <summary>
    /// Contains a command and its parameters
    /// </summary>
    public class Query
    {
        /// <summary>
        /// The sql command that will be executed
        /// Use @0, @1, @2, @... to specifiy parameters
        /// </summary>
        public string CommandText { get; set; }
        /// <summary>
        /// The parameters that will fill the @ placeholders of the command text
        /// </summary>
        public object[] Parameters { get; set; } = null;

        public Query() { }

        public Query(string commandText, params object[] parameters)
        {
            CommandText = commandText;
            Parameters = parameters;
        }
    }
}
