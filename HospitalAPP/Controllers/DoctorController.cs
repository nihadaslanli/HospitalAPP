using AutoMapper;
using HospitalAPP.Dtos.DoctorDtos;
using HospitalAPP.DLL.Entities;
using HospitalAPP.Dtos.DoctorDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HospitalAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly HospitalAPP.Context _appContext;
        private readonly IMapper _mapper;

        public DoctorController(HospitalAPP.Context appContext, IMapper mapper)
        {
            _appContext = appContext;
            _mapper = mapper;
        }

        [HttpGet("")]
        public async Task<IActionResult> Get(int page = 1, string search = null)
        {
            var query = _appContext.Doctors.AsQueryable();
            if (search != null)
                query = query.Where(d => d.Name.ToLower().Contains(search.ToLower()));
            var datas = await query
                .Skip((page - 1) * 3)
                .Take(3)
                .Include(d => d.Department)
                .ToListAsync();
            var totalCount = await query.CountAsync();
            DoctorListDto doctorListDto = new();
            doctorListDto.Doctors = _mapper.Map<List<DoctorReturnDto>>(datas);
            doctorListDto.CurrentPage = page;
            doctorListDto.TotalCount = totalCount;
            return Ok(doctorListDto);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var existDoctor = await _appContext.Doctors
                .AsNoTracking()
                .Include("Department")
                .FirstOrDefaultAsync(d => d.Id == id);
            if (existDoctor == null) return NotFound();
            return Ok(_mapper.Map<DoctorReturnDto>(existDoctor));
        }
        [HttpPost("")]
        public async Task<IActionResult> Create(DoctorCreateDto doctorCreateDto)
        {
            var existDepart = await _appContext.Departments.Include("Doctors").FirstOrDefaultAsync(d => d.Id == doctorCreateDto.DepartmentId);
            if (existDepart == null)
                return BadRequest("Department is not found...");
            if (existDepart.Doctors.Count() >= existDepart.Limit)
                return Conflict("Group limit reached..");

            Doctor doctor = _mapper.Map<Doctor>(doctorCreateDto);
         await _appContext.Doctors.AddAsync(doctor);
            await _appContext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existDoctor = await _appContext.Doctors.FirstOrDefaultAsync(d => d.Id == id);
            if (existDoctor is null) return NotFound();
            _appContext.Doctors.Remove(existDoctor);
            await _appContext.SaveChangesAsync();
            return NoContent();

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, DoctorUpdateDto doctorUpdateDto)
        {
            var existDoctor = await _appContext.Doctors.Include(d => d.Department).FirstOrDefaultAsync(d => d.Id == id);
            if (existDoctor is null) return NotFound();
            if (existDoctor.DepartmentId != doctorUpdateDto.DepartmentId)
            {
                var existDep = await _appContext.Departments.Include(d => d.Doctors).FirstOrDefaultAsync(d => d.Id == doctorUpdateDto.DepartmentId);
                if (existDep is null)
                    return NotFound("Group not found");

                if (existDep.Doctors.Count() >= existDep.Limit)
                    return Conflict("Group limit reached..");
            }
            _mapper.Map(doctorUpdateDto, existDoctor);
            existDoctor.UpdateDate = DateTime.Now;
            await _appContext.SaveChangesAsync();
            return NoContent();
        }

    }
}
