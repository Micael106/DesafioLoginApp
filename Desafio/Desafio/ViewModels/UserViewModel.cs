using Desafio.DataAccess;
using Desafio.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Desafio.ViewModels
{
    public class UserViewModel : ViewModelBase
    {

        private string _Nickname;
        public string Nickname
        {
            get => _Nickname;
            set => SetProperty(ref _Nickname, value);
        }

        private string _Email;
        public string Email
        {
            get => _Email;
            set => SetProperty(ref _Email, value);
        }

        private string _Name;
        public string Name
        {
            get => _Name;
            set => SetProperty(ref _Name, value);
        }

        public DelegateCommand LogoutCommand { get; }

        public UserViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Usuário";
            LogoutCommand = new DelegateCommand(Logout);
        }

        private async void Logout()
        {
            Console.WriteLine("Logout user...");
            await NavigationService.GoBackAsync();
        }

        public override void OnNavigatedFrom(INavigationParameters parameters)
        {
            Console.WriteLine("OnNavigatedFrom");
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            Console.WriteLine("OnNavigatedTo");
            Nickname = parameters["Nickname"] as string;
            Name = parameters["Name"] as string;
            Email = parameters["Email"] as string;
            Console.WriteLine("{0} {1} {2}", Name, Nickname, Email);
        }
    }
 }
