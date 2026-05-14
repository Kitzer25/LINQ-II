namespace LAB08_MauricioCalderón.DTO_s.Operations.Read;

public class ClientOrderReadDTO
{
    public string ClientName { get; set; }
    public List<OrderClientReadDTO> ClientOrders { get; set; }
}