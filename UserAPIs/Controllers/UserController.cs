using Microsoft.AspNetCore.Mvc;
namespace UserAPIs.Controllers;


[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{

    DataContextDapper _dapper;
    public UserController(IConfiguration config)
    {
        _dapper = new DataContextDapper(config);
    }

    [HttpGet("TestDbConnection")]
    public DateTime TestData()
    {
        return _dapper.LoadDataSingle<DateTime>("SELECT GETDATE()");
    }


    [HttpGet("GetUsers/{stringValue}")]
    public string[] GetUsers(string stringValue)
    {
        string[] stringResponse = new string[]{
            "test one", "test two", stringValue
        };
        return stringResponse;
    }
}