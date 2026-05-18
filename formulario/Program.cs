// programa formulario com integracao em banco de dados local
// Primeiro, instale o pacote no terminal do projeto:
// dotnet add package MySql.Data

using System;

//tem q adicionar biblioteca
using MySql.Data.MySqlClient;


class Program
{
    static void Main()
    {

        // colocando as informacoes do banco
        string conexaoBanco = 
            "server=localhost;" +
            "database=formulario;" +
            "user=root;" +
            "password=SenhaNova123!;";


        while (true)
        {
            Console.Write("\nDeseja adicionar cliente? [S/N]: ");
            string? opcao = Console.ReadLine();

            if(opcao?.ToUpper() == "S")
            {
                Console.Write("Nome: ");
                string? nome = Console.ReadLine();

                Console.Write("Contato: ");
                int.TryParse(Console.ReadLine(), out int contato);


                //-------------------------------------------------------
                //Claro. Essa parte é a responsável por: conectar no MySQL,
                //executar o INSERT, tratar possíveis erros.
                try
                // o try significa “tente executar isso”.
                {

                    // cria uma conexão com o banco.
                    //O using fecha a conexão automaticamente no final.
                    //Sem ele você teria que fazer: conexao.Close();
                    using(MySqlConnection conexao = new MySqlConnection(conexaoBanco))
                    {
                        conexao.Open();//Aqui o C# realmente tenta conectar no MySQL.

                        // Aqui você escreve o comando SQL.
                        string sql =
                            "INSERT INTO dados(nome_cliente, contato_cliente)"+
                            "VALUES(@nome, @contato)";
                        

                        // CRIANDO O COMANDO SQL
                        using(MySqlCommand comando = new MySqlCommand(sql, conexao))
                        {
                            // PASSANDO OS VALORES
                            comando.Parameters.AddWithValue("@nome", nome);
                            comando.Parameters.AddWithValue("@contato", contato);

                            comando.ExecuteNonQuery();
                        }
                    }
                }
                //o catch dignifica “se der erro, capture o erro”.
                catch (Exception erro)
                {
                    Console.WriteLine($"Erro: {erro.Message}");
                }

                // -------------------------------------------------------------------

            }
            else if (opcao=="N" || opcao == "n")
            {
                Console.WriteLine("Finalizando...");
                break;
            }
            else
            {
                Console.WriteLine("opcao inválida. Tente novamente");   
            }
        }
    }
}