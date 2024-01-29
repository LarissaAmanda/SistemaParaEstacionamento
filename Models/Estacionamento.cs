using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace SistemaEstacionamento1.Models
{
    public class Estacionamento
    {
        private decimal PrecoInicial { get; set; }
        private decimal PrecoPorHora { get; set; }

        private int VagaComum { get; set; }

        private int VagaIdoso { get; set; }

        private int VagaPCD { get; set; }

        private int VagaCarroEletrico { get; set; }

        private int VagaMoto { get; set; }

        List<Vaga> vagasEstacionamento = new List<Vaga>();

        public Estacionamento(decimal precoInical, decimal precoPorHora, int vagaComum, int vagaIdoso, int vagaPCD, int vagaCarroEletrico, int vagaMoto )
        {

            PrecoInicial = precoInical;
            PrecoPorHora = precoPorHora;
            VagaComum = vagaComum;
            VagaIdoso = vagaIdoso;
            VagaPCD = vagaPCD;
            VagaCarroEletrico = vagaCarroEletrico;
            VagaMoto = vagaMoto;
            
        }
        public void CriarVagas()
        {   //Cria as vagas de acordo com a quantidade especificada na propriedade do estacionamento. 
            for( int i = 1; i <= VagaComum; i++ )
            {
                 vagasEstacionamento.Add(new Vaga($"A{i}", null, 1)); // Vaga Comum
            }
            for( int i = 1; i <= VagaIdoso; i++ )
            {
                 vagasEstacionamento.Add(new Vaga($"B{i}", null, 2)); // Vaga Idoso
            }
            for( int i = 1; i <= VagaPCD; i++ )
            {
                 vagasEstacionamento.Add(new Vaga($"C{i}", null, 3)); // Vaga PCD
            }
            for( int i = 1; i <= VagaCarroEletrico; i++ )
            {
                 vagasEstacionamento.Add(new Vaga($"D{i}", null, 4)); // Vaga Carro Elétrico
            }
            for( int i = 1; i <= VagaMoto; i++)
            {
                vagasEstacionamento.Add(new Vaga($"E{i}", null, 5)); // Vaga Moto
            }
        }
        public void ListarVagas()
        {
            int contador = 0;
            foreach (Vaga vaga in vagasEstacionamento)
            {   //Verifica se a vaga está disponivel ou ocupada e apresenta esse resultado 
                string status = vaga.Disponivel ? "Disponível" : "Ocupado";
                Console.WriteLine($"{contador + 1} - {vaga.NomeVaga} - {status}");
                contador++;
            }
           
        }
        public void AdicionarVeiculo()
        {
            
            Console.WriteLine("Digite a placa do veículo");
            string placaDoVeiculo = Console.ReadLine();

            string placaVeiculo = placaDoVeiculo.ToUpper();

            if(vagasEstacionamento.Any(vaga => vaga.VeiculoEstacionado != null && vaga.VeiculoEstacionado.Placa == placaVeiculo))
            {
                Console.WriteLine("Esse carro já foi registrado no estacionamento");
            }
            else 
            {
                try 
                {
                    bool validacaoPlaca = ValidarPlaca(placaVeiculo);

                    if(validacaoPlaca)
                    {
                        try
                        {
                        Console.WriteLine("Digite o Tipo de veículo");
                        Console.WriteLine(" 1 - Carro\n 2 - Moto");
                        string tipoDeVeiculoEntrada = Console.ReadLine();

                        if(tipoDeVeiculoEntrada == "1")
                        {
                        tipoDeVeiculoEntrada = "Carro";
                        
                        try {

                        Console.WriteLine("Qual o tipo da vaga:");
                        Console.WriteLine(" 1 - Comum\n 2 - Idoso\n 3 - Pessoa com deficiência\n 4 - Carro Elétrico");
                        int tipoDeVaga = Convert.ToInt32(Console.ReadLine());

                        DateTime horaEntradaDoVeiculo = DateTime.Now;
                        
                            Vaga vagaDisponivel = vagasEstacionamento.Find(vaga => vaga.TipoDaVaga == tipoDeVaga 
                            && vaga.Disponivel );
                            
                            if(vagaDisponivel != null)
                            {
                                Veiculo novoVeiculo = new Veiculo(placaVeiculo, tipoDeVeiculoEntrada);
                                vagaDisponivel.VeiculoEstacionado = novoVeiculo;
                                vagaDisponivel.HoraEntrada = horaEntradaDoVeiculo;
                                vagaDisponivel.Disponivel = false;

                                Console.WriteLine($"Data e hora de entrada: {vagaDisponivel.HoraEntrada}");
                                Console.WriteLine($"Tipo de veículo: {novoVeiculo.TipoDoVeiculo}");
                                Console.WriteLine($"Placa: {novoVeiculo.Placa}");
                                Console.WriteLine($"Vaga: {vagaDisponivel.NomeVaga}");
                            }
                            else
                            {
                                Console.WriteLine($"Não há vagas disponíveis para o tipo {tipoDeVaga} ");
                            }

                        } catch (ArgumentOutOfRangeException ex)
                        {
                            Console.WriteLine($"Digite uma opção válida. Erro ao validar tipo de vaga: {ex.Message}");
                        }
                       
                        } if (tipoDeVeiculoEntrada == "2") 
                        {   
                            tipoDeVeiculoEntrada = "Moto";
                            int tipoDeVagaParaOVeiculo = 5; //moto 

                            DateTime horaDeEntradaDaMoto = DateTime.Now;

                            Vaga vagaDisponivelMoto = vagasEstacionamento.Find(vaga => vaga.TipoDaVaga ==  tipoDeVagaParaOVeiculo
                            && vaga.Disponivel );
                            
                            if(vagaDisponivelMoto != null)
                            {

                                Veiculo novoVeiculoMoto = new Veiculo(placaVeiculo, tipoDeVeiculoEntrada);
                                vagaDisponivelMoto.VeiculoEstacionado = novoVeiculoMoto;
                                vagaDisponivelMoto.HoraEntrada = horaDeEntradaDaMoto;
                                vagaDisponivelMoto.Disponivel = false;

                                Console.WriteLine($"Data e hora de entrada: {vagaDisponivelMoto.HoraEntrada}");
                                Console.WriteLine($"Tipo de veículo: {novoVeiculoMoto.TipoDoVeiculo}");
                                Console.WriteLine($"Placa: {novoVeiculoMoto.Placa}");
                                Console.WriteLine($"Vaga: {vagaDisponivelMoto.NomeVaga}");
                            }
                            else
                            {
                                Console.WriteLine($"Não há vagas disponíveis para o tipo");
                            }
                        }
                        
                        } 
                        catch (ArgumentOutOfRangeException ex)
                        {
                            Console.WriteLine($"Digite uma opção válida. Erro ao validar placa: {ex.Message}");
                        }
                    
                    } else {
                        Console.WriteLine("Digite um modelo válido de placa");
                    }
            
                } 
                catch (ArgumentOutOfRangeException ex)
                {
                Console.WriteLine($"A placa mencionada não é válida. Erro ao validar placa: {ex.Message}");
                } 
                catch (FormatException ex)
                {
                // Se a conversão falhar devido a uma string vazia ou não numérica
                Console.WriteLine($"Entrada inválida. Certifique-se de inserir um valor numérico.{ex.Message}");
                }
            }
        }
        public void ListarVeiculos()
        {
            Console.WriteLine("Os carros estacionados são:");
        
            DateTime horaAtual = DateTime.Now;
            int Contador = 0;
        
            foreach (Vaga vaga in vagasEstacionamento)
            {   //Verifica se há carro estacionado na vaga
                if (vaga.VeiculoEstacionado != null)
                {   //Calcula quanto tempo o carro está na vaga e apresenta a placa, vaga e tempo que o carro está ocupando a vaga
                    TimeSpan tempoEstacionado = horaAtual - vaga.HoraEntrada;
                    Console.WriteLine($"{Contador +1} - Veículo do tipo: {vaga.VeiculoEstacionado.TipoDoVeiculo}, de placa: {vaga.VeiculoEstacionado.Placa}, está na vaga: {vaga.NomeVaga} do tipo {vaga.TipoDaVaga}. Estacionado há {tempoEstacionado.Hours} horas");
                }
                else
                {   //Caso não haja carro na vaga, é apresentado o nome da vaga e a mensagem que está disponivel
                    Console.WriteLine($"{Contador +1} - Vaga {vaga.NomeVaga} está disponível.");
                }
                Contador ++;
            }
        }
       
        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do carro que deseja remover?");
            string placaRemover = Console.ReadLine();

            string placaRemoverAtual = placaRemover.ToUpper();

            if(!String.IsNullOrEmpty(placaRemover)){
            // Encontrar a vaga associada à placa
            Vaga vaga = vagasEstacionamento.Find(vaga => vaga.VeiculoEstacionado != null && vaga.VeiculoEstacionado.Placa == placaRemoverAtual);
            
            if (vaga != null)
            {
                DateTime horaSaida = DateTime.Now;
                //Calcula o tempo de permanencia do veículo na vaga
                TimeSpan tempoPermanencia = horaSaida - vaga.HoraEntrada;
                
                vaga.VeiculoEstacionado = null;
                vaga.Disponivel = true;
                decimal valorASerPago = CalcularPreco(tempoPermanencia);

                Console.WriteLine($"O veículo foi removido. Tempo de permanência: {tempoPermanencia.Hours} horas. O valor a ser pago é de R${valorASerPago}");
            }
            else
            {
            Console.WriteLine("Placa não encontrada no sistema.");
            }

            }
            
        }
        private decimal CalcularPreco(TimeSpan tempoPermanencia)
        {   //Converte o tipo timespan para decimal 
            decimal tempoDecimal = (decimal)tempoPermanencia.Hours;
            //Calcula o valor total a ser pago
            decimal valorTotal = tempoDecimal * PrecoPorHora + PrecoInicial;
            //Arredonda o valor e apresenta duas casas decimais.
            return Math.Round(valorTotal, 2);
        }
       
        
        private bool ValidarPlaca(string placa)
        {
            if (string.IsNullOrWhiteSpace(placa)) { return false; }
          
            if (placa.Length > 8) { return false; }

            placa = placa.Replace("-", "").Trim();

            /*
              Verifica se o caractere da posição 4 é uma letra, se sim, aplica a validação para o formato de placa do Mercosul,
              senão, aplica a validação do formato de placa padrão.
             */
            if (char.IsLetter(placa, 4))
            {
                //Verifica se a placa está no formato: três letras, um número, uma letra e dois números.
                 
                var padraoMercosul = new Regex("[a-zA-Z]{3}[0-9]{1}[a-zA-Z]{1}[0-9]{2}");
                return padraoMercosul.IsMatch(placa);
            }
            else
            {
                // Verifica se os 3 primeiros caracteres são letras e se os 4 últimos são números.
                var padraoNormal = new Regex("[a-zA-Z]{3}[0-9]{4}");
                return padraoNormal.IsMatch(placa);
            }
        }
    }
}
