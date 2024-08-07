using System.ComponentModel.DataAnnotations.Schema;

public class Transaction
{
    public int Id { get; set; }
    public string? Description { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
}

