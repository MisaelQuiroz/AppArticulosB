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
using System.Xml.Linq;


 

namespace CatalogoDeProductos
{
    public partial class FormPrincipal : Form
    {
        private List<Articulo> listaArticulo;
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cargar();
            cbxCampo.Items.Add("Marca");
            cbxCampo.Items.Add("Categoria");
            
        }
        private void cbxCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string opcion = cbxCampo.SelectedItem.ToString();


            if (opcion == "Marca")
            {
                cbxCriterio.Items.Clear();
                cbxCriterio.Items.Add("Samsung");
                cbxCriterio.Items.Add("Apple");
                cbxCriterio.Items.Add("Sony");
                cbxCriterio.Items.Add("Huawei");
                cbxCriterio.Items.Add("Motorola");


            }
            if (opcion == "Categoria")
            {
                cbxCriterio.Items.Clear();
                cbxCriterio.Items.Add("Celular");
                cbxCriterio.Items.Add("Television");
                cbxCriterio.Items.Add("Media");
                cbxCriterio.Items.Add("Audio");

            }
            
        }



        private void cargar()
        {
            ArticuloNegocio Negocio = new ArticuloNegocio();
            // este metodo se encapsula en un try y se relaciona con la validación del la variable 
            //aux.UrlImagen para campos en estadoo NULL 
            try
            {
                listaArticulo = Negocio.listar();
                dgvArticulos.DataSource = listaArticulo;
                cargarImagen(listaArticulo[0].ImagenUrl);


                //ocultarcolumnas();


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
        //private void ocultarColumnas()
        //{
        //    dgvArticulos.Columns["IdMarca"].Visible = true;


        //}

        private void cargarImagen(string imagen)
        {
            try
            {
                pbxArticulos.Load(imagen);
            }
            catch (Exception ex)
            {
                pbxArticulos.Load("https://developers.elementor.com/docs/assets/img/elementor-placeholder-image.png");
            }
        }

        private void dgvArticulos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvArticulos.CurrentRow != null)
            {
                Articulo seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem; // LE indicas. De la grilla dgvpokemons, de la primer fila, traeme el objeto cargado
                cargarImagen(seleccionado.ImagenUrl);

            }

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            try
            {
                if (validarFiltro())
                    return;

                string campo = cbxCampo.SelectedItem.ToString();
                string criterio = cbxCriterio.SelectedItem.ToString();
                //string filtro = txbFiltro.Text;
                dgvArticulos.DataSource = negocio.filtrar(campo, criterio);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
        private bool validarFiltro()
        {
            if (cbxCampo.SelectedIndex < 0)
            {
                MessageBox.Show("Selecciona un marca");
            }
            if (cbxCriterio.SelectedIndex < 0)
            {
                MessageBox.Show("Selecciona una categoria");
                return true;
            }

            //if (cbxCampo.SelectedItem.ToString() == "Codigo")
            //{
            //    if (!(soloNumeros(txbFiltro.Text)))
            //    {
            //        MessageBox.Show("Ingresa solo numeros para filtrar un campo nuérico ");
            //        return true;
            //    }
            //}
            return false;
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

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            formNuevoArticulo alta = new formNuevoArticulo();
            alta.ShowDialog();
            cargar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Articulo seleccionado;
            seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
            //aqui se crea un nuevo pokemon llamado seleccionado . 
            // a partir de la lista. Seria el Pokemon seleccionado en el current 

            // Se le pasa por parametro el pokemon seleccionado.
            // En el codigo de la ventana o clase frmNuevoPok 
            // Se tiene que duplicar el constructor indicando que se pasara por parametro 
            // Un nuevo pokemon 
            formNuevoArticulo modificar = new formNuevoArticulo(seleccionado);
            modificar.ShowDialog();
            cargar();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            eliminar();
        }
        private void eliminar()
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            Articulo seleccionado;

            try
            {
                DialogResult respuesta = MessageBox.Show("De verdad quieres eliminarlo", "Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (respuesta == DialogResult.Yes)
                {
                    seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                    negocio.eliminar(seleccionado.Id);
                    

                    cargar();

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        //private void btnBorrar_Click(object sender, EventArgs e)
        //{
        //    eliminar();
        //}
    }
}
