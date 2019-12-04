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
    public class MainPageViewModel : ViewModelBase
    {
        private string _nickname;

        private string _password;

        public DelegateCommand SignupCommand { get; }

        public DelegateCommand LoginUserCommand { get; }

        private IDatabase Database { get; }

        public MainPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Database = new Database();
            Title = "NCA";
            SignupCommand = new DelegateCommand(GotoSignup);
            LoginUserCommand = new DelegateCommand(LoginUser);
        }

        private void GotoSignup()
        {
            Console.WriteLine("Go to Signup...");
            NavigationService.NavigateAsync("Signup");
        }

        private async void LoginUser()
        {
            Console.WriteLine("Trying to login user...");
            var user = await Database.GetUserByNickname(_nickname);
            if (CheckCredentials(user))
            {
                var navParams = new NavigationParameters
                {
                    { "Name", user.Name },
                    { "Nickname", user.Nickname },
                    { "Email", user.Email }
                };
                await NavigationService.NavigateAsync("User", navParams);
            }
            else
            {
                Console.WriteLine("Falha no Login. Usuário ou Senha incorreta!");
                await Prism.PrismApplicationBase.Current.MainPage.DisplayAlert("Falha de Login", "Usuário ou Senha incorretos", "Ok");
            }
        }

        private bool CheckCredentials(User user)
        {
            if (user == null) return false;
            return _password == user.Password;
        }

        public string Nickname
        {
            get { return _nickname; }
            set { SetProperty(ref _nickname, value); }
        }

        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }
    }
 }
