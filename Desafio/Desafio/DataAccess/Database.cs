using Desafio.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.DataAccess
{
    
    public class Database : IDatabase
    {
        public SQLiteAsyncConnection connection;

        IRepository<Tarefa> TarefaRepo;

        IRepository<User> UserRepo;

        
        public Database()
        {
            connection = new SQLiteAsyncConnection(
                Path.Combine(
                    Environment.GetFolderPath(
                        Environment.SpecialFolder.LocalApplicationData),
                        "Database.db3"));

            //TarefaRepo = new Repository<Tarefa>(connection);
            UserRepo = new Repository<User>(connection);

        }

        public async  Task<int> DeleteTarefa(Tarefa tarefa)
        {
            await connection.CreateTableAsync<Tarefa>();
            return await TarefaRepo.Delete(tarefa);
        }

        public async Task<Tarefa> GetTarefaById(int id)
        {
            await connection.CreateTableAsync<Tarefa>();
            return await TarefaRepo.Get(tarefa => tarefa.id == id);
        }

        public async Task<List<Tarefa>> GetTarefas()
        {
            await connection.CreateTableAsync<Tarefa>();
            return await TarefaRepo.Get();
        }

        public async Task<int> InsertTarefa(Tarefa tarefa)
        {
            await connection.CreateTableAsync<Tarefa>();
            return await TarefaRepo.Insert(tarefa);
        }

        public async Task<List<User>> GetUsers()
        {
            await connection.CreateTableAsync<User>();
            return await UserRepo.Get();
        }

        public async Task<int> InsertUser(User user)
        {
            await connection.CreateTableAsync<User>();
            return await UserRepo.Insert(user);
        }

        public async Task<User> GetUserById(int id)
        {
            await connection.CreateTableAsync<User>();
            return await UserRepo.Get(user => user.Id == id);
        }

        public async Task<User> GetUserByNickname(string nickname)
        {
            return await UserRepo.Get(user => user.Nickname == nickname);
        }
    }
}
