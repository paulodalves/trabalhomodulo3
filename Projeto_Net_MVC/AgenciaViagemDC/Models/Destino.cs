using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgenciaViagemDC.Models
{
    public class Destino
    {
        public int Id { get; set; }
        public string UF { get; set; }
        public string Cidade { get; set; }
        [DataType(DataType.Currency)] // Coloca o R$
        public decimal Preco { get; set; }
    }
}
