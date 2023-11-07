using MeuBancoBackend.DTO;
using MeuBancoBackend.Extension;
using MeuBancoBackend.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MeuBancoBackend.Service
{
    public class UsuarioService : IUsuarioService
    {

        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly AppSetting _appSettings;

        public UsuarioService(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            IOptions<AppSetting> appSettings
            ) 
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _appSettings = appSettings.Value;
        }

        public IdentityUser CadastrarUsuario(NovoUsuarioDTO usuario)
        {
            IdentityUser user = new IdentityUser()
            {
                Email = usuario.Email,
                EmailConfirmed = true,
                UserName = usuario.Email,
            };
            _ = _userManager.CreateAsync(user, usuario.Senha).Result;
            return user;
        }

        public async Task<SignInResult> Login(LoginDTO usuario)
        {
            SignInResult result = await _signInManager.PasswordSignInAsync(usuario.Email, usuario.Password, false, true);

            return result;
        }

        public async Task<LoginResponseDTO> GerarTokenJwt(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var claims = await _userManager.GetClaimsAsync(user);

            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id));
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Nbf, ToUnixEpochDate(DateTime.UtcNow).ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(DateTime.UtcNow).ToString(), ClaimValueTypes.Integer64));

            var identityClaims = new ClaimsIdentity();
            identityClaims.AddClaims(claims);

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _appSettings.Emissor,
                Audience = _appSettings.ValidoEm,
                Subject = identityClaims,
                Expires = DateTime.UtcNow.AddHours(_appSettings.ExpiracaoHoras),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            });
            var encodedToken = tokenHandler.WriteToken(token);

            var response = new LoginResponseDTO
            {
                AccessToken = encodedToken,
                ExpiresIn = TimeSpan.FromHours(_appSettings.ExpiracaoHoras).TotalSeconds,
                Id = user.Id,
                Email = user.Email,
            };

            return response;
        }

        private static long ToUnixEpochDate(DateTime date)
            => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);

        public IdentityUser AtualizarUsuario(IdentityUser usuario)
        {
             _ = _userManager.UpdateAsync(usuario).Result;
            return usuario;
        }

        public IdentityUser BuscarUsuarioPeloId(string id)
        {
            return _userManager.FindByIdAsync(id).Result;
        }
    }
}
