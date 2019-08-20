using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace Session_02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Leon"].ConnectionString);
        private void Form1_Load(object sender, EventArgs e)
        {
            ListaAnios();
            ListaNombres();
        }


        public void ListaAnios()
        {
            using (SqlCommand cmd = new SqlCommand("Usp_Lista_Apellidos", cn))
            {
                using (SqlDataAdapter da = new SqlDataAdapter())
                {
                    da.SelectCommand = cmd;
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    using (DataSet df = new DataSet())
                    {
                        da.Fill(df, "Usp_Lista_Apellidos");
                        CboApe.DataSource = df.Tables["Usp_Lista_Apellidos"];
                        CboApe.DisplayMember = "Apellidos";
                        CboApe.ValueMember = "Apellidos";
                    }
                }
            }
        }


        public void ListaNombres()
        {
            using (SqlCommand cmd = new SqlCommand("Usp_Lista_Nombres", cn))
            {
                using (SqlDataAdapter da = new SqlDataAdapter())
                {
                    da.SelectCommand = cmd;
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    using (DataSet df = new DataSet())
                    {
                        da.Fill(df, "Usp_Lista_Nombres");
                        CboNom.DataSource = df.Tables["Usp_Lista_Nombres"];
                        CboNom.DisplayMember = "Nombre";
                        CboNom.ValueMember = "Nombre";
                    }
                }
            }
        }

        private void CboAnios_SelectionChangeCommitted(object sender, EventArgs e)
        {
            using (SqlCommand cmd = new SqlCommand("Usp_Lista_Busqueda", cn))
            {
                using (SqlDataAdapter Da = new SqlDataAdapter())
                {
                    Da.SelectCommand = cmd;
                    Da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    Da.SelectCommand.Parameters.AddWithValue("@apellidos", CboApe.SelectedValue);
                    using (DataSet df = new DataSet())
                    {
                        Da.Fill(df, "Empleados");
                        DgPedidos.DataSource = df.Tables["Empleados"];
                        LblNumero.Text = df.Tables["Empleados"].Rows.Count.ToString();
                    }
                }
            }
        }

        private void DgPedidos_DoubleClick(object sender, EventArgs e)
        {
            object Codigo;
            Codigo = DgPedidos.CurrentRow.Cells[0].Value;
            using (SqlCommand cmd = new SqlCommand("Usp_Lista_Busqueda", cn))
            {
                using (SqlDataAdapter Da = new SqlDataAdapter())
                {
                    Da.SelectCommand = cmd;
                    Da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    Da.SelectCommand.Parameters.AddWithValue("@anio", Codigo);
                    using (DataSet df = new DataSet())
                    {
                        Da.Fill(df, "Empleados");
                        DgDetalle.DataSource = df.Tables["Empleados"];
                        LblMonto.Text = df.Tables["Empleados"].ToString();
                    }
                }
            }
        }

        private void CboNom_SelectionChangeCommitted(object sender, EventArgs e)
        {
            using (SqlCommand cmd = new SqlCommand("Usp_Lista_Busqueda", cn))
            {
                using (SqlDataAdapter Da = new SqlDataAdapter())
                {
                    Da.SelectCommand = cmd;
                    Da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    Da.SelectCommand.Parameters.AddWithValue("@nombres", CboNom.SelectedValue);
                    using (DataSet df = new DataSet())
                    {
                        Da.Fill(df, "Empleados");
                        DgPedidos.DataSource = df.Tables["Empleados"];
                        LblNumero.Text = df.Tables["Empleados"].Rows.Count.ToString();
                    }
                }
            }
        }
    }
}
