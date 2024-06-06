using Data.Models;

namespace Web.Services;

public class ShoppingCartService {
  private readonly List<Product> products = [];
  public ShoppingCartService() { }
  public List<Product> Products => products;
  public decimal Total => products.Sum(p => p.Price);

  public void AddProductToCart(Product product) {
    if (products.Contains(product))
      return;

    products.Add(product);
  }

	public void RemoveProduct(Product product)
	{
		var productToRemove = products.Where(p => p.Id == product.Id).FirstOrDefault();
		if (productToRemove == null)
			return;

		products.Remove(productToRemove);
	}

	public void Clear() {
    products.Clear();
  }
}
