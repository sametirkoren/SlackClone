namespace Application.User
{
    public class UserDto{
        public string Id {get;set;}
        public string Token{get;set;}
        public string UserName {get;set;}
        public string Email {get;set;}

        public string Avatar {get;set;}

        public bool IsOnline {get;set;}
    }
}