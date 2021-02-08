using Newtonsoft.Json;

namespace ReqresAPITestsNetCore
{
    public class APITests<T>
    {
        public (RegisterUserDTO content, int statusCode) RegisterUser(string endpoint, RegisterUserRequestDTO payload)
        {
            var registeruser = new APIHelpers<RegisterUserDTO>();
            var url = registeruser.ConfigURL(endpoint);
            var request = registeruser.CreatePostReq(payload);
            var response = registeruser.GetResponse(url, request);
            var code = (int)response.StatusCode;
            RegisterUserDTO content = registeruser.GetContent<RegisterUserDTO>(response);
            return (content, code);
        }

        public (ListOfUsersDTO content, int statusCode) GetUsers(string endpoint)
        {
            var user = new APIHelpers<ListOfUsersDTO>();
            var url = user.ConfigURL(endpoint);
            var request = user.CreateGetReq();
            var response = user.GetResponse(url, request);
            var code = (int)response.StatusCode;
            var content = user.GetContent<ListOfUsersDTO>(response);
            return (content, code);
        }
    }
}