using CodeTest.Application.DTOs;
using CodeTest.Application.Exceptions;
using CodeTest.Application.Interfaces.HttpClients;
using FluentValidation;
using MediatR;

namespace CodeTest.Application.CQRS.Persons.Queries;

public class GetPersonQuery : IRequest<PersonDto>
{
    public int Id { get; set; }
}

public class GetPersonQueryHandler(IStarWarsClient starWarsClient) : IRequestHandler<GetPersonQuery, PersonDto>
{
    public async Task<PersonDto> Handle(GetPersonQuery request, CancellationToken cancellationToken)
    {
        var person = await starWarsClient.GetPersonAsync(request.Id);
        if (person == null)
        {
            throw new NotFoundException($"No person found with ID {request.Id}");
        }
        return person;
    }
}

public class GetPersonQueryValidator : AbstractValidator<GetPersonQuery>
{
    public GetPersonQueryValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0)
            .WithMessage("Person ID must be greater than 0.");
    }
}