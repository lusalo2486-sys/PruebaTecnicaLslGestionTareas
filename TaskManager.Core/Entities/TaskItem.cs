using TaskStatus = TaskManager.Core.Enums.TaskStatus;

namespace TaskManager.Core.Entities
{
    public class TaskItem
    {
        public int Id { get; set; }

        public string Titulo { get; set; } = string.Empty;

        public string Descripcion { get; set; } = string.Empty;

        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;

        public DateTime? FechaLimite { get; set; }

        public TaskStatus Estado { get; set; } = TaskStatus.Pendiente;
    }
}
