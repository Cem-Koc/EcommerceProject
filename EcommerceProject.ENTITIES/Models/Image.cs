using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.ENTITIES.Models
{
    public class Image : BaseEntity
    {
        public Image(string fileName, string fileType)
        {
            FileName = fileName;
            FileType = fileType;
        }

        public string FileName { get; set; }
        public string FileType { get; set; }
        public int SortImage { get; set; }
        public int ProductID { get; set; }

        //Relational Properties
        public virtual Product Product { get; set; }
    }
}
