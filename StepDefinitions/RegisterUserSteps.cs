using NUnit.Framework;
using ReqresAPITestsNetCore;
using TechTalk.SpecFlow;

namespace APITestProject.StepDefinitions
{
    [Binding]
    public class RegisterUserSteps
    {
        APITestApp aPITestApp = new APITestApp();
        ScenarioContext scenarioContext = ScenarioContext.Current;

        [Given(@"I send request to register a new user with '(.*)' as email and I enter '(.*)' as password and save response as '(.*)'")]
        public void GivenISendRequestToRegisterANewUserWithAsEmailAndIEnterAsPasswordAndSaveResponseAs(string email, string password, string responseSave)
        {
            var response = aPITestApp.RegisterNewUser(email, password);
            scenarioContext.Add(responseSave, response);
        }

        [Then(@"response '(.*)' has code '(.*)' and token '(.*)' and '(.*)'")]
        public void ThenResponseHasCodeAndTokenAndMessage(string responseSave, int code, string token, string message)
        {
            if (message == "null") { message = null; }
            if (token == "null") { token = null; }
            var response = scenarioContext.Get<(RegisterUserDTO content, int statusCode)>(responseSave);
            var statusCode = response.statusCode;
            var contentToken = response.content.Token;
            var contentMessage = response.content.Error;
            Assert.AreEqual(code, statusCode, "Code is not as expected");
            Assert.AreEqual(token, contentToken, "Token is not as expected");
            Assert.AreEqual(message, contentMessage, "Message is not as expected");
        }

        [Given(@"I send a Get request to get the list of users and save response as '(.*)'")]
        public void GivenISendAGetRequestToGetTheListOfUsersAndSaveResponseAs(string responseSave)
        {
            var getRequest = aPITestApp.GetListOfUsers();
            scenarioContext.Add(responseSave, getRequest);
        }

        [Then(@"response '(.*)' has code '(.*)' with a list of users")]
        public void ThenResponseHasCodeWithAListOfUsers(string responseSave, int code)
        {
            var response = scenarioContext.Get<(ListOfUsersDTO content, int statusCode)>(responseSave);
            Assert.AreEqual(code, response.statusCode, "Code is not as expected");
            Assert.AreEqual("Michael", response.content.Data[0].First_Name);
        }
    }
}