namespace Data.Entity;
public class ProductOption {
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public uint Price { get; set; }
    public bool IsChecked { get; set; }
}
