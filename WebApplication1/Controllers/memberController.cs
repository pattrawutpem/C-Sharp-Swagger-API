using Microsoft.AspNetCore.Mvc;
using WebApplication1.control.Icontrol;
using WebApplication1.control.veiwModel;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class memberController : Controller
    {
        private readonly ImemberControl _Imember;

        public memberController(ImemberControl imember)
        {
            _Imember = imember;

        }

        //add Member
        [HttpPost]
        public async Task<IActionResult> addMem(MemberViewModel model) {
            var add = await _Imember.addMember(model);
            return Ok(add);
        }

        //Get memberAll
        [HttpGet]
        public async Task<ActionResult> getmemberAll() {
            var mem = await _Imember.getAllMem();
            return Ok(mem);
        }

        //Delete member
        [HttpDelete]
        public async Task<ActionResult> deleteMem(int Id) {
            var mem = await _Imember.deleteMem(Id);
            return Ok(mem);
        }

        //Get member by id
        [HttpGet("{Id}")]
        public async Task<ActionResult> getByIdMem(int Id)
        {
            var mem = await _Imember.getMemById(Id);
            return Ok(mem);
        }


        //Get member by id Join
        [HttpGet("GetMemnerById")]
        public async Task<ActionResult> getByIdJoinMem(int Id)
        {
            var mem = await _Imember.getMemByIdJoin(Id);
            return Ok(mem);
        } 
        
        //Get member All Join
        [HttpGet("GetAll")]
        public async Task<ActionResult> getJoinAllMem()
        {
            var mem = await _Imember.getJoinAll();
            return Ok(mem);
        }

        //Get member Left Join And Right Join
        [HttpGet("GetRLJoin")]
        public async Task<ActionResult> getRLJoin()
        {
            var mem = await _Imember.getRLjoin();
            return Ok(mem);
        }

        //put member
        [HttpPut("{Id}")]
        public async Task<ActionResult> updatemem(MemberViewModel model)
        {
            var mem = await _Imember.updateMem(model);
            return Ok(mem);
        }

        //addBulk
        [HttpPost("AddMemberBulk")]
        public async Task<ActionResult> AddMemBulk(string MemberTypeCode)
        {
            var mem = await _Imember.addBulk(MemberTypeCode);
            return Ok(mem);
        }

        //addBulk
        [HttpPut("updateMemberBulk")]
        public async Task<ActionResult> updateMemBulk(string MemberTypeCode)
        {
            var mem = await _Imember.updateBulk(MemberTypeCode);
            return Ok(mem);
        }

        //deleteBulk
        [HttpDelete("deleteMemBulk")]
        public async Task<ActionResult> deleteMemBulk(string MemberTypeCode)
        {
            var mem = await _Imember.deleteBulk(MemberTypeCode);
            return Ok(mem);
        }
    }   
}
