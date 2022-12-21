using AutoMapper;
using LoanApi.Controllers;
using LoanApi.DTO;
using LoanApi.Models;
using LoanApi.Repository;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanApi_Test
{
    [TestFixture]
    public class UserControllerTest
    {
        Mock<IUserRepo> mock = new Mock<IUserRepo>();
        Mock<IMapper> map = new Mock<IMapper>();
        UserController userController;

        [OneTimeSetUp]
        public void SetUp()
        {
            userController = new UserController(mock.Object, map.Object);
            mock = new Mock<IUserRepo>();
        }

        private static IEnumerable<List<UserdetailDTO>> GetAllCustomers_TestCase
        {
            get
            {
                yield return new List<UserdetailDTO> {
                new UserdetailDTO{ Userid = 1, Firstname = "Dakshi", Lastname = "Shukla", Username = "DS", password = "123", role = "Admin"} ,
                new UserdetailDTO{Userid = 2, Firstname = "Sakshi", Lastname = "Shukla", Username = "Ss", password = "123", role = "User" }
                };
            }
        }

        [Test]
        [TestCase]
        public void GetUserTest()
        {
            mock.Setup(x => x.GetUserList());
            var result = userController.GetUserList() as Task<IActionResult>;
            Assert.IsNotNull(result);
        }
        [Test]
        [TestCase("1")]
        public void GetUserByUserIdTest(int customerId)
        {
            mock.Setup(x => x.GetUserByUserId(customerId));
            var result = userController.GetUserbyUserId(customerId) as Task<IActionResult>;
            Assert.IsNotNull(result);
        }

        


    }

}

