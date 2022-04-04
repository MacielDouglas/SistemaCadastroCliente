using Cadastro_Pessoa_FS1.Interfaces;

namespace Cadastro_Pessoa_FS1.Classes
{
    public abstract class Pessoa : IPessoa
    {
        //atributo no começo
        public string? nome { get; set; } // atalho para criar é prop + tab  e ? serve para dizer q pd ser vazio

        public Endereco? endereco { get; set; }

        public float rendimento { get; set; }



        //interface a baixo
        public abstract float PagarImposto(float rendimento); //Abstrato, pq ele não tem conteudo, o conteudo estará em quem herdar


        public void VerificarPastaArquivo(string caminho)
        {
            string pasta = caminho.Split("/")[0];

            if (!Directory.Exists(pasta))
            {
                Directory.CreateDirectory(pasta);
            }

            if (!File.Exists(caminho))
            {
                using (File.Create(caminho))
                {

                }

            }

        }

    }
}