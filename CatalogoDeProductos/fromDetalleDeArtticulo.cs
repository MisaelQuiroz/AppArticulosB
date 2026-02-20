using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dominio;
using Negocio; 


namespace CatalogoDeProductos
{
    public partial class fromDetalleDeArtticulo : Form
    {
        private Articulo articulo = null;

        
        public fromDetalleDeArtticulo()
        {
            InitializeComponent();
            
        }
        public fromDetalleDeArtticulo(Articulo articulo)
        {
            InitializeComponent();
            this.articulo = articulo;
            Text = "Modificar articulo  ";
        }

        private void fromDetalleDeArtticulo_Load(object sender, EventArgs e)
        {
            if (articulo != null)
            {
               
                cargarImagen1(articulo.ImagenUrl);
                cargarTexto(articulo.Nombre);
                cargarTexto(articulo.Descripcion);
                cargarTexto(articulo.Marca.ToString());
                
                
                // El Id de tipo y el Id de debilidad se deben de agregar a la busqueda den DB
                // en pokemon negocio. metodo listar ()
            }
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
        //        cargarImagen1(listaArticulo[0].ImagenUrl);
        //        ocultarColumnas();


        //    }
        //    catch (Exception ex)
        //    {

        //        MessageBox.Show(ex.ToString());
        //    }
        //}
        private void cargarImagen1(string imagen)
        {
            try
            {
                pbxDetalleArticulo.Load(imagen);

            }
            catch (Exception ex)
            {
                pbxDetalleArticulo.Load("https://developers.elementor.com/docs/assets/img/elementor-placeholder-image.png");
            }
        }
        private void cargarTexto(string texto)
        {
            try
            {
                if (articulo != null)
                {
                    lblNombre.Text = articulo.Nombre;
                    lblDescripcion.Text = articulo.Descripcion;
                    lblCategoria.Text = articulo.Categoria.ToString();
                    lblMarca.Text = articulo.Marca.ToString();
                }

            }
            catch (Exception ex)
            {
                pbxDetalleArticulo.Load("https://developers.elementor.com/docs/assets/img/elementor-placeholder-image.png");
            }
        }

        
    }
}
