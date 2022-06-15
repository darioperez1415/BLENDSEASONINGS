using BLENDSEASONINGS.Models;

namespace BLENDSEASONINGS.Repos
{
    public interface IBlendRepository
    {
         List<Blend> GetAllBlends();
        List<Blend> GetSingleBlend(int id);
         public void CreateBlendOrder(Blend blendOrder);
           

       // public void UpdateBlendOrder(Blend blend);
    }
}
