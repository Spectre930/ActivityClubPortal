using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ids.core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IEventRepository Events { get; }
        Task<int> CommitAsync();
    }
}
