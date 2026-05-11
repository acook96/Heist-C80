public class TeamMember
{
    public string Name { get; set; }
    public int SkillLevel { get; set; }
    public decimal CourageFactor { get; set; }
    
    public decimal ChickenFactor{
        get
        {
            return (SkillLevel * CourageFactor); 
        }
    }
}