
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPP.Controllers
{
    public class DepartmentController
    {

        [HttpGet]
        public IActionResult <Department>Get()
        {
            return StatusCode(200, list);
        }
      


    }
}
