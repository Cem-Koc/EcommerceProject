using EcommerceProject.ENTITIES.Enums;
using EcommerceProject.ENTITIES.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.ENTITIES.Models
{
    public abstract class BaseEntity : IEntity
    {
        public BaseEntity()
        {
            CreatedDate = DateTime.Now;
            Status = DataStatus.Inserted;
        }
        public int ID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
		public string CreatedBy { get; set; } = "Undefined";
		public string? ModifiedBy { get; set; }
		public string? DeletedBy { get; set; }
		public DataStatus Status { get; set; }
    }
}
