using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proxsure_API.Models.SuscriptionModels
{
    public interface ISuscriptionRepository
    {
         
         Suscription AddSuscription (Suscription suscription);
        Task<List<Suscription>> GetAllSuscriptions ();
        Task<Suscription> GetSuscription (int id);
    }
}