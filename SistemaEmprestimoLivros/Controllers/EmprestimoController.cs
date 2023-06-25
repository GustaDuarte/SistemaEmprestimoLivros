using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebApi.Domain.DTOs;
using WebApi.Domain.Entities;
using WebApi.Domain.Interfaces.RepositoryInterfaces;
using WebApi.Domain.ViewModels;

namespace WebApi.Controllers
{
    [Route("api/emprestimos")]
    public class EmprestimoController : ControllerBase
    {
        private readonly IEmprestimoRepository _emprestimoRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmprestimoController(IEmprestimoRepository emprestimoRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _emprestimoRepository = emprestimoRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var emprestimos = _mapper.Map<IList<EmprestimoDTO>>(await _emprestimoRepository.GetAllAsync());
            return HttpMessageOk(emprestimos);
        }
        
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var emprestimo = _mapper.Map<EmprestimoDTO>(await _emprestimoRepository.GetByIdAsync(id));
            return HttpMessageOk(emprestimo);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] EmprestimoViewModel model)
        {
            var emprestimo = _mapper.Map<Emprestimo>(model);

            if (model.DataDevolucao == null)
            {
                emprestimo.DataDevolucao = DateTime.MinValue;
            }

            _emprestimoRepository.Save(emprestimo);
            await _unitOfWork.Commit();

            return HttpMessageOk(_mapper.Map<EmprestimoDTO>(emprestimo));
        }


        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] EmprestimoViewModel model)
        {
            if (!ModelState.IsValid) return HttpMessageError("Dados incorretos");

            var emprestimo = await _emprestimoRepository.GetByIdAsync(id);
            if (emprestimo == null) return NotFound();

            emprestimo.DataEmprestimo = model.DataEmprestimo;
            emprestimo.DataDevolucao = model.DataDevolucao;
            emprestimo.LivroId = model.LivroId;
            emprestimo.UsuarioId = model.UsuarioId;

            _emprestimoRepository.Update(emprestimo);
            await _unitOfWork.Commit();

            return Ok(emprestimo);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> RemoveAsync(int id)
        {
            var emprestimo = await _emprestimoRepository.GetByIdAsync(id);

            if (emprestimo == null) return NotFound();
            var wasRemoved = _emprestimoRepository.Delete(id);
            await _unitOfWork.Commit();

            return HttpMessageOk(id);
        }

        [HttpPost("emprestar-livro")]
        public async Task<IActionResult> EmprestarLivroAsync([FromBody] EmprestimoViewModel model)
        {
            var emprestimo = _mapper.Map<Emprestimo>(model); 
            _emprestimoRepository.Save(emprestimo);
            await _unitOfWork.Commit();

            return HttpMessageOk(_mapper.Map<EmprestimoDTO>(emprestimo));
        }

        [HttpPost("devolver-livro/{id:int}")]
        public async Task<IActionResult> DevolverLivroAsync(int id)
        {
            var emprestimo = await _emprestimoRepository.GetByIdAsync(id);

            if (emprestimo == null) return NotFound();

            // Realizar ações necessárias para a devolução do livro (lógica de negócio específica)

            var wasRemoved = _emprestimoRepository.Delete(id);
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