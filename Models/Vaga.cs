using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaEstacionamento1.Models
{   

  
    public class Vaga
    {
        public string NomeVaga { get; set; }
     
        public Veiculo VeiculoEstacionado { get; set; }

        public DateTime HoraEntrada {get; set;}

        public int TipoDaVaga { get; set; }
    
        public bool Disponivel { get; set; }

        public Vaga(string nomeVaga, Veiculo veiculo, int tipoVaga){

            NomeVaga = nomeVaga;
            VeiculoEstacionado = veiculo;
            TipoDaVaga = tipoVaga;
            Disponivel = true;
        
        }

      

    }
}