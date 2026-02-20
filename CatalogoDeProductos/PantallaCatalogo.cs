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
    public partial class PantallaCatalogo : Form
    {
        private List<Articulo> listaArticulo;
        public PantallaCatalogo()
        {
            InitializeComponent();
            
        }

        private void PantallaCatalogo_Load(object sender, EventArgs e)
        {
            cargar();

        }
        

        private void cargar()
        {
            ArticuloNegocio Negocio = new ArticuloNegocio();
            // este metodo se encapsula en un try y se relaciona con la validación del la variable 
            //aux.UrlImagen para campos en estadoo NULL 
            try
            {
                listaArticulo = Negocio.listar();
                dgvPantallaCatalogo.DataSource = listaArticulo;
                cargarImagen(listaArticulo[0].ImagenUrl);
                ocultarColumnas ();


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
       

        private void cargarImagen(string imagen)
        {
            try
            {
                pbx1Contenedor.Load(imagen);
                
            }
            catch (Exception ex)
            {
                pbx1Contenedor.Load("https://developers.elementor.com/docs/assets/img/elementor-placeholder-image.png");
            }
        }
        



        private void ocultarColumnas()
        {
            //dgvPantallaCatalogo.Columns["IdMarca"].Visible = true;
            dgvPantallaCatalogo.Columns["Id"].Visible = false;
            dgvPantallaCatalogo.Columns["ImagenUrl"].Visible = false;
            dgvPantallaCatalogo.Columns["Precio"].Visible = false;
            dgvPantallaCatalogo.Columns["Codigo"].Visible = false;
            dgvPantallaCatalogo.Columns["Descripcion"].Visible = false;

        }

        private void dgvPantallaCatalogo_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPantallaCatalogo.CurrentRow != null)
            {
                Articulo seleccionado = (Articulo)dgvPantallaCatalogo.CurrentRow.DataBoundItem; // LE indicas. De la grilla dgvpokemons, de la primer fila, traeme el objeto cargado
                cargarImagen(seleccionado.ImagenUrl);

            }

        }

        private void dgvPantallaCatalogo_DoubleClick(object sender, EventArgs e)
        {
            
            
        }

        private void btnVerdetalle_Click(object sender, EventArgs e)
        {
            Articulo seleccionado;
            seleccionado = (Articulo)dgvPantallaCatalogo.CurrentRow.DataBoundItem;

            fromDetalleDeArtticulo detalle = new fromDetalleDeArtticulo(seleccionado);
            detalle.ShowDialog();


        }

        private void txbFiltroCliente_TextChanged(object sender, EventArgs e)
        {
            List<Articulo> listaFiltrada;
            string filtro = txbFiltroCliente.Text;

            if (filtro.Length > 3)
            {
                // al metodo Contains se le pasa por parametro lo que hay en el filtro. Devuelve verdadero o falso 
                // si la cadena del filtro tambien se encuentra en la cadena de busqueda Nombre.ToUpper 
                listaFiltrada = listaArticulo.FindAll(x => x.Nombre.ToUpper().Contains(filtro.ToUpper()) || x.Marca.Descripcion.ToUpper().Contains(filtro.ToUpper()));
            }
            else
            {
                listaFiltrada = listaArticulo;
            }

            dgvPantallaCatalogo.DataSource = null;
            dgvPantallaCatalogo.DataSource = listaFiltrada;
            ocultarColumnas();
        }
    }
}
