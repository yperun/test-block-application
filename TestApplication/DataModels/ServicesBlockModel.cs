namespace TestApplication.DataModels;

public class ServicesBlockModel : BlockModel
{
    public string HeadlineText { get; set; }
    public IEnumerable<ServiceCardModel> ServiceCards { get; set; }
}
