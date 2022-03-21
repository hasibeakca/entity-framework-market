using AppCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.DAL.Dto.Product
{
   public class GetListProductDto : IDto
    { // EKLERKEN YANI ADD DE ID YI KENDISI ATIYOR AMA GETIR DEDIGIMIZDE ID ITSTERIS KI ID SI ILE BIRLIKTE GELSİN
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int SubCategoryId { get; set; }
        public string SubCategoryName { get; set; }
    }
}
