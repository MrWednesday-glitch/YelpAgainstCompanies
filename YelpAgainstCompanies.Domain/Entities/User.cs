﻿namespace YelpAgainstCompanies.Domain.Entities;

[ExcludeFromCodeCoverage]
public class User : EntityBase
{
    public string? FirstName { get; set; }

    public string LastName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;
}