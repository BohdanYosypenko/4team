namespace _4Teammate.Data.Entities;

public class SportLookupEntity
{
  public int Id { get; set; }

  public int SportTypeFID { get; set; }

  public int LookupCategoryFID { get; set; }

  public DateTime TimeStart { get; set; }

  public DateTime TimeEnd { get; set; }

  public decimal Latitude { get; set; }

  public decimal Longitude { get; set; }

  public decimal PriceStart { get; set; }

  public decimal PriceEnd { get; set; }

  public int AgeStart { get; set; }

  public int AgeEnd { get; set; }

  public char Gender { get; set; }


  public TeammateUserEntity User { get; set; }
  public SportTypeEntity SportType { get; set; }
  public LookupCategoryEntity LookupCategory { get; set; }
}

