using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dominio;
using Negocio;
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace CatalogoDeProductos
{
    public partial class formNuevoArticulo : Form
    {
        private Articulo articulo = null;
        private OpenFileDialog archivo = null;

        public formNuevoArticulo()
        {
            InitializeComponent();
        }
        public formNuevoArticulo(Articulo articulo)
        {
            InitializeComponent();
            this.articulo = articulo;
            Text = "Modificar articulo  "; 
        }

        private void formNuevoArticulo_Load(object sender, EventArgs e)
        {
            MarcasNegocio marcasNegocio = new MarcasNegocio();
            CategoriasNegocio categoriaNegocio = new CategoriasNegocio();   
            try
            {
                // los cbx. para que solo deje seleccionar lo que existe en la lista 
                // en la parte de diseño , activar la propiedad DropDown Style. " Dropdow list" 

                // ValueMember y DisplayMember es para mostrar un codigo y un valor 
                // en este caso el codigo e Id y el valor es la descripción.
                // Sirve para la siguiente validación al precargar los datos que ya tenia en tabla
                // El pokemon que pasan por parametro al modificar 
                cbxAgregarMarca.DataSource = marcasNegocio.listar();
                cbxAgregarMarca.ValueMember = "Id";
                cbxAgregarMarca.DisplayMember = "Descripcion";
                cbxAgregarCategoria.DataSource = categoriaNegocio.listar();
                cbxAgregarCategoria.ValueMember = "Id";
                cbxAgregarCategoria.DisplayMember = "Descripcion";


                // Esta validación es para que se precargue la ventana al seleccionar "modificar"
                // el pokemon de la validacion es el pokemon pasado por paametro 
                // si no esta null . ya estas en modificacion 
                if (articulo != null)
                {
                    txbAgregarCodigo.Text = articulo.Codigo.ToString();
                    txbSumarNombre.Text = articulo.Nombre;
                    txbAgregarDescripcion.Text = articulo.Descripcion;
                    txbAgregarImagen.Text = articulo.ImagenUrl;
                    cargarImagen(articulo.ImagenUrl);

                    cbxAgregarMarca.SelectedValue = articulo.Marca.Id;
                    cbxAgregarCategoria.SelectedValue = articulo.Categoria.Id;
                    txbAgregarPrecio.Text = articulo.Precio.ToString();
                    
                    // El Id de tipo y el Id de debilidad se deben de agregar a la busqueda den DB
                    // en pokemon negocio. metodo listar ();
                    

                }
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
                pbxImagenUrl.Load(imagen);
            }
            catch (Exception ex)
            {
                pbxImagenUrl.Load(" https://developers.elementor.com/docs/assets/img/elementor-placeholder-image.png");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            try
            {
                if (articulo == null)
                    articulo = new Articulo();

                articulo.Codigo = txbAgregarCodigo.Text.ToString();
                articulo.Nombre = txbSumarNombre.Text;
                articulo.Descripcion = txbAgregarDescripcion.Text;
                articulo.ImagenUrl = txbAgregarImagen.Text;
                articulo.Marca = (Marcas)cbxAgregarMarca.SelectedItem;
                articulo.Categoria =(Categorias)cbxAgregarCategoria.SelectedItem;
                articulo.Precio = decimal.Parse( txbAgregarPrecio.Text);

                if (articulo.Id != 0)
                {
                    negocio.modificar(articulo);
                    MessageBox.Show("Modificado exitosamente");
                }
                else 
                {
                    negocio.agregar(articulo);
                    MessageBox.Show("Agregado exitosamentre");
                }



            }
            catch (Exception ex)
            {

               MessageBox.Show (ex.ToString ());
            }
        }

        private void btnAgregarLocal_Click(object sender, EventArgs e)
        {
        
            archivo = new OpenFileDialog(); // con esta se abre la ventana 
            archivo.Filter = ("jpg|*.jpg| png|*.png");// con esta se filtran archivos jpg 
            if (archivo.ShowDialog() == DialogResult.OK)
            {
                txbAgregarImagen.Text = archivo.FileName;
                cargarImagen(archivo.FileName);
                //para guardar la imagen en la carpeta lo siguiente
            }
        
    }
    }
}
