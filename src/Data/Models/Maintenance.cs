namespace Data.Models;
public class Maintenance
{
    public int Id { get; set; }
    public string Message { get; set; }
    public string Reason { get; set; }
    public DateTime[] Schedules { get; set; } = new DateTime[2];
}
