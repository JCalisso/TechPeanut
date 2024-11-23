using TechPeanut.Api.Data.Converter.Implementations;
using TechPeanut.Api.Data.VO;
using TechPeanut.Api.Models;
using TechPeanut.Api.Repository.Generic;

namespace TechPeanut.Api.Business.Implementations
{
    public class CargosBusinessImplementation : ICargosBusiness
    {
        private readonly IRepository<Cargos> _repository;
        private readonly CargosConverter _converter;

        public CargosBusinessImplementation(IRepository<Cargos> repository)
        {
            _repository = repository;
            _converter = new CargosConverter();
        }

        public List<CargosVO> FindAll()
        {
            return _converter.Parse(_repository.FindAll());
        }

        public CargosVO FindById(int id)
        {
            return _converter.Parse(_repository.FindById(id));
        }

        public CargosVO Create(CargosVO Cargos)
        {
            var CargosEntity = _converter.Parse(Cargos);
            CargosEntity = _repository.Create(CargosEntity);

            return _converter.Parse(CargosEntity);
        }

        public CargosVO Update(CargosVO Cargos)
        {
            var CargosEntity = _converter.Parse(Cargos);
            CargosEntity = _repository.Update(CargosEntity);

            return _converter.Parse(CargosEntity);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
