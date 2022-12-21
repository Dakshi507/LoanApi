using AuthenticationMicroservice.Context;
using AuthenticationMicroservice.Controllers;
using AuthenticationMicroservice.Repository;
using AuthorizationMicroservice.DTOS;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;
using System.Security.Cryptography;
using System.Text;

namespace AuthTest
{
    public class Tests
    {
        AccountController accountController;
        private LoginDto LoginDto;
        Mock<IAuthRepo> mock = new Mock<IAuthRepo>();
        Mock<IMapper> map = new Mock<IMapper>();
        Mock<IConfiguration> config = new Mock<IConfiguration>();

        [SetUp]
        public void Setup()
        {
            accountController = new AccountController(mock.Object, config.Object, map.Object);
            LoginDto = new LoginDto()
            {
                UserName = "DS",
                Password = "123"
            };
            using var hmac = new HMACSHA512();
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(LoginDto.Password));
        }

        [Test]
        public void LoginTest()
        {
            var result = accountController.Login(LoginDto);
            Assert.IsNotNull(result);
        }
        [Test]
        [TestCase(1, "DS", "Dakshi", "Shukla", "123", "Admin")]
        public void RegisterTest(int id, string uname, string fname, string lname, string pass, string val)
        {
            RegisterDto user = new RegisterDto
            {
                UserId = id,
                UserName = uname,
                Firstname = fname,
                Lastname = lname,
                Password = pass,
                role = val



            };

            var result = accountController.Register(user) as Task<IActionResult>;
            Assert.IsNotNull(result);
        }
    }
}