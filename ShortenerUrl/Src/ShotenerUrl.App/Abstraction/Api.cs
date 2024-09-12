namespace ShotenerUrl.App.Abstraction;

public record ApiModel(int Code, bool Status, string Message, object? Result);

public static class ApiResponse
{
    public static string Lang { get; set; } = "fa-ir";

    public static ApiModel Success(string message, object? result)
        => new(200, true, message, result);

    public static ApiModel ApiException(string message = "خطایی رخ داد مجدادا تلاش کنید")
            => new(500, false, message, new { });

    public static ApiModel Faild(int code, string message)
        => new(code, false, message, new { });
}
