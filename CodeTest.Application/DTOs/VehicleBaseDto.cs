namespace CodeTest.Application.DTOs;

public class VehicleBaseDto
{
    public int Id { get; set; } 
    public string? Name { get; set; }
    public string? Model { get; set; }
    public string? Manufacturer { get; set; }
    public string? Length { get; set; }
    public string? CostInCredits { get; set; }
    public string? Crew { get; set; }
    public string? Passengers { get; set; }
    public string? MaxAtmospheringSpeed { get; set; }
    public string? CargoCapacity { get; set; }
    public string? Consumables { get; set; }

    // Common collections
    public ICollection<string> Films { get; set; } = new List<string>();
    public ICollection<string> Pilots { get; set; } = new List<string>();

    public string? Url { get; set; }
    public DateTime Created { get; set; }
    public DateTime Edited { get; set; }
}