using MVC.Models;

namespace KendoDemo.Repositories.Interface;

public interface IUserInterface
{
    Task<int> Register(t_User user);
    Task<t_User> Login(vm_Login user);

    object GetUserProfile(string? userId);
    bool UpdateUserProfile(t_Contact model);
}

