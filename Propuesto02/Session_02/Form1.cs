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
   
        }


        public void ListaAnios()
        {
            using (SqlCommand cmd = new SqlCommand("Usp_ListaAnios", cn))
            {
                using (SqlDataAdapter da = new SqlDataAdapter())
                {
                    da.SelectCommand = cmd;
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    using (DataSet df = new DataSet())
                    {
                        da.Fill(df, "Usp_ListaAnios");
                        CboAnio.DataSource = df.Tables["Usp_ListaAnios"];
                        CboAnio.DisplayMember = "Anios";
                        CboAnio.ValueMember = "Anios";
                    }
                }
            }
        }



        private void CboAnios_SelectionChangeCommitted(object sender, EventArgs e)
        {
            using (SqlCommand cmd = new SqlCommand("Usp_ListaMeses", cn))
            {
                using (SqlDataAdapter Da = new SqlDataAdapter())
                {
                    Da.SelectCommand = cmd;
                    Da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    Da.SelectCommand.Parameters.AddWithValue("@anio", CboAnio.SelectedValue);
                    using (DataSet df = new DataSet())
                    {
              
                        Da.Fill(df, "Usp_ListaMeses");
                        CboMes.DataSource = df.Tables["Usp_ListaMeses"];
                        CboMes.DisplayMember = "Mes";
                        CboMes.ValueMember = "Mes";
                     
                    }
                }
            }
        }

        private void CboMes_SelectionChangeCommitted(object sender, EventArgs e)
        {
            using (SqlCommand cmd = new SqlCommand("Usp_Lista_PedidosxMesXAnioTest", cn))
            {
                using (SqlDataAdapter Da = new SqlDataAdapter())
                {
                    Da.SelectCommand = cmd;
                    Da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    Da.SelectCommand.Parameters.AddWithValue("@anio", CboAnio.SelectedValue);
                    Da.SelectCommand.Parameters.AddWithValue("@mes", CboMes.SelectedValue);
                    using (DataSet df = new DataSet())
                    {
                        Da.Fill(df, "Usp_Lista_PedidosxMesXAnioTest");
                        DgPedidos.DataSource = df.Tables["Usp_Lista_PedidosxMesXAnioTest"];
                      
                    }
                }
            }
        }
    }
}
