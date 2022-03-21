using AppCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.DAL.Dto.Category
{
    public class UpdateCategoryDto : IDto
    {
        // KATEGORIDE BISEY DEGISTIRECEKSEM ONUN ALT KATEGORISI DE DEĞİŞİR BU YUZDEN ONUDA ISTEDIM SINIRLANDIRMA YAPILDIGINDA SADECE UPDATE DE ALT KATEGORISININ ID SI ISTENIR
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
