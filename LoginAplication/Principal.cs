using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;


namespace LoginAplication
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            //Se llama a la conexion con la base de datos
            //Se crea un objeto tipo de SQL que sera el puente para la conexion a la base de datos
            SqlConnection conexion = new SqlConnection("Server = PC\\EQUIPO ; Database = SISTEMA; INTEGRATED SECURITY = true");

            //Hacemos la consulta con el objeto de tipo SQL command a la base de datos
            SqlCommand cmd = new SqlCommand("SELECT USUARIO, PASSWORD FROM TBLPERSONA", conexion);

            //Se crea un objeto Data Apdapter que ejecute la consulta
            SqlDataAdapter sqlData = new SqlDataAdapter(cmd);

            //Hacemos un datatable
            DataTable tbl = new DataTable(); // Tabla vacia
            sqlData.Fill(tbl); //Llenamos la tabla con lo que tenemos en el Sqladapter
            dtgusuarios.DataSource = tbl; //Lenamos el data grid view con la informacion del SQL Adapter de la tabla 
        }
    }

}
