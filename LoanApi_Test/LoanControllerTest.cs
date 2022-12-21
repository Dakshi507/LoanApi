using AutoMapper;
using LoanApi.Controllers;
using LoanApi.DTO;
using LoanApi.Repository;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace LoanApi_Test
{
    public class Tests
    {
        Mock<ILoanRepo> mock = new Mock<ILoanRepo>();
        Mock<IMapper> map = new Mock<IMapper>();

        LoanController loanController;

        [OneTimeSetUp]
        public void Setup()
        {
            loanController = new LoanController(mock.Object, map.Object);
            loanController = new LoanController(mock.Object, map.Object);
            mock = new Mock<ILoanRepo>();

        }

        [Test]
        public void GetLoanTest()
        {
            mock.Setup(x => x.GetLoanList());
            loanController = new LoanController(mock.Object, map.Object);
            var result = loanController.GetLoanList() as Task<IActionResult>;
            Assert.IsNotNull(result);
        }


        [Test]
        [TestCase("1")]
        public void GetLoanbyUserIdTest(int id)
        {
            mock.Setup(x => x.GetLoanByUSerId(id));
            var result = loanController.GetLoanbyUserId(id) as Task<IActionResult>;
            Assert.IsNotNull(result);
        }

        [Test]
        [TestCase("1")]
        public void GetLoanbyLoanIdTest(int id)
        {
            mock.Setup(x => x.GetLoanByLoanId(id));
            var result = loanController.GetLoanbyLoanNo(id) as Task<IActionResult>;
            Assert.IsNotNull(result);
        }

        [Test]
        [TestCase(1, "Satna", 200000, "Home", "3 Year")]
        public void AddLoanTest(int number, string address, int amount, string type,
            string term)
        {
            LoandetailDTO loan = new LoandetailDTO
            {
                Loannumber = number,
                Propertyaddress = address,
                Loanamount = amount,
                Loantype = type,
                Loanterm = term
                

            };

            var result = loanController.AddLoan(loan) as Task<IActionResult>;
            Assert.IsNotNull(result);
        }
    }
}