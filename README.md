# Sistema de Cadastro de Cliente - ClientLab

Foi criado o desenvolvimento de um novo sistema de cadastro de clientes customizado,
atendendo às seguintes características:


    •        o sistema de clientes deverá armazenar os cadastros das pessoas físicas e jurídicas;

    •        o cadastro das pessoas físicas é feito com os seguintes dados: nome, CPF e data de nascimento;

    •        o cadastro das pessoas jurídicas é feito com os seguintes dados: nome, CNPJ e razão social;

    •        ambos devem possuir um endereço e indicar se o endereço é comercial ou residencial;

    •        o sistema armazena os registros em arquivos;



## **TECONOLOGIAS UTILIZADAS**

    * Ferramenta Online Draw.io, para a criação do diagrama UML;
    * Para o SERVER-SIDE, foi usado a linguagem C# e framework .NET;
    * Gravação dos arquivos Pessoa Física foi em .txt, e para pessoa jurídica .csv;



## **PLANEJAMENTO DO SISTEMA**

    Foi criado um diagrama UML para entender como o sistema irá se comunicar por completo,
    que explica a estrutura e organização do sistema.
    
    A base do sistema foi feito orientado a objetos para cadastro de clientes da ClientLab,
    modelando suas classes, seus atributos, operações e relações entre objetos, atendendo às seguintes características:

    - Deverá armazenar os cadastros das pessoas físicas e jurídicas;

    - As pessoas físicas possuem nome, CPF e data de nascimento;  

    - As pessoas jurídicas possuem nome, CNPJ e razão social;         

    - Ambos possuem a opção para pagar imposto;

    - Ambos possuem um endereço e indicar se o endereço é comercial ou residencial;  

    - O sistema deve armazenar seus registros em arquivos.

 

## **Pré-requisitos de instalação**

Para a execução é necessario ter a pelo menos:
    * dotnet 6.0.201



## **Execução da aplicação**

Pode-se fazer um cópia da aplicação utilizando o comando:

    * git clone https://github.com/MacielDouglas/SistemaCadastroCliente.git

Após feito o clone, para executar usa o comando:
    * dotnet run

No sistema aparecerá um menu inicial com tres opções:
     1 - Pessoa Física
     2 - Pessoa Jurídica  
     0 - Sair

Dentro das Opções 1 e 2 ainda temos mais tres opções:
    1 - Cadastrar
    2 - Listar
    0 - Voltar



## **Erros Comuns**

Foi observados alguns erros:
    * cadastrar cnpj diferente de /0001 ;
    * cadastrar letra ao inves de numero, em endereço / numero ;



## **Contribuidores**

Aluno: Douglas Maciel;
Professor: Odirlei Saraiba (Senai);