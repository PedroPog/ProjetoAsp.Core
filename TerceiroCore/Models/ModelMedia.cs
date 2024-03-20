using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TerceiroCore.Models
{
    public class ModelMedia
    {
        [DisplayName("Venda Janeiro")]
        public String Jan { get; set; }
        [DisplayName("Venda Fervereiro")]
        public String Fer { get; set; }
        [DisplayName("Venda Março")]
        public String Mar { get; set; }
        [DisplayName("Venda Abrir")]
        public String Abr { get; set; }
    }
}
