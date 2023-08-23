namespace TestApplication;

public static class Constants
{
    public const string DefaultWebsitePageFileName = "default-web-page.json";
    public const string HeaderBlockId = "header";
    public const string HeroBlockId = "hero";
    public const string ServicesBlockId = "services";
    public static readonly string FilePersistencePath = Path.Combine(Environment.CurrentDirectory, "Persistence/Files");
}
