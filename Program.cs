using System.Collections;
using System.Diagnostics;
using System.Linq.Expressions;
using SistemaEstacionamento1.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;

        try {
        Console.WriteLine("Adiministração do estacionamento:");
        Console.WriteLine("Digite a quantidade de vagas Comuns");
        int vagaComumQuantidade = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Digite a quantidade de vagas para Idosos");
        int vagaIdosoQuantidade = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Digite a quantidade de vagas para Pessoas com deficiência");
        int vagaPCDQuantidade = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Digite a quantidade de vagas para Carros Elétricos");
        int vagaCarroEletricoQuantidade = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Digite a quantidade de vagas para motos");
        int vagaMotoQuatidade = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Qual o preço fixo?");
        decimal precoInical = Convert.ToDecimal(Console.ReadLine());
        Console.WriteLine("Qual o preço por hora?");
        decimal precoPorHora = Convert.ToDecimal(Console.ReadLine());

        Estacionamento estacionamento1 =
        new Estacionamento(precoInical, precoPorHora, vagaComumQuantidade, 
        vagaIdosoQuantidade, vagaPCDQuantidade, vagaCarroEletricoQuantidade, vagaMotoQuatidade);

        estacionamento1.CriarVagas();

        bool exibirMenuPrincipal = true;
   
        while(exibirMenuPrincipal) {
                Console.Clear();
                Console.WriteLine(" 1 - Adicionar veículo");
                Console.WriteLine(" 2 - Remover veículo");
                Console.WriteLine(" 3 - Listar veículos");
                Console.WriteLine(" 4 - Listar Vagas");
                Console.WriteLine(" 5 - Encerrar programa");
        
            try {
            switch(Console.ReadLine()){

                case "1": 
                estacionamento1.AdicionarVeiculo();
                break;
                case "2": 
                estacionamento1.RemoverVeiculo();
                break;
                case "3": 
                estacionamento1.ListarVeiculos();
                break;
                case "4":
                estacionamento1.ListarVagas();
                break;
                case "5": exibirMenuPrincipal = false;
                break;

                default:
                    Console.WriteLine("Opção inválida");
                    break;
            }
            } catch (Exception ex)
            {
                Console.WriteLine($" Digite uma opção válida. Ocorreu um erro: {ex.Message}");
            }

            Console.WriteLine("Pressione uma tecla para continuar");
            Console.ReadKey();

        }
          Console.WriteLine("O programa se encerrou");

        } catch (Exception ex)
        {
        Console.WriteLine($"Digite uma quantidade válida. Ocorreu um erro durante a inicialização: {ex.Message}");
        }
    } 
}