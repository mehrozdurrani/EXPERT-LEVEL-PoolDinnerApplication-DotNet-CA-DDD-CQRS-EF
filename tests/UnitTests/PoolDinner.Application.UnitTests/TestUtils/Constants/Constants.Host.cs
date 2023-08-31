
using PoolDinner.Domain.HostAggregate.ValueObjects;

namespace PoolDinner.Application.UnitTests.TestUtils.Constants
{
    public partial class Constants
    {
        public static class Host
        {
            public static readonly HostId Id = HostId.Create(Guid.NewGuid());
        }  
    }
}