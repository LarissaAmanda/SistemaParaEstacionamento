using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace SistemaEstacionamento1.Models
{
    public class Veiculo
    {
        public string Placa { get; set; }
        public string TipoDoVeiculo {get; set;}
        public Veiculo(string placa, string tipoDoVeiculo){

            Placa = placa;
            TipoDoVeiculo = tipoDoVeiculo;
        
        }
  
    }
}