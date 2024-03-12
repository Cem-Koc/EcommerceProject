using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.ENTITIES.Dtos.Products
{
    public class NewArrivalsListResponseDto
    {
        public List<NewArrivalsDto> NewArrivalsAll { get; set; }
        public List<NewArrivalsDto> NewArrivalsWomen { get; set; }
        public List<NewArrivalsDto> NewArrivalsMen { get; set; }
    }
}
