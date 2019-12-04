using Desafio.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.DataAccess
{
    public interface IDatabase
    {
        Task<int> InsertTarefa(Tarefa tarefa);
        Task<int> DeleteTarefa(Tarefa tarefa);
        Task<List<Tarefa>> GetTarefas();
        Task<Tarefa> GetTarefaById(int id);


        Task<int> InsertUser(User user);
        Task<List<User>> GetUsers();
        Task<User> GetUserById(int id);
        Task<User> GetUserByNickname(string nickname);
    }
}
