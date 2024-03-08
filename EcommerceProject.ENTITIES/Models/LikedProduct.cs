using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.ENTITIES.Models
{
	public class LikedProduct : BaseEntity
	{
		public int ProductID { get; set; }
		public int AppUserID { get; set; }

		//Relational Properties
		public virtual Product Product { get; set; }
		public virtual AppUser AppUser { get; set; }
	}
}
