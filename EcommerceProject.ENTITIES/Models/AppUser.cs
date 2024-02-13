using EcommerceProject.ENTITIES.Enums;
using EcommerceProject.ENTITIES.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.ENTITIES.Models
{
    public class AppUser : IdentityUser<int>, IEntity
    {
        public AppUser()
        {
            CreatedDate = DateTime.Now;
            Status = DataStatus.Inserted;
        }
        public int ID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public DataStatus Status { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
		public string CreatedBy { get; set; }
		public string? ModifiedBy { get; set; }
		public string? DeletedBy { get; set; }

        //Relational Properties
        public virtual List<Order> Orders { get; set; }
	}
}
