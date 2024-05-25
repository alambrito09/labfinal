using labfinal.data.data_acces;

namespace labfinal
{
    public partial class Form1 : Form
    {

        private modelo modelo;
        public Form1()
        {
            InitializeComponent();
            modelo = new modelo("localhost", "root", "root");  
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (modelo.ProbarConexion())
            {
                MessageBox.Show("Conexión exitosa");
            }
            else
            {
                MessageBox.Show("Error en la conexión");
            }
        }
    }
}
