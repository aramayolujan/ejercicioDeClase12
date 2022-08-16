using System.Data;
using System.Data.SqlClient;
namespace ejercicioDeClase12
{
  
   
        public class ProductoVendidoHandler : DbHandler
        {

            public List<ProductoVendido> GetProductosVendidos(int idUsuario)
            {
                List<ProductoVendido> productosVendidos = new List<ProductoVendido>();

            ProductoHandler productoHandler = new ProductoHandler();

           List<Producto> prodsUsuario = productoHandler.GetProductos(idUsuario);
            foreach(Producto producto in prodsUsuario)
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand sqlCommand = new SqlCommand(
                            "select productoVendido.Id, productoVendido.IdProducto, productoVendido.Stock, productoVendido.IdVenta " +
                            "from  ProductoVendido " +
                            "where ProductoVendido.IdProducto =  @idProducto", sqlConnection))
                    {
                        var parametro = new SqlParameter();
                        parametro.ParameterName = "idProducto";
                        parametro.SqlDbType = SqlDbType.BigInt;
                        parametro.Value = producto.Id;
                        sqlCommand.Parameters.Add(parametro);


                        sqlConnection.Open();

                        using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                        {
                            // Me aseguro que haya filas que leer
                            if (dataReader.HasRows)
                            {
                                while (dataReader.Read())
                                {
                                    ProductoVendido productoVendido = new ProductoVendido();
                                    productoVendido.Id = Convert.ToInt32(dataReader["Id"]);
                                    productoVendido.IdProducto = Convert.ToInt32(dataReader["IdProducto"]);
                                    productoVendido.Stock = Convert.ToInt32(dataReader["Stock"]);
                                    productoVendido.IdVenta = Convert.ToInt32(dataReader["IdVenta"]);



                                    productosVendidos.Add(productoVendido);
                                }
                            }
                        }

                        sqlConnection.Close();
                    }
                }
            }
            

            return productosVendidos;
            ;
        }
        }
    
}
