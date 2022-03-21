using AppCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.DAL.Entities
{
    public class SubCategory: Audit , IEntity, ISoftDeleted
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; } 
        public int CategoryId { get; set; } // ID BELİRLEDİM
        public Category CategoryFK{ get; set; } //FK YA ATADIM
        public bool IsDeleted { get ; set ; }
    }
}
