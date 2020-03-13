using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessAssociate.API.Utils;
using EGMS.BusinessAssociate.Domain;
using EGMS.BusinessAssociate.Domain.Enums;
using EGMS.BusinessAssociate.Domain.ValueObjects;
using Microsoft.AspNetCore.Mvc;


namespace BusinessAssociate.API.BusinessAssociate
{
    [Route("api/[controller]")]
    [ApiController]
    public class InternalAssociateQueryController : BaseController <EGMSAssociate>
    {
        private readonly EGMSAssociateRepository _egmsAssociateRepository;


        public InternalAssociateQueryController(EGMSAssociateRepository repository)
        {
            _egmsAssociateRepository = repository;
        }

        // GET: api/BusinessAssociates
        [HttpGet]
#pragma warning disable 1998
        public async Task<ActionResult<IEnumerable<InternalAssociate>>> GetAssociates()
#pragma warning restore 1998
        {
            return new List<InternalAssociate>(); //await _context.Business.ToListAsync();
        }

        // GET: api/BusinessAssociates/5
        [HttpGet("{id}")]
#pragma warning disable 1998
        public async Task<ActionResult<InternalAssociate>> GetAssociate(int id)
#pragma warning restore 1998
        {
            //var egmsAssociate = await _context.BusinessAssociates.FindAsync(id);

            //if (egmsAssociate == null)
            //{
            //    return NotFound();
            //}

            DUNSNumber aglDUNSNumber = DUNSNumber.Create(123456789).Value;
            LongName aglLongName = LongName.Create("AtlantaGasLight").Value;
            ShortName aglShortName = ShortName.Create("AGL").Value;

            InternalAssociate internalAssociate =
                new InternalAssociate(aglDUNSNumber, aglLongName, aglShortName, InternalAssociateType.LDC_FACILITY) {Status = Status.ACTIVE};

            return internalAssociate;
        }
    }
}
