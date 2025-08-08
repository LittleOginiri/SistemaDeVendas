using System.Collections.Generic;
using System.Data.SqlClient;
using SistemaVendas.Model;

namespace SistemaVendas.DAO
{
    public class UsuarioDAO
    {
        // Retorna todos os usuários cadastrados
        public IEnumerable<Usuario> ObterTodos()
        {
            var lista = new List<Usuario>();
            using var cn = Conexao.ObterConexao();
            using var cmd = cn.CreateCommand();

            cmd.CommandText =
                "SELECT id_usuario, nome, login, senha, tipo_usuario, id_cliente FROM Usuarios";

            using var rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                lista.Add(new Usuario
                {
                    IdUsuario = rdr.GetInt32(0),
                    Nome = rdr.GetString(1),
                    Login = rdr.GetString(2),
                    Senha = rdr.GetString(3),
                    TipoUsuario = rdr.GetString(4),
                    IdCliente = rdr.IsDBNull(5) ? 0 : rdr.GetInt32(5) // permite ID nulo
                });
            }
            return lista;
        }

        // Valida login e senha no banco de dados
        public Usuario ValidarLogin(string login, string senha)
        {
            using var cn = Conexao.ObterConexao();
            using var cmd = cn.CreateCommand();

            cmd.CommandText =
                @"SELECT id_usuario, nome, login, senha, tipo_usuario, id_cliente
                  FROM Usuarios
                  WHERE login = @login AND senha = @senha";

            cmd.Parameters.AddWithValue("@login", login);
            cmd.Parameters.AddWithValue("@senha", senha);

            using var rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                return new Usuario
                {
                    IdUsuario = rdr.GetInt32(0),
                    Nome = rdr.GetString(1),
                    Login = rdr.GetString(2),
                    Senha = rdr.GetString(3),
                    TipoUsuario = rdr.GetString(4),
                    IdCliente = rdr.IsDBNull(5) ? 0 : rdr.GetInt32(5)
                };
            }

            return null;
        }

        // Recupera um usuário pelo ID
        public Usuario ObterPorId(int id)
        {
            using var cn = Conexao.ObterConexao();
            using var cmd = cn.CreateCommand();

            cmd.CommandText =
                @"SELECT id_usuario, nome, login, senha, tipo_usuario, id_cliente
                  FROM Usuarios
                  WHERE id_usuario = @id";

            cmd.Parameters.AddWithValue("@id", id);

            using var rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                return new Usuario
                {
                    IdUsuario = rdr.GetInt32(0),
                    Nome = rdr.GetString(1),
                    Login = rdr.GetString(2),
                    Senha = rdr.GetString(3),
                    TipoUsuario = rdr.GetString(4),
                    IdCliente = rdr.IsDBNull(5) ? 0 : rdr.GetInt32(5)
                };
            }

            return null;
        }

        // Insere novo usuário
        public void Inserir(Usuario u)
        {
            using var cn = Conexao.ObterConexao();
            using var cmd = cn.CreateCommand();

            cmd.CommandText =
                @"INSERT INTO Usuarios (nome, login, senha, tipo_usuario, id_cliente)
                  VALUES (@nome, @login, @senha, @tipo, @cliente)";

            cmd.Parameters.AddWithValue("@nome", u.Nome);
            cmd.Parameters.AddWithValue("@login", u.Login);
            cmd.Parameters.AddWithValue("@senha", u.Senha);
            cmd.Parameters.AddWithValue("@tipo", u.TipoUsuario);
            cmd.Parameters.AddWithValue("@cliente", u.IdCliente);

            cmd.ExecuteNonQuery();
        }

        // Atualiza dados do usuário
        public void Atualizar(Usuario u)
        {
            using var cn = Conexao.ObterConexao();
            using var cmd = cn.CreateCommand();

            cmd.CommandText =
                @"UPDATE Usuarios
                  SET nome        = @nome,
                      login       = @login,
                      senha       = @senha,
                      tipo_usuario= @tipo,
                      id_cliente  = @cliente
                  WHERE id_usuario = @id";

            cmd.Parameters.AddWithValue("@nome", u.Nome);
            cmd.Parameters.AddWithValue("@login", u.Login);
            cmd.Parameters.AddWithValue("@senha", u.Senha);
            cmd.Parameters.AddWithValue("@tipo", u.TipoUsuario);
            cmd.Parameters.AddWithValue("@cliente", u.IdCliente);
            cmd.Parameters.AddWithValue("@id", u.IdUsuario);

            cmd.ExecuteNonQuery();
        }

        // Remove um usuário pelo ID
        public void Excluir(int id)
        {
            using var cn = Conexao.ObterConexao();
            using var cmd = cn.CreateCommand();

            cmd.CommandText =
                "DELETE FROM Usuarios WHERE id_usuario = @id";

            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }
    }
}
