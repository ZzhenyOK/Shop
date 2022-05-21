using Shop.BLL.DTO;
using Shop.DAL.Context;
using Shop.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.BLL.Services
{
    public class ManufactureService
    {
        private ManufactureRepository manufactureRepository;

        public object Manufacture { get; private set; }

        public ManufactureService(ManufactureRepository manufactureRepository)
        {
            this.manufactureRepository = manufactureRepository;
        }
        public IEnumerable<ManufactureDTO> GetAll()
        {
            return manufactureRepository
                .GetAll()
                .Select(manufacture => new ManufactureDTO
                {
                    Id = manufacture.ManufactureId,
                    Name = manufacture.ManufactureName
                });
        }
        public ManufactureDTO Get(int Id)
        {
            var manufacture = manufactureRepository.Get(Id);
            return new ManufactureDTO
            {
                Id = manufacture.ManufactureId,
                Name=manufacture.ManufactureName
            };
        }
        public void Delete(ManufactureDTO manufactureDTO)
        {
            var manufactureToDelete = manufactureRepository.Get(manufactureDTO.Id);
            manufactureRepository.Delete(manufactureToDelete);
            manufactureRepository.Save();
        }
        public void Update(ManufactureDTO manufactureDTO)
        {
            var manufactureToUpdate = manufactureRepository.Get(manufactureDTO.Id);
            manufactureToUpdate.ManufactureName = manufactureDTO.Name;
            manufactureRepository.CreateOrUpdate(manufactureToUpdate);
            manufactureRepository.Save();
        }
        public ManufactureDTO Create(ManufactureDTO manufactureDTO)
        {
            var manufacture = new Manufacture { ManufactureName = manufactureDTO.Name };
            manufactureRepository.CreateOrUpdate(manufacture);
            manufacture.ManufactureId = manufactureDTO.Id;
            manufactureRepository.Save();
            return manufactureDTO;
        }
    }
}
