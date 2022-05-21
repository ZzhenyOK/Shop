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
    public class GoodService
    {
        private GoodRepository goodRepository;

        public GoodService(GoodRepository goodRepository)
        {
            this.goodRepository = goodRepository;
        }
        public IEnumerable<GoodDTO> GetAll()
        {
            return goodRepository
                .GetAll()
                .Select(good => new GoodDTO
                {
                    Id = good.GoodId,
                    Name = good.GoodName
                });
        }
        public GoodDTO Get(int Id)
        {
            var good = goodRepository.Get(Id);
            return new GoodDTO
            {
                Id = good.GoodId,
                Name= good.GoodName
            };
        }
        public void Delete(GoodDTO goodDTO)
        {
            var goodToDelete = goodRepository.Get(goodDTO.Id);
            goodRepository.Delete(goodToDelete);
            goodRepository.Save();
        }
        public void Update(GoodDTO goodDTO)
        {
            var goodToUpdate = goodRepository.Get(goodDTO.Id);
            goodToUpdate.GoodName = goodDTO.Name;
            goodRepository.CreateOrUpdate(goodToUpdate);
            goodRepository.Save();
        }
        public GoodDTO Create(GoodDTO goodDTO)
        {
            var good = new Good { GoodName = goodDTO.Name };
            goodRepository.CreateOrUpdate(good);
            goodDTO.Id = good.GoodId;
            goodRepository.Save();
            return goodDTO;
        }
    }
}
