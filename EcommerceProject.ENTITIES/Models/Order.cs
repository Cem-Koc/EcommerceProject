﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.ENTITIES.Models
{
    public class Order:BaseEntity
    {
        public string ShippingAddress { get; set; }
        public int? AppUserID { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string PostCode { get; set; }
		public string PhoneNumber { get; set; }
		public string EmailAddress { get; set; }

		//Relational Properties
		public virtual AppUser AppUser { get; set; }
        public virtual List<OrderDetail> OrderDetails { get; set; }
    }
}
