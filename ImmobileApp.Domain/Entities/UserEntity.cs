
using ImmobileApp.Comunication.enums;

namespace ImmobileApp.Domain.Entities
{
    public class UserEntity
    {
        public Guid Id { get; set; } = new Guid();
        public string UserName { get; set; } = string.Empty;
        public string UserEmail { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;

        public DateTime BornDate { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public  string CivilState { get; set; } = string.Empty;


        public ICollection<ImmobileEntity> Immobiles { get; } = new List<ImmobileEntity>();

      
    }
}
