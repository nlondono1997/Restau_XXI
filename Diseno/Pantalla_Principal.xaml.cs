using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Capa_Transversal;
using System.ComponentModel; // CancelEventArgs
using Diseno.Properties;


namespace Diseno
{
    /// <summary>
    /// Lógica de interacción para Pantalla_Principal.xaml
    /// </summary>
    public partial class Pantalla_Principal
    {
        public Pantalla_Principal()
        {
            InitializeComponent();
            InformacionUsuario();
        }

        private void InformacionUsuario()
        {
            LblNombre.Content = CacheInicioSesion.Nombre;
            LblRol.Content = CacheInicioSesion.Rol;
            LblCorreo.Content = CacheInicioSesion.Email;
  
        }

        private void BtnCerrarSesion_Click(object sender, EventArgs e)
        {
            Pantalla_Principal principal = new Pantalla_Principal();
            if (MessageBox.Show("¿Estas seguro de cerrar sesion?", "Cierre de Sesion", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                this.Close();
        }
    }
}