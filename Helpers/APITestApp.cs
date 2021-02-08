using NUnit.Framework;

namespace ReqresAPITestsNetCore
{
    public class APITestApp
    {
        public (RegisterUserDTO content, int statusCode) RegisterNewUser(string email, string password)
        {
            string endpoint = "api/register";
            var payload = RegisterUserRequestDTO.RegisterUserModel(email, password);
            var apitests = new APITests<RegisterUserDTO>();
            return apitests.RegisterUser(endpoint, payload);
        }

        public (ListOfUsersDTO content, int statusCode) GetListOfUsers()
        {
            string endpoint = "api/users?page=2";
            var apitests = new APITests<ListOfUsersDTO>();
            return apitests.GetUsers(endpoint);
        }
    }
}