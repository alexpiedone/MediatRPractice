namespace Domain.Models;

public class Balance : BaseModel
{
    public Guid AccountId { get; set; }  // Associated account identifier

    // Assets
    public decimal CashAndCashEquivalents { get; set; }  // Cash or assets easily convertible to cash
    public decimal AccountsReceivable { get; set; }  // Money owed by customers
    public decimal Inventory { get; set; }  // Value of goods available for sale
    public decimal Investments { get; set; }  // Investments held by the entity
    public decimal PropertyPlantAndEquipment { get; set; }  // Long-term assets like buildings and machinery
    public decimal IntangibleAssets { get; set; }  // Non-physical assets like patents and trademarks

    // Liabilities
    public decimal AccountsPayable { get; set; }  // Money owed to suppliers
    public decimal ShortTermDebt { get; set; }  // Debt due within a year
    public decimal LongTermDebt { get; set; }  // Debt due after one year

    // Equity
    public decimal CommonStock { get; set; }  // Value of common shares issued
    public decimal RetainedEarnings { get; set; }  // Cumulative net earnings retained in the entity
    
    public DateTime LastUpdated { get; set; }  // Timestamp of the last update
}
