namespace PruebaTecnicaLslGestionTareas.DTOs
{
    public class TaskCreateDto
    {
        public string Titulo { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public DateTime? FechaLimite { get; set; }
    }
}
