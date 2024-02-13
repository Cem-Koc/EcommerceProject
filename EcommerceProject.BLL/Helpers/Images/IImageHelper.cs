using EcommerceProject.ENTITIES.Dtos.Images;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.BLL.Helpers.Images
{
	public interface IImageHelper
	{
		Task<ImageUploadedDto> Upload(string name, IFormFile imageFile, string folderName = null);
		void Delete(string imageName);
	}
}
