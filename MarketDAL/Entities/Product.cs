using AppCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.DAL.Entities
{
    public class Product : Audit , IEntity, ISoftDeleted
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public  int Price { get; set; }
        public bool IsDeleted { get; set; }
        public int SubCategoryId { get; set; }
        public SubCategory SubCategoryFK { get; set; }
    }
}
