using ejercicioDeClase12;

namespace ejercicoDeClase12
{
    public class probarObjetos
    {
        static void Main(string[] args)
        {
            //PRODUCTO
            ProductoHandler productoHandler = new ProductoHandler();
            productoHandler.GetProductos(1);

            //ProductoHandler deleteProducto = new ProductoHandler();
            //deleteProducto.DeleteProducto(9);

            ProductoHandler addProducto = new ProductoHandler();
            addProducto.AddProducto("Remera", 500, 1000, 5, 1);

            ProductoHandler updateProducto = new ProductoHandler();
            updateProducto.UpdateProducto(2, 3000);

            //USUARIO
            UsuarioHandler usuarioHandler = new UsuarioHandler();
            usuarioHandler.GetUsuarios("eperez");

            //UsuarioHandler deleteUsuario = new UsuarioHandler();
            //deleteUsuario.DeleteUsuario(1);

            UsuarioHandler updateUsuario = new UsuarioHandler();
            updateUsuario.UpdateUsuario(2, "eperez12");

            UsuarioHandler addUsuario = new UsuarioHandler();
            addUsuario.AddUsuario("Maria", "Aramayo", "MLAramayo", "contraseñaDeMaria", "marialujan@gmail.com");


            //PRODUCTO VENDIDO
            ProductoVendidoHandler productoVendidoHandler = new ProductoVendidoHandler();
            productoVendidoHandler.GetProductosVendidos(2);

            //ProductoVendidoHandler deleteProductoVendido = new ProductoVendidoHandler();
            //deleteProductoVendido.DeleteProductoVendido(1);

            ProductoVendidoHandler updateProductoVendido = new ProductoVendidoHandler();
            updateProductoVendido.UpdateProductoVendido(2, 10);

            ProductoVendidoHandler addProductoVendido = new ProductoVendidoHandler();
            addProductoVendido.AddProductoVendido(5, 15, 4);


            //VENTA
            VentaHandler ventaHandler = new VentaHandler();
            ventaHandler.GetVenta(2);

            //VentaHandler deleteVenta = new VentaHandler();
            //deleteVenta.DeleteVenta(6);

            VentaHandler updateVenta = new VentaHandler();
            updateVenta.UpdateVenta(5, "nuevo comentario");

            VentaHandler addVenta = new VentaHandler();
            addVenta.AddVenta("nueva venta");

            //INICIO DE SESION
            InicioDeSesionHandler inicioDeSesion= new InicioDeSesionHandler();
            List<Usuario> usuarios = inicioDeSesion.GetInicioDeSesion("tcasazza", "SoyTobiasCasazza");
            if (usuarios.Count>0)
            {
                Console.WriteLine(usuarios.First().Nombre);
               
            }

        }
    }
}