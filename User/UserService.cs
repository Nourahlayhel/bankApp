namespace TransAccount.User
{
    public class UserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<UserDto> Authenticate(LoginDto loginDto)
        {
            var user = await this.userRepository.Authenticate(loginDto);
            return user.toDtoModel();
        }
    }
}
