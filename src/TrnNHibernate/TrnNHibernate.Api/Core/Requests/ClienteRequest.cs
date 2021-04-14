using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrnNHibernate.Api.Core.Requests
{
    public class ClienteRequest
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}