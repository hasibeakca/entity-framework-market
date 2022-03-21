using AppCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.DAL.Dto.Product
{
   public class AddProductDto : IDto
    {
       // ID KENDISI ATADIGI ICIN BEN ATAMADIM
        public string  Name { get; set; }
        public int Price { get; set; }
        public int SubCategoryId { get; set; }
    }
}
