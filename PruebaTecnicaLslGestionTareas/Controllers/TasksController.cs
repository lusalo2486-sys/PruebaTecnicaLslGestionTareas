using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Core.Entities;
using TaskManager.Core.Interfaces;
using PruebaTecnicaLslGestionTareas.DTOs;

namespace PruebaTecnicaLslGestionTareas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TasksController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // GET: api/tasks
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tasks = await _unitOfWork.Tasks.ObtenerTodosAsync();
            var result = _mapper.Map<IEnumerable<TaskResponseDto>>(tasks);
            return Ok(result);
        }

        // GET: api/tasks/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var task = await _unitOfWork.Tasks.ObtenerPorIdAsync(id);

            if (task == null)
                return NotFound(new { message = "La tarea no existe." });

            return Ok(_mapper.Map<TaskResponseDto>(task));
        }

        // POST: api/tasks
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TaskCreateDto dto)
        {
            var entity = _mapper.Map<TaskItem>(dto);

            await _unitOfWork.Tasks.AgregarAsync(entity);
            await _unitOfWork.GuardarCambiosAsync();

            var result = _mapper.Map<TaskResponseDto>(entity);

            return CreatedAtAction(nameof(GetById), new { id = entity.Id }, result);
        }

        // PUT: api/tasks/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] TaskUpdateDto dto)
        {
            var entity = await _unitOfWork.Tasks.ObtenerPorIdAsync(id);

            if (entity == null)
                return NotFound(new { message = "La tarea no existe." });

            _mapper.Map(dto, entity);

            _unitOfWork.Tasks.Actualizar(entity);
            await _unitOfWork.GuardarCambiosAsync();

            return Ok(_mapper.Map<TaskResponseDto>(entity));
        }

        // DELETE: api/tasks/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _unitOfWork.Tasks.ObtenerPorIdAsync(id);

            if (entity == null)
                return NotFound(new { message = "La tarea no existe." });

            _unitOfWork.Tasks.Eliminar(entity);
            await _unitOfWork.GuardarCambiosAsync();

            return NoContent();
        }
    }
}
