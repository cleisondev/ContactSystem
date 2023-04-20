using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ContactSystem.Models
{
    public class ContactModel
    {
        public int Id { get; set; }
        [Required (ErrorMessage ="Digite o nome do contato")]

        public string Name { get; set; }

        [Required(ErrorMessage = "Digite o e-mail do contato")]
        [EmailAddress(ErrorMessage ="E-mail inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Digite o celular do contato")]
        [Phone(ErrorMessage ="O celular informado não é válido")]
        public string Cell { get; set; }



    }
}
