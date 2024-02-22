﻿namespace EntityFrameworkCore.WebAPI.DTOs;

public class CreatePersonelDto
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty; 
    public IFormFile? File { get; set; } //primitive type değil!!
}
