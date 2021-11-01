using AutoMapper;
using eInvoice.Models.AppSettings;
using eInvoice.Models.DTOModel;
using eInvoice.Models.Enums;
using eInvoice.Models.Models;
using eInvoice.Services.Clients;
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
        private readonly IdentityServiceHttpClient httpClient;
        private readonly IGenericRepository<User> genericRepo;
        private readonly Jwt jwtSettings;
        private readonly IMapper mapper;

        public UserService(IUserRepository userRepo, IGenericRepository<User> genericRepo, IOptions<Jwt> jwtSettings, IdentityServiceHttpClient httpClient, IMapper mapper)
        {
            this.userRepo = userRepo;
            this.jwtSettings = jwtSettings.Value;
            this.genericRepo = genericRepo;
            this.httpClient = httpClient;
            this.mapper = mapper;
        }

        public async Task<string> LogIn(AuthRequestModel model)
        {
            var user = userRepo.GetByUsername(model.UserName);
            if (user == null)
                throw new UnauthorizedAccessException($"Incorrect username: {model.UserName}");

            // verify password
            bool verified = BCrypt.Net.BCrypt.Verify(model.Password, user.Password);
            if (!verified)
                throw new UnauthorizedAccessException("Incorrect Password!");

            if (user.Role == UserRole.User)
            {
                // authentication successful so generate User jwt token
                var token = generateJwtToken(user);
                return token;
            }

            // Get Admin Tax Payer Token
            var taxPayerToken = await httpClient.GetToken();
            return taxPayerToken;
        }

        public void Register(UserRegisterationModel model)
        {
            var user = userRepo.GetUser(model.UserName, model.Password);

            // return null if user not found
            if (user != null)
                throw new Exception("User already registered");

            model.Password = BCrypt.Net.BCrypt.HashPassword(model.Password);

            var userObject = mapper.Map<UserRegisterationModel, User>(model);

            if (userObject.Role == UserRole.Admin)
                userObject.Status = AccountStatus.Approved;
            else
                //Rejected until Admin approves
                userObject.Status = AccountStatus.Rejected;

            genericRepo.Insert(userObject);
        }

        public IEnumerable<User> GetAll()
        {
            return genericRepo.GetAll();
        }

        public User GetById(int id)
        {
            return genericRepo.GetById(id);
        }

        public User GetByUsername(string username)
        {
            return userRepo.GetByUsername(username);
        }

        private string generateJwtToken(User user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(jwtSettings.Key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public string Approve(int id)
        {
            var user = genericRepo.GetById(id);

            if (user == null)
                throw new Exception($"User with id:{id} does not exist!");

            user.Status = AccountStatus.Approved;
            genericRepo.Update(user);

            return AccountStatus.Approved.ToString();
        }

        public string Reject(int id)
        {
            var user = genericRepo.GetById(id);

            if (user == null)
                throw new Exception($"User with id:{id} does not exist!");

            user.Status = AccountStatus.Rejected;
            genericRepo.Update(user);

            return AccountStatus.Rejected.ToString();
        }

        public string Delete(int id)
        {
            var user = genericRepo.GetById(id);

            if (user == null)
                throw new Exception($"User with id:{id} does not exist!");

            genericRepo.Delete(user);

            return "User Account Deleted Succesfully!";
        }
    }
}
