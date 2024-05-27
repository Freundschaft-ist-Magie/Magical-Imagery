using Data.Entity;

namespace Data.Models;

public class Product {
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Image { get; set; }
    public string? Description { get; set; }
    public string[]? Tags { get; set; }
    public uint Price { get; set; }
    public string? Category { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public string Pixel => $"{Width}X{Height}";
    public int LicenceId { get; set; }
    public Licence? Licence { get; set; }
    public List<Comment>? Comments { get; set; }

    public List<ProductOption> Options = [
        new ProductOption() { Id = 1, Name = "Veränderungsgarantie", Price = 25, IsChecked = false },
        new ProductOption() { Id = 2, Name = "Volles Urheberrecht", Price = 25, IsChecked = false },
    ];
}
