using EshopOnline.Application.DTO;
using EshopOnline.Application.Interfaces;
using EshopOnline.Domain.Entities;
using EshopOnline.Domain.Interface;
using EshopOnline.Domain.Interface.Pattern;

namespace EshopOnline.Application.Services
{
    public class PropertisTitleService : IPropertisTitleService
    {
        private readonly IPropertiseTitleRepository _propertiseTitleRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PropertisTitleService(IPropertiseTitleRepository propertiseTitleRepository,
                                      IUnitOfWork unitOfWork)
        {
            _propertiseTitleRepository = propertiseTitleRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<long> InsertAsync(PropertisTitleDto model)
        {
            PropertisTitle propertiseTitle = new PropertisTitle();
            propertiseTitle.Title = model.Title;
            propertiseTitle.CreateDate = DateTime.Now;
            var result = await _propertiseTitleRepository.InsertAsync(propertiseTitle);
            
            _unitOfWork.SaveChanges();

            return result.ID;
        }
    }
}
