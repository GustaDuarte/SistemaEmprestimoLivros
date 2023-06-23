using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Poo_AS.Domain.DTOs;
using Poo_AS.Domain.Entities;
using Poo_AS.Domain.Entities.Interfaces;
using Poo_AS.Domain.Interfaces.ServiceInterfaces;
using Poo_AS.Domain.ViewModels;

namespace WebApi.Controllers
{
    [Route("api/usuarios")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IUsuarioService _usuarioService;
        private readonly IMapper _mapper;

        public UsuarioController(IUsuarioRepository usuarioRepository, IUsuarioService usuarioService, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _usuarioService = usuarioService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var usuarios = _mapper.Map<IList<UsuarioDTO>>(await _usuarioRepository.GetAllAsync());
            return HttpMessageOk(usuarios);
        }
        
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var usuario = _mapper.Map<UsuarioDTO>(await _usuarioRepository.GetByIdAsync(id));
            return HttpMessageOk(usuario);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(UsuarioViewModel model)
        {
            if (!ModelState.IsValid) return HttpMessageError("Dados incorretos");

            var usuario = _mapper.Map<Usuario>(model);
            var result = await _usuarioService.Add(usuario);

            if (!result) return HttpMessageError("Dados invalidos");

            return HttpMessageOk(_mapper.Map<UsuarioDTO>(usuario));
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> RemoveAsync(int id)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(id);

            if (usuario == null) return NotFound();

            var result = await _usuarioService.Remove(id);

            if (!result) return HttpMessageError("Não foi possível remover o autor");

            return HttpMessageOk(id);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateAsync(int id, UsuarioViewModel model)
        {
            if (!ModelState.IsValid) return HttpMessageError("Dados incorretos");

            var usuario = _mapper.Map<Usuario>(model);
            
            var result = await _usuarioService.Update(usuario);

            if (!result) return HttpMessageError("Dados invalidos");

            return HttpMessageOk(_mapper.Map<UsuarioDTO>(usuario));
        }

        private IActionResult HttpMessageOk(dynamic data = null)
        {
            if (data == null)
                return NoContent();
            else
                return Ok(new
                {
                    data
                });
        }

        private IActionResult HttpMessageError(string message = "")
        {
            return BadRequest(new
            {
                message
            });
        }
    }
}