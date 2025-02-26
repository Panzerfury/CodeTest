﻿namespace CodeTest.Application.DTOs;

public class PersonDto
{
    public string? Name { get; set; }
    public string? BirthYear { get; set; }
    public string? EyeColor { get; set; }
    public string? Gender { get; set; }
    public string? HairColor { get; set; }
    public string? Height { get; set; }
    public string? Mass { get; set; }
    public string? SkinColor { get; set; }
    public string? Homeworld { get; set; }
    public List<string> Films { get; set; } = new();
    public List<string> Species { get; set; }  = new();
    public List<string> Starships { get; set; }  = new();
    public List<string> Vehicles { get; set; }  = new();
    public string? Url { get; set; }
    public DateTime Created { get; set; }
    public DateTime Edited { get; set; }
}