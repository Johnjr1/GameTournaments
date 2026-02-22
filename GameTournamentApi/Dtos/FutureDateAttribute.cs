using System.ComponentModel.DataAnnotations;

namespace GameTournamentApi.Dtos;

public class FutureDateAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is DateTime date && date < DateTime.UtcNow)
        {
            return new ValidationResult("Date must be in the future.");
        }

        return ValidationResult.Success;
    }
}
