namespace LAB08_MauricioCalderón.DTO_s.Operations.Read;

public class ProductoUpdateDTO
{
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public decimal Price { get; set; }
}