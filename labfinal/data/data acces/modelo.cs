using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labfinal.data.data_acces
{
    internal class modelo
    {
        private string connectionString = "Server=localhost;Database=tareabase;Uid=root;Pwd=root;";
        MySqlConnection connection;
        public modelo()
        {
            connection = new MySqlConnection(connectionString);
        }
        public modelo(string servidor, string usur, string pwd)
        {
            connectionString = "Server=" + servidor + ";Database=tareabase;Uid=" + usur + ";Pwd=" + pwd + ";";
        }
        public bool ProbarConexion()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
        public void Insertar(int id, string nombreconsola, string compañia, DateTime fechalanzamiento, int generacion)
        {
            try
            {
                string query = "INSERT INTO Usuarios (Nombre, Apellido, FechaNacimiento, Email, Saldo, Activo) VALUES (@Nombre, @Apellido, @FechaNacimiento, @Email, @Saldo, @Activo)";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Nombre", nombre);
                cmd.Parameters.AddWithValue("@Apellido", apellido);
                cmd.Parameters.AddWithValue("@FechaNacimiento", fechaNacimiento);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Saldo", saldo); //decimal.Parse(txtSaldo.Text)
                cmd.Parameters.AddWithValue("@Activo", activo);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar el registro: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        public void Actualizar(int id, string nombre, string apellido, DateTime fechaNacimiento, string email, decimal saldo, bool activo)
        {
            try
            {
                string query = "UPDATE Usuarios SET Nombre = @Nombre, Apellido = @Apellido, FechaNacimiento = @FechaNacimiento, Email = @Email, Saldo = @Saldo, Activo = @Activo WHERE ID = @ID";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters.AddWithValue("@Nombre", nombre);
                cmd.Parameters.AddWithValue("@Apellido", apellido);
                cmd.Parameters.AddWithValue("@FechaNacimiento", fechaNacimiento);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Saldo", saldo);
                cmd.Parameters.AddWithValue("@Activo", activo);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el registro: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        public DataTable LeerTodos()
        {
            DataTable dt = new DataTable();
            try
            {
                string query = "SELECT * FROM Usuarios";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                connection.Open();
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al leer los registros: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return dt;
        }
        public DataRow LeerPorId(int id)
        {
            DataTable dt = new DataTable();
            try
            {
                string query = "SELECT * FROM Usuarios WHERE ID = @ID";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@ID", id);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                connection.Open();
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al leer el registro: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return dt.Rows[0];
        }
        public void Eliminarconsola(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string sql = "DELETE FROM personajes_dragon_ball WHERE id = @id";
                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@id", id);

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
