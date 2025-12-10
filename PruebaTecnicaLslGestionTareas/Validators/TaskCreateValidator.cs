using FluentValidation;
using PruebaTecnicaLslGestionTareas.DTOs;

namespace PruebaTecnicaLslGestionTareas.Validators
{
    public class TaskCreateValidator : AbstractValidator<TaskCreateDto>
    {
        public TaskCreateValidator()
        {
            RuleFor(x => x.Titulo)
                .NotEmpty().WithMessage("El título es obligatorio.")
                .MaximumLength(200).WithMessage("El título no debe exceder 200 caracteres.");

            RuleFor(x => x.Descripcion)
                .MaximumLength(1000).WithMessage("La descripción no debe exceder 1000 caracteres.");

            RuleFor(x => x.FechaLimite)
                .GreaterThan(DateTime.UtcNow)
                .When(x => x.FechaLimite.HasValue)
                .WithMessage("La fecha límite debe ser mayor que la fecha actual.");
        }
    }
}
