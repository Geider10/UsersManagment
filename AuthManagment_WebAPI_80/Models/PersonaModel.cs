namespace AuthManagment_WebAPI_80.Models
{
    public class PersonaModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Role Rol { get; set; }
        public DateTime DateCreation { get; set; }


    }

    public enum Role
    {
        Admin, User
    }
}
