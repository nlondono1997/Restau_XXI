using System;
using Oracle.ManagedDataAccess.Client;
using Capa_Transversal;

namespace Conexion
{
    public class UsuariosDao : ConexionOracle
    {
        public bool Ingreso(string usuario, string contrasena)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new OracleCommand())
                {
                    command.Connection = connection;
                    command.CommandText = ("SELECT us.id,us.nombre||' '||us.apellidos as Nombre,us.usuario,us.contrasena,us.email, us.fono,ro.rol_descripcion,us.estado FROM usuario us JOIN roles ro ON us.rol_id = ro.rol_id where USUARIO=:usuario and CONTRASENA=:contrasena");

                    command.Parameters.Add(":usuario", usuario);
                    command.Parameters.Add(":contrasena", contrasena);
                    command.CommandType = System.Data.CommandType.Text;
                    OracleDataReader reader;
                    reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            CacheInicioSesion.ID = reader.GetInt32(0);
                            CacheInicioSesion.Nombre = reader.GetString(1);
                            CacheInicioSesion.Usuario = reader.GetString(2);
                            CacheInicioSesion.Contrasena = reader.GetString(3);
                            CacheInicioSesion.Email = reader.GetString(4);
                            CacheInicioSesion.Fono = reader.GetString(5);
                            CacheInicioSesion.Rol = reader.GetString(6);
                            CacheInicioSesion.Estado = reader.GetString(7);
                        }
                        return true;
                    }
                    else
                        return false;
                }
            }
        }
    }
}
