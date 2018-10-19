using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proxsure_API.Models.Suscriptions {
    public interface ISuscriptionRepository {
         Task<Suscription> AddSuscription (Suscription suscription);
        Task<IEnumerable<Suscription>> GetAllSuscriptions ();
        Task<Suscription> GetSuscription (int id);
    }
}