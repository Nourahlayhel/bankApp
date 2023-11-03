using Microsoft.EntityFrameworkCore;
using TransAccount.Database;

namespace TransAccount.User
{
    public class UserRepository : IUserRepository
    {
        private readonly TransAccContext context;

        public UserRepository(TransAccContext context)
        {
            this.context = context;
        }

        public async Task<UserModel> Authenticate(LoginDto loginDto)
        {
            var user = await this.context.Users.Where(u => u.Email == loginDto.Email).SingleOrDefaultAsync();
            if(user == null)
            {
                throw new Exception();
            }
            else
            {
                if(user.Password == loginDto.Password)
                {
                    return new UserModel(user);
                }
                else
                {
                    throw new Exception();
                }
            }
        }
    }
}
