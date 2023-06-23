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
    public class AutorService : BaseService, IAutorService
    {
        private readonly IAutorRepository _autorRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AutorService(IAutorRepository autorRepository, IUnitOfWork unitOfWork)
        {
            _autorRepository = autorRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Add(Autor autor)
        {
            if (!ExecutarValidacao(new AutorValidation(), autor)) return false;

            _autorRepository.Save(autor);
            await _unitOfWork.Commit();
            return true;
        }

        public async Task<bool> Remove(int id)
        {
            var wasRemoved = _autorRepository.Delete(id);

            if (wasRemoved)
            {
                await _unitOfWork.Commit();
                return true;
            }
            else
                return false;
        }

        public async Task<bool> Update(Autor autor)
        {
            if (!ExecutarValidacao(new AutorValidation(), autor)) return false;

            _autorRepository.Update(autor);
            await _unitOfWork.Commit();
            return true;
        }

        public void Dispose()
        {
            _autorRepository?.Dispose();
        }
    }
}