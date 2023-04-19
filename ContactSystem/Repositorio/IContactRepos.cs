using ContactSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactSystem.Repositorio
{
    public interface IContactRepos
    {
        List<ContactModel> BuscarTodos();
        ContactModel Add(ContactModel contato);
        bool Deletar(ContactModel contato);

    }
}
