namespace WebApi.Modelo.Modelos
{
    public class View_Paciente : UsuarioBase
    {
        public string SeguroSocial { get; set; }
        public string CodigoPostal { get; set; }
        public int Telefono { get; set; }
    }
}