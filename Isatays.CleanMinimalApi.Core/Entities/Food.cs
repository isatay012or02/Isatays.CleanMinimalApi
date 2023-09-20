namespace Isatays.CleanMinimalApi.Core.Entities;

public class Food
{
    public int UserId { get; set; }

    public int Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime? EditDate { get; set; }
}
