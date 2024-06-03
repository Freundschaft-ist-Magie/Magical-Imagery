using Data.Models;

namespace Web.Services;

  public class ShoppingCartService
  {
      private List<Product> products = new();
      public ShoppingCartService() { }
      public List<Product> Products => products;
      public int Total => products.Sum(x => 1);

      public void AddProductToCart(Product product)
      {
          if (products.Contains(product)) return;
          products.Add(product);
      }

      public void RemoveProduct(Product product)
      {
          products.Remove(product);
      }

      public void Clear()
      {
          products.Clear();
      }
  }
