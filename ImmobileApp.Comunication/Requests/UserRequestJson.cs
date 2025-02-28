using ImmobileApp.Comunication.enums;

namespace ImmobileApp.Comunication.Requests
{
    public class UserRequestJson
    {
        public string UserName { get; set; } = string.Empty;
        public string UserEmail { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public RoleEnum? Role { get; set; } = RoleEnum.OPERATOR;

        public string Phone { get; set; } = string.Empty;

        public DateTime? BornDate { get; set; }


        public CivilStateEnum? CivilState { get; set; } = CivilStateEnum.SINGLE;
}

   
}
