﻿namespace EcommerceProject.UI.ResultMessages
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
            public static string UndoDelete(string productName)
            {
                return $"{productName} isimli ürün başarıyla aktif edilmiştir.";
            }
        }
		public static class Category
		{
			public static string Add(string categoryName)
			{
				return $"{categoryName} isimli kategori başarıyla eklenmiştir.";
			}
			public static string AddError(string categoryName)
			{
				return $"{categoryName} isimli kategori sistemde bulunmaktadır.";
			}

			public static string Update(string categoryName)
			{
				return $"{categoryName} isimli kategori başarıyla güncellenmiştir.";
			}
			public static string UpdateError(string categoryName)
			{
				return $"{categoryName} isimli kategori sistemde bulunmaktadır.";
			}
			public static string Delete(string categoryName)
			{
				return $"{categoryName} isimli kategori başarıyla silinmiştir.";
			}
		}

        public static class CustomerType
        {
            public static string Add(string customerTypeName)
            {
                return $"{customerTypeName} isimli müşteri tipi başarıyla eklenmiştir.";
            }
            public static string AddError(string customerTypeName)
            {
                return $"{customerTypeName} isimli müşteri tipi sistemde bulunmaktadır.";
            }
            public static string Update(string customerTypeName)
            {
                return $"{customerTypeName} isimli müşteri tipi başarıyla güncellenmiştir.";
            }
            public static string UpdateError(string customerTypeName)
            {
                return $"{customerTypeName} isimli müşteri tipi sistemde bulunmaktadır.";
            }
            public static string Delete(string customerTypeName)
            {
                return $"{customerTypeName} isimli müşteri tipi başarıyla silinmiştir.";
            }
        }
		public static class ProductColor
		{
			public static string Add(string productColor)
			{
				return $"{productColor} isimli ürün rengi başarıyla eklenmiştir.";
			}
			public static string AddError(string productColor)
			{
				return $"{productColor} isimli ürün rengi sistemde bulunmaktadır.";
			}
			public static string Update(string productColor)
			{
				return $"{productColor} isimli ürün rengi başarıyla güncellenmiştir.";
			}
			public static string UpdateError(string productColor)
			{
				return $"{productColor} isimli ürün rengi sistemde bulunmaktadır.";
			}
			public static string Delete(string productColor)
			{
				return $"{productColor} isimli ürün rengi başarıyla silinmiştir.";
			}
		}
		public static class ProductSize
		{
			public static string Add(string productSize)
			{
				return $"{productSize} isimli ürün bedeni başarıyla eklenmiştir.";
			}
			public static string AddError(string productSize)
			{
				return $"{productSize} isimli ürün bedeni sistemde bulunmaktadır.";
			}
			public static string Update(string productSize)
			{
				return $"{productSize} isimli ürün bedeni başarıyla güncellenmiştir.";
			}
			public static string UpdateError(string productSize)
			{
				return $"{productSize} isimli ürün bedeni sistemde bulunmaktadır.";
			}
			public static string Delete(string productSize)
			{
				return $"{productSize} isimli ürün bedeni başarıyla silinmiştir.";
			}
		}
		public static class User
		{
			public static string Add(string userName)
			{
				return $"{userName} email adresli kullanıcı başarıyla eklenmiştir.";
			}
			public static string AddError(string userName)
			{
				return $"{userName} email adresli kullanıcı sistemde bulunmaktadır.";
			}
			public static string Update(string userName)
			{
				return $"{userName} email adresli kullanıcı başarıyla güncellenmiştir.";
			}
			public static string UpdateError(string userName)
			{
				return $"{userName} email adresli kullanıcı sistemde bulunmaktadır.";
			}
			public static string Delete(string userName)
			{
				return $"{userName} email adresli kullanıcı başarıyla silinmiştir.";
			}
            public static string Register(string userName)
            {
                return $"{userName} email adresi ile sisteme kayıt işlemi tamamlanmıştır.";
            }
            public static string RegisterError(string userName)
            {
                return $"{userName} email adresi ile kayıt işleminde bir hata oluşturmuş.";
            }
        }
	}
}
