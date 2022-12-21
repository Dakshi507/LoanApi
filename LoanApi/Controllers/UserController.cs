using AutoMapper;
using LoanApi.DTO;
using LoanApi.Models;
using LoanApi.Repository;
using LoanApi.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoanApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserRepo _userRepo;
        private readonly IMapper _mapper;


        public UserController(IUserRepo userRepo, IMapper mapper)
        {
            _userRepo = userRepo;
            _mapper = mapper;
        }

        [HttpGet("GetUserbyUserId/{userid}")]
        public async Task<IActionResult> GetUserbyUserId([FromRoute] int userid)
        {
            ResponseApi<UserdetailDTO> _response = new ResponseApi<UserdetailDTO>();
            try
            {
                Userdetail userdetails = await _userRepo.GetUserByUserId(userid);

                UserdetailDTO userdetail = _mapper.Map<UserdetailDTO>(userdetails);
                _response = new ResponseApi<UserdetailDTO>() { Status = true, Msg = "OK", Values = userdetail };


                return StatusCode(StatusCodes.Status200OK, _response);
            }
            catch (Exception ex)
            {
                _response = new ResponseApi<UserdetailDTO>() { Status = false, Msg = ex.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }

        }


        [HttpGet]
        public async Task<IActionResult> GetUserList()
        {
            ResponseApi<List<UserdetailDTO>> _response = new ResponseApi<List<UserdetailDTO>>();

            try
            {
                List<Userdetail> userdetailslist = await _userRepo.GetUserList();
                if (userdetailslist.Count > 0)
                {
                    List<UserdetailDTO> userlist = _mapper.Map<List<UserdetailDTO>>(userdetailslist);
                    _response = new ResponseApi<List<UserdetailDTO>>() { Status = true, Msg = "OK", Values = userlist };
                }
                else
                {
                    _response = new ResponseApi<List<UserdetailDTO>>() { Status = true, Msg = "No Data" };
                }
                return StatusCode(StatusCodes.Status200OK, _response);
            }
            catch (Exception ex)
            {
                _response = new ResponseApi<List<UserdetailDTO>>() { Status = false, Msg = ex.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }
    }
}
