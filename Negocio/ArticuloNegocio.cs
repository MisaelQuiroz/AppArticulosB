using dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ArticuloNegocio
    {

        public List<Articulo> listar()
        {
            List<Articulo> lista = new List<Articulo>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            try
            {
                conexion.ConnectionString = " server = .\\SQLEXPRESS ; database = CATALOGO_DB ; integrated security = true ";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "Select A.Id, Codigo, Nombre, A.Descripcion,M.Descripcion Marca, C.Descripcion Categoria,IdMarca, IdCategoria, ImagenUrl, A.Precio from CATEGORIAS C, MARCAS M, ARTICULOS A Where A.IdMarca = M.Id And A.IdCategoria = C.Id "; //  , M.Id , C.Id,ImagenUrl,Where M.Id = A.IdMarca And C.Id = A.IdCategoria"
                comando.Connection = conexion;

                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Articulo aux = new Articulo();


                    aux.Id = (int)lector["Id"];
                    aux.Codigo = (string)lector["Codigo"];
                    aux.Nombre = (string)lector["Nombre"];
                    aux.Descripcion = (string)lector["Descripcion"];

                    aux.Marca = new Marcas();
                    aux.Marca.Id = (int)lector["IdMarca"];
                    aux.Marca.Descripcion = (string)lector["Marca"];

                    aux.Categoria = new Categorias();
                    aux.Categoria.Id = (int)lector["IdCategoria"];
                    aux.Categoria.Descripcion = (string)lector["Categoria"];

                    if (!(lector["ImagenUrl"] is DBNull))
                        aux.ImagenUrl = (string)lector["ImagenUrl"];

                    aux.Precio = (decimal)lector["Precio"];

                    lista.Add(aux);
                }


                conexion.Close();
                return lista;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public List<Articulo> filtrar(string campo, string criterio)
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string consulta = "Select A.Id, Codigo, Nombre, A.Descripcion,M.Descripcion Marca, C.Descripcion Categoria,IdMarca, IdCategoria, ImagenUrl, A.Precio from CATEGORIAS C, MARCAS M, ARTICULOS A Where A.IdMarca = M.Id And A.IdCategoria = C.Id  And ";
                if (campo == "Marca")
                {
                    if (criterio == "Samsung")
                    { 
                        consulta += "M.Descripcion like 'Sam%'";
                    }
                    if (criterio == "Apple")
                    {
                        consulta += "M.Descripcion like 'App%'";
                    }
                    if (criterio == "Sony")
                    {
                        consulta += "M.Descripcion like 'Son%'";
                    }
                    if (criterio == "Huawei")
                    {
                        consulta += "M.Descripcion like 'Hua%'";
                    }
                    if (criterio == "Motorola")
                    {
                        consulta += "M.Descripcion like 'Mot%'";
                    }
                  
                }
                if (campo == "Categoria")
                {
                    if (criterio == "Celular")
                    {
                        consulta += "C.Descripcion like 'Cel%'";
                    }
                    if (criterio == "Television")
                    {
                        consulta += "C.Descripcion like 'Tel%'";
                    }
                    if (criterio == "Media")
                    {
                        consulta += "C.Descripcion like 'Med%'";
                    }
                    if (criterio == "Audio")
                    {
                        consulta += "C.Descripcion like 'Aud%'";
                    }

                }

                


                    // '%ka' asi me buscaria todos los que terminen con K 
                    // 'ka%' Asi buscaria todos los que comiencebn con Ka
                    // '%  %' Asi busca todo lo que hay en medio de los dos porcentajes 

                
                datos.setearConsulta(consulta);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    


                    aux.Marca = new Marcas();
                    aux.Marca.Id = (int)datos.Lector["IdMarca"];
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];

                    aux.Categoria = new Categorias();
                    aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];



                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                        aux.ImagenUrl = (string)datos.Lector["ImagenUrl"];

                    aux.Precio = (decimal)datos.Lector["Precio"];

                    lista.Add(aux);
                }



                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public void agregar(Articulo nuevo) 
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Insert into ARTICULOS (Codigo, Nombre, Descripcion, ImagenUrl, IdMarca, IdCategoria, Precio) values (@codigo, @nombre, @descripcion, @imagenUrl, @idMarca, @idCategoria, @precio)");
                datos.setearParametros("@codigo", nuevo.Codigo);
                datos.setearParametros("@nombre", nuevo.Nombre);
                datos.setearParametros("@descripcion", nuevo.Descripcion);
                datos.setearParametros("@imagenUrl", nuevo.ImagenUrl);
                datos.setearParametros("@idMarca", nuevo.Marca.Id);
                datos.setearParametros("@idCategoria", nuevo.Categoria.Id);
                datos.setearParametros("@precio", nuevo.Precio);
                datos.ejecutarAccion();


            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally 
            {
                datos.cerrarConexion();
            }

        }

        public void modificar(Articulo art)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("update  ARTICULOS  set Codigo = @codigo, Nombre = @nombre, Descripcion =@descripcion, ImagenUrl =@imagenUrl,IdMarca=@idMarca,IdCategoria =@idCategoria, Precio = @precio where id = @id");
                datos.setearParametros("@codigo", art.Codigo);
                datos.setearParametros("@nombre", art.Nombre);
                datos.setearParametros("@desc", art.Descripcion);
                datos.setearParametros("@imagenUrl", art.ImagenUrl);
                datos.setearParametros("@idMarca" , art.Marca.Id);
                datos.setearParametros("@idCategoria", art.Categoria.Id);
                datos.setearParametros("precio", art.Precio);
                datos.setearParametros("id", art.Id);

                datos.ejecutarAccion();
                

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void eliminar (int id)
        {
            Articulo seleccionado = new Articulo();
            try
            {   
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta("delete from articulos where id = @id");
                datos.setearParametros("@id", id);
                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }






}
