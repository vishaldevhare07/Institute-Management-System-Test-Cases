using Microsoft.VisualStudio.TestTools.UnitTesting;
using ComputerCourse;

namespace ComputerCourse.Tests
{
    [TestClass]
    public class LoginTests
    {
        [TestMethod]
        public void ValidateLogin_With_Valid_Credentials_Returns_True()
        {
            AdminLogin login = new AdminLogin();

            string email = "vishal@gmail.com";
            string password = "123456";

            bool result = login.ValidateLogin(email, password);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ValidateLogin_With_Invalid_Password_Returns_False()
        {
            AdminLogin login = new AdminLogin();

            string email = "vishal@gmail.com";
            string password = "wrongpassword";

            bool result = login.ValidateLogin(email, password);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ValidateLogin_With_Empty_Email_Returns_False()
        {
            AdminLogin login = new AdminLogin();

            string email = "";
            string password = "123456";

            bool result = login.ValidateLogin(email, password);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ValidateLogin_With_Empty_Password_Returns_False()
        {
            AdminLogin login = new AdminLogin();

            string email = "vishal@gmail.com";
            string password = "";

            bool result = login.ValidateLogin(email, password);

            Assert.IsFalse(result);
        }
    }
}