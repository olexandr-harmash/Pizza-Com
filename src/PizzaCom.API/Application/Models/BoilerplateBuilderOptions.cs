namespace PizzaCom.API.Models;

public class BuildBoilerplateDTO
{
    public int Id { get; set; }
    public List<OptionDto> Options { get; set; }
    public List<ComponentDto> Components { get; set; }
}