using BLENDSEASONINGS.Models;

namespace BLENDSEASONINGS.Repos
{
    public interface ISpiceRepository
    {
        List<Spice> GetAllSpices();
        Spice GetSpiceById(int id);
    }
}
