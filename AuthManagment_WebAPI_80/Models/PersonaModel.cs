namespace AuthManagment_WebAPI_80.Models
{
    public class PersonaModel
    {
        public required string Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string Rol { get; set; }
        public DateTime DateCreation { get; set; }


    }


}
