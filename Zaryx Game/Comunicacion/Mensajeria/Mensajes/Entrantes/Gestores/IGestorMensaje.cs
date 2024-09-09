using Zaryx_Game.Autenticacion.Sesiones;

namespace Zaryx_Game.Comunicacion.Mensajeria.Gestores
{
    public interface IGestorMensaje
    {
        Task GestionarMensaje(Sesion sesion, string mensaje);
    }
}