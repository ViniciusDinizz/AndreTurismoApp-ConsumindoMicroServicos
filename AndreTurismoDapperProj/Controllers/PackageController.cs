using AndreTurismoDapperProj.Models;
using AndreTurismoDapperProj.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AndreTurismoDapperProj.Controllers
{
    [Route("api/Package")]
    [ApiController]
    public class PackageController : ControllerBase
    {
        private readonly PackageService _packageService;

        public PackageController()
        {
            _packageService = new PackageService();
        }
        [HttpGet]
        public async Task<ActionResult>  GetAll()
        {
            var package = _packageService.GetAll();
            if (package is null) return NotFound();

            return Ok(package);
        }
        /*[HttpGet("{Id}", Name = "GetPackageId")]
        public ActionResult GetId(int id)
        {
            var package = _packageRepository.GetId(id);
            if (package is null) return NotFound();

            return Ok(package);
        }*/
        [HttpPost]
        public async Task<ActionResult> Create(Package package)
        {
            if (package is null) return NotFound();
            package = await _packageService.Create(package);
            return Ok(package);
        }
        /*[HttpDelete]
        public ActionResult Delete(int id)
        {
            var package = (_packageRepository.GetId(id));
            if (package is null) return NotFound();
            _packageRepository.Delete(id);
            return Ok();
        }
        [HttpPut]
        public ActionResult Update(Package package)
        {
            var id = _packageRepository.GetId(package.Id);
            if (id is null) return NotFound();
            _packageRepository.Update(package);
            return Ok();
        }*/
    }
}
