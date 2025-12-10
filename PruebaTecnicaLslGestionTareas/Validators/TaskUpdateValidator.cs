using FluentValidation;
using PruebaTecnicaLslGestionTareas.DTOs;

namespace PruebaTecnicaLslGestionTareas.Validators
{
    public class TaskUpdateValidator : AbstractValidator<TaskUpdateDto>
    {
        public TaskUpdateValidator()
        {
            RuleFor(x => x.Titulo)
                .NotEmpty().WithMessage("El título es obligatorio.")
                .MaximumLength(200);

            RuleFor(x => x.Descripcion)
                .MaximumLength(1000);

            RuleFor(x => x.FechaLimite)
                .GreaterThan(DateTime.UtcNow)
                .When(x => x.FechaLimite.HasValue)
                .WithMessage("La fecha límite debe ser mayor que la fecha actual.");

            RuleFor(x => x.Estado)
                .IsInEnum().WithMessage("El estado indicado no es válido.");
        }
    }
}
