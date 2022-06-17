using BLENDSEASONINGS.Models;

namespace BLENDSEASONINGS.Repos
{
    public interface IBlendRepository
    {
         List<Blend> GetAllBlends();
         Blend GetSingleBlend(int id);
         public void CreateBlendOrder(Blend blendOrder);
         public void DeleteBlend(int id);
    }
}
