using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CatalogoDeProductos
{
    public partial class LoginAdministrador : Form
    {
        
        public LoginAdministrador()
        {
            InitializeComponent();
        }

        private void LoginAdministrador_Load(object sender, EventArgs e)
        {
            
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {



            try
            {
                if (!(string.IsNullOrWhiteSpace(txbCuenta.Text) || (string.IsNullOrWhiteSpace(txbContraseña.Text))))
                {
                    string cuenta =(txbCuenta.Text);
                    string contraseña = (txbContraseña.Text);

                    if (!(soloNumeros(txbContraseña.Text)))
                    {
                        MessageBox.Show("Ingresa solo numeros para contraseña");
                        return ;
                    }

                    if (contraseña.Equals("12345") & cuenta.Equals("misa.92@hotmail.com"))
                    {

                        FormPrincipal nueva = new FormPrincipal();
                        nueva.ShowDialog();

                    }
                    else
                    {
                        MessageBox.Show(" La cuenta o la contraseña son incorrectas");
                    }

                }
                else 
                {
                    MessageBox.Show("Debes ingresar un valor en cuenta y contraseña");
                    
                }

            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

            
        }

        private bool soloNumeros(string cadena)
        {
            foreach (char caracter in cadena)
            {
                if (!(char.IsNumber(caracter)))
                    return false;
            }
            return true;
        }
    }
}
