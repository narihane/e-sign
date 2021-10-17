using eInvoice.Models.AppSettings;
using eInvoice.Models.DTOModel;
using eInvoice.Models.Enums;
//using eInvoice.Models.Models;
using eInvoice.Services.Repositories;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace eInvoice.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepo;
        //private readonly IGenericRepository<User> genericRepo;
        private readonly Jwt jwtSettings;

        //public UserService(IUserRepository userRepo, IGenericRepository<User> genericRepo, IOptions<Jwt> jwtSettings)
        //{
        //    this.userRepo = userRepo;
        //    this.jwtSettings = jwtSettings.Value;
        //    this.genericRepo = genericRepo;
        //}

        //public AuthResponseModel LogIn(AuthRequestModel model)
        //{
        //    var user = userRepo.GetUser(model.UserName, model.Password);

        //    // return null if user not found
        //    if (user == null) return null;

        //    // authentication successful so generate jwt token
        //    var token = generateJwtToken(user);

        //    return new AuthResponseModel(user, token);
        //}

        //public void Register(UserRegisterationModel model)
        //{
        //    var user = userRepo.GetUser(model.UserName, model.Password);

        //    // return null if user not found
        //    if (user != null)
        //    {
        //        throw new Exception("User already registered");
        //    }

        //    var userObject = new User
        //    {
        //        Password = model.Password,
        //        Role = UserRole.user.ToString(),
        //        Username = model.UserName,
        //        Usersdetail = new Usersdetail
        //        {
        //            FirstName = model.FirstName,
        //            LastName = model.LastName,
        //            FullName = $"{model.FirstName.Trim()} {model.LastName.Trim()}",
        //            Email = model.Email,
        //            FullAddress = $"{model.Country}, {model.City},{model.Street}",
        //            Phone = model.Phone,
        //            City = model.City,
        //            Country = model.Country,
        //            Street = model.Street
        //        }
        //    };

        //    genericRepo.Insert(userObject);
        //}

        //public IEnumerable<User> GetAll()
        //{
        //    return genericRepo.GetAll();
        //}

        //public User GetById(int id)
        //{
        //    return genericRepo.GetById(id);
        //}

        //private string generateJwtToken(User user)
        //{
        //    // generate token that is valid for 7 days
        //    var tokenHandler = new JwtSecurityTokenHandler();
        //    var key = Encoding.ASCII.GetBytes(jwtSettings.Key);
        //    var tokenDescriptor = new SecurityTokenDescriptor
        //    {
        //        Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
        //        Expires = DateTime.UtcNow.AddDays(7),
        //        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        //    };
        //    var token = tokenHandler.CreateToken(tokenDescriptor);
        //    return tokenHandler.WriteToken(token);
        //}
    }
}
