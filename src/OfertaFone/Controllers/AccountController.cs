using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OfertaFone.Domain.Entities;
using OfertaFone.Domain.Interfaces;
using OfertaFone.Utils.Attributes;
using OfertaFone.Utils.Exceptions;
using OfertaFone.Utils.Extensions;
using OfertaFone.WebUI.Identity;
using OfertaFone.WebUI.Tipo;
using OfertaFone.WebUI.ViewModels.Account;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace OfertaFone.WebUI.Controllers
{
    public class AccountController : BaseController
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IRepository<Usuario> _userRepository;
        private readonly IRepository<PerfilUsuario> _perfilRepository;
        private readonly IFileStorage fileStorage;

        public AccountController(
            SignInManager<ApplicationUser> signInManager,
            IRepository<Usuario> userRepository,
            IRepository<PerfilUsuario> perfilRepository,
            IFileStorage _fileStorage)
        {
            _signInManager = signInManager;
            _userRepository = userRepository;
            _perfilRepository = perfilRepository;
            fileStorage = _fileStorage;
        }

        [HttpGet, AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            return View();
        }

        [HttpPost, AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = await _userRepository.Table.Where(user => user.Login.ToLower() == loginViewModel.Username.ToLower()).FirstOrDefaultAsync();
                    if (user == null || user.Id < 1)
                    {
                        throw new LogicalException("Nome de usuário não registrado!");
                    }

                    if (!user.Senha.Equals(loginViewModel.Password))
                    {
                        throw new LogicalException("Senha inválida!");
                    }

                    HttpContext.Session.Set("UserId", user.Id);
                    var result = await _signInManager.PasswordSignInAsync(
                       loginViewModel.Username,
                       loginViewModel.Password,
                       loginViewModel.RememberMe,
                       lockoutOnFailure: false);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("EditProfile", "Account");
                    }

                }
            }
            catch (Exception ex)
            {
                TratarException(ex);
            }
            return View(loginViewModel);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Vitrine");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet, AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        ///
        [HttpPost, AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            try
            {
                if (registerViewModel.Password != registerViewModel.ConfirmPassword)
                {
                    ModelState.AddModelError(nameof(registerViewModel.ConfirmPassword), "As senhas não coincidem.");
                }

                if (ModelState.IsValid)
                {
                    var usuario = new Usuario()
                    {
                        Nome = registerViewModel.Nome,
                        Login = registerViewModel.Username,
                        Senha = registerViewModel.Password,
                        Email = registerViewModel.Email,
                        Situacao = (int?)TipoSituacao.ATIVO,
                        PerfilUsuarioId = (int?)TipoPerfil.ADMIN,
                        Image = TipoImagensPadrao._USUARIO
                    };

                    if (await _userRepository.Table.Where(a => a.Login.ToLower() == registerViewModel.Username.ToLower()).FirstOrDefaultAsync() != null)
                    {
                        throw new LogicalException("Já existe um usuário registrado com o nome de usuário inserido.");
                    }

                    if (await _userRepository.Table.Where(u => u.Email == usuario.Email).AnyAsync())
                    {
                        throw new LogicalException("Já existe um usuário cadastrado com o e-mail fornecido.");
                    }

                    await _userRepository.Insert(usuario);
                    await _userRepository.CommitAsync();

                    AddSuccess("Usuário cadastrado com sucesso!");
                    return RedirectToAction("Login", "Account");
                }
            }
            catch (Exception ex)
            {
                TratarException(ex);
            }

            return View(registerViewModel);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet, Authorize, SessionExpire]
        public async Task<IActionResult> EditProfile()
        {
            var user = await _userRepository.FindById(HttpContext.Session.Get<int>("UserId"));
            var perfis = await _perfilRepository.Table.Where(a => a.Situacao == (int)TipoSituacao.ATIVO).ToListAsync();

            var viewModel = new EditProfileViewModel()
            {
                Email = user.Email,
                Username = user.Login,
                Nome = user.Nome,
                PerfilUsuarioId = user.PerfilUsuarioId,
                Image = user.Image,
                CpfCnpj = user.CpfCnpj,
                DataNascimento = user.DataNascimento,
                Perfis = perfis.Select(p => new SelectListItem
                {
                    Text = p.Nome,
                    Value = p.Id.ToString(),
                }).ToList(),
            };
            return View(viewModel);
        }

        [HttpPost, Authorize, SessionExpire]
        public async Task<IActionResult> EditProfile(EditProfileViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string UrlImg = await Request.UploadFile(fileStorage);

                    var user = await _userRepository.FindById(HttpContext.Session.Get<int>("UserId"));
                    user.CpfCnpj = viewModel.CpfCnpj;
                    user.Nome = viewModel.Nome;
                    user.DataNascimento = viewModel.DataNascimento;
                    viewModel.Image = user.Image = UrlImg ?? user.Image;

                    await _userRepository.Update(user);
                    await _userRepository.CommitAsync();

                    AddSuccess("Usuário editado com sucesso!");
                }
            }
            catch (Exception ex)
            {
                TratarException(ex);
            }
            return View(viewModel);
        }

        [HttpGet, AllowAnonymous]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        ///
        [HttpPost, AllowAnonymous]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel forgotPasswordViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // TODO: Logica de esqueci minha senha
                    AddSuccess("Email de recuperação enviado!");
                    return RedirectToAction("Login", "Account");
                }
            }
            catch (Exception ex)
            {
                TratarException(ex);
            }

            return View(forgotPasswordViewModel);
        }
    }
}
