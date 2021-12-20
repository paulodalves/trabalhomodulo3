using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgenciaViagemDC.Models
{
    public class Viaja
    {
                
        public int Id { get; set; }
        public string CidadeDestino { get; set; }
        public string NomeCliente { get; set; }

        // Formata  DateTime para se encaixar no tipo date do banco sem hora
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataViagem { get; set; }
        [DataType(DataType.Currency)] // Coloca o R$
        public decimal PrecoPassagem { get; set; }
        public int QtdPassagem { get; set; }
        [DataType(DataType.Currency)]
        public decimal ValorTotal { get; set; }

        // Regra de negócio     
        public decimal calcula(decimal valor, int qtd)
        {
            if (qtd == 1) 
            {
                return valor * qtd;
            }
            else if (qtd == 2)
            {
                return (valor * qtd) - ((valor * qtd) * 0.1m);

            } 
            else if ( qtd == 3)
            {
                return (valor * qtd) - ((valor * qtd) * 0.2m);
            }

            return (valor * qtd) - ((valor * qtd) * 0.3m);

        }
    }
}
