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
using Business;
using Entity;

namespace Semana04
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

        private void BtnConsultar_Click(object sender, RoutedEventArgs e)
        {
            BPedido bPedido = null;
            try
            {
                bPedido = new BPedido();
                dgvPedido.ItemsSource = bPedido.GetPedidosEntreFechas(
                    Convert.ToDateTime(txtFechaInicio.Text),
                    Convert.ToDateTime(txtFechaFin.Text));
            }
            catch (Exception)
            {
                MessageBox.Show("Comunicarse con el administrador");
            }
            finally
            {
                bPedido = null;
            }
        }

        private void DgvPedido_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BDetalleDePedido bDetalleDePedido = null;
            try
            {
                int idpedido;
                EnPedido pedido = (EnPedido)dgvPedido.SelectedItem;
                idpedido = pedido.IdPedido;
                bDetalleDePedido = new BDetalleDePedido();
                dgvDetallePedido.ItemsSource = bDetalleDePedido.GetEDetalleDePedidosPorId(idpedido);
                txtTotal.Text = bDetalleDePedido.GetDetalleTotalPorId(idpedido).ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                bDetalleDePedido = null;
            }
        }
    }
}