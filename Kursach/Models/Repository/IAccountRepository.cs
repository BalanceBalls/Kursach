using Kursach.Models.ViewModels;

namespace Kursach.Models.Repository
{
    public interface IAccountRepository
    {
        UserModel GetUser(LoginModel model);

        int AddUser(RegisterModel model);

        UserModel GetUserByEmail(string email);
    }
}