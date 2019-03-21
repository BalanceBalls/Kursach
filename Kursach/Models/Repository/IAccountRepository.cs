using Kursach.Models.ViewModels;

namespace Kursach.Models.Repository
{
    public interface IAccountRepository
    {
        UserModel GetUser(LoginModel model);

        void AddUser(RegisterModel model);

        UserModel GetUserByEmail(string email);
    }
}