using Zaryx_DAO.Interfaces;
using Zaryx_Game.Autenticacion;
using Zaryx_Game.Autenticacion.Sesiones;
using Zaryx_Game.Comunicacion.Conexion;
using Zaryx_Game.Comunicacion.Mensajeria.Gestores;
using Zaryx_Game.Datos;
using Zaryx_Game.Datos.Modelos;
using Zaryx_Game.Juego.Modelos.Entidades.Personajes.Guerrero;
using Zaryx_Game.Juego.Modelos.Entidades.Personajes.Tirador;
using Zaryx_Game.Juego.Modelos.Items.Personajes.Tirador;
using Zaryx_Mensajes.Procesamiento;
using Zaryx_Mensajes.Salientes.Mensajes;

namespace Zaryx_Game.Comunicacion.Mensajeria.Mensajes.Entrantes.Gestores
{
    public class GestorMensajeSolicitarPersonajes : IGestorMensaje
    {
        public async Task GestionarMensaje(Sesion sesion, string mensaje)
        {
            if(sesion != null && sesion.Cuenta != null)
            {
                long idCuenta = sesion.Cuenta.IdCuenta;

                // Recuperación de personajes:

                List<GuerreroDTO> guerrerosDTO = await GestorDeDatos.Instancia().GestorGuerrero.ObtenerGuerrerosPorCuenta(idCuenta);
                List<TiradorDTO> tiradoresDTO = await GestorDeDatos.Instancia().GestorTirador.ObtenerTiradoresPorCuenta(idCuenta);

                List<Guerrero> guerreros = new();
                List<Tirador> tiradores = new();

                foreach(GuerreroDTO g in guerrerosDTO)
                {
                    Guerrero guerrero = new Guerrero(g, sesion.IdSesion);
                    await guerrero.CargarInventario();
                    guerreros.Add(guerrero);
                }


                foreach(TiradorDTO t in tiradoresDTO)
                {
                    Tirador tirador = new Tirador(t, sesion.IdSesion);
                    await tirador.CargarInventario();
                    tiradores.Add(tirador);
                }


                MS_EnviarPersonajes m_personajes = new(guerreros, tiradores);
                Emisor.Enviar(sesion.IdSesion, m_personajes.Tipo(), Serializador.Serializar(m_personajes));
            }
        }
    }
}