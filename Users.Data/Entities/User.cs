﻿using Users.Data.Entities.Abstract;

namespace Users.Data.Entities;

public sealed class User : BaseEntity
{
    public string LastName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public DateTimeOffset DateOfBirth { get; set; }
}