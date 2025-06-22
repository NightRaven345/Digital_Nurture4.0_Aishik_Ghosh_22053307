public class Product
{
    public int ProductId { get; set; }

    public required string ProductName { get; set; }

    public required string Category { get; set; }

    public override string ToString() =>
        $"ID: {ProductId}, Name: {ProductName}, Category: {Category}";
}
