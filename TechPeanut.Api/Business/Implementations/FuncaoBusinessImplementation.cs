using TechPeanut.Api.Data.Converter.Implementations;
using TechPeanut.Api.Data.VO;
using TechPeanut.Api.Models;
using TechPeanut.Api.Repository.Generic;

namespace TechPeanut.Api.Business.Implementations
{
    public class FuncaoBusinessImplementation : IFuncaoBusiness
    {
        private readonly IRepository<Funcao> _repository;
        private readonly FuncaoConverter _converter;

        public FuncaoBusinessImplementation(IRepository<Funcao> repository)
        {
            _repository = repository;
            _converter = new FuncaoConverter();
        }

        public List<FuncaoVO> FindAll()
        {
            return _converter.Parse(_repository.FindAll());
        }

        public FuncaoVO FindById(int id)
        {
            return _converter.Parse(_repository.FindById(id));
        }

        public FuncaoVO Create(FuncaoVO Funcao)
        {
            var FuncaoEntity = _converter.Parse(Funcao);
            FuncaoEntity = _repository.Create(FuncaoEntity);

            return _converter.Parse(FuncaoEntity);
        }

        public FuncaoVO Update(FuncaoVO Funcao)
        {
            var FuncaoEntity = _converter.Parse(Funcao);
            FuncaoEntity = _repository.Update(FuncaoEntity);

            return _converter.Parse(FuncaoEntity);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
