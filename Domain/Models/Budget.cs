namespace Domain.Models;


public class Budget : BaseModel
{
    public Guid AccountId { get; set; }  // The account associated with the budget
    public string Category { get; set; }  // Budget category (e.g., Rent, Utilities)
    public decimal AllocatedAmount { get; set; }  // Allocated budget for the category
    public decimal SpentAmount { get; set; }  // Amount spent from the budget
    public decimal RemainingAmount
    {
        get { return AllocatedAmount - SpentAmount; }  // Remaining budget
    }
    public DateTime StartDate { get; set; }  // Start date of the budget period
    public DateTime EndDate { get; set; }  // End date of the budget period
    public string Notes { get; set; }  // Additional notes about the budget
}
