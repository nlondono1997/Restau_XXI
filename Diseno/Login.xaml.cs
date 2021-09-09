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
using MahApps.Metro.Controls;
using System.Runtime.InteropServices;
using Modelo_Negocio;
using Diseno;

namespace Diseno
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class Login
    {
        public Login()
        {
            InitializeComponent();
            LblError.Visibility =Visibility.Hidden;
        }



        //Mensaje de error
        private void msgError(string msg)
        {
            LblError.Content = "     " + msg;
            LblError.Visibility = Visibility.Visible;
        }

        //----------------------------------

        public void CerrarSesion(object sender, EventArgs e)
        {
            TxtUsuario.Text = "";
            TxtContrasena.Text = "";
            LblError.Visibility = Visibility.Hidden;
            this.Show();
            //txtUsuario.Focus();
        }

        private void BtnAcceder_Click(object sender, RoutedEventArgs e)
        {
            if (TxtUsuario.Text != "")
            {
                if (TxtContrasena.Text != "")
                {
                    Modelo_Usuarios usuario = new Modelo_Usuarios();
                    var IngresoValido = usuario.IngresoUsuario(TxtUsuario.Text, TxtContrasena.Text);
                    if (IngresoValido == true)
                    {
                        Pantalla_Principal mainManu = new Pantalla_Principal();
                        mainManu.Show();
                        mainManu.Closed += CerrarSesion;
                        this.Hide();
                    }
                    else
                        msgError("Usuario o Contraseña invalido.");
                    TxtContrasena.Clear();
                    TxtUsuario.Focus();
                }
                else
                    msgError("Porfavor Ingresa tu contraseña.");
            }
            else
                msgError("Porfavor Ingresa tu usuario.");
        }

        private void MetroWindow_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
