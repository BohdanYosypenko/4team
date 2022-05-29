namespace _4Teammate.Data.Entities;

public class LookupCategoryEntity
{
    public int Id { get; set; }

    public string DefaultName { get; set; }

    public string Name { get; set; }

    public List<SportLookupEntity> SportLookups { get; set; }
}
