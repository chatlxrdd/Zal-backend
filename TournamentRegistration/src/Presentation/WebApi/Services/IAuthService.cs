namespace WebApi.Services
{
    public interface IAuthService
    {
        string GenerateJwtToken(Core.Entities.User user);
    }
}
