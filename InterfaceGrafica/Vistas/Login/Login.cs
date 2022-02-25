using InterfaceGrafica.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;


namespace InterfaceGrafica
{
    public partial class Login : Form
    {

        
        
        public Login()
        {
            InitializeComponent();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);


        private void Login_Load(object sender, EventArgs e)
        {
            
            lblDireccionIP.Text = $"Direccion IP : {Conexion.getLocalIPAddressWithNetworkInterface(NetworkInterfaceType.Ethernet)}";
            string direccionIP = Conexion.getLocalIPAddressWithNetworkInterface(NetworkInterfaceType.Ethernet);

            if (direccionIP.Equals("192.168.100.30"))
            {
                try
                {
                    SqlConnection con = new SqlConnection(Conexion.ConexionPruebas());
                    con.Open();

                    if (con.State > 0)
                    {
                        lblConexion.Text = "Success connection";
                        lblConexion.ForeColor = Color.GreenYellow;
                        con.Close();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se establecio la conexion " + ex.Message);
                }

            }
            else
            {
                try
                {
                    SqlConnection con = new SqlConnection(Conexion.ConexionProduccion());
                    con.Open();

                    if (con.State > 0)
                    {
                        lblConexion.Text = "Success connection";
                        lblConexion.ForeColor = Color.GreenYellow;
                        con.Close();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se establecio la conexion " + ex.Message);
                }
            }

           

            


       

        }

        private void txtUser_Enter(object sender, EventArgs e)
        {
            if (txtUser.Text == "USUARIO")
            {
                txtUser.Text = "";
                txtUser.ForeColor = Color.LightGray;
            }
        }

        private void txtUser_Leave(object sender, EventArgs e)
        {
            if (txtUser.Text == "")
            {
                txtUser.Text = "USUARIO";
                txtUser.ForeColor = Color.DimGray;
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtPass_Enter(object sender, EventArgs e)
        {
            if (txtPass.Text == "PASSWORD")
            {
                txtPass.Text = "";
                txtPass.ForeColor = Color.LightGray;
                txtPass.PasswordChar = '*';
            }
        }

        private void txtPass_Leave(object sender, EventArgs e)
        {
            if (txtPass.Text == "")
            {
                txtPass.Text = "PASSWORD";
                txtPass.ForeColor = Color.DimGray;
                
                txtPass.UseSystemPasswordChar = false;
            }
        }

        private void Login_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
