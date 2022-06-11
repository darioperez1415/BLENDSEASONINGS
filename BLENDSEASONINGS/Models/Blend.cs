namespace BLENDSEASONINGS.Models
{
    public class Blend
    {
        public int Id { get; set; }
        public string name{ get; set; }
        public decimal weight  { get; set; }
        public List<Spice> Ingedients { get; set; }
        // List of spice called ingredients 
        // Ingredient object ie list 
        // For each row you will have to add a spice to the
        // ingredient list of blend 
    }
}
