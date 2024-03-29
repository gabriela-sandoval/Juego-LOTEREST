﻿using System;
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

namespace Juego_LOTEREST
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void buttonSiguienteIniciarSesion_Click(object sender, RoutedEventArgs e)
        {
            using (Models.ModelsContainer db = new Models.ModelsContainer())
            {
                var oUsuario = new Models.Usuario();
                oUsuario.nombre = textBoxNombreDeUsuarioCrearCuenta.Text;
                oUsuario.email = textBoxCorreoElectronicoCrearCuenta.Text;
                oUsuario.contrasena = PasswordBoxContraseniaCrearCuenta.Password;

                db.Usuarios.Add(oUsuario);
                db.SaveChanges();
            }
        }

        private void buttonIngresarIniciarSesion_Click(object sender, RoutedEventArgs e)
        {
            using (Models.ModelsContainer db = new Models.ModelsContainer())
            {

                foreach (var oUsuario in db.Usuarios)
                {
                    if ((oUsuario.email.Equals(textBoxCorreoElectronicoIniciarSesion.Text)) && (oUsuario.contrasena.Equals(passwordBoxContraseniaIniciarSesion.Password)))
                    {
                        MessageBox.Show("Coincide el correo y la contraseña");
                    }
                }
            }
        }
    }
}
