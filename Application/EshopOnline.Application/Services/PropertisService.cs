using EshopOnline.Application.DTO;
using EshopOnline.Application.DTOs;
using EshopOnline.Application.Interfaces;
using EshopOnline.Domain.Entities;
using EshopOnline.Domain.Interface;
using EshopOnline.Domain.Interface.Pattern;

namespace EshopOnline.Application.Services
{
    public class PropertisService : IPropertisService
    {
        private readonly IPropertisRepository _propertiseRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PropertisService(IPropertisRepository propertiseRepository,
                                 IUnitOfWork unitOfWork)
        {
            _propertiseRepository = propertiseRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<long> InsertAsync(PropertisDto model)
        {
            Propertis propertise = new Propertis();
            propertise.TitleID = model.TitleID;
            propertise.Title = model.Title;
            propertise.CreateDate = DateTime.Now;
            var result = await _propertiseRepository.InsertAsync(propertise);
            
            _unitOfWork.SaveChanges();

            return result.ID;
        }
    }
}
