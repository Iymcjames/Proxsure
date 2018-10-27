using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Proxsure_API.Models.Context;

namespace Proxsure_API.Models.SuscriptionModels {
    public class SuscriptionRepository : ISuscriptionRepository {
        private readonly ApplicationDbContext applicationDbContext;
        private readonly IMapper mapper;

        public SuscriptionRepository (ApplicationDbContext applicationDbContext, IMapper mapper) {
            this.applicationDbContext = applicationDbContext;
            this.mapper = mapper;
        }

        public async Task<SuscriptionDTO> AddSuscription (Suscription suscription) {
            if (suscription == null)
                return null;

            await applicationDbContext.Suscriptions.AddAsync (suscription);
            return mapper.Map<SuscriptionDTO> (suscription);

        }

        public async Task<List<SuscriptionDTO>> GetAllSuscriptions () {
            if (applicationDbContext.Suscriptions.Any ())
                return mapper.Map<List<SuscriptionDTO>> (await applicationDbContext.Suscriptions.ToListAsync ());

            return null;
        }

        public async Task<SuscriptionDTO> GetSuscription (int id) {
            return mapper.Map<SuscriptionDTO> (await applicationDbContext.Suscriptions.FindAsync (id));
        }
    }
}