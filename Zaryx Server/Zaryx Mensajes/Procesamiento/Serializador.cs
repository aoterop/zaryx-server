using Newtonsoft.Json;

namespace Zaryx_Mensajes.Procesamiento
{
    public static class Serializador
    {
        public static string Serializar(object mensaje)
        {
            return JsonConvert.SerializeObject(mensaje);
        }
    }
}