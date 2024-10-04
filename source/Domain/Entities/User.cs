using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Classes
{
    public abstract class User
    {
        public string Name { get; set; }

        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)] //esto funcionara cuando tengamos el context
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Dni { get; set; }
        
        public User(string name, string email, string password,int dni)
        {
            Name = name;
            Id = 0;
            Email = email;
            Password = password;
            Dni = dni;
        }
    }
}
