namespace ReqresAPITestsNetCore
{
    public class RegisterUserRequestDTO
    {
        public string email { get; set; }
        public string password { get; set; }

        public static RegisterUserRequestDTO RegisterUserModel(string email, string password)
        {
            return new RegisterUserRequestDTO
            {
                email = email,
                password = password
            };
        }
    }
}