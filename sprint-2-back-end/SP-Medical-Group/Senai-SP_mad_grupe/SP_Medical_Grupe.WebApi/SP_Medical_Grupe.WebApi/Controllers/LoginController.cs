using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SP_Medical_Grupe.WebApi.Interfaces;
using SP_Medical_Grupe.WebApi.Repositories;
using SP_Medical_Grupe.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using SP_Medical_Grupe.WebApi.ViewModels;

namespace SP_Medical_Grupe.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository(); 
        }

        [HttpPost] 
        public IActionResult Post(LoginViewModel login)
        {
            try
            {
                Usuario usuarioBuscado = _usuarioRepository.Login(login.Email, login.Senha);

                if (usuarioBuscado == null)
                {
                    return NotFound("E-mail ou senha inválidos!");
                }

                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),
                    new Claim(ClaimTypes.Role, usuarioBuscado.IdTipoUsuario.ToString())
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("projetoSp_Medical_Groupe-api"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "ProjetoSp_Medical_Groupe.WebApi",
                    audience: "ProjetoSp_Medical_Groupe.WebApi",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(20),
                    signingCredentials: creds
                );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }
    }
}
