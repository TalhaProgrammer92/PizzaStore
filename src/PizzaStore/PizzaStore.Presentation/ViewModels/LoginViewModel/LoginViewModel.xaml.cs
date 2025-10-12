using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PizzaStore.ApplicationCore.DTOs.LoginDto;
using PizzaStore.ApplicationCore.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PizzaStore.Presentation.ViewModels.LoginViewModel
{
    /// <summary>
    /// Interaction logic for LoginViewModel.xaml
    /// </summary>
    public partial class LoginViewModel : ObservableObject
    {
        //public LoginViewModel()
        //{
        //    InitializeComponent();
        //}
        private readonly IAuthService _authService;
        private readonly IUserSession _session;

        [ObservableProperty] private string username;
        [ObservableProperty] private string password;

        public IAsyncRelayCommand LoginCommand { get; }
        public LoginViewModel(IAuthService authService, IUserSession session)
        {
            _authService = authService;
            _session = session;
            LoginCommand = new AsyncRelayCommand(LoginAsync);
        }

        private async Task LoginAsync()
        {
            var result = await _authService.LoginAsync(new LoginDto(Username, Password));
            if (result.IsSuccess) _session.SetToken(result.Token);
            else /* show validation message */
        }
    }
}
