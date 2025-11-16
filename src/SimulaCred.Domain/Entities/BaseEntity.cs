using System.ComponentModel.DataAnnotations;

namespace SimulaCred.Domain.Entities;

public abstract class BaseEntity
{
    [Key]
    public int Id { get; set; }
    
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }
}