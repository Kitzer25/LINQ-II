namespace LAB08_MauricioCalderón.DTO_s.Operations.Read;

public class ClientWithOrdersDTO
{
    public int OrderId { get; set; }
    public DateTime OrderDate { get; set; }
    public List<ProductoReadDTO> Products { get; set; }
}