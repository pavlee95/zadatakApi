using Bogus;
using Microsoft.AspNetCore.Mvc;
using Zadatak.Domain;
using Zadatak.EFDataAccess;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Zadatak.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FakerController : ControllerBase
    {
        private readonly ZadatakContext _context;

        public FakerController(ZadatakContext context)
        {
            _context = context;
        }

        // GET: api/<FakerController>
        [HttpGet]
        public IActionResult Get()
        {
            //var rolesIds = _context.Users.Select(x => x.Id).ToList();
            //var users = GetFakeUsers(rolesIds);
            //_context.Users.AddRange(users);


            _context.SaveChanges();

            return Ok();
        }

        private static List<User> GetFakeUsers(List<int> rolesIds)
        {
            var usersFaker = new Faker<User>();
            usersFaker.RuleFor(u => u.UserName, f => f.Internet.UserName());
            usersFaker.RuleFor(u => u.FirstName, f => f.Name.FirstName());
            usersFaker.RuleFor(u => u.LastName, f => f.Name.LastName());
            usersFaker.RuleFor(u => u.Password, f => f.Internet.Password());
            usersFaker.RuleFor(u => u.Email, f => f.Internet.Email());
            usersFaker.RuleFor(u => u.RoleId, f => f.PickRandom(rolesIds));

            var users = usersFaker.Generate(20);
            return users;
        }
    }
}
