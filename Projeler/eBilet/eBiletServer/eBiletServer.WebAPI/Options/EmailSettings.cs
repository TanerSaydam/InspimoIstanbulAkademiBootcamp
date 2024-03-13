namespace eBiletServer.WebAPI.Options;

public sealed class EmailSettings
{
    public string From { get; set; } = string.Empty;
    public string SMTP { get; set; } = string.Empty;
    public int Port { get; set; }
}
