using Zaryx_Game.Autenticacion;
using Zaryx_Game.Autenticacion.Sesiones;
using Zaryx_Game.Comunicacion.Mensajeria.Mensajes.Entrantes;
using Zaryx_Game.General;

namespace Zaryx_Game.Comunicacion.Mensajeria
{
    internal class Procesador
    {
        private readonly Buzon buzon;

        public Procesador(Buzon buzon)
        {
            this.buzon = buzon;
        }

        public async Task ProcesarMensajes()
        {
            string mensaje;

            string[] partesMensaje;

            
            while (true) // cambiar esto
            {
                await buzon.EsperarMensaje();

                mensaje = buzon.ObtenerSiguienteMensaje();

                if(mensaje != null)
                {
                    partesMensaje = mensaje.Split('§');

                    byte idSesion = byte.Parse(partesMensaje[0]);
                    byte tipoMensaje = byte.Parse(partesMensaje[1]);


                    if (GestorDeSesiones.Instancia().ExisteSesionConId(idSesion))
                    {// Se encola el mensaje en la sesión (si no es nula).
                        GestorDeSesiones.Instancia().ObtenerSesion(idSesion)?.AgregarMensaje(mensaje);
                    }
                    else
                    {// Crear la nueva sesión.
                                                
                        if (tipoMensaje == (byte)Tipos.MensajeEntrante.ME_REGISTRAR_SESION)
                        {
                            await GestorDeSesiones.Instancia().CrearSesion(idSesion);
                            _ = GestorDeSesiones.Instancia().ObtenerSesion(idSesion)!.ProcesarMensajes(); // Fire and forget!
                        }
                    }                                  
                }
            }
        }
    }
}