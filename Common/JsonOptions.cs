namespace FatturaElettronica.Common
{
    /// <summary>
    /// Provides formatting optons for JSON output.
    /// </summary>
    /// <remarks>Currently a wrapper around Newtonsoft.Json.Formatting. We provide it so in the future we can remove json.net
    /// dependancy without changing the external API.</remarks>
    public enum JsonOptions
    {
        None = 0,
        Indented = 1,
    }
}
