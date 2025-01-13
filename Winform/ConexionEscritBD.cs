using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Winform
{
    // Esta es la clase que me va a permirtir crear los metodos a la base de datos.
    class ConexionEscritBD
    {
        // Creamos Metodos Public para que pueda ser accedida desde el exterior. ESTE METODO LO QUE HACE ES LEER 
        // LOS REGISTROS DE LA BASE DE DATOS.

        // Creamos una lista de articulos llamada Listar:
        // el objetivo es: devolver una lista
        public List<Articulos> listar()
        {
            // creamos una nueva lista llamada Lista.
            List<Articulos> Lista = new List<Articulos>();

            // Vamos a crear todas las funciones para que se pueda conectar a la base de datos.

            // Para establecer la conexion y poder leer los datos necesito declarar un par de objetos y configurarlos.
            //para la conexion: creamos el objeto:
            SqlConnection Conexion = new SqlConnection();
            // para realizar acciones: creamos el objeto:
            SqlCommand Comando = new SqlCommand();
            // Como resultado de la lectura que realize de la base de datos: voy a obtener un set de datos.
            // y lo vamos a guardar en un lector llamado: creamos la variable:
            SqlDataReader lector;

            // dentro de este Try vamos a poner todas las funcionalidades que pueden fallar.
            try
            {
                // vamos a configurar la cadena de conexion que es un atributo de la conexion: donde digo, 
                // a que servidor me voy a conectar. + ahora decimos a que base de datos lo voy hacer(nombre de la BD):
                Conexion.ConnectionString = "server=FLIA-MAIDANA\\SQLEXPRESS01; database=CATALOGO_P3_DB; integrated security=true;";
                 // lo siguiente que hacemos es el comando que es la accion de lectura, inyectando la setencia sql que voy a utilizar
                 Comando.CommandType = System.Data.CommandType.Text;
                //ahora le vamos a decir cual va hacer el texto: consulta sql:
                Comando.CommandText = "select Codigo, Nombre, AR.Descripcion, Precio, MAR.Descripcion Marca, CAT.Descripcion Categoria, ImagenUrl from ARTICULOS AR, MARCAS MAR, CATEGORIAS CAT, IMAGENES IMAG where MAR.Id = AR.IdMarca AND CAT.Id = AR.IdCategoria AND IMAG.Id = AR.Id";
                // y ahora decimos que este comando en la "conexion":
                Comando.Connection = Conexion;

               // A La conexion la abrimos con:
               Conexion.Open();
                //para realizar la lectura: 
                lector = Comando.ExecuteReader();

                //para leer el lector: usaremos un while que es el que se encarda de decir tipo: si existe algo 
                // para leer me va a devolver true. y me posiciona en la primera fila
                while (lector.Read()) 
                {
                    //creamos un Articulo auxiliar al que le cargamos los datos del lector de ese registro.
                    Articulos aux = new Articulos();
                    // la forma de cargarlo:
                    aux.Codigo = (string)lector["Codigo"];
                    aux.Nombre = (string)lector["Nombre"];
                    aux.Descripcion = (string)lector["Descripcion"];
                    aux.Precio = (decimal)lector["Precio"];
                    aux.Marca = new Marcas();
                    aux.Marca.Descripcion = (string)lector["Marca"];
                    aux.Categoria = new Categorias();
                    aux.Categoria.Descripcion = (string)lector["Categoria"];
                    aux.ImagenUrl = new Imagen();
                    aux.ImagenUrl.ImagenUrl = (string)lector["ImagenUrl"];


                    //una vez obtenido cada dato: se van a ir guardando en la lista.
                    Lista.Add(aux);
                    //cuando ya no hay mas nada por leer, el while da false, sale del while,
                    //cierra la conexion y retorna la lista.
                }
                
                Conexion.Close();

                return Lista;
            }
            catch (Exception ex){

                throw ex;
            }
            
            
        }
    }
}
