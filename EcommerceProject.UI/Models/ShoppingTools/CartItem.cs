using Newtonsoft.Json;

namespace EcommerceProject.UI.Models.ShoppingTools
{
	[Serializable]
	public class CartItem
	{
		public CartItem()
		{
			Amount++;
		}
		[JsonProperty("ID")]
		public int ID { get; set; }

		[JsonProperty("Name")]
		public string Name { get; set; }

		[JsonProperty("Amount")]
		public int Amount { get; set; }

		[JsonProperty("Price")]
		public decimal Price { get; set; }

		[JsonProperty("ImageFileName")]
		public string ImageFileName { get; set; }

		[JsonProperty("ProductSize")]
		public string ProductSize { get; set; }

		[JsonProperty("ProductColor")]
		public string ProductColor { get; set; }

		[JsonProperty("SubTotal")]
		public decimal SubTotal
		{
			get
			{
				return Amount * Price;
			}
		}
	}
}
