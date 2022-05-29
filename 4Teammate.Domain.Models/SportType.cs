namespace _4Teammate.Domain.Models;

public class SportType
{
    public int Id { get; set; }

    public int CategoryFID { get; set; }

    public string DefaultName { get; set; }

    public string Name { get; set; }
}
