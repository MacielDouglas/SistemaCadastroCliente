using Cadastro_Pessoa_FS1.Classes;

Console.WriteLine(@$"
=================================================
|       Bem vindo ao sistema de cadasto de      |
|           Pessoas Físicas e Juridícas         |
=================================================
");

BarraCarregamento("Carregando..", 500);

List<PessoaFisica> listPf = new List<PessoaFisica>();
List<PessoaJuridica> listPJ = new List<PessoaJuridica>();

string? opcao;
do
{
    Console.Clear();

    Console.WriteLine(@$"
=================================================
|         Escolha uma das opções abaixo         |
|-----------------------------------------------|
|              1 - Pessoa Física                |
|              2 - Pessoa Jurídica              |
|                                               |
|              0 - Sair                         |
=================================================
");

    opcao = Console.ReadLine();

    switch (opcao)
    {
        case "1":
            PessoaFisica metodoPf = new PessoaFisica();

            string? opcaoPf; //variavel para armezenar o cadastro do usuario e para o cod. se repetir

            do
            {
                Console.Clear();

                Console.WriteLine(@$"
=================================================
|         Escolha uma das opções abaixo         |
|-----------------------------------------------|
|          1 - Cadastrar Pessoa Física          |
|          2 - Lista Pessoa Física              |
|                                               |
|          0 - Voltar ao Menu Anterior          |
=================================================
");

                opcaoPf = Console.ReadLine();

                switch (opcaoPf)
                {
                    case "1":

                        PessoaFisica novaPf = new PessoaFisica();
                        Endereco novoEnd = new Endereco();

                        Console.Clear();
                        Console.WriteLine($"Digite o nome da pessoa física que deseja cadastrar");
                        novaPf.nome = Console.ReadLine();

                        Console.Clear();

                        bool dataValida; // variavel armazena o resultado abaixo
                        do
                        {

                            Console.WriteLine($"Digite a data de nascimento, ex. DD/MM/AAAA");
                            string? dataNasc = Console.ReadLine();

                            dataValida = metodoPf.ValidarDataNascimento(dataNasc); //Metodo p/ avaliar se dataNasc está correta
                            if (dataValida)
                            {
                                novaPf.dataNascimento = dataNasc;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine($"Data invalida!!! Por favor digite uma data válida.");
                                Console.ResetColor();

                            }
                        } while (dataValida == false); //tambem poderia se (dataValida != true)



                        Console.Clear();
                        Console.WriteLine($"Digite o numero do CPF");
                        novaPf.cpf = Console.ReadLine();

                        Console.Clear();
                        Console.WriteLine($"Digite o rendimento mensal (digite somente numeros)");
                        novaPf.rendimento = float.Parse(Console.ReadLine()); //ReadLine retorna String, é preciso converter usamos float.Parse

                        Console.Clear();
                        Console.WriteLine($"Digite o logradouro");
                        novoEnd.logradouro = Console.ReadLine();

                        Console.WriteLine($"Digite o numero");
                        novoEnd.numero = int.Parse(Console.ReadLine());

                        Console.WriteLine($"Digite complementeo (Aperte ENTER para vazio)");
                        novoEnd.complemento = Console.ReadLine();

                        Console.WriteLine($"Este endereço é comercial? S/N");
                        string endCom = Console.ReadLine().ToUpper();

                        if (endCom == "S")
                        {
                            novoEnd.endComercial = true;
                        }
                        else
                        {
                            novoEnd.endComercial = false;
                        }


                        novaPf.endereco = novoEnd;

                        metodoPf.Inserir(novaPf);

                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine($"Cadastro realizado com sucesso!!!");
                        Thread.Sleep(3000);
                        Console.ResetColor();

                        break;

                    case "2":
                        Console.Clear();

                        List<PessoaFisica> listaPf = metodoPf.Ler();

                        foreach (PessoaFisica cadaPefisica in listaPf)
                        {
                            Console.Clear();
                            Console.WriteLine(@$"
Nome: {cadaPefisica.nome}
Data de Nascimento {cadaPefisica.dataNascimento}
CPF: {cadaPefisica.cpf}
");

                            Console.WriteLine($"Aperte 'Enter' para continuar");
                            Console.ReadLine();
                        }

                        break;


                    case "0":
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine($"Opção inválida, por favor digite outra opção");
                        Thread.Sleep(2000);
                        break;
                }

            } while (opcaoPf != "0");


            break;

        case "2":
            PessoaJuridica metodoPj = new PessoaJuridica();

            string? opcaoPJ;

            do
            {
                Console.Clear();

                Console.WriteLine(@$"
=================================================
|         Escolha uma das opções abaixo         |
|-----------------------------------------------|
|          1 - Cadastrar Pessoa Jurídica        |
|          2 - Listar Pessoas Jurídicas         |
|                                               |
|          0 - Voltar ao Menu Anterior          |
=================================================
");

                opcaoPJ = Console.ReadLine();

                switch (opcaoPJ)
                {
                    case "1":
                        PessoaJuridica novaPj = new PessoaJuridica();
                        Endereco novoEndPj = new Endereco();

                        Console.Clear();
                        Console.WriteLine($"Digite o nome \"fantasia\" da empresa para cadastrar.");
                        novaPj.nome = Console.ReadLine();
                        Console.Clear();


                        bool cnpjValido;

                        do
                        {
                            Console.WriteLine($"Digite o cnpj da empresa ex: 00.000.000/0001-00");
                            string? cnpjCorreto = Console.ReadLine();

                            cnpjValido = metodoPj.ValidarCnpj(cnpjCorreto);
                            if (cnpjValido)
                            {
                                novaPj.cnpj = cnpjCorreto;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine($"Cnpj incorreto, por favor digite um cnpj correto!!!");
                                Console.ResetColor();

                            }
                        } while (cnpjValido == false);
                        Console.Clear();

                        Console.WriteLine($"Digite a Razão Social da empresa");
                        novaPj.razaoSocial = Console.ReadLine();
                        Console.Clear();


                        Console.WriteLine($"Digite o logradouro, Ex. Rua: Brasil");
                        novoEndPj.logradouro = Console.ReadLine();

                        Console.WriteLine($"Digite o numero");
                        novoEndPj.numero = int.Parse(Console.ReadLine());

                        Console.WriteLine($"Digite complementeo (Aperte ENTER para vazio)");
                        novoEndPj.complemento = Console.ReadLine();

                        novaPj.endereco = novoEndPj;

                        Console.WriteLine($"Digite o rendimento mensal da empresa, (apenas numeros)");
                        novaPj.rendimento = float.Parse(Console.ReadLine());
                        Console.Clear();

                        metodoPj.Inserir(novaPj);

                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine($"Cadastro Realizado com sucesso!!!");
                        Thread.Sleep(2000);
                        Console.ResetColor();

                        break;

                    case "2":
                        Console.Clear();

                        List<PessoaJuridica> listaPJ = metodoPj.Ler();

                        foreach (PessoaJuridica cadaPejuridica in listaPJ)
                        {
                            Console.Clear();
                            Console.WriteLine(@$"
Nome: {cadaPejuridica.nome}
Razão Social: {cadaPejuridica.razaoSocial}
CNPJ: {cadaPejuridica.cnpj}
Endereço: {cadaPejuridica.endereco}
Rendimento: {cadaPejuridica.rendimento}");

                            Console.WriteLine($"Aperte 'Enter' para continuar");
                            Console.ReadLine();
                        }


                        break;

                    case "0":
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine($"Opção inválida, por favor digite outra opção");
                        Thread.Sleep(2000);
                        break;
                }

            } while (opcaoPJ != "0");

            break;

        case "0":
            Console.Clear();
            BarraCarregamento("Finalizando..", 300);

            break;

        default:
            Console.Clear();
            Console.WriteLine($"Opção inválida, por favor digite outra opção");
            Thread.Sleep(2000);
            break;
    }

} while (opcao != "0");

static void BarraCarregamento(string texto, int tempo)
{
    Console.BackgroundColor = ConsoleColor.DarkYellow;
    Console.ForegroundColor = ConsoleColor.Black;

    Console.Write($"{texto}");

    for (var contador = 0; contador < 10; contador++)
    {
        Console.Write(".");
        Thread.Sleep(tempo);
    }

    Console.ResetColor();
}
