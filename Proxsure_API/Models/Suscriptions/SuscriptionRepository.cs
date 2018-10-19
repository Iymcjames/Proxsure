using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proxsure_API.Models.Context;

namespace Proxsure_API.Models.Suscriptions {
    public class SuscriptionRepository : ISuscriptionRepository {
        private readonly ApplicationDbContext applicationDbContext;
        public SuscriptionRepository (ApplicationDbContext applicationDbContext) {
            this.applicationDbContext = applicationDbContext;
        }
        public async Task<Suscription> AddSuscription (Suscription suscription) {
            if (suscription == null)
                return null;

            await applicationDbContext.Suscriptions.AddAsync (suscription);
            return suscription;

        }

        public async Task<IEnumerable<Suscription>> GetAllSuscriptions () {
            if (applicationDbContext.Suscriptions.Any()) 
            return await applicationDbContext.Suscriptions.ToListAsync();

            return null;
        }

        public  Task<Suscription> GetSuscription (int id) {
           return  applicationDbContext.Suscriptions.FindAsync(id);
        }
    }
}