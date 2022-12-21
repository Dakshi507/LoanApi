using AutoMapper;
using LoanApi.Context;
using LoanApi.DTO;
using LoanApi.Models;
using LoanApi.Repository;
using LoanApi.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LoanApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class LoanController : ControllerBase
    {
        private readonly ILoanRepo _loanRepo;
        private readonly IMapper _mapper;
       


        public LoanController(ILoanRepo loanRepo, IMapper mapper)
        {
            _loanRepo = loanRepo;
            _mapper = mapper;
           
        }

        [HttpPost]
        public async Task<IActionResult> AddLoan(LoandetailDTO request)
        {
            ResponseApi<LoandetailDTO> _response = new ResponseApi<LoandetailDTO>();
            try
            {
                Loandetail _model = _mapper.Map<Loandetail>(request);
                Loandetail _loandetailsCreated = await _loanRepo.AddLoan(_model);
                if (_loandetailsCreated.UserId == request.Userid)
                {
                    _response = new ResponseApi<LoandetailDTO>()
                    {
                        Status = true,
                        Msg = "OK",
                        Values = _mapper.Map<LoandetailDTO>(_loandetailsCreated)

                    };
                }
                else
                {
                    _response = new ResponseApi<LoandetailDTO> { Status = true, Msg = "Could not create" };
                }
                return StatusCode(StatusCodes.Status200OK, _response);
            }
            catch (Exception ex)
            {
                _response = new ResponseApi<LoandetailDTO>() { Status = false, Msg = ex.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }


        [HttpGet]
        public async Task<IActionResult> GetLoanList()
        {
            ResponseApi<List<LoandetailDTO>> _response = new ResponseApi<List<LoandetailDTO>>();

            try
            {
                List<Loandetail> loandetailslist = await _loanRepo.GetLoanList();
                if (loandetailslist.Count > 0)
                {
                    List<LoandetailDTO> loanlist = _mapper.Map<List<LoandetailDTO>>(loandetailslist);
                    _response = new ResponseApi<List<LoandetailDTO>>() { Status = true, Msg = "OK", Values = loanlist };
                }
                else
                {
                    _response = new ResponseApi<List<LoandetailDTO>>() { Status = true, Msg = "No Data" };
                }
                return StatusCode(StatusCodes.Status200OK, _response);
            }
            catch (Exception ex)
            {
                _response = new ResponseApi<List<LoandetailDTO>>() { Status = false, Msg = ex.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }

        [HttpGet("GetLoanbyUserId/{userid}")]
        public async Task<IActionResult> GetLoanbyUserId([FromRoute] int userid)
        {
            ResponseApi<List<LoandetailDTO>> _response = new ResponseApi<List<LoandetailDTO>>();
            try
            {
                List<Loandetail> loandetails = await _loanRepo.GetLoanByUSerId(userid);
                if (loandetails.Count > 0)
                {
                    List<LoandetailDTO> loanlist = _mapper.Map<List<LoandetailDTO>>(loandetails);
                    _response = new ResponseApi<List<LoandetailDTO>>() { Status = true, Msg = "OK", Values = loanlist };
                }
                else
                {
                    _response = new ResponseApi<List<LoandetailDTO>>() { Status = true, Msg = "No Data" };
                }
                return StatusCode(StatusCodes.Status200OK, _response);
            }
            catch (Exception ex)
            {
                _response = new ResponseApi<List<LoandetailDTO>>() { Status = false, Msg = ex.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }

        }

        [HttpGet("GetLoanbyLoanNo/{loanid}")]
        public async Task<IActionResult> GetLoanbyLoanNo([FromRoute] int loanid)
        {
            ResponseApi<LoandetailDTO> _response = new ResponseApi<LoandetailDTO>();
            try
            {
                Loandetail loandetails = await _loanRepo.GetLoanByLoanId(loanid);

                LoandetailDTO loanlist = _mapper.Map<LoandetailDTO>(loandetails);
                _response = new ResponseApi<LoandetailDTO>() { Status = true, Msg = "OK", Values = loanlist };


                return StatusCode(StatusCodes.Status200OK, _response);
            }
            catch (Exception ex)
            {
                _response = new ResponseApi<LoandetailDTO>() { Status = false, Msg = ex.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }

        }

        [HttpPut]
        public async Task<IActionResult> Put(LoandetailDTO request)
        {
            ResponseApi<LoandetailDTO> _response = new ResponseApi<LoandetailDTO>();
            try
            {
                Loandetail _model = _mapper.Map<Loandetail>(request);
                Loandetail _loandetailEdited = await _loanRepo.UpdateLoan(_model);
                _response = new ResponseApi<LoandetailDTO>()
                {
                    Status = true,
                    Msg = "OK",
                    Values = _mapper.Map<LoandetailDTO>(_loandetailEdited)
                };
                return StatusCode(StatusCodes.Status200OK, _response);
            }
            catch (Exception ex)
            {
                _response = new ResponseApi<LoandetailDTO>() { Status = false, Msg = ex.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, _response);

            }
        }

        //[HttpGet]
        //public IActionResult GetAll()
       // {
         //   return Ok(_context.Userdetails.Include(user => user.Loandetails).ToList());
        //}



        /*
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateLoan(int id, JsonPatchDocument request)
        {
            ResponseApi<LoandetailDTO> _response = new ResponseApi<LoandetailDTO>();
            try
            {
                
                Loandetail _loandetailsUpdated = await _loanRepo.UpdateLoan(id, request);
                if (_loandetailsUpdated.Loannumber == id)
                {
                    _response = new ResponseApi<LoandetailDTO>()
                    {
                        Status = true,
                        Msg = "OK",
                        Values = _mapper.Map<LoandetailDTO>(_loandetailsUpdated)

                    };
                }
                else
                {
                    _response = new ResponseApi<LoandetailDTO> { Status = true, Msg = "Could not create" };
                }
                return StatusCode(StatusCodes.Status200OK, _response);
            }
            catch (Exception ex)
            {
                _response = new ResponseApi<LoandetailDTO>() { Status = false, Msg = ex.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }*/
    }
}
