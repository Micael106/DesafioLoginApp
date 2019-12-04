using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Models
{
    public class User
    {
        [PrimaryKey]
        public short Id { get; set; }
        [NotNull]
        public string Name { get; set; }
        [NotNull]
        public string Email { get; set; }
        [NotNull]
        public string Nickname { get; set; }
        [NotNull]
        public string Password { get; set; }
    }
}
