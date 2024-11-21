using TechPeanut.Api.Controllers;
using TechPeanut.Api.Data.Converter.Implementations;
using TechPeanut.Api.Data.VO;
using TechPeanut.Api.Models;
using TechPeanut.Api.Repository.Generic;

namespace TechPeanut.Api.Business.Implementations
{
    public class PessoasBusinessImplementation : IPessoaBusiness
    {
        private readonly IRepository<Pessoas> _repository;
        private readonly PessoasConverter _converter;

        public PessoasBusinessImplementation(IRepository<Pessoas> repository)
        {
            _repository = repository;
            _converter = new PessoasConverter();
        }

        public List<PessoasVO> FindAll()
        {
            return _converter.Parse(_repository.FindAll());
        }

        public PessoasVO FindById(int id)
        {
            return _converter.Parse(_repository.FindById(id));
        }

        public PessoasVO Create(PessoasVO pessoas)
        {
            var pessoasEntity = _converter.Parse(pessoas);
            pessoasEntity = _repository.Create(pessoasEntity);

            return _converter.Parse(pessoasEntity);
        }

        public PessoasVO Update(PessoasVO pessoas)
        {
            var pessoasEntity = _converter.Parse(pessoas);
            pessoasEntity = _repository.Update(pessoasEntity);

            return _converter.Parse(pessoasEntity);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
