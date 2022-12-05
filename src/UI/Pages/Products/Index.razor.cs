using Microsoft.AspNetCore.Components;
using Models;

namespace UI.Pages.Products
{
    public partial class Index
    {
        public Product Product { get; set; }

        public Index()
        {
            Product = new();
        }

        protected void BtnCadastrar_Click()
        {
            _navigationManager.NavigateTo("/product/create");
        }
    }
}