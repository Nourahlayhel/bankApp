namespace TransAccount.User
{
    public interface IUserRepository
    {
        Task<UserModel> Authenticate(LoginDto loginDto);
    }
}
