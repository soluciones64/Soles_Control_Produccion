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
using System.Windows.Shapes;

namespace CrtProduccion.vistas
{
    /// <summary>
    /// Interaction logic for VehiculoPartesBRWfrm.xaml
    /// </summary>
    public partial class VehiculoPartesBRWfrm : Window
    {
        public int idParte = 0;
        System.Data.DataSet dsGrid = new System.Data.DataSet();

        public VehiculoPartesBRWfrm()
        {
            InitializeComponent();
        }

        private void DataG_Loaded(object sender, RoutedEventArgs e)
        {
            llenaGrid();
        }

        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.idParte = 0;
            this.DialogResult = false;
        }


        public void llenaGrid()
        {

            dsGrid.Clear();

            dsGrid = datamanager.ConsultaDatos("select * from  Vehiculo_Partes order By Descripcion");

            DataG.ItemsSource = dsGrid.Tables[0].DefaultView;

            DataG.CanUserAddRows = false;
            DataG.Columns[0].Width = 25;
            DataG.Columns[0].IsReadOnly = true;
            DataG.Columns[0].Header = "idParte";
            DataG.Columns[0].CanUserResize = false;

            DataG.Columns[1].IsReadOnly = true;
            DataG.Columns[1].Width = 175;
            DataG.Columns[1].Header = "Referencia ";
            DataG.Columns[1].CanUserResize = false;


            DataG.Columns[2].IsReadOnly = true;
            DataG.Columns[2].Width = 175;
            DataG.Columns[2].Header = "Descripción";
            DataG.Columns[2].CanUserResize = false;

            DataG.Columns[3].IsReadOnly = true;
            DataG.Columns[3].Width = 25;
            DataG.Columns[3].Header = "idSuplidor";
            DataG.Columns[3].CanUserResize = false;

            DataG.Columns[4].IsReadOnly = true;
            DataG.Columns[4].Width = 50;
            DataG.Columns[4].Header = "Precio";
            DataG.Columns[4].CanUserResize = false;

            DataG.Columns[5].IsReadOnly = true;
            DataG.Columns[5].Width = 50;
            DataG.Columns[5].Header = "Existencia";
            DataG.Columns[5].CanUserResize = false;

            datamanager.ConexionCerrar();
        }
        private void DataG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object item = DataG.SelectedItem;
            object item1 = DataG.SelectedItem;

            string sidUGrupo = (DataG.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;

            if (!Int32.TryParse(sidUGrupo, out idParte))
            {
                idParte = 0;
            }
            else
            {
                btnAceptar.IsEnabled = true;
                btnAceptar_png.IsEnabled = true;
            }
        }
        private void DataG_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (sender != null)
            {
                DataGridRow dgr = sender as DataGridRow;
                this.DialogResult = true;
            }
        }
    }
}