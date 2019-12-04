using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Models
{
    public class Tarefa
    {
        [PrimaryKey]
        public int id { get; set; }
        [NotNull]
        public string titulo { get; set; }
        [NotNull]
        public bool finalizada { get; set; }
    }
}
