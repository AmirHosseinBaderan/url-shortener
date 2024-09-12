using FluentValidation;

namespace ShotenerUrl.App.Endpoint;

public class CreateUrlValidator : AbstractValidator<CreateShortUrlRequest>
{
    public CreateUrlValidator()
    {
        RuleFor(x => x.Url)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage("Url is required");
    }
}
