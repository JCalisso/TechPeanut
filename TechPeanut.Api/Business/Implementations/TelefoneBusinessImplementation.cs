using TechPeanut.Api.Data.Converter.Implementations;
using TechPeanut.Api.Data.VO;
using TechPeanut.Api.Models;
using TechPeanut.Api.Repository.Generic;

namespace TechPeanut.Api.Business.Implementations
{
    public class TelefoneBusinessImplementation : ITelefoneBusiness
    {
        private readonly IRepository<Telefones> _repository;
        private readonly TelefonesConverter _converter;

        public TelefoneBusinessImplementation(IRepository<Telefones> repository)
        {
            _repository = repository;
            _converter = new TelefonesConverter();
        }

        public List<TelefonesVO> FindAll()
        {
            return _converter.Parse(_repository.FindAll());
        }

        public TelefonesVO FindById(int id)
        {
            return _converter.Parse(_repository.FindById(id));
        }


        public TelefonesVO Create(TelefonesVO Telefones)
        {
            var TelefonesEntity = _converter.Parse(Telefones);
            TelefonesEntity = _repository.Create(TelefonesEntity);

            return _converter.Parse(TelefonesEntity);
        }

        public TelefonesVO Update(TelefonesVO Telefones)
        {
            var TelefonesEntity = _converter.Parse(Telefones);
            TelefonesEntity = _repository.Update(TelefonesEntity);

            return _converter.Parse(TelefonesEntity);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
