namespace LAB08_MauricioCalderón.DTO_s.Operations.Read;

public class OrdenReadDTO
{
    public int OrderId { get; set; }
    public int ClientId { get; set; }
    public DateTime OrderDate { get; set; }

    public ClienteReadDTO? Client { get; set; }

    public ICollection<DetalleOrdenReadDTO> OrderDetails { get; set; } = new List<DetalleOrdenReadDTO>();
}