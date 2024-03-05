using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.control.Icontrol;
using WebApplication1.control.veiwModel;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class memberTypeController : ControllerBase // เป็น Implement ControllerBase ให้กับ UserController ทำให้ UserController สามารถใช้งาน method ต่างๆจาก ControllerBase
    {
        //DI(Dependencies Injection)  class ใช้งานสำหรับ UserController ผ่านการเรียกใช้งานที่ Constructor ของ class 
        private readonly ImemberTypeControl _ImemberTypeControl;
        public memberTypeController(ImemberTypeControl imemberTypeControl)
        {
            _ImemberTypeControl = imemberTypeControl;
        }

        //Add data 
        [HttpPost]
        // Task<ActionResult> เป็นการบอกระบบว่าจะมีการ Response ค่า
        public async Task<IActionResult> add(MemberTypeViewModel model) {
            var adds = await _ImemberTypeControl.add(model); //รับค่าใหม่ที่จะ Add new data 
            return Ok(adds);
        }

        //Get data id
        [HttpGet("{memberTypeCode}")]
        public async Task<ActionResult> GetDataById(string memberTypeCode)
        {
            var dataAll = await _ImemberTypeControl.getById(memberTypeCode);
            return Ok(dataAll);
        }

        //Get dataAll
        [HttpGet]
        public async Task<ActionResult> GetdataAll()
        {
            var dataAll = await _ImemberTypeControl.getAll();
            return Ok(dataAll);
        }

        //Update Data
        [HttpPut("{MemberTypeCode}")]
        public async Task<ActionResult> updataData(MemberTypeViewModel model)
        {
            var Updata = await _ImemberTypeControl.updateData(model);
            return Ok(Updata);
        }

        //Delete data
        [HttpDelete]
        public async Task<ActionResult> deleteData(string MemberTypeCode)
        {
            var dlData = await _ImemberTypeControl.deleteData(MemberTypeCode);
            return Ok(dlData);

        }

    }

  
}
