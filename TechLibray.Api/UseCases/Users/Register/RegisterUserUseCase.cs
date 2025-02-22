using FluentValidation.Results;
using TechLibrary.Communication.Request;
using TechLibrary.Communication.Responses;
using TechLibrary.Exception;
using TechLibray.Api.Domain.Entidades;
using TechLibray.Api.Infrastructure.DataAccess;
using TechLibray.Api.Infrastructure.Security.Encryption;
using TechLibray.Api.Infrastructure.Security.Tokens.Access;

namespace TechLibray.Api.UseCases.Users.Register;

public class RegisterUserUseCase
{
    public ResponseRegisterUsersJson Execute(RequestUserJson request)
    {
        var dbContext = new TechLibraryDbContext();
        Validate(request, dbContext);

        var cryptography = new BCryptAlgorithm();

        var entity = new User
        {
            Name = request.Name,
            Email = request.Email,
            Password = cryptography.HashPassword(request.Password),
        };

        dbContext.Users.Add(entity);
        dbContext.SaveChanges();

        var tokenGenerator = new JwtTokenGenerator();

        return new ResponseRegisterUsersJson
        {
            Name = entity.Name,
            AccessToken = tokenGenerator.Generate(entity),
        };
    }

    private void Validate(RequestUserJson request, TechLibraryDbContext dbContext)
    {
        var validator = new RegisterUserValidator();
        var result = validator.Validate(request);

        var existUserWithEmail = dbContext.Users.Any(user => user.Email.Equals(request.Email));

        if(existUserWithEmail)
            result.Errors.Add(new ValidationFailure("Email", "E-mail ja registrado"));

        if (result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(error => error.ErrorMessage).ToList();

            throw new ErrorOnvalidationException(errorMessages);
        }
    }

}
