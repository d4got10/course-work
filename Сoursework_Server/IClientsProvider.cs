using System.Collections.Generic;

namespace Сoursework_Server
{
    public interface IClientsProvider
    {
        IReadOnlyList<Client> Clients { get; }
    }
}
