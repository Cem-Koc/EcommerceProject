﻿using EcommerceProject.ENTITIES.Dtos.Images;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.BLL.Helpers.Images
{
	public class ImageHelper : IImageHelper
	{
		private readonly IWebHostEnvironment _env;
		private readonly string _wwwroot;
		private const string _imgFolder = "images";
		private const string _productImageFolder = "product-images";

		public ImageHelper(IWebHostEnvironment env)
        {
			_env = env;
			_wwwroot = env.WebRootPath;
		}

		private string ReplaceInvalidChars(string fileName)
		{
			return fileName.Replace("İ", "I")
				 .Replace("ı", "i")
				 .Replace("Ğ", "G")
				 .Replace("ğ", "g")
				 .Replace("Ü", "U")
				 .Replace("ü", "u")
				 .Replace("ş", "s")
				 .Replace("Ş", "S")
				 .Replace("Ö", "O")
				 .Replace("ö", "o")
				 .Replace("Ç", "C")
				 .Replace("ç", "c")
				 .Replace("é", "")
				 .Replace("!", "")
				 .Replace("'", "")
				 .Replace("^", "")
				 .Replace("+", "")
				 .Replace("%", "")
				 .Replace("/", "")
				 .Replace("(", "")
				 .Replace(")", "")
				 .Replace("=", "")
				 .Replace("?", "")
				 .Replace("_", "")
				 .Replace("*", "")
				 .Replace("æ", "")
				 .Replace("ß", "")
				 .Replace("@", "")
				 .Replace("€", "")
				 .Replace("<", "")
				 .Replace(">", "")
				 .Replace("#", "")
				 .Replace("$", "")
				 .Replace("½", "")
				 .Replace("{", "")
				 .Replace("[", "")
				 .Replace("]", "")
				 .Replace("}", "")
				 .Replace(@"\", "")
				 .Replace("|", "")
				 .Replace("~", "")
				 .Replace("¨", "")
				 .Replace(",", "")
				 .Replace(";", "")
				 .Replace("`", "")
				 .Replace(".", "")
				 .Replace(":", "")
				 .Replace(" ", "");
		}
       
		public async Task<ImageUploadedDto> Upload(string name, IFormFile imageFile, string folderName = null)
		{
            if (folderName == null)
            {
				folderName = _productImageFolder;
            }
			if (!Directory.Exists($"{_wwwroot}/{_imgFolder}/{folderName}"))
				Directory.CreateDirectory($"{_wwwroot}/{_imgFolder}/{folderName}");

			string oldFileName = Path.GetFileNameWithoutExtension(imageFile.FileName);
			string fileExtension = Path.GetExtension(imageFile.FileName);

			name = ReplaceInvalidChars(name);

			DateTime dateTime = DateTime.Now;

			string newFileName = $"{name}_{dateTime.Millisecond}{fileExtension}";

			var path = Path.Combine($"{_wwwroot}/{_imgFolder}/{folderName}", newFileName);

			await using var stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None, 1024 * 1024,useAsync:false);
			await imageFile.CopyToAsync(stream);
			await stream.FlushAsync();

			string message = $"{newFileName} isimli resim eklenmiştir.";

			return new ImageUploadedDto()
			{
				FullName = $"{folderName}/{newFileName}"
			};
        }
		public void Delete(string imageName)
		{
			var fileToDelete = Path.Combine($"{_wwwroot}/{_imgFolder}/{imageName}");
            if (File.Exists(fileToDelete))
				File.Delete(fileToDelete);
        }
	}
}