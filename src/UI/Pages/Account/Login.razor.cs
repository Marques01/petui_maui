using Microsoft.AspNetCore.Components;
using Models;

namespace UI.Pages.Account
{
    public partial class Login
    {
        UserDto userDto;

        UserToken userToken;

        bool loginInvalido = false;

        public Login()
        {
            userDto = new();

            userToken = new();
        }

        protected async Task BtnLogin_Click()
        {
            userToken = await _accountServices.LoginAsync(userDto);

            await CheckLogin();
        }

        protected async Task CheckLogin()
        {
            if (string.IsNullOrEmpty(userToken.Token))
            {
                loginInvalido = true;
            }
            else
            {
                await _authServices.Login(userToken.Token);

                _navigationManager.NavigateTo("home", true);
            }
        }
    }
}