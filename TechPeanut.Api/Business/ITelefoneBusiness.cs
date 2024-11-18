using TechPeanut.Api.Data.VO;

namespace TechPeanut.Api.Business
{
    public interface ITelefoneBusiness
    {
        TelefonesVO Create(TelefonesVO telefones);

        TelefonesVO FindById(int id);

        List<TelefonesVO> FindAll();

        TelefonesVO Update(TelefonesVO telefones);

        void Delete(int id);
    }
}
