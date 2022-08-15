using ejercicioDeClase12;

namespace ejercicoDeClase12
{
    public class probarObjetos
    {
        static void Main(string[] args)
        {
            ProductoHandler productoHandler = new ProductoHandler();

            productoHandler.GetProductos();

            UsuarioHandler usuarioHandler = new UsuarioHandler();

            usuarioHandler.GetUsuarios();
        }
    }
}