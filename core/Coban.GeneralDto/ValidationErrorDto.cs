namespace Coban.GeneralDto;
public record ValidationErrorDto(string Field, string ErrorMessage, string? InvalidValue = null);
