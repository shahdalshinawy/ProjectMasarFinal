
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics.Eventing.Reader;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using job.DTO;
using job.Models;
using Microsoft.EntityFrameworkCore;

namespace job.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IConfiguration config;
        private readonly OnlineExamsEntity _context;
        //Rana
        public AccountController(UserManager<ApplicationUser> _userManager,IConfiguration _config,OnlineExamsEntity context)
        {
            userManager = _userManager;
            config = _config;
            _context = context;
        }

        //register
        [HttpPost("Regitser")]
        public async Task<ActionResult<Data>> Register(RegisterDTO registerDTO)
        {
            Data Return = new Data();
            if (ModelState.IsValid)
            {
                ApplicationUser appUser = new ApplicationUser();
                appUser.Email = registerDTO.email;
                appUser.UserName = registerDTO.username;
                

                IdentityResult result = await userManager.CreateAsync(appUser, registerDTO.password);
                if (result.Succeeded)
                {

                    Profile profile = new Profile();
                    profile.Id=appUser.Id;
                    profile.ForthName = registerDTO.FourthName;
                    profile.NationalID = registerDTO.NationalID;
                    profile.userNumber = registerDTO.UserNumber;
                    profile.IsStudent = registerDTO.IsStudent;
                    profile.UserName = registerDTO.username;
                    Return.Message = "Success";
                    Return.IsPass = true;
                    if (registerDTO.IsStudent)
                    {
                        await userManager.AddToRoleAsync(appUser, "IsStudent");
                        profile.IsStudent = true;

                        Return.IsStudent = true;

                    }
                    else
                    {
                        await userManager.AddToRoleAsync(appUser, "IsTeacher");
                        profile.IsTeacher = true;
                        Return.IsStudent = false;

                    }
                    _context.profile.Add(profile);
                    _context.SaveChanges();

                    return Ok(Return);
                }
                else
                    Return.Message = "NotVaild";
                    return Ok(Return);

            }

            return Content("Not Vaild");
        }



        [HttpPost("Login")]
        public async Task<ActionResult<DataReturnlogin>> Login(LoginDTO loginDTO)
        {
            DataReturnlogin data = new DataReturnlogin();
            if (ModelState.IsValid)
            {
                //check ....
                ApplicationUser usermodel = await userManager.FindByNameAsync(loginDTO.UserName);
                if (usermodel != null && await userManager.CheckPasswordAsync(usermodel, loginDTO.password))
                {
                    //create cliams
                    List<Claim> myclaim = new List<Claim>();
                    myclaim.Add(new Claim(ClaimTypes.NameIdentifier, usermodel.Id));
                    myclaim.Add(new Claim(ClaimTypes.Name, usermodel.UserName));
                    myclaim.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));

                    List<string> role = (List<string>)await userManager.GetRolesAsync(usermodel);
                    if (role != null)
                    {
                        foreach (var claim in role)
                        {
                            myclaim.Add(new Claim(ClaimTypes.Role, claim));
                        }
                    }

                    //signingCredentials ---->( key , alg) in --> header

                    //key ==> (semantissecrtkey)

                    var authSecuritKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWT:SecrytKey"]));


                    SigningCredentials credentials =
                        new SigningCredentials(authSecuritKey, SecurityAlgorithms.HmacSha256);


                    //represent token
                    JwtSecurityToken mytoken = new JwtSecurityToken(
                        issuer: config["JWT:ValidIss"],
                        audience: config["JWT:ValidAud"],
                        expires: DateTime.UtcNow.AddDays(3),
                        claims: myclaim,
                        signingCredentials: credentials
                        );
                    //create token
                    return Ok(
                     new
                     {
                        token= new JwtSecurityTokenHandler().WriteToken(mytoken),

                     }
              
                     );
                    
                    data.Message = "Success";
                    data.IsPass = true;
                    
                    return Ok(data);
                }
                else
                {
                  data.Message = "NotValid";
                    return Ok(data);
                }
            }
            return Content("Invalid");

        }
    }
}
