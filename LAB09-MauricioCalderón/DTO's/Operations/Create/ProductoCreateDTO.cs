namespace LAB08_MauricioCalderón.DTO_s.Operations.Create;

public class ProductoCreateDTO
{
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public decimal Price { get; set; }
}