using System.Text.RegularExpressions;
using Cadastro_Pessoa_FS1.Interfaces;

namespace Cadastro_Pessoa_FS1.Classes
{
    public class PessoaJuridica : Pessoa, IPessoaJuridica
    {
        //Atributos cnpj e razao social
        public string? cnpj { get; set; }
        public string? razaoSocial { get; set; }

        public string caminho { get; private set; } = "Database/PessoaJuridica.csv";

        // Métodos
        public override float PagarImposto(float rendimento)
        {
            //throw new NotImplementedException(); para não dar erro pois aida não tem método
            if (rendimento <= 3000)
            {
                return rendimento * .03f;
            }
            else if (rendimento > 3000 && rendimento <= 6000)
            {
                return rendimento * .05f;
            }
            else if (rendimento > 6000 && rendimento <= 10000)
            {
                return rendimento * .07f;
            }
            else
            {
                return rendimento * .09f;
            }
        }

        public bool ValidarCnpj(string cnpj)
        { //Regex, método para validar dois formantos de cnpj
            if (Regex.IsMatch(cnpj, @"(^(\d{2}\.\d{3}\.\d{3}/\d{4}-\d{2})|(\d{14})$)"))
            {
                if (cnpj.Length == 18)
                { //condição para comparar /0001
                    if (cnpj.Substring(11, 4) == "0001")
                    {
                        return true;
                    }
                }
                else if (cnpj.Length == 14)
                {
                    if (cnpj.Substring(8, 4) == "0001")
                    {
                        return true;
                    }
                }
            }
            return false;

        }

        public void Inserir(PessoaJuridica pj)
        {

            VerificarPastaArquivo(caminho);

            string[] pjString = { $"{pj.nome}, {pj.cnpj}, {pj.razaoSocial}, {pj.endereco}, {pj.rendimento}" };

            File.AppendAllLines(caminho, pjString);
        }

        public List<PessoaJuridica> Ler()
        {

            List<PessoaJuridica> listaPj = new List<PessoaJuridica>();

            string[] linhas = File.ReadAllLines(caminho);

            foreach (string cadaLinha in linhas)
            {
                string[] atributos = cadaLinha.Split(",");

                PessoaJuridica cadaPj = new PessoaJuridica();

                cadaPj.nome = atributos[0];
                cadaPj.cnpj = atributos[1];
                cadaPj.razaoSocial = atributos[2];

                listaPj.Add(cadaPj);
            }

            return listaPj;
        }
    }
}