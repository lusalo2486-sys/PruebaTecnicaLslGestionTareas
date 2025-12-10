using TaskManager.Core.Enums;
using TaskStatus = TaskManager.Core.Enums.TaskStatus;

namespace PruebaTecnicaLslGestionTareas.DTOs
{
    public class TaskUpdateDto
    {
        public string Titulo { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public DateTime? FechaLimite { get; set; }
        public TaskStatus Estado { get; set; }
    }
}
