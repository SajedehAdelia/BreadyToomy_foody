using System;
namespace BreadyToomy_Foody.Models
{
	public class Product
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public ProductType Type { get; set; }
		public decimal Price { get; set; }

		public Product(int id, string name, ProductType type, decimal price)
		{
			Id = id;
			Name = name;
			Type = type;
			Price = price;
		}

		public decimal calculeTotalPrice(int quantity)
		{
			return quantity * Price;
		}
	}

	public enum ProductType
	{
		Food,
		Drinks,
		Snacks

	}
}

