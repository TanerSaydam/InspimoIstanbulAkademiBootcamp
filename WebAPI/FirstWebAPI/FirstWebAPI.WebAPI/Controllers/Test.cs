using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace FirstWebAPI.WebAPI.Controllers;

[ApiController]
[Route("/api/[controller]/[action]")]
public class Test : ControllerBase
{
    [HttpGet]
    //[HttpPost]
    //[HttpPut] //postun aynısı
    //[HttpDelete] //get'in aynısı    
    public IActionResult GetAll(string name) //primitive => ilkel tipler parametre olarak istenebilir
    {
        return Ok(new {Message = "Sayın " + name + " API çalışıyor..."});
    }

    [HttpPost]
    public IActionResult Create(string name)
    {
        return Ok(new { Message = "Sayın " + name + " API çalışıyor..." });
    }

    [HttpPost]
    public IActionResult Update(string name)
    {
        return Ok(new { Message = "Sayın " + name + " API çalışıyor..." });
    }

    [HttpGet]
    public IActionResult DeleteById(string name)
    {
        return Ok(new { Message = "Sayın " + name + " API çalışıyor..." });
    }
}
