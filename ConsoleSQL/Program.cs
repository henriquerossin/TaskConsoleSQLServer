using Microsoft.Data.SqlClient;

namespace ConsoleSQL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var connection = new SqlConnection(DBConnection.GetConnectionString());

            //CRUD - Create

            var pessoa = new Pessoa("Gabriela Freijó", "12345", new DateOnly(1990, 5, 20));

            var sqlInsertPessoa = 
                $"INSERT INTO Pessoas (nome, cpf, dataNascimento) " +
                $"VALUES (@Nome, @CPF, @DataNascimento);" +
                $"SELECT SCOPE_IDENTITY();";

            connection.Open();

            var command = new SqlCommand(sqlInsertPessoa, connection);

            command.Parameters.AddWithValue("@Nome", pessoa.Nome);
            command.Parameters.AddWithValue("@CPF", pessoa.Cpf);
            command.Parameters.AddWithValue("@DataNascimento", pessoa.DataNascimento);

            //int pessoaId = Convert.ToInt32(command.ExecuteScalar());

            //var telefone = new Telefone("11", "987654321", "Celular", pessoaId);

            //var sqlInsertTelefone =                 
                //$"INSERT INTO Telefones (ddd, numero, tipo, pessoaId) " +
                //$"VALUES (@Ddd, @Numero, @Tipo, @PessoaId)";

            //command = new SqlCommand(sqlInsertTelefone, connection);
            //command.Parameters.AddWithValue("@Ddd", telefone.Ddd);
            //command.Parameters.AddWithValue("@Numero", telefone.Numero);
            //command.Parameters.AddWithValue("@Tipo", telefone.Tipo);
            //command.Parameters.AddWithValue("@PessoaId", telefone.PessoaId);

            //command.ExecuteNonQuery();

            connection.Close();

            //CRUD - Read

            connection.Open();

            // var sqlSelectPessoas = "SELECT id, nome, cpf, dataNascimento FROM Pessoas";
            var sqlSelectPessoas = 
                $"select * from Pessoas p" +
                $"\r\nLEFT JOIN Telefones t" +
                $"\r\nON p.id = t.pessoaId";

            command = new SqlCommand(sqlSelectPessoas, connection);

            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                var pessoaLida = new Pessoa(
                    reader.GetString(1),
                    reader.GetString(2),
                    DateOnly.FromDateTime(reader.GetDateTime(3))
                );
                pessoaLida.SetId(reader.GetInt32(0));

                var telefone = new Telefone(
                    reader.GetString(5),
                    reader.GetString(6),
                    reader.GetString(7),
                    reader.GetInt32(8)
                );

                Console.WriteLine(pessoaLida);
                Console.WriteLine(telefone);
            }

            connection.Close();

            //CRUD - Update

            connection.Open();

            var sqlUpdatePessoa = "UPDATE Pessoas SET nome = @Nome WHERE id = @Id";

            command = new SqlCommand(sqlUpdatePessoa, connection);
            command.Parameters.AddWithValue("@Nome", "Teste Silva");
            command.Parameters.AddWithValue("@Id", 1);

            //command.ExecuteNonQuery();

            connection.Close();

            //CRUD - Delete

            connection.Open();

            var sqlDeletePessoa = "DELETE FROM Pessoas WHERE id = @Id";

            command = new SqlCommand(sqlDeletePessoa, connection);
            command.Parameters.AddWithValue("@Id", 5);

            //command.ExecuteNonQuery();

            connection.Close();
        }
    }
}
