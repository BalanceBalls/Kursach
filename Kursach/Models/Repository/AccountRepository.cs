using Dapper;
using Microsoft.Extensions.Configuration;
using Kursach.Models.ViewModels;

namespace Kursach.Models.Repository
{
    public class AccountRepository : BaseRepository, IAccountRepository
    {
        public AccountRepository(IConfiguration config) : base(config) { }

        public UserModel GetUser(LoginModel model)
        {
            using (var conn = Connection)
            {
                conn.Open();
                return conn.QuerySingleOrDefault<UserModel>($@"
select	id      	{nameof(UserModel.Id)},
		Name		{nameof(UserModel.Name)},
        Email       {nameof(UserModel.Email)},
		Password	{nameof(UserModel.Password)}
from	Users
where	Email		=	@{nameof(model.Email)}
	and	Password	=	@{nameof(model.Password)}
", new { model.Email, model.Password });
            }
        }

        public UserModel GetUserByEmail(string email)
        {
            using (var conn = Connection)
            {
                conn.Open();
                return conn.QuerySingleOrDefault<UserModel>($@"
select	id      	{nameof(UserModel.Id)},
		Name		{nameof(UserModel.Name)},
        Email       {nameof(UserModel.Email)},
		Password	{nameof(UserModel.Password)}
from	Users
where	Email = @{nameof(email)}
", new { email });
            }
        }

        public void AddUser(RegisterModel model)
        {
            using (var conn = Connection)
            {
                conn.Open();
                conn.Execute($@"
insert Users (Email, Password)
values (@{nameof(model.Email)}, @{nameof(model.Password)})
", new { model.Email, model.Password });
            }
        }
    }
}