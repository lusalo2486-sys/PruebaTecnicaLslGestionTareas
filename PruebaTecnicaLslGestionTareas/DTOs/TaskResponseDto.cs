using TaskManager.Core.Enums;
using TaskStatus = TaskManager.Core.Enums.TaskStatus;

namespace PruebaTecnicaLslGestionTareas.DTOs
{
    public class TaskResponseDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaLimite { get; set; }
        public TaskStatus Estado { get; set; }
    }
}
