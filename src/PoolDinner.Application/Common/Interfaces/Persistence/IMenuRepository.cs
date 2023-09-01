using PoolDinner.Domain.MenuAggregate;

namespace PoolDinner.Application.Common.Interfaces.Persistence
{
    public interface IMenuRepository
    {
       public void Add(Menu menu);
    }
}

