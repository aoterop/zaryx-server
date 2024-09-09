using Zaryx_Game.Autenticacion.Sesiones;
using Zaryx_Game.Comunicacion.Conexion;
using Zaryx_Game.Comunicacion.Mensajeria.Gestores;
using Zaryx_Game.Comunicacion.Mensajeria.Mensajes.Entrantes.Mensajes;
using Zaryx_Game.Comunicacion.Mensajeria.Mensajes.Salientes.Mensajes;
using Zaryx_Game.Datos;
using Zaryx_Game.General;
using Zaryx_Mensajes.Procesamiento;

namespace Zaryx_Game.Comunicacion.Mensajeria.Mensajes.Entrantes.Gestores
{
    public class GestorMensajeBorrarPersonaje : IGestorMensaje
    {
        public async Task GestionarMensaje(Sesion sesion, string mensaje)
        {
            ME_BorrarPersonaje? me =  Deserializador.Deserializar<ME_BorrarPersonaje>(mensaje);

            if(sesion != null && me != null)
            {
                bool borrado = false;
                switch(me.Clase)
                {
                    case (byte)Tipos.Clase.GUERRERO:
                        {
                            borrado = await GestorDeDatos.Instancia().GestorGuerrero.EliminarGuerrero(me.IdPersonaje);
                        }break;

                    case (byte)Tipos.Clase.TIRADOR:
                        {
                            borrado = await GestorDeDatos.Instancia().GestorTirador.EliminarTirador(me.IdPersonaje);
                        }break;

                    case (byte)Tipos.Clase.MAGO:
                        {

                        }break;                      
                }

                MS_PersonajeBorrado ms = new(me.IdPersonaje, borrado);
                Emisor.Enviar(sesion.IdSesion, ms.Tipo(), Serializador.Serializar(ms));
            }
        }
    }
}