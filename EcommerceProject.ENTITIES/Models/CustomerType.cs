﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.ENTITIES.Models
{
    public class CustomerType : BaseEntity
    {
        public CustomerType()
        {
            
        }
        public CustomerType(string name, string createdBy)
        {
            CustomerTypeName = name;
            CreatedBy = createdBy;
        }
        public string CustomerTypeName { get; set; }

        //Relational Properties
        public virtual List<Product> Products { get; set; }
    }
}
