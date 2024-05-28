namespace Data.Models;

  public class Licence
  {
      public int Id { get; set; }
      public string Name { get; set; } = string.Empty;
      public string Description { get; set; } = string.Empty;
      public string ShortDescription { get; set; } = string.Empty;
      public List<Product>? Products { get; set; }
  }
