namespace _4Teammate.Data.Entities;

public class SportCategoryEntity
{
    public int Id { get; set; }

    public string DefaultName { get; set; }

    public string Name { get; set; }


    public List<SportTypeEntity> SportTypes { get; set; }
}

