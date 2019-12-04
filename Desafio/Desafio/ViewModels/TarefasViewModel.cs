using Desafio.DataAccess;
using Desafio.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Desafio.ViewModels
{
    public class TarefasViewModel : ViewModelBase
    {
        public ObservableCollection<Tarefa> Tarefas { get; private set; }

        private IDatabase Database { get; }
        public DelegateCommand<string> AddTarefaCommand { get; }
        public DelegateCommand<int> DelTarefaCommand { get; }

        private bool _Carregando;
        public bool Carregando
        {
            get => _Carregando;
            set => SetProperty(ref _Carregando, value);
        }

        public TarefasViewModel(INavigationService navigationService) : base(navigationService)
        {
            Database = new Database();

            AddTarefaCommand = new DelegateCommand<string>(AddTarefa);

            Tarefas = new ObservableCollection<Tarefa>();

            CarregarTarefas();
        }

        public async void CarregarTarefas()
        {
            Carregando = true;

            var tarefas = await Database.GetTarefas();
            Device.BeginInvokeOnMainThread(() => {
                foreach (var tarefa in tarefas)
                {
                    Tarefas.Add(tarefa);
                }
            });

            Carregando = false;
        }

        private bool CanAddTarefa(string arg)
        {
            return true;
        }

        private void DelTarefa(int id)
        {

        }

        private async void AddTarefa(string titulo)
        {
            var tarefas = await Database.GetTarefas();
            var tarefa = new Tarefa() { titulo = titulo, finalizada = false };
            await Database.InsertTarefa(tarefa);
            Tarefas.Add(tarefa);

        }
    }
}
