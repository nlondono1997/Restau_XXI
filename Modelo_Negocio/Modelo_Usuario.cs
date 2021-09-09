using System;
using Conexion;
using Capa_Transversal;

namespace Modelo_Negocio
{
    public class Modelo_Usuarios
    {
        UsuariosDao usuariosDAO = new UsuariosDao();
        public bool IngresoUsuario(string usuario, string contraseña)
        {
            return usuariosDAO.Ingreso(usuario, contraseña);
        }
        public bool editContraseña(int usuario, string contraseña)
        {
            if (usuario == CacheInicioSesion.ID)
            {

            }
            return true;
        }
    }
}
