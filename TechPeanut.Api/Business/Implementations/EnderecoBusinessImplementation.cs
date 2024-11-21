using TechPeanut.Api.Data.Converter.Implementations;
using TechPeanut.Api.Data.VO;
using TechPeanut.Api.Models;
using TechPeanut.Api.Repository.Generic;

namespace TechPeanut.Api.Business.Implementations
{
    public class EnderecoBusinessImplementation : IEnderecosBusiness
    {
        private readonly IRepository<Enderecos> _repository;
        private readonly EnderecoConverter _converter;

        public EnderecoBusinessImplementation(IRepository<Enderecos> repository)
        {
            _repository = repository;
            _converter = new EnderecoConverter();
        }

        public List<EnderecosVO> FindAll()
        {
            return _converter.Parse(_repository.FindAll());
        }

        public EnderecosVO FindById(int id)
        {
            return _converter.Parse(_repository.FindById(id));
        }

        public EnderecosVO Create(EnderecosVO enderecos)
        {
            var enderecosEntity = _converter.Parse(enderecos);
            enderecosEntity = _repository.Create(enderecosEntity);

            return _converter.Parse(enderecosEntity);
        }

        public EnderecosVO Update(EnderecosVO enderecos)
        {
            var enderecosEntity = _converter.Parse(enderecos);
            enderecosEntity = _repository.Update(enderecosEntity);

            return _converter.Parse(enderecosEntity);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
