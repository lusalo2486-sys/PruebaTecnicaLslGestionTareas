using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Core.Entities;

namespace TaskManager.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<TaskItem> Tasks { get; }

        Task<int> GuardarCambiosAsync();
    }
}
