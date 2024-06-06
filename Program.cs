using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Aula20240605
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* PARTE 2 Abrir conexão */
            SqlConnection conexao;
            conexao = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Banco01;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            try
            {
                conexao.Open();
                Console.WriteLine("Conexão aberta!");

                /* PARTE 2 Inserir Dados */
                /*var insertCmd = conexao.CreateCommand();
                insertCmd.CommandText = "INSERT INTO Exemplo (Nome, Sobrenome) VALUES (@nome, @sobrenome);";

                var parNome = new SqlParameter("nome", "Maria");
                var parSobrenome = new SqlParameter("sobrenome", "Silva");

                insertCmd.ExecuteNonQuery();
                Console.WriteLine("Linha Inserida!");*/

                var selectCmd = conexao.CreateCommand();
                selectCmd.CommandText = "SELECT * FROM Exemplo";

                SqlDataReader leitorDados = selectCmd.ExecuteReader();

                while (leitorDados.Read())
                {
                    Console.WriteLine("Nome: "+ leitorDados["Nome"] + "Sobrenome: "+ leitorDados["Sobrenome"]);

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERRO!");
            }
            finally
            {
                conexao.Close();
                Console.WriteLine("Conexão fechada!");
            }
        }
    }
}
