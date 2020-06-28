using System.Collections.Generic;
using System.Net;

namespace WebApi.Modelo.Modelos
{
    public class ModeloRespuesta<T>
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }
        public IEnumerable<T> Data { get; set; }
        public T Objeto { get; set; }
    }
}