using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Poo_AS.Domain.DTOs;
using Poo_AS.Domain.Entities;
using Poo_AS.Domain.Entities.Interfaces;
using Poo_AS.Domain.ViewModels;

namespace Poo_AS.Controllers
{
    [Route("api/livros")]
    public class LivroController : ControllerBase
    {
        private readonly ILivroRepository _livroRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public LivroController(ILivroRepository livroRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _livroRepository = livroRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var livros = _mapper.Map<IList<LivroDTO>>(await _livroRepository.GetAllAsync());
            return HttpMessageOk(livros);
        }
        
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var livro = _mapper.Map<LivroDTO>(await _livroRepository.GetByIdAsync(id));
            return HttpMessageOk(livro);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(LivroViewModel model)
        {
            var livro = _mapper.Map<Livro>(model); 
            _livroRepository.Save(livro);
            await _unitOfWork.Commit();

            return HttpMessageOk(_mapper.Map<LivroDTO>(livro));
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateAsync(int id, LivroViewModel model)
        {
            var livro = await _livroRepository.GetByIdAsync(id);
            if (livro == null) return NotFound();

            // Atualiza as propriedades do livro com base no LivroViewModel
            livro.Titulo = model.Titulo;
            livro.UsuarioId = model.UsuarioId;

            // Mapeia a lista de autores do LivroViewModel para a lista de autores do Livro
            livro.Autores = _mapper.Map<List<Autor>>(model.Autores);

            _livroRepository.Update(livro);
            await _unitOfWork.Commit();

            return Ok(livro);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> RemoveAsync(int id)
        {
            var livro = await _livroRepository.GetByIdAsync(id);

            if (livro == null) return NotFound();
            var wasRemoved = _livroRepository.Delete(id);
            await _unitOfWork.Commit();
            return HttpMessageOk(id);
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