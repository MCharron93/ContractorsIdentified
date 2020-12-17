namespace ContractorsIdentified.Models
{
  public class Contractor
  {
    public string Name { get; set; }
    public int Wage { get; set; }
    public int Id { get; set; }
    public string CreatorId { get; set; }
    public Profile Creator { get; set; }
  }
}