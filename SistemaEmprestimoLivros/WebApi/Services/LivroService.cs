using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Interfaces;
using Poo_AS.Domain.Entities;
using Poo_AS.Domain.Entities.Interfaces;
using Poo_AS.Domain.Entities.Validations;
using Poo_AS.Domain.Interfaces.ServiceInterfaces;
using Services;

namespace WebApi.Services
{
    public class LivroService : BaseService, ILivroService
    {
        private readonly ILivroRepository _livroRepository;
        private readonly IUnitOfWork _unitOfWork;

        public LivroService(ILivroRepository livroRepository, IUnitOfWork unitOfWork)
        {
            _livroRepository = livroRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Add(Livro livro)
        {
            if (!ExecutarValidacao(new LivroValidation(), livro)) return false;

            _livroRepository.Save(livro);
            await _unitOfWork.Commit();
            return true;
        }

        public async Task<bool> Remove(int id)
        {
            var wasRemoved = _livroRepository.Delete(id);

            if (wasRemoved)
            {
                await _unitOfWork.Commit();
                return true;
            }
            else
                return false;
        }

        public async Task<bool> Update(Livro livro)
        {
            if (!ExecutarValidacao(new LivroValidation(), livro)) return false;

            _livroRepository.Update(livro);
            await _unitOfWork.Commit();
            return true;
        }

        public Task<bool> UpdateAutor(Autor autor)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _livroRepository?.Dispose();
        }


    }
}