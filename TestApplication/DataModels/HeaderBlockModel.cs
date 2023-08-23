namespace TestApplication.DataModels;

public class HeaderBlockModel : BlockModel
{
    public string BusinessName { get; set; }
    public string LogoUri { get; set; }
    public IEnumerable<WebsiteLink> NavigationMenuLinks { get; set; }
    public CtaButton Button { get; set; }
}
