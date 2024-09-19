using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SistemaGerenciamentoContasBancarias
{
    class Program
    {
        static List<Cliente> clientes = new List<Cliente>();
        static List<ContaCorrente> contasCorrente = new List<ContaCorrente>();
        static List<ContaPoupanca> contasPoupanca = new List<ContaPoupanca>();
        static string caminhoClientes = "clientes.json";
        static string caminhoContasCorrente = "contasCorrente.json";
        static string caminhoContasPoupanca = "contasPoupanca.json";

        static void Main(string[] args)
        {
            CarregarDados();
            MenuPrincipal();
        }

        static void MenuPrincipal()
        {
            int opcao;
            string autor = "Autor: Natan";
            string dataAtual = DateTime.Now.ToString("dd/MM/yyyy HH:mm");

            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Magenta; // Cor roxa
                Console.WriteLine("╔═══════════════════════════════════════════════════════╗");
                Console.WriteLine("║                 BEM-VINDO AO BANCO XYZ                ║");
                Console.WriteLine("╚═══════════════════════════════════════════════════════╝");
                Console.ForegroundColor = ConsoleColor.White; // Cor branca
                Console.WriteLine($"║ {autor}                                          ║");
                Console.WriteLine($"║ Data/Horário de Entrada: {dataAtual}             ║");
                Console.WriteLine("║ [1] Gerenciar Clientes                                ║");
                Console.WriteLine("║ [2] Gerenciar Contas Corrente                         ║");
                Console.WriteLine("║ [3] Gerenciar Contas Poupança                         ║");
                Console.WriteLine("║ [4] Relatório                                         ║"); // Adicionando opção de relatório
                Console.WriteLine("║ [0] Sair                                              ║");
                Console.ForegroundColor = ConsoleColor.Magenta; // Cor roxa
                Console.WriteLine("╚═══════════════════════════════════════════════════════╝");
                Console.ForegroundColor = ConsoleColor.White; // Cor branca
                Console.Write("Escolha uma opção: ");

                if (int.TryParse(Console.ReadLine(), out opcao) && (opcao >= 0 && opcao <= 4))
                {
                    switch (opcao)
                    {
                        case 1:
                            MenuClientes();
                            break;
                        case 2:
                            MenuContasCorrente();
                            break;
                        case 3:
                            MenuContasPoupanca();
                            break;
                        case 4:
                            GerarRelatorio(); // Chama o método de relatório
                            break;
                        case 0:
                            Console.WriteLine("\nSaindo... Obrigado por usar o Banco XYZ!");
                            break;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red; // Cor de erro
                    Console.WriteLine("Entrada inválida. Por favor, insira um número entre 0 e 4.");
                    Console.ForegroundColor = ConsoleColor.White; // Volta para branco
                }

                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                Console.ReadKey();
            } while (opcao != 0);
        }

        static void GerarRelatorio()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta; // Cor roxa
            Console.WriteLine("╔═══════════════════════════════════════════════════════╗");
            Console.WriteLine($"║                     RELATÓRIO                          ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════╝");
            Console.ForegroundColor = ConsoleColor.White; // Cor branca

            // Relatório de Clientes
            Console.WriteLine("\nClientes:");
            if (clientes.Count == 0)
            {
                Console.WriteLine("Nenhum cliente cadastrado.");
            }
            else
            {
                // Exibir cabeçalhos
                Console.WriteLine("-----------------------------------------------------------------------------------");
                Console.WriteLine("{0,-5} | {1,-20} | {2,-15} | {3,-20}", "ID", "Nome", "CPF", "Data de Nascimento");
                Console.WriteLine("-----------------------------------------------------------------------------------");

                // Exibir dados dos clientes
                foreach (var cliente in clientes)
                {
                    Console.WriteLine("{0,-5} | {1,-20} | {2,-15} | {3,-20}",
                        cliente.Id,
                        cliente.Nome,
                        cliente.CPF,
                        cliente.DataNascimento.ToShortDateString());
                }
                Console.WriteLine("-----------------------------------------------------------------------------------");
            }

            // Relatório de Contas Corrente
            Console.WriteLine("\nContas Correntes:");
            if (contasCorrente.Count == 0)
            {
                Console.WriteLine("Nenhuma conta corrente cadastrada.");
            }
            else
            {
                // Exibir cabeçalhos
                Console.WriteLine("-----------------------------------------------------------------------------------");
                Console.WriteLine("{0,-5} | {1,-15} | {2,-12} | {3,-20}", "ID", "Cliente", "Saldo", "Tipo");
                Console.WriteLine("-----------------------------------------------------------------------------------");

                // Exibir dados das contas correntes
                foreach (var conta in contasCorrente)
                {
                    var cliente = clientes.Find(c => c.Id == conta.ClienteId);
                    Console.WriteLine("{0,-5} | {1,-15} | R$ {2,-10:F2} | {3,-20}",
                        conta.Id,
                        cliente?.Nome ?? "Não encontrado",
                        conta.Saldo,
                        "Conta Corrente");
                }
                Console.WriteLine("-----------------------------------------------------------------------------------");
            }

            // Relatório de Contas Poupança
            Console.WriteLine("\nContas Poupança:");
            if (contasPoupanca.Count == 0)
            {
                Console.WriteLine("Nenhuma conta poupança cadastrada.");
            }
            else
            {
                // Exibir cabeçalhos
                Console.WriteLine("-----------------------------------------------------------------------------------");
                Console.WriteLine("{0,-5} | {1,-15} | {2,-12} | {3,-20}", "ID", "Cliente", "Saldo", "Tipo");
                Console.WriteLine("-----------------------------------------------------------------------------------");

                // Exibir dados das contas poupança
                foreach (var conta in contasPoupanca)
                {
                    var cliente = clientes.Find(c => c.Id == conta.ClienteId);
                    Console.WriteLine("{0,-5} | {1,-15} | R$ {2,-10:F2} | {3,-20}",
                        conta.Id,
                        cliente?.Nome ?? "Não encontrado",
                        conta.Saldo,
                        "Conta Poupança");
                }
                Console.WriteLine("-----------------------------------------------------------------------------------");
            }

            Console.ForegroundColor = ConsoleColor.White; // Volta para a cor branca
        }



        static void MenuClientes()
        {
            int opcao;
            string titulo = "GERENCIAR CLIENTES";

            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Magenta; // Cor roxa
                Console.WriteLine("╔═══════════════════════════════════════════════════════╗");
                Console.WriteLine($"║   {titulo,-45}       ║");
                Console.WriteLine("╚═══════════════════════════════════════════════════════╝");
                Console.ForegroundColor = ConsoleColor.White; // Cor branca
                Console.WriteLine("\n║═══════════════════════════════════════════════════════║");
                Console.WriteLine("║ [1] Adicionar Cliente                                 ║");
                Console.WriteLine("║═══════════════════════════════════════════════════════║");
                Console.WriteLine("║ [2] Listar Clientes                                   ║");
                Console.WriteLine("║═══════════════════════════════════════════════════════║");
                Console.WriteLine("║ [3] Atualizar Cliente                                 ║");
                Console.WriteLine("║═══════════════════════════════════════════════════════║");
                Console.WriteLine("║ [4] Remover Cliente                                   ║");
                Console.WriteLine("║═══════════════════════════════════════════════════════║");
                Console.WriteLine("║ [0] Voltar                                            ║");
                Console.ForegroundColor = ConsoleColor.Magenta; // Cor roxa
                Console.WriteLine("╚═══════════════════════════════════════════════════════╝");
                Console.ForegroundColor = ConsoleColor.White; // Cor branca
                Console.Write("Escolha uma opção: ");

                if (int.TryParse(Console.ReadLine(), out opcao))
                {
                    switch (opcao)
                    {
                        case 1:
                            AdicionarCliente();
                            break;
                        case 2:
                            ListarClientes();
                            break;
                        case 3:
                            AtualizarCliente();
                            break;
                        case 4:
                            RemoverCliente();
                            break;
                        case 0:
                            Console.WriteLine("\nVoltando ao menu principal...");
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red; // Cor de erro
                            Console.WriteLine("Opção inválida, tente novamente.");
                            Console.ForegroundColor = ConsoleColor.White; // Volta para branco
                            break;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red; // Cor de erro
                    Console.WriteLine("Entrada inválida. Por favor, insira um número.");
                    Console.ForegroundColor = ConsoleColor.White; // Volta para branco
                }

                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                Console.ReadKey();
            } while (opcao != 0);
        }


        static void MenuContasCorrente()
        {
            int opcao;
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Magenta; // Cor roxa
                Console.WriteLine("╔═══════════════════════════════════════════════════════╗");
                Console.WriteLine($"║   GERENCIAR CONTA CORRENTE                            ║");
                Console.WriteLine("╚═══════════════════════════════════════════════════════╝");
                Console.ForegroundColor = ConsoleColor.White; // Cor branca

                Console.WriteLine("\n║═══════════════════════════════════════════════════════║");
                Console.WriteLine("║ [1] Adicionar Conta Corrente                          ║");
                Console.WriteLine("║═══════════════════════════════════════════════════════║");
                Console.WriteLine("║ [2] Listar Contas Corrente                            ║");
                Console.WriteLine("║═══════════════════════════════════════════════════════║");
                Console.WriteLine("║ [3] Atualizar Conta Corrente                          ║");
                Console.WriteLine("║═══════════════════════════════════════════════════════║");
                Console.WriteLine("║ [4] Remover Conta Corrente                            ║");
                Console.WriteLine("║═══════════════════════════════════════════════════════║");
                Console.WriteLine("║ [0] Voltar                                            ║");
                Console.ForegroundColor = ConsoleColor.Magenta; // Cor roxa
                Console.WriteLine("╚═══════════════════════════════════════════════════════╝");
                Console.ForegroundColor = ConsoleColor.White; // Cor branca
                Console.Write("Escolha uma opção: ");

                if (int.TryParse(Console.ReadLine(), out opcao))
                {
                    switch (opcao)
                    {
                        case 1:
                            AdicionarContaCorrente();
                            break;
                        case 2:
                            ListarContasCorrente();
                            break;
                        case 3:
                            AtualizarContaCorrente();
                            break;
                        case 4:
                            RemoverContaCorrente();
                            break;
                        case 0:
                            Console.WriteLine("\nVoltando ao menu principal...");
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red; // Cor de erro
                            Console.WriteLine("Opção inválida, tente novamente.");
                            Console.ForegroundColor = ConsoleColor.White; // Volta para a cor branca
                            break;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red; // Cor de erro
                    Console.WriteLine("Entrada inválida. Por favor, insira um número.");
                    Console.ForegroundColor = ConsoleColor.White; // Volta para a cor branca
                }

                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                Console.ReadKey();
            } while (opcao != 0);
        }


        static void MenuContasPoupanca()
        {
            int opcao;
            string autor = "Autor: Natan";
            string dataAtual = DateTime.Now.ToString("dd/MM/yyyy HH:mm");

            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Magenta; // Cor roxa
                Console.WriteLine("╔═══════════════════════════════════════════════════════╗");
                Console.WriteLine($"║                GERENCIAR CONTA POUPANÇA               ║");
                Console.WriteLine("╚═══════════════════════════════════════════════════════╝");
                Console.ForegroundColor = ConsoleColor.White; // Cor branca
                Console.WriteLine($"║ {autor}                                          ║");
                Console.WriteLine($"║ Data/Horário: {dataAtual}                        ║");
                Console.WriteLine("║ [1] Adicionar Conta Poupança                          ║");
                Console.WriteLine("║ [2] Listar Contas Poupança                            ║");
                Console.WriteLine("║ [3] Atualizar Conta Poupança                          ║");
                Console.WriteLine("║ [4] Remover Conta Poupança                            ║");
                Console.WriteLine("║ [0] Voltar                                            ║");
                Console.ForegroundColor = ConsoleColor.Magenta; // Cor roxa
                Console.WriteLine("╚═══════════════════════════════════════════════════════╝");
                Console.ForegroundColor = ConsoleColor.White; // Cor branca
                Console.Write("Escolha uma opção: ");

                if (int.TryParse(Console.ReadLine(), out opcao) && (opcao >= 0 && opcao <= 4))
                {
                    switch (opcao)
                    {
                        case 1:
                            AdicionarContaPoupanca();
                            break;
                        case 2:
                            ListarContasPoupanca();
                            break;
                        case 3:
                            AtualizarContaPoupanca();
                            break;
                        case 4:
                            RemoverContaPoupanca();
                            break;
                        case 0:
                            Console.WriteLine("\nVoltando ao menu principal...");
                            break;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red; // Cor de erro
                    Console.WriteLine("Entrada inválida. Por favor, insira um número entre 0 e 4.");
                    Console.ForegroundColor = ConsoleColor.White; // Volta para a cor branca
                }

                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                Console.ReadKey();
            } while (opcao != 0);
        }




        static void AdicionarCliente()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta; // Cor roxa
            Console.WriteLine("╔═══════════════════════════════════════════════════════╗");
            Console.WriteLine($"║   ADICIONAR NOVO CLIENTE                              ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════╝");
            Console.ForegroundColor = ConsoleColor.White; // Cor branca

            string nome;
            while (true)
            {
                Console.Write("Digite o nome do cliente: ");
                nome = Console.ReadLine();

                // Validação: permitir apenas letras e espaços e não ser nulo ou vazio
                if (!string.IsNullOrWhiteSpace(nome) && Regex.IsMatch(nome, @"^[A-Za-z\s]+$"))
                    break;
                Console.ForegroundColor = ConsoleColor.Red; // Cor de erro
                Console.WriteLine("Nome inválido. Por favor, insira apenas letras e espaços.");
                Console.ForegroundColor = ConsoleColor.White; // Volta para a cor branca
            }

            DateTime dataNascimento;
            while (true)
            {
                Console.Write("Digite a data de nascimento (dd/MM/yyyy): ");
                if (DateTime.TryParse(Console.ReadLine(), out dataNascimento))
                    break;
                Console.ForegroundColor = ConsoleColor.Red; // Cor de erro
                Console.WriteLine("Data inválida. Tente novamente.");
                Console.ForegroundColor = ConsoleColor.White; // Volta para a cor branca
            }

            string cpf;
            while (true)
            {
                Console.Write("Digite o CPF do cliente (somente números): ");
                cpf = Console.ReadLine();

                // Validação do CPF: deve ter exatamente 11 dígitos numéricos
                if (Regex.IsMatch(cpf, @"^\d{11}$"))
                    break;

                Console.ForegroundColor = ConsoleColor.Red; // Cor de erro
                Console.WriteLine("CPF inválido. O CPF deve conter exatamente 11 dígitos numéricos.");
                Console.ForegroundColor = ConsoleColor.White; // Volta para a cor branca
            }

            Console.Write("Digite o endereço do cliente: ");
            string endereco = Console.ReadLine();

            int id = clientes.Count > 0 ? clientes[clientes.Count - 1].Id + 1 : 1;
            Cliente cliente = new Cliente(id, nome, dataNascimento, cpf, endereco);
            clientes.Add(cliente);

            Console.ForegroundColor = ConsoleColor.Green; // Cor verde
            Console.WriteLine("\nCliente adicionado com sucesso!");
            Console.ForegroundColor = ConsoleColor.White; // Volta para a cor branca
            SalvarDados();

            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
        }




        static void ListarClientes()
        {
            Console.Clear();
            string titulo = "LISTA DE CLIENTES";

            Console.ForegroundColor = ConsoleColor.Magenta; // Cor roxa
            Console.WriteLine("╔═══════════════════════════════════════════════════════╗");
            Console.WriteLine($"║   {titulo,-45}       ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════╝");
            Console.ForegroundColor = ConsoleColor.White; // Cor branca

            Console.WriteLine("\n║═══════════════════════════════════════════════════════║");

            if (clientes.Count == 0)
            {
                Console.WriteLine("║ Nenhum cliente cadastrado.                             ║");
            }
            else
            {
                // Exibir cabeçalhos
                Console.WriteLine("-----------------------------------------------------------------------------------");
                Console.WriteLine("{0,-5} | {1,-20} | {2,-15} | {3,-15} | {4,-25}", "ID", "Nome", "Data Nascimento", "CPF", "Endereço");
                Console.WriteLine("-----------------------------------------------------------------------------------");

                foreach (var cliente in clientes)
                {
                    Console.WriteLine("{0,-5} | {1,-20} | {2,-15:dd/MM/yyyy} | {3,-15} | {4,-25}",
                        cliente.Id,
                        cliente.Nome,
                        cliente.DataNascimento,
                        cliente.CPF,
                        cliente.Endereco);
                }
                Console.WriteLine("-----------------------------------------------------------------------------------");
            }

            Console.WriteLine("\n║═══════════════════════════════════════════════════════║");
            Console.ForegroundColor = ConsoleColor.Magenta; // Cor roxa
            Console.WriteLine("╚═══════════════════════════════════════════════════════╝");
            Console.ForegroundColor = ConsoleColor.White; // Cor branca
        }





        static void AtualizarCliente()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta; // Cor roxa
            Console.WriteLine("╔═══════════════════════════════════════════════════════╗");
            Console.WriteLine($"║   ATUALIZAR CLIENTE                                   ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════╝");
            Console.ForegroundColor = ConsoleColor.White; // Cor branca

            Console.Write("Digite o ID do cliente a ser atualizado: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var cliente = clientes.Find(c => c.Id == id);
                if (cliente != null)
                {
                    Console.Write("Novo nome (deixe em branco para não alterar): ");
                    string novoNome = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(novoNome))
                        cliente.Nome = novoNome;

                    Console.Write("Nova data de nascimento (deixe em branco para não alterar): ");
                    string novaDataStr = Console.ReadLine();
                    if (DateTime.TryParse(novaDataStr, out DateTime novaData))
                        cliente.DataNascimento = novaData;

                    Console.Write("Novo CPF (deixe em branco para não alterar): ");
                    string novoCPF = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(novoCPF) && Regex.IsMatch(novoCPF, @"^\d{11}$"))
                        cliente.CPF = novoCPF;
                    else if (!string.IsNullOrWhiteSpace(novoCPF))
                    {
                        Console.ForegroundColor = ConsoleColor.Red; // Cor de erro
                        Console.WriteLine("CPF inválido. O CPF deve conter exatamente 11 dígitos numéricos.");
                        Console.ForegroundColor = ConsoleColor.White; // Volta para a cor branca
                    }

                    Console.Write("Novo endereço (deixe em branco para não alterar): ");
                    string novoEndereco = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(novoEndereco))
                        cliente.Endereco = novoEndereco;

                    Console.ForegroundColor = ConsoleColor.Green; // Cor verde
                    Console.WriteLine("\nCliente atualizado com sucesso!");
                    Console.ForegroundColor = ConsoleColor.White; // Volta para a cor branca
                    SalvarDados();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red; // Cor de erro
                    Console.WriteLine("Cliente não encontrado.");
                    Console.ForegroundColor = ConsoleColor.White; // Volta para a cor branca
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red; // Cor de erro
                Console.WriteLine("ID inválido.");
                Console.ForegroundColor = ConsoleColor.White; // Volta para a cor branca
            }

            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
        }


        static void RemoverCliente()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta; // Cor roxa
            Console.WriteLine("╔═══════════════════════════════════════════════════════╗");
            Console.WriteLine($"║   REMOVER CLIENTE                                    ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════╝");
            Console.ForegroundColor = ConsoleColor.White; // Cor branca

            Console.Write("Digite o ID do cliente a ser removido: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var cliente = clientes.Find(c => c.Id == id);
                if (cliente != null)
                {
                    clientes.Remove(cliente);
                    Console.ForegroundColor = ConsoleColor.Green; // Cor verde
                    Console.WriteLine("\nCliente removido com sucesso!");
                    Console.ForegroundColor = ConsoleColor.White; // Volta para a cor branca
                    SalvarDados();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red; // Cor de erro
                    Console.WriteLine("Cliente não encontrado.");
                    Console.ForegroundColor = ConsoleColor.White; // Volta para a cor branca
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red; // Cor de erro
                Console.WriteLine("ID inválido.");
                Console.ForegroundColor = ConsoleColor.White; // Volta para a cor branca
            }

            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
        }


        static void AdicionarContaCorrente()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta; // Cor roxa
            Console.WriteLine("╔═══════════════════════════════════════════════════════╗");
            Console.WriteLine($"║   ADICIONAR NOVA CONTA CORRENTE                       ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════╝");
            Console.ForegroundColor = ConsoleColor.White; // Cor branca

            Console.Write("Digite o ID do cliente: ");
            if (int.TryParse(Console.ReadLine(), out int clienteId))
            {
                if (clientes.Exists(c => c.Id == clienteId))
                {
                    double saldo = 0.0; // Saldo inicial

                    int id = contasCorrente.Count > 0 ? contasCorrente[^1].Id + 1 : 1;
                    ContaCorrente conta = new ContaCorrente(id, saldo, clienteId);
                    contasCorrente.Add(conta);

                    Console.ForegroundColor = ConsoleColor.Green; // Cor verde para sucesso
                    Console.WriteLine("\nConta Corrente adicionada com sucesso!");
                    Console.ForegroundColor = ConsoleColor.White; // Volta para a cor branca
                    SalvarDados();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red; // Cor de erro
                    ExibirMensagemErro("Cliente não encontrado.");
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red; // Cor de erro
                ExibirMensagemErro("ID inválido.");
            }

            Console.ForegroundColor = ConsoleColor.White; // Volta para a cor branca
            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
        }


        static void ListarContasCorrente()
        {
            Console.Clear();
            string titulo = "LISTA DE CONTAS CORRENTES";

            Console.ForegroundColor = ConsoleColor.Magenta; // Cor roxa
            Console.WriteLine("╔═══════════════════════════════════════════════════════╗");
            Console.WriteLine($"║              {titulo,-43}               ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════╝");
            Console.ForegroundColor = ConsoleColor.White; // Cor branca

            Console.WriteLine("\n║═══════════════════════════════════════════════════════║");

            if (contasCorrente.Count == 0)
            {
                Console.WriteLine("║ Nenhuma conta corrente cadastrada.                     ║");
            }
            else
            {
                // Exibir cabeçalhos
                Console.WriteLine("-----------------------------------------------------------------------------------");
                Console.WriteLine("{0,-5} | {1,-15} | {2,-20} | {3,-20}", "ID", "Saldo", "Cliente", "Status");
                Console.WriteLine("-----------------------------------------------------------------------------------");

                foreach (var conta in contasCorrente)
                {
                    var cliente = clientes.Find(c => c.Id == conta.ClienteId);
                    string clienteNome = cliente != null ? cliente.Nome : "Não encontrado";
                    string status = cliente != null ? "Ativo" : "Inativo";

                    Console.WriteLine("{0,-5} | R$ {1,-15:F2} | {2,-20} | {3,-20}",
                        conta.Id,
                        conta.Saldo,
                        clienteNome,
                        status);
                }
                Console.WriteLine("-----------------------------------------------------------------------------------");
            }

            Console.WriteLine("\n║═══════════════════════════════════════════════════════║");
            Console.ForegroundColor = ConsoleColor.Magenta; // Cor roxa
            Console.WriteLine("╚═══════════════════════════════════════════════════════╝");
            Console.ForegroundColor = ConsoleColor.White; // Cor branca
        }




        static void AtualizarContaCorrente()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta; // Cor roxa
            Console.WriteLine("╔═══════════════════════════════════════════════════════╗");
            Console.WriteLine($"║   ATUALIZAR CONTA CORRENTE                            ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════╝");
            Console.ForegroundColor = ConsoleColor.White; // Cor branca

            Console.Write("Digite o ID da conta a ser atualizada: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var conta = contasCorrente.Find(c => c.Id == id);
                if (conta != null)
                {
                    Console.Write("Novo saldo (deixe em branco para não alterar): ");
                    string novoSaldoStr = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(novoSaldoStr))
                    {
                        // Não altera o saldo se a entrada for em branco
                    }
                    else if (double.TryParse(novoSaldoStr, out double novoSaldo))
                    {
                        conta.Saldo = novoSaldo;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red; // Cor de erro
                        Console.WriteLine("Saldo inválido. O valor deve ser numérico.");
                        Console.ForegroundColor = ConsoleColor.White; // Volta para a cor branca
                    }

                    Console.ForegroundColor = ConsoleColor.Green; // Cor verde
                    Console.WriteLine("\nConta Corrente atualizada com sucesso!");
                    Console.ForegroundColor = ConsoleColor.White; // Volta para a cor branca
                    SalvarDados();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red; // Cor de erro
                    Console.WriteLine("Conta não encontrada.");
                    Console.ForegroundColor = ConsoleColor.White; // Volta para a cor branca
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red; // Cor de erro
                Console.WriteLine("ID inválido.");
                Console.ForegroundColor = ConsoleColor.White; // Volta para a cor branca
            }

            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
        }



        static void RemoverContaCorrente()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta; // Cor roxa
            Console.WriteLine("╔═══════════════════════════════════════════════════════╗");
            Console.WriteLine($"║                REMOVER CONTA CORRENTE                ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════╝");
            Console.ForegroundColor = ConsoleColor.White; // Cor branca

            Console.Write("Digite o ID da conta a ser removida: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var conta = contasCorrente.Find(c => c.Id == id);
                if (conta != null)
                {
                    contasCorrente.Remove(conta);
                    Console.ForegroundColor = ConsoleColor.Green; // Cor verde
                    Console.WriteLine("\nConta Corrente removida com sucesso!");
                    Console.ForegroundColor = ConsoleColor.White; // Volta para a cor branca
                    SalvarDados();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red; // Cor de erro
                    Console.WriteLine("Conta não encontrada.");
                    Console.ForegroundColor = ConsoleColor.White; // Volta para a cor branca
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red; // Cor de erro
                Console.WriteLine("ID inválido.");
                Console.ForegroundColor = ConsoleColor.White; // Volta para a cor branca
            }

            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
        }


        static void AdicionarContaPoupanca()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta; // Cor roxa
            Console.WriteLine("╔═══════════════════════════════════════════════════════╗");
            Console.WriteLine($"║            ADICIONAR NOVA CONTA POUPANÇA            ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════╝");
            Console.ForegroundColor = ConsoleColor.White; // Cor branca

            Console.Write("Digite o ID do cliente: ");
            if (int.TryParse(Console.ReadLine(), out int clienteId))
            {
                if (clientes.Exists(c => c.Id == clienteId))
                {
                    double saldo = 0.0; // Saldo inicial
                    Console.Write("Digite o saldo inicial (ou deixe em branco para R$ 0,00): ");
                    string saldoInput = Console.ReadLine();

                    if (!string.IsNullOrWhiteSpace(saldoInput))
                    {
                        if (double.TryParse(saldoInput, out double saldoInicial) && saldoInicial >= 0)
                        {
                            saldo = saldoInicial;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red; // Cor de erro
                            ExibirMensagemErro("Saldo inválido. O saldo deve ser um número positivo.");
                            return; // Saída antecipada
                        }
                    }

                    int id = contasPoupanca.Count > 0 ? contasPoupanca[^1].Id + 1 : 1;
                    ContaPoupanca conta = new ContaPoupanca(id, saldo, clienteId);
                    contasPoupanca.Add(conta);

                    Console.ForegroundColor = ConsoleColor.Green; // Cor verde
                    Console.WriteLine("\nConta Poupança adicionada com sucesso!");
                    Console.ForegroundColor = ConsoleColor.White; // Volta para a cor branca
                    SalvarDados();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red; // Cor de erro
                    ExibirMensagemErro("Cliente não encontrado.");
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red; // Cor de erro
                ExibirMensagemErro("ID inválido.");
            }

            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
        }


        static void ListarContasPoupanca()
        {
            Console.Clear();
            string titulo = "LISTA DE CONTAS POUPANÇAS";

            Console.ForegroundColor = ConsoleColor.Magenta; // Cor roxa
            Console.WriteLine("╔═══════════════════════════════════════════════════════╗");
            Console.WriteLine($"║              {titulo,-43}               ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════╝");
            Console.ForegroundColor = ConsoleColor.White; // Cor branca

            Console.WriteLine("\n║═══════════════════════════════════════════════════════║");

            if (contasPoupanca.Count == 0)
            {
                Console.WriteLine("║ Nenhuma conta poupança cadastrada.                     ║");
            }
            else
            {
                // Exibir cabeçalhos
                Console.WriteLine("-----------------------------------------------------------------------------------");
                Console.WriteLine("{0,-5} | {1,-15} | {2,-20} | {3,-20}", "ID", "Saldo", "Cliente", "Status");
                Console.WriteLine("-----------------------------------------------------------------------------------");

                foreach (var conta in contasPoupanca)
                {
                    var cliente = clientes.Find(c => c.Id == conta.ClienteId);
                    string clienteNome = cliente != null ? cliente.Nome : "Não encontrado";
                    string status = cliente != null ? "Ativo" : "Inativo";

                    Console.ForegroundColor = ConsoleColor.Green; // Cor verde para conta e saldo
                    Console.WriteLine("{0,-5} | R$ {1,-15:F2} | {2,-20} | {3,-20}",
                        conta.Id,
                        conta.Saldo,
                        clienteNome,
                        status);
                }
                Console.WriteLine("-----------------------------------------------------------------------------------");
            }

            Console.WriteLine("\n║═══════════════════════════════════════════════════════║");
            Console.ForegroundColor = ConsoleColor.Magenta; // Cor roxa
            Console.WriteLine("╚═══════════════════════════════════════════════════════╝");
            Console.ForegroundColor = ConsoleColor.White; // Cor branca
        }




        static void AtualizarContaPoupanca()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta; // Cor roxa
            ExibirBorda(() =>
            {
                ExibirTitulo("ATUALIZAR CONTA POUPANÇA");

                Console.ForegroundColor = ConsoleColor.White; // Cor branca
                Console.Write("Digite o ID da conta a ser atualizada: ");

                if (int.TryParse(Console.ReadLine(), out int id))
                {
                    var conta = contasPoupanca.Find(c => c.Id == id);
                    if (conta != null)
                    {
                        Console.Write("Novo saldo (deixe em branco para não alterar): ");
                        string novoSaldoStr = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(novoSaldoStr))
                        {
                            // Não altera o saldo se a entrada for em branco
                        }
                        else if (double.TryParse(novoSaldoStr, out double novoSaldo))
                        {
                            if (novoSaldo < 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Red; // Cor de erro
                                Console.WriteLine("Erro: O saldo não pode ser negativo.");
                            }
                            else
                            {
                                conta.Saldo = novoSaldo;
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red; // Cor de erro
                            Console.WriteLine("Erro: Saldo inválido. O valor deve ser numérico.");
                        }

                        Console.ForegroundColor = ConsoleColor.Green; // Cor verde
                        Console.WriteLine("\nConta Poupança atualizada com sucesso!");
                        Console.ForegroundColor = ConsoleColor.White; // Volta para a cor branca
                        SalvarDados();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red; // Cor de erro
                        ExibirMensagemErro("Conta não encontrada.");
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red; // Cor de erro
                    ExibirMensagemErro("ID inválido.");
                }

                Console.ForegroundColor = ConsoleColor.White; // Volta para a cor branca
            });
        }


        static void RemoverContaPoupanca()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta; // Cor roxa
            ExibirBorda(() =>
            {
                ExibirTitulo("REMOVER CONTA POUPANÇA");

                Console.ForegroundColor = ConsoleColor.White; // Cor branca
                Console.Write("Digite o ID da conta a ser removida: ");

                if (int.TryParse(Console.ReadLine(), out int id))
                {
                    var conta = contasPoupanca.Find(c => c.Id == id);
                    if (conta != null)
                    {
                        Console.ForegroundColor = ConsoleColor.Red; // Cor de aviso
                        Console.WriteLine($"Tem certeza que deseja remover a conta com ID {conta.Id} (Saldo: R$ {conta.Saldo:F2})? (s/n)");
                        string confirmacao = Console.ReadLine()?.ToLower();

                        if (confirmacao == "s")
                        {
                            contasPoupanca.Remove(conta);
                            Console.ForegroundColor = ConsoleColor.Green; // Cor verde
                            Console.WriteLine("\nConta Poupança removida com sucesso!");
                            Console.ForegroundColor = ConsoleColor.White; // Volta para a cor branca
                            SalvarDados();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow; // Cor de aviso
                            Console.WriteLine("\nRemoção da conta cancelada.");
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red; // Cor de erro
                        ExibirMensagemErro("Conta não encontrada.");
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red; // Cor de erro
                    ExibirMensagemErro("ID inválido.");
                }

                Console.ForegroundColor = ConsoleColor.White; // Volta para a cor branca
            });
        }


        static void SalvarDados()
        {
            try
            {
                File.WriteAllText(caminhoClientes, JsonSerializer.Serialize(clientes));
                File.WriteAllText(caminhoContasCorrente, JsonSerializer.Serialize(contasCorrente));
                File.WriteAllText(caminhoContasPoupanca, JsonSerializer.Serialize(contasPoupanca));
            }
            catch (Exception ex)
            {
                ExibirMensagemErro("Erro ao salvar dados: " + ex.Message);
            }
        }

        static void CarregarDados()
        {
            try
            {
                if (File.Exists(caminhoClientes))
                    clientes = JsonSerializer.Deserialize<List<Cliente>>(File.ReadAllText(caminhoClientes)) ?? new List<Cliente>();
                if (File.Exists(caminhoContasCorrente))
                    contasCorrente = JsonSerializer.Deserialize<List<ContaCorrente>>(File.ReadAllText(caminhoContasCorrente)) ?? new List<ContaCorrente>();
                if (File.Exists(caminhoContasPoupanca))
                    contasPoupanca = JsonSerializer.Deserialize<List<ContaPoupanca>>(File.ReadAllText(caminhoContasPoupanca)) ?? new List<ContaPoupanca>();
            }
            catch (Exception ex)
            {
                ExibirMensagemErro("Erro ao carregar dados: " + ex.Message);
            }
        }

        static void ExibirMenu(string titulo, string[] opcoes)
        {
            int maxLength = 0;
            foreach (string opcao in opcoes)
            {
                if (opcao.Length > maxLength)
                    maxLength = opcao.Length;
            }

            string border = new string('-', maxLength + 4);
            CentralizarTexto(border);
            CentralizarTexto(titulo);
            CentralizarTexto(border);
            foreach (string opcao in opcoes)
            {
                CentralizarTexto($"| {opcao} |");
            }
            CentralizarTexto(border);
        }

        static void ExibirTitulo(string titulo)
        {
            string border = new string('=', titulo.Length + 4);
            CentralizarTexto(border);
            CentralizarTexto($"| {titulo} |");
            CentralizarTexto(border);
        }

        static void ExibirMensagemErro(string mensagem)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            CentralizarTexto(mensagem);
            Console.ResetColor();
        }

        static void CentralizarTexto(string texto)
        {
            int larguraConsole = Console.WindowWidth;
            int posicaoCentral = (larguraConsole / 2) - (texto.Length / 2);
            Console.SetCursorPosition(posicaoCentral, Console.CursorTop);
            Console.WriteLine(texto);
        }

        static void ExibirBorda(Action conteudo)
        {
            int larguraConsole = Console.WindowWidth;
            string border = new string('=', larguraConsole - 2);

            Console.WriteLine(border);
            Console.WriteLine("|" + new string(' ', larguraConsole - 2) + "|");
            conteudo();
            Console.WriteLine("|" + new string(' ', larguraConsole - 2) + "|");
            Console.WriteLine(border);
        }
    }

    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string CPF { get; set; }
        public string Endereco { get; set; }

        public Cliente(int id, string nome, DateTime dataNascimento, string cpf, string endereco)
        {
            Id = id;
            Nome = nome;
            DataNascimento = dataNascimento;
            CPF = cpf;
            Endereco = endereco;
        }
    }

    public class ContaCorrente
    {
        public int Id { get; set; }
        public double Saldo { get; set; }
        public int ClienteId { get; set; }

        public ContaCorrente(int id, double saldo, int clienteId)
        {
            Id = id;
            Saldo = saldo;
            ClienteId = clienteId;
        }
    }

    public class ContaPoupanca
    {
        public int Id { get; set; }
        public double Saldo { get; set; }
        public int ClienteId { get; set; }

        public ContaPoupanca(int id, double saldo, int clienteId)
        {
            Id = id;
            Saldo = saldo;
            ClienteId = clienteId;
        }
    }
}
