namespace Coban.Application.Responses.Base.Enums;

public enum ErrorType :uint
{
    // 400 - Client Errors
    BadRequest = 400,
    NotFound = 404,
    Unauthorized = 401,
    Forbidden = 403,
    Conflict = 409,
    UnprocessableEntity = 422,
    TooManyRequests = 429,

    // 500 - Server Errors
    InternalServerError = 500,
    NotImplemented = 501,
    ServiceUnavailable = 503,
    GatewayTimeout = 504,
    HttpVersionNotSupported = 505,

    // Custom Error Codes (600+ for application-specific errors)
    ValidationError = 600,
    BusinessRuleViolation = 601,
    DataIntegrityViolation = 602,
    DependencyFailure = 603,
    TimeoutError = 604,

    // Database Errors
    DatabaseConnectionFailure = 700,
    QueryExecutionError = 701,
    TransactionFailure = 702,

    // File Errors
    FileNotFoundError = 800,
    FileReadError = 801,
    FileWriteError = 802,

    // Authentication & Authorization
    TokenExpired = 900,
    InvalidToken = 901,
    AccessDenied = 902,

    // Networking Errors
    NetworkError = 1000,
    DnsResolutionError = 1001,
    SslHandshakeError = 1002,

    // API Errors
    ApiCommunicationError = 1100,
    ExternalServiceError = 1101,
    RateLimitExceeded = 1102,

    // General Errors
    UnknownError = 1200,
    OperationFailed = 1201
}

