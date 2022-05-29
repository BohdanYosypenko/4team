namespace _4Teammate.Data.Repositories.Interfaces;

public interface IUnitOfWork
{
    public ILookupCategoryRepository LookupCategory { get; set; }
    public ISportCategoryRepository SportCategory { get; set; }
    public ISportLookupRepository SportLookup { get; set; }
    public ISportTypeRepository SportType { get; set; }
    public void SaveAsync();    
}
