using ImmobileApp.Domain.enums;

namespace ImmobileApp.Domain.Entities
{
    public class UserEntity
    {
        private Guid Id { get; set; } = new Guid();
        private string UserName { get; set; } = string.Empty;
        private string UserEmail { get; set; } = string.Empty;
        private string Password { get; set; } = string.Empty;
        private RoleEnum Role { get; set; } = RoleEnum.OPERATOR;
        

    }
}
