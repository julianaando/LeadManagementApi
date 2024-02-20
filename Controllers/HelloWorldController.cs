using Microsoft.AspNetCore.Mvc;

namespace lead_management_api.Controllers;

// atributo para indicar ao compulador que a classe deve servir respostas às req HTTP
// permite que o app identifique se as infos enviadas para a api vêm do body, header ou queries
[ApiController]
// rota que o controller é acessado. Por estar como [controller], token replacement
// o atributo utiliza como rota o nome da classe (HelloController -> /Hello)
[Route("[controller]")]
public class HelloWorldController : Controller
{

    [HttpGet]
    public string Get() => "Hello world!";
}
