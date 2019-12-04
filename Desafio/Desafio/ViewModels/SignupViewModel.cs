using Desafio.DataAccess;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using Desafio.Models;

namespace Desafio.ViewModels
{

    public class SignupViewModel : ViewModelBase
    {

        public DelegateCommand SignupUserCommand { get; set; }

        public DelegateCommand GotoMainPageCommand { get; set; }

        private IDatabase Database { get; }

        private string _name;
        private string _email;
        private string _user;
        private string _password;

        public SignupViewModel(INavigationService navigationService) : base(navigationService)
        {
            Database = new Database();
            Title = "Cadastrar-se";
            SignupUserCommand = new DelegateCommand(SignupUser);
            GotoMainPageCommand = new DelegateCommand(GotoMainPage);
        }

        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        public string Email
        {
            get { return _email; }
            set { SetProperty(ref _email, value); }
        }

        public string User
        {
            get { return _user; }
            set { SetProperty(ref _user, value); }
        }

        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        private async void SignupUser()
        {
            Console.WriteLine("Signup new user...");
            Console.WriteLine("Info: {0} {1} {2} {3}", _name, _email, _user, _password);

            var user = new User() { Name = _name, Email = _email, Nickname = _user, Password = _password};
            await Database.InsertUser(user);

            await NavigationService.GoBackAsync();
        }

        private void GotoMainPage()
        {
            NavigationService.NavigateAsync("Signup");
        }

    }
}
