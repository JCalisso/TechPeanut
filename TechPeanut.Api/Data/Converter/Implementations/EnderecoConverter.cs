using TechPeanut.Api.Data.Converter.Contract;
using TechPeanut.Api.Data.VO;
using TechPeanut.Api.Models;

namespace TechPeanut.Api.Data.Converter.Implementations
{
    public class EnderecoConverter : IParser<EnderecosVO, Enderecos>, IParser<Enderecos, EnderecosVO>
    {
        public Enderecos Parse(EnderecosVO origin)
        {
            if (origin == null) return null;
            return new Enderecos
            {
                Id = origin.Id,
                Endereco = origin.Endereco,
                Bairro = origin.Bairro,
                NO_Endereco = origin.NO_Endereco,
                Observacao = origin.Observacao,
                CEP = origin.CEP
            };
        }

        public EnderecosVO Parse(Enderecos origin)
        {
            if (origin == null) return null;
            return new EnderecosVO
            {
                Id = origin.Id,
                Endereco = origin.Endereco,
                Bairro = origin.Bairro,
                NO_Endereco = origin.NO_Endereco,
                Observacao = origin.Observacao,
                CEP = origin.CEP
            };
        }

        public List<Enderecos> Parse(List<EnderecosVO> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }

        public List<EnderecosVO> Parse(List<Enderecos> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
