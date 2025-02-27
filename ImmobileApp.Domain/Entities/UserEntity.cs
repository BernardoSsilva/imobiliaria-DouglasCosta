using ImmobileApp.Domain.enums;

namespace ImmobileApp.Domain.Entities
{
    public class UserEntity
    {
        public Guid Id { get; set; } = new Guid();
        public string UserName { get; set; } = string.Empty;
        public string UserEmail { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public RoleEnum Role { get; set; } = RoleEnum.OPERATOR;

        public ICollection<ImmobileEntity> Immobiles { get; } = new List<ImmobileEntity>();

    }
}
