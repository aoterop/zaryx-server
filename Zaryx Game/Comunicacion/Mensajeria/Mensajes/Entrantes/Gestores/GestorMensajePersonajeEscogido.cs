using Zaryx_DAO.Interfaces;
using Zaryx_Game.Autenticacion.Sesiones;
using Zaryx_Game.Comunicacion.Mensajeria.Gestores;
using Zaryx_Game.Comunicacion.Mensajeria.Mensajes.Entrantes.Mensajes;
using Zaryx_Game.Datos;
using Zaryx_Game.Datos.Modelos;
using Zaryx_Game.General;
using Zaryx_Game.Juego;
using Zaryx_Game.Juego.Modelos.Entidades.Personajes.Guerrero;
using Zaryx_Game.Juego.Modelos.Entidades.Personajes.Tirador;
using Zaryx_Mensajes.Procesamiento;

namespace Zaryx_Game.Comunicacion.Mensajeria.Mensajes.Entrantes.Gestores
{
    public class GestorMensajePersonajeEscogido : IGestorMensaje
    {
        public async Task GestionarMensaje(Sesion sesion, string mensaje)
        {
            ME_PersonajeEscogido? me = Deserializador.Deserializar<ME_PersonajeEscogido>(mensaje);

            if (sesion != null && me != null)
            {
                switch(me.Clase)
                {
                    case (byte)Tipos.Clase.GUERRERO:
                        {
                            GuerreroDTO? guerreroDTO = await GestorDeDatos.Instancia().GestorGuerrero.ObtenerGuerreroPorId(me.IdPersonaje);

                            if(guerreroDTO != null)
                            {
                                Guerrero guerrero = new(guerreroDTO, sesion.IdSesion);
                                await guerrero.CargarInventario();
                                GestorJuego.Instancia().GestorPersonajes.AgregarPersonaje(guerrero);                                
                            }
                        }
                        break;

                    case (byte)Tipos.Clase.TIRADOR:
                        {
                            TiradorDTO? tiradorDTO = await GestorDeDatos.Instancia().GestorTirador.ObtenerTiradorPorId(me.IdPersonaje);

                            if(tiradorDTO != null)
                            {
                                Tirador tirador = new(tiradorDTO, sesion.IdSesion);
                                await tirador.CargarInventario();
                                GestorJuego.Instancia().GestorPersonajes.AgregarPersonaje(tirador);
                            }
                        }
                        break;

                    case (byte)Tipos.Clase.MAGO:
                        {// En el futuro...

                        }break;
                    default: { } break;
                }
            }
        }
    }
}