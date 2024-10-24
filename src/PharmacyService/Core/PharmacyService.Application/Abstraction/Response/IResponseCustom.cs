﻿using System.Net;

namespace PharmacyService.Application.Abstraction.Response;

public interface IResponseCustom
{
    IEnumerable<ValidationExceptionModel> Errors { get; set; }
    public bool Success { get; set; }
    public string  Message { get; set; }
    public HttpStatusCode HttpStatusCode { get; set; } 
}

    public class ValidationExceptionModel
{
    public string? Property { get; set; }
    public IEnumerable<string>? Errors { get; set; }
}