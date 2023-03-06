using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Msharp.Domain.Entities;

public class Factory
{
    [Column("FactoryId")]
    public int Id { get; set; }

    [Required(ErrorMessage = "Factory name is a required field.")]
    [MaxLength(60, ErrorMessage = "Maximum length for the Name is 60 characters.")]
    public string Name { get; set; } = null!;

    [Required(ErrorMessage = "Location is a required field.")]
    [MaxLength(120, ErrorMessage = "Maximum length for the Location is 120 characters.")]
    public string Location { get; set; } = null!;

    public int ProductionCapacity { get; set; }

    [Required(ErrorMessage = "FactoryType is a required field.")]
    [MaxLength(120, ErrorMessage = "Maximum length for the FactoryType is 120 characters.")]
    public string FactoryType { get; set; }

    public ICollection<Employee> Employees { get; set; }
}
