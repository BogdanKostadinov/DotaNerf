using System.ComponentModel.DataAnnotations;

namespace DotaNerf.Models;

public class Hero
{
    [Key]
    public int Id { get; set; }
    public required string Name { get; set; }
}
