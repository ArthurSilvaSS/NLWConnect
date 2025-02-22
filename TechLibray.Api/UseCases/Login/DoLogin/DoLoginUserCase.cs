using TechLibrary.Communication.Request;
using TechLibrary.Communication.Responses;
using TechLibrary.Exception;
using TechLibray.Api.Infrastructure.DataAccess;
using TechLibray.Api.Infrastructure.Security.Encryption;
using TechLibray.Api.Infrastructure.Security.Tokens.Access;

namespace TechLibray.Api.UseCases.Login.DoLogin;

public class DoLoginUserCase
{
    public ResponseRegisterUsersJson Execute(RequestLoginJson request)
    {
        var dbContext = new TechLibraryDbContext();
        var entity = dbContext.Users.FirstOrDefault(user => user.Email.Equals(request.Email));

        if (entity is null)
            throw new InvalidLoginException();
        

        var cryptography = new BCryptAlgorithm();
        var passwordIsValid = cryptography.Verify(request.Password, entity);

        if (passwordIsValid == false)
            throw new InvalidLoginException();

         var tokenGenerator = new JwtTokenGenerator();

        return new ResponseRegisterUsersJson
        {
            Name = entity.Name,
            AccessToken = tokenGenerator.Generate(entity)
        };
    }
}
