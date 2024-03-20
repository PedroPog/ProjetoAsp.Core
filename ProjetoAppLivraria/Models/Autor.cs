using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjetoAppLivraria.Models
{
    public class Autor
    {
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Display(Name = "Autor")]
        public string nomeAutor { get; set; }

        [Display(Name = "Status")]
        public string status { get;set; }
    }
}
