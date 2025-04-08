namespace Front.Pages
{
    using Front.Models;
    public partial class Register
    {
        private User registerModel = new User();
        private string message;

        private async Task HandleRegister()
        {
            var result = await UserService.RegisterUserAsync(registerModel);
            message = result ? "User registered successfully!" : "Registration failed.";
        }
    }
}
