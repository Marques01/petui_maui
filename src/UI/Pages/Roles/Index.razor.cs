using Models;

namespace UI.Pages.Roles
{
    public partial class Index
    {
        public IEnumerable<ApplicationRoles> Roles { get; set; }

        public Index()
        {
            Roles = Enumerable.Empty<ApplicationRoles>();
        }

        protected override async Task OnInitializedAsync()
        {
            await GetRoles();
        }

        protected async Task GetRoles()
        {
            Roles = await _roleServices.GetAllRolesAsync();
        }
    }
}