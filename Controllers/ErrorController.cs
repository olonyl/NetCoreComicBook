using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NicaSource.Controllers
{
    [AllowAnonymous] // Only needed if authorization is set up globally for the app
    [Route("Error")]
    public class ErrorController : Controller
    {
        [Route("404")]
        public IActionResult NotFound()
        {
            return View();
        }
    }
}