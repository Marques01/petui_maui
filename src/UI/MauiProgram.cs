using Microsoft.AspNetCore.Components.Authorization;
using Services;
using Services.Interfaces;

namespace UI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddScoped<TokenAuthenticationProvider>();

            builder.Services.AddScoped<IAuthorizeServices, TokenAuthenticationProvider>(
                provider => provider.GetRequiredService<TokenAuthenticationProvider>()
                );

            builder.Services.AddScoped<AuthenticationStateProvider, TokenAuthenticationProvider>(
              provider => provider.GetRequiredService<TokenAuthenticationProvider>());

            builder.Services.AddHttpClient<TokenAuthenticationProvider>(x =>
            {
                x.BaseAddress = new Uri("https://https://apistorepet.azurewebsites.net/");
                x.DefaultRequestHeaders.Add("Accept", "application/+json");
            });

            builder.Services.AddHttpClient<IAccountServices, AccountServices>(x =>
            {
                x.BaseAddress = new Uri("https://https://apistorepet.azurewebsites.net/");
                x.DefaultRequestHeaders.Add("Accept", "application/+json");
            });

            builder.Services.AddHttpClient<IRolesServices, RolesServices>(x =>
            {
                x.BaseAddress = new Uri("https://https://apistorepet.azurewebsites.net/");
                x.DefaultRequestHeaders.Add("Accept", "application/+json");
            });

            builder.Services.AddHttpClient<IProductServices, ProductServices>(x =>
            {
                x.BaseAddress = new Uri("https://https://apistorepet.azurewebsites.net/");
                x.DefaultRequestHeaders.Add("Accept", "application/+json");
            });

            builder.Services.AddOptions();

            builder.Services.AddAuthorizationCore();

            builder.Services.AddMauiBlazorWebView();
#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
#endif
            return builder.Build();
        }
    }
}