namespace EcommerceProject.UI.ResultMessages
{
	public static class Messages
	{
		public static class Product
		{
			public static string Add(string productName)
			{
				return $"{productName} isimli ürün başarıyla eklenmiştir.";
			}

			public static string Update(string productName)
			{
				return $"{productName} isimli ürün başarıyla güncellenmiştir.";
			}

			public static string Delete(string productName)
			{
				return $"{productName} isimli ürün başarıyla silinmiştir.";
			}
		}
	}
}
