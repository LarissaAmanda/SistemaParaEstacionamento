# Sistema Para Estacionamento
Este é um programa simples de administração de estacionamento, escrito em C#. O programa permite a configuração do estacionamento com diferentes tipos de vagas e preços, além de oferecer funcionalidades como adicionar veículos, remover veículos, listar veículos estacionados e listar vagas disponíveis.

## Configuração Inicial

Ao iniciar o programa, você será solicitado a inserir a quantidade de vagas para diferentes tipos de vagas, o preço inicial e o preço por hora de estacionamento.

## Menu Principal

Após a configuração inicial, o programa entra em um loop, exibindo as seguintes opções:

1 - Adicionar veículo: Permite registrar a entrada de um veículo no estacionamento, solicitando a placa, tipo de veículo e tipo de vaga.

2 - Remover veículo: Permite remover um veículo do estacionamento, solicitando a placa do veículo a ser removido.

3 - Listar veículos: Apresenta uma lista dos veículos estacionados, indicando o tipo de veículo, placa, vaga e tempo de permanência.

4 - Listar Vagas: Exibe a disponibilidade de todas as vagas no estacionamento.

5 - Encerrar programa: Finaliza a execução do programa.

## Classes
### Estacionamento
A classe principal que gerencia as operações do estacionamento, como adicionar, remover e listar veículos. Configura as vagas e calcula o preço a ser pago pelos clientes.

### Vaga
Representa uma vaga no estacionamento, contendo informações como nome da vaga, tipo de vaga, estado de disponibilidade, veículo estacionado e hora de entrada.

### Veículo
Representa um veículo, contendo informações como placa e tipo de veículo (carro ou moto).

## Instruções de Uso
1. Ao iniciar o programa, forneça as informações solicitadas para configurar o estacionamento.

2. Utilize o menu principal para executar diferentes operações no estacionamento.

3. Certifique-se de digitar informações válidas quando solicitado para evitar erros.

4. Encerre o programa escolhendo a opção "Encerrar programa" no menu principal.

## Observações: 
1 - Certifique-se de fornecer informações válidas durante a execução do programa para evitar erros.
2 - Caso ocorram erros durante a execução, mensagens informativas serão exibidas para orientar o usuário.
Este é um programa básico e pode ser expandido conforme necessário para atender a requisitos adicionais.

Desenvolvido por Larissa Amanda Tomaz
em janeiro de 2024
