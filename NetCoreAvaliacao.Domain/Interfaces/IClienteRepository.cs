using NetCoreAvaliacao.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace NetCoreAvaliacao.Domain.Interfaces
{
    public interface IClienteRepository
    {
        Task<Cliente> RetornaClientePorId(Guid id);

        Task<bool> RemoveCliente(Cliente cliente);

        Task AtualizaCliente(Cliente cliente);

        Task<Cliente> IncluiNovoCliente(Cliente cliente);


    }
}
