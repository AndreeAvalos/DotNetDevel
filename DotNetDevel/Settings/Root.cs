namespace DotNetDevel.Settings;

public class Root
{
    public DatabaseSettings DatabaseSettings { get; set; } = null!;
    public JwtSettings JwtSettings { get; set; } = null!;
}