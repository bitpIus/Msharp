namespace Msharp.Domain.Dto;

public class FactoryDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Location { get; set; } = null!;
    public int ProductionCapacity { get; set; }
    public string Type { get; set; } = null!;
}
