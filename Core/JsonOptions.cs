namespace FatturaElettronica.Core
{
    /// <summary>
    /// Provides formatting optons for JSON output.
    /// </summary>
    /// <remarks>Currently a wrapper around Newtonsoft.Json.Formatting. We provide it so in the future we can remove
    /// json.net dependancy without changing the external API.</remarks>
    public class JsonOptions
    {
        public Formatting Formatting { get; set; } = Formatting.None;
        public DefaultValueHandling DefaultValueHandling { get; set; } = DefaultValueHandling.Ignore;
    }

    public enum Formatting
    {
        None = 0,
        Indented = 1,
    }

    public enum DefaultValueHandling
    {
        Include = 0,
        Ignore = 1,
    }
}