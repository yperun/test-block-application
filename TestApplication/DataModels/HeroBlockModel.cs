namespace TestApplication.DataModels;

public class HeroBlockModel : BlockModel
{
    public string HeadlineText { get; set; }
    public string DescriptionText { get; set; }
    public CtaButton Button { get; set; }
    public string ImageUri { get; set; }
    public Position ImageAlignment { get; set; }
    public Position ContentAlignment { get; set; }
}
