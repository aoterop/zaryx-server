using Zaryx_Game.Autenticacion;
using Zaryx_Game.Autenticacion.Sesiones;
using Zaryx_Game.Comunicacion.Conexion;
using Zaryx_Game.Comunicacion.Mensajeria.Gestores;
using Zaryx_Mensajes.Entrantes;
using Zaryx_Mensajes.Procesamiento;
using Zaryx_Mensajes.Salientes.Mensajes;

namespace Zaryx_Game.Comunicacion.Mensajeria.Mensajes.Entrantes.Gestores
{
    internal class GestorMensajeCrearPersonaje : IGestorMensaje
    {
        public async Task GestionarMensaje(Sesion sesion, string mensaje)
        {
            ME_CrearPersonaje? m = Deserializador.Deserializar<ME_CrearPersonaje>(mensaje);

            if (m != null && m.Nombre != null)
            {
                if(sesion != null && sesion.Cuenta != null)
                {
                    bool creado = await Autenticador.CrearPersonaje(sesion.Cuenta.IdCuenta, m.Nombre, m.Clase, m.Peinado, m.AspectoFacial);

                    if(creado)
                    {// Personaje creado con éxito.
                        MS_CrearPersonaje ms = new(false);
                        Emisor.Enviar(sesion.IdSesion, ms.Tipo(), Serializador.Serializar(ms));
                    }
                    else
                    {// El personaje no se pudo crear.
                        MS_CrearPersonaje ms = new(true);
                        Emisor.Enviar(sesion.IdSesion, ms.Tipo(), Serializador.Serializar(ms));                        
                    }
                }
            }
        }
    }
}