using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjetoAppLivraria.Models
{
    public class Autor
    {
        [Display(Name = "Código")]
        public int idautor { get; set; }

        [Display(Name = "Autor")]
        public string nameautor { get; set; }

        [Display(Name = "Status")]
        public String status { get;set; }
    }
}
