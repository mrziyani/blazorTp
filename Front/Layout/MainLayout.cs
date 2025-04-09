namespace Front.Layout
{
    public partial class MainLayout
    {
        private async Task Logout()
        {

            var token = await localStorage.GetItemAsync<string>("authToken");
            if (!string.IsNullOrEmpty(token))
            {

                await localStorage.RemoveItemAsync("authToken");

            }


            NavigationManager.NavigateTo("/login", forceLoad: true);
        }
    }
}
