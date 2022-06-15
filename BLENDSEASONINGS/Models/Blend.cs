namespace BLENDSEASONINGS.Models
{
    public class Blend
    {
        public int Id { get; set; }
        public string Name{ get; set; }
        public decimal Weight  { get; set; }
        public List<Spice> Ingredients { get; set; } = new List<Spice>();
    }
}




// List of spice called ingredients 
// Ingredient object ie list 
// For each row you will have to add a spice to the
// ingredient list of blend 