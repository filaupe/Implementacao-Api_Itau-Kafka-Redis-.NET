using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItauFunctions.Kafka.Implementation.Repositories.Interfaces
{
    public interface IKafkaRepository
    {
        Task ConsumeAsync(CancellationToken cancellationToken);
    }
}
