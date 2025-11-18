using Microsoft.Data.SqlClient;

namespace ConsoleSQL
{
    internal class Program
    {
        static void Main()
        {
            using var connection = new SqlConnection(DBConnection.GetConnectionString());

            #region Create
            //CRUD - Create

            /*
            connection.Open();

            var pessoa = new Pessoa("Pocoyo violento", "666", new DateOnly(2002, 4, 9));

            var sqlInsertPessoa =
                $"INSERT INTO Pessoas (nome, cpf, dataNascimento) " +
                $"VALUES (@Nome, @CPF, @DataNascimento);" +
                $"SELECT SCOPE_IDENTITY();";

            var command = new SqlCommand(sqlInsertPessoa, connection);

            command.Parameters.AddWithValue("@Nome", pessoa.Nome);
            command.Parameters.AddWithValue("@CPF", pessoa.Cpf);
            command.Parameters.AddWithValue("@DataNascimento", pessoa.DataNascimento);

            int pessoaId = Convert.ToInt32(command.ExecuteScalar());

            var telefone = new Telefone("11", "987654321", "Celular", pessoaId);

            var sqlInsertTelefone =
                $"INSERT INTO Telefones (ddd, numero, tipo, pessoaId) " +
                $"VALUES (@Ddd, @Numero, @Tipo, @PessoaId)";

            command = new SqlCommand(sqlInsertTelefone, connection);
            command.Parameters.AddWithValue("@Ddd", telefone.Ddd);
            command.Parameters.AddWithValue("@Numero", telefone.Numero);
            command.Parameters.AddWithValue("@Tipo", telefone.Tipo);
            command.Parameters.AddWithValue("@PessoaId", telefone.PessoaId);

            command.ExecuteNonQuery();

            var endereco = new Endereco(
                "Rua dos Cria",
                666,
                "Casa dos Guri", 
                "Liúrnia dos Lagos", 
                "Caelid",
                "ER",
                "1234567890",
                pessoaId);

            var sqlInsertEndereco = 
                $"INSERT INTO Enderecos " +
                $"VALUES (@logradouro, @numero, @complemento, @bairro," +
                $"@cidade, @estado, @cep, @PessoaId)";

            command = new SqlCommand(sqlInsertEndereco, connection);
            command.Parameters.AddWithValue("@logradouro", endereco.Logradouro);
            command.Parameters.AddWithValue("@numero", endereco.Numero);
            command.Parameters.AddWithValue("@complemento", endereco.Complemento);
            command.Parameters.AddWithValue("@bairro", endereco.Bairro);
            command.Parameters.AddWithValue("@cidade", endereco.Cidade);
            command.Parameters.AddWithValue("@estado", endereco.Estado);
            command.Parameters.AddWithValue("@cep", endereco.Cep);
            command.Parameters.AddWithValue("@PessoaId", endereco.PessoaId);

            command.ExecuteNonQuery();

            connection.Close();
            */
            #endregion

            #region Read
            //CRUD - Read

            /*
            connection.Open();

            var sqlSelectPessoas =
                "select " +
                "p.id, " +
                "p.nome, " +
                "p.cpf, " +
                "p.dataNascimento, " +
                "e.logradouro, " +
                "e.numero, " +
                "e.complemento, " +
                "e.bairro, " +
                "e.cidade, " +
                "e.estado, " +
                "e.cep, " +
                "t.ddd, " +
                "t.numero, " +
                "t.tipo " +
                "from Pessoas p " +
                "LEFT JOIN Enderecos e " +
                "ON e.pessoaId = p.id " +
                "LEFT JOIN Telefones t " +
                "ON p.id = t.pessoaId ";

            var command = new SqlCommand(sqlSelectPessoas, connection);

            var reader = command.ExecuteReader();

            List<Pessoa> pessoaLida = new List<Pessoa>();

            while (reader.Read())
            {
                int id = reader.GetInt32(0);

                var pessoaExistente = pessoaLida.FirstOrDefault(x => x.Id == id);

                var novaPessoa = new Pessoa(
                    reader.GetString(1),
                    reader.GetString(2),
                    DateOnly.FromDateTime(reader.GetDateTime(3))
                );

                var endereco = new Endereco(
                reader.GetString(4),
                reader.IsDBNull(5) ? 0 : reader.GetInt32(5),
                reader.IsDBNull(6) ? "" : reader.GetString(6),
                reader.GetString(7),
                reader.GetString(8),
                reader.GetString(9),
                reader.GetString(10),
                id);

                var telefone = new Telefone(
                reader.GetString(11),
                reader.GetString(12),
                reader.GetString(13),
                id);

                if (pessoaExistente is not null)
                {
                    pessoaExistente.Telefones.Add(telefone);
                    pessoaExistente.Enderecos.Add(endereco);
                    continue;
                }

                novaPessoa.SetId(id);
                
                novaPessoa.Telefones.Add(telefone);

                novaPessoa.Enderecos.Add(endereco);

                pessoaLida.Add(novaPessoa);
            }

            foreach (var p in pessoaLida)
            {
                Console.WriteLine(p);
                Console.WriteLine("------------");
            }

            connection.Close();
            */
            #endregion

            #region Update
            //CRUD - Update

            /*
            connection.Open();

            var sqlUpdatePessoa = "UPDATE Pessoas SET nome = @Nome WHERE id = @Id";

            command = new SqlCommand(sqlUpdatePessoa, connection);
            command.Parameters.AddWithValue("@Nome", "Teste Silva");
            command.Parameters.AddWithValue("@Id", 1);

            command.ExecuteNonQuery();

            connection.Close();
            */
            #endregion

            #region Delete
            //CRUD - Delete

            /*
            connection.Open();

            var sqlDeletePessoa = "DELETE FROM Pessoas WHERE id = @Id";

            command = new SqlCommand(sqlDeletePessoa, connection);
            command.Parameters.AddWithValue("@Id", 5);

            command.ExecuteNonQuery();

            connection.Close();
            */
            #endregion
        }
    }
}
