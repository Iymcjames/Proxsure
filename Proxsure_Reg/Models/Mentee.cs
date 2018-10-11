namespace Proxsure_Reg.Models
{
    public class Mentee
    {
        public int Id { get; set; }
        public int ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

    
    }
}