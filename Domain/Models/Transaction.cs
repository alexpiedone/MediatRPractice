namespace Domain.Models;

public class Transaction : BaseModel
{
    public decimal Amount { get; set; } 
    public DateTime Date { get; set; }  
    public string Description { get; set; } 
    public TransactionType Type { get; set; } 
    public Guid AccountId { get; set; }  

    public string Currency { get; set; } 
    public bool IsRecurring { get; set; } 
    public string ReferenceNumber { get; set; } 
    public string Category { get; set; } 
    public DateTime CreatedAt { get; set; } 

    public Guid SenderId { get; set; }  
    public Guid ReceiverId { get; set; } 
}


public class TransactionType
{
    public Guid Id { get; set; } 
    public string Name { get; set; }  
    public string Description { get; set; }  
}