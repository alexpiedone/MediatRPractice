namespace Domain.Models;

public class BaseModel
{
    public Guid Id { get; set; }  

    public bool Active { get;set; } = true;

    public DateTime CreatedAt { get; set; } = DateTime.Now;

}
