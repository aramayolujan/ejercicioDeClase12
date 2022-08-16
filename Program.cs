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

            //USUARIO
            UsuarioHandler usuarioHandler = new UsuarioHandler();
            usuarioHandler.GetUsuarios("eperez");

            UsuarioHandler deleteUsuario = new UsuarioHandler();
            deleteUsuario.DeleteUsuario(1);

            UsuarioHandler updateUsuario = new UsuarioHandler();
            updateUsuario.UpdateUsuario(2, "eperez12");

            UsuarioHandler addUsuario = new UsuarioHandler();
            addUsuario.AddUsuario("Maria", "Aramayo", "MLAramayo", "contraseñaDeMaria", "marialujan@gmail.com");


            //PRODUCTO VENDIDO
            ProductoVendidoHandler productoVendidoHandler = new ProductoVendidoHandler();
            productoVendidoHandler.GetProductosVendidos(2);


            //VENTA
            VentaHandler ventaHandler = new VentaHandler();
            ventaHandler.GetVenta(2);


        }
    }
}