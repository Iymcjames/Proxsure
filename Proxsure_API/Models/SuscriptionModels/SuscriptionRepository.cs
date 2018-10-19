using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proxsure_API.Models.Context;

namespace Proxsure_API.Models.SuscriptionModels {
    public class SuscriptionRepository : ISuscriptionRepository {
        private readonly ApplicationDbContext applicationDbContext;
        public SuscriptionRepository (ApplicationDbContext applicationDbContext) {
            this.applicationDbContext = applicationDbContext;
        }
        public Suscription AddSuscription (Suscription suscription) {
            if (suscription == null)
                return null;

            applicationDbContext.Suscriptions.AddAsync (suscription);
            return suscription;

        }

        public Task<List<Suscription>> GetAllSuscriptions () {
            if (applicationDbContext.Suscriptions.Any ())
                return applicationDbContext.Suscriptions.ToListAsync ();

            return null;
        }

        public Task<Suscription> GetSuscription (int id) {
            return applicationDbContext.Suscriptions.FindAsync (id);
        }
    }
}