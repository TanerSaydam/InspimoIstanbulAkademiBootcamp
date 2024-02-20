using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DependencyInjection.WebAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ValuesController(IClass1 class1) : ControllerBase
{

    [HttpGet]
    public IActionResult Get()
    {
        class1.Method();

        return Ok();
    }      

}

public interface IClass1
{
    void Method();
}

public class Class1 : IClass1
{
    public Class1(Student student)
    {
        
    }

    public void Method()
    {

    }
}

public class Class2 : IClass1
{
    public Class2(Student student)
    {

    }

    public void Method()
    {

    }
}

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
}
