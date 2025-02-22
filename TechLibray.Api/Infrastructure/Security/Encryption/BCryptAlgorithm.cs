using TechLibray.Api.Domain.Entidades;

namespace TechLibray.Api.Infrastructure.Security.Encryption;

public class BCryptAlgorithm
{
    public string HashPassword(string password) => BCrypt.Net.BCrypt.HashPassword(password);

    public bool Verify(string password, User user) => BCrypt.Net.BCrypt.Verify(password, user.Password);
}
