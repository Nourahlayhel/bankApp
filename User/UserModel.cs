using TransAccount.Database;

namespace TransAccount.User
{
    public class UserModel
    {
        private readonly int userId;
        private readonly string firstName;
        private readonly string lastName;
        private readonly string email;
        private readonly string password;

        public UserModel(int userId, string firstName, string lastName, string email, string password)
        {
            this.userId = userId;
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.password = password;
        }
        public UserModel(DbUser dbUser) : this(dbUser.UserID, dbUser.FirstName, dbUser.LastName, dbUser.Email, dbUser.Password)
        {
        }

        public UserDto toDtoModel()
        {
            return new UserDto()
            {
                UserId = userId,
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = password,
            };
        }
    }
}
