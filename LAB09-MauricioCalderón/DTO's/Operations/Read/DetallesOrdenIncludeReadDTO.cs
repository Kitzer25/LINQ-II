namespace LAB08_MauricioCalderón.DTO_s.Operations.Read;

public class DetallesOrdenIncludeReadDTO
{
    public int OrderId { get; set; }
    public DateTime OrderDate { get; set; }
    public List<DetallesOrdenProductoReadDTO> Products { get; set; }
}