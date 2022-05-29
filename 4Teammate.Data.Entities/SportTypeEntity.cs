namespace _4Teammate.Data.Entities;

public class SportTypeEntity
{
    public int Id { get; set; }

    public int CategoryFID { get; set; }

    public string DefaultName { get; set; }

    public string Name { get; set; }


    public SportCategoryEntity SportCategory { get; set; }
    public List<SportLookupEntity> SportLookups { get; set; }
}

