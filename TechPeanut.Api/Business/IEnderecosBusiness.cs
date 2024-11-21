using TechPeanut.Api.Data.VO;

namespace TechPeanut.Api.Business
{
    public interface IEnderecosBusiness
    {
        EnderecosVO Create(EnderecosVO enderecos);

        EnderecosVO FindById(int id);

        List<EnderecosVO> FindAll();

        EnderecosVO Update(EnderecosVO enderecos);

        void Delete(int id);

    }
}
