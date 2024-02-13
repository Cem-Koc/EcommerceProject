using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.ENTITIES.Models
{
	public class ImageDetail:BaseEntity
	{
		public int ProductID { get; set; }
		public int ImageID { get; set; }
		public int SortImage { get; set; }

		//Relational Properties
		public virtual Product Product { get; set; }
		public virtual Image Image { get; set; }
	}
}
