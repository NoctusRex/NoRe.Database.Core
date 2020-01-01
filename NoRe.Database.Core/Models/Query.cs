namespace NoRe.Database.Core.Models
{
    /// <summary>
    /// Contains a command and its parameters
    /// </summary>
    public class Query
    {
        public string CommandText { get; set; }
        public object[] Parameters { get; set; } = null;

        public Query() { }

        public Query(string commandText, params object[] parameters)
        {
            CommandText = commandText;
            Parameters = parameters;
        }
    }
}
