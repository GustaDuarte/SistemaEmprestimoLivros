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
    [Route("api/autores")]
    public class AutorController : ControllerBase
    {
        private readonly IAutorRepository _autorRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AutorController(IAutorRepository autorRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _autorRepository = autorRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var autores = _mapper.Map<IList<AutorDTO>>(await _autorRepository.GetAllAsync());
            return HttpMessageOk(autores);
        }
        
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var autor = _mapper.Map<AutorDTO>(await _autorRepository.GetByIdAsync(id));
            return HttpMessageOk(autor);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(AutorViewModel model)
        {
            var autor = _mapper.Map<Autor>(model); 
            _autorRepository.Save(autor);
            await _unitOfWork.Commit();

            return HttpMessageOk(_mapper.Map<AutorDTO>(autor));
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateAsync(int id, AutorViewModel model)
        {
            var autor = await _autorRepository.GetByIdAsync(id);
            if (autor == null) return NotFound();

            autor.Nome = model.Nome;
            autor.Telefone = model.Telefone;
            autor.LivroId = model.LivroId;

            _autorRepository.Update(autor);
            await _unitOfWork.Commit();

            return Ok(autor);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> RemoveAsync(int id)
        {
            var autor = await _autorRepository.GetByIdAsync(id);

            if (autor == null) return NotFound();
            var wasRemoved = _autorRepository.Delete(id);
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