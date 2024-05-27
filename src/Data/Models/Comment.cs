namespace Data.Models;
public class Comment {
  public int Id { get; set; }
  public string Author { get; set; }
  public string Content { get; set; }
  public string? ProfileImage { get; set; }
  public int ProductId { get; set; }
  public Product? Product { get; set; }
}
