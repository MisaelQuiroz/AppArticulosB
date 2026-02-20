using dominio;
using Negocio; 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CatalogoDeProductos
{
    public partial class PantallaIniciofrm : Form
    {
        //private List<Articulo> listaArticulo;

        public PantallaIniciofrm()
        {
            InitializeComponent();
        }

        private void PantallaInicio_Load(object sender, EventArgs e)
        {
            try
            {
                pbxZorroAbarrotero.Load("https://www.mundoejecutivo.com.mx/wp-content/uploads/2023/03/zorro-abarrotero.jpg");
            }
            catch (Exception ex)
            {
                pbxZorroAbarrotero.Load("https://developers.elementor.com/docs/assets/img/elementor-placeholder-image.png");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PantallaCatalogo alta = new PantallaCatalogo();
            alta.ShowDialog();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoginAdministrador alta = new LoginAdministrador();
            alta.ShowDialog();
        }

        //private void cargar()
        //{

        //    ArticuloNegocio Negocio = new ArticuloNegocio();
        //    // este metodo se encapsula en un try y se relaciona con la validación del la variable 
        //    //aux.UrlImagen para campos en estadoo NULL 
        //    try
        //    {
        //        listaArticulo = Negocio.listar();
        //        dgvPantallaCatalogo.DataSource = listaArticulo;
        //        cargarImagen(listaArticulo[0].ImagenUrl);


        //        //ocultarcolumnas();


        //    }
        //    catch (Exception ex)
        //    {

        //        MessageBox.Show(ex.ToString());
        //    }

        //}
        //private void cargarImagen(string imagen)
        //{
        //    try
        //    {
        //        pbxArticulos.Load(imagen);
        //    }
        //    catch (Exception ex)
        //    {
        //        pbxArticulos.Load("https://developers.elementor.com/docs/assets/img/elementor-placeholder-image.png");
        //    }
        //}
    }
}
