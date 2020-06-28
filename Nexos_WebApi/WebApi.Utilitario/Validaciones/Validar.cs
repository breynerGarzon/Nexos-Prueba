using WebApi.Modelo.Excepciones;
using WebApi.Utilitario.Mensajes;

namespace WebApi.Utilitario.Validaciones
{
    public static class Validar
    {
        public static int VALOR_PERMITIDO = 0;
        public static void ValidarCampoTexto(string Valor){
            if (string.IsNullOrEmpty(Valor))
            {
                var mensaje = string.Format(Mensajes_Pacientes.DATO_INVALIDO, Valor);
                throw new ValidacionException(mensaje);
            }
        }
        public static void ValidarCampoNumerico(int Valor){
            if (Valor<=VALOR_PERMITIDO)
            {
                var mensaje = string.Format(Mensajes_Pacientes.DATO_INVALIDO, Valor);
                throw new ValidacionException(mensaje);
            }
        }
    }
}