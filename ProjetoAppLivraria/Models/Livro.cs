using System.ComponentModel.DataAnnotations;

namespace ProjetoAppLivraria.Models
{
    public class Livro
    {

        [Display(Name = "Código")]
        public int idlivro { get; set; }

        [Display(Name = "Livro")]
        public string namelivro { get; set; }
        public Autor refautor { get; set; }

        [Display(Name = "Autor")]
        public List<Autor> idautor { get; set; }
    }
}
