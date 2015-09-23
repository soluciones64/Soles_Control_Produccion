﻿using System.Windows;


namespace CrtProduccion
{
    /// <summary>
    /// Interaction logic for iniciofrm.xaml
    /// </summary>
    public partial class iniciofrm : Window
    {

        public iniciofrm()
        {

            // Controla el acceso al sistema.
            segLoginfrm dlg = new segLoginfrm();
            dlg.ShowDialog();
            if (dlg.DialogResult.HasValue == false)
                Application.Current.Shutdown();
            else
            {

                // Validar que el usuario logueado tiene acceso al sistema.
                if (!datamanager.probarPermiso("0", "acceso") || dlg.DialogResult.Value == false)
                {
                    if (dlg.DialogResult.Value != false)
                        MessageBox.Show("No tiene acceso al sistema.", "Seguridad", MessageBoxButton.OK, MessageBoxImage.Error);

                    Close();
                }

                // Iniciar todos los componentes del menu principal
                InitializeComponent();
                opcionesEstado();
            }

        }


        private void opcionesEstado()
        {
            mainHerramientas.IsEnabled = datamanager.probarPermiso("H", "acceso");
            herCambioClave.IsEnabled = datamanager.probarPermiso("H00", "acceso");

            #region Heramientas de Seguridad
            // Opcion de Herramienta - Seguridad
            herSeguridad.IsEnabled = datamanager.probarPermiso("HS01", "acceso");

            // Opciones de Seguridad
            segUsuario.IsEnabled = datamanager.probarPermiso("HS0101", "acceso");
            segGrupo.IsEnabled = datamanager.probarPermiso("HS0102", "acceso");
            segAsignaGrupo.IsEnabled = datamanager.probarPermiso("HS0103", "acceso");
            segPerfilGrupo.IsEnabled = datamanager.probarPermiso("HS0104", "acceso");
            segPerfilUsuario.IsEnabled = datamanager.probarPermiso("HS0105", "acceso");
            #endregion

        }


        #region Opciones de Seguridad
        private void segUsuario_Click(object sender, RoutedEventArgs e)
        {
            segUsuariofrm dlg = new segUsuariofrm();
            dlg.ShowDialog();
        }


        private void segGrupo_Click(object sender, RoutedEventArgs e)
        {
            segGrupofrm dlg = new segGrupofrm();
            dlg.ShowDialog();
        }

        private void segAsignaGrupo_Click(object sender, RoutedEventArgs e)
        {
            segGrupoAsignafrm dlg = new segGrupoAsignafrm();
            dlg.ShowDialog();
        }

        private void segPerfilGrupo_Click(object sender, RoutedEventArgs e)
        {
            segGrupoPerfilfrm dlg = new segGrupoPerfilfrm();
            dlg.ShowDialog();
        }

        private void segPerfilUsuario_Click(object sender, RoutedEventArgs e)
        {
            segUsuarioPerfilfrm dlg = new segUsuarioPerfilfrm();
            dlg.ShowDialog();
        }

        private void mainSalir_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Seguro que Desea Salir ?", "Salir",
                MessageBoxButton.YesNo, MessageBoxImage.Warning) != MessageBoxResult.No)
                Close();
        } 
        #endregion


    }
}

