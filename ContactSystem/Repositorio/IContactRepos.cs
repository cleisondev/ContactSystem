using ContactSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactSystem.Repositorio
{
    public interface IContactRepos
    {
        ContactModel ListarPorId(int id);
        List<ContactModel> BuscarTodos();
        ContactModel Add(ContactModel contato);

        ContactModel Atualizar(ContactModel contato);
        bool Apagar(int id);

    }
}
