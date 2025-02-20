using TechLibrary.Communication.Request;
using TechLibrary.Communication.Responses;
using TechLibrary.Exception;
using TechLibray.Api.Domain.Entidades;
using TechLibray.Api.Infrastructure;

namespace TechLibray.Api.UseCases.Users.Register;

public class RegisterUserUseCase
{
    public ResponseRegisterUsersJson Execute(RequestUserJson request)
    {
        Validate(request);

        var entity = new User
        {
            Name = request.Name,
            Email = request.Email,
            Password = request.Password
        };

        var dbContext = new TechLibraryDbContext();
        dbContext.Users.Add(entity);
        dbContext.SaveChanges();

        return new ResponseRegisterUsersJson
        {
            Name = entity.Name,
        };
    }

    private void Validate(RequestUserJson request)
    {
        var validator = new RegisterUserValidator();
        var result = validator.Validate(request);

        if (result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(error => error.ErrorMessage).ToList();

            throw new ErrorOnvalidationException(errorMessages);
        }
    }

}
