using TaskManager.Core.Entities;
using TaskManager.Core.Interfaces;
using TaskManager.Infrastructure.Data;

namespace TaskManager.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TaskDbContext _context;

        public IRepository<TaskItem> Tasks { get; }

        public UnitOfWork(TaskDbContext context)
        {
            _context = context;

            Tasks = new Repository<TaskItem>(_context);
        }

        public async Task<int> GuardarCambiosAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
