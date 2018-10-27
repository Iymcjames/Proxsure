using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proxsure_API.Models.SuscriptionModels
{
    public interface ISuscriptionRepository
    {
         
         Task<SuscriptionDTO> AddSuscription (Suscription suscription);
        Task<List<SuscriptionDTO>> GetAllSuscriptions ();
        Task<SuscriptionDTO> GetSuscription (int id);
    }
}