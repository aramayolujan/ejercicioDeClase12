using ejercicioDeClase12;

namespace ejercicoDeClase12
{
    public class probarObjetos
    {
        static void Main(string[] args)
        {
            ProductoHandler productoHandler = new ProductoHandler();

            productoHandler.GetProductos(1);

            UsuarioHandler usuarioHandler = new UsuarioHandler();

            usuarioHandler.GetUsuarios("eperez");

            ProductoVendidoHandler productoVendidoHandler = new ProductoVendidoHandler();

            productoVendidoHandler.GetProductosVendidos(2);


        }
    }
}