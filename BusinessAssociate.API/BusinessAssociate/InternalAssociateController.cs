using System.Threading.Tasks;
using BusinessAssociate.API.DTOs;
using BusinessAssociate.API.Utils;
using BusinessAssociates.EventSourcing;
using BusinessAssociates.WebApi;
using CSharpFunctionalExtensions;
using EGMS.BusinessAssociate.Domain;
using EGMS.BusinessAssociate.Domain.Enums;
using EGMS.BusinessAssociate.Domain.ValueObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BusinessAssociate.API.BusinessAssociate
{
    [Route("api/[controller]")]
    [ApiController]
    public class InternalAssociateController : CommandApi<InternalAssociate>//BaseController <InternalAssociate>
    {
        private readonly EGMSAssociateRepository _repository;
        readonly ILogger _log;
        ApplicationService<InternalAssociate> Service { get; }

        public InternalAssociateController(
            ApplicationService<InternalAssociate> applicationService,
            ILoggerFactory loggerFactory) : base (applicationService, loggerFactory)
        {
            _log = loggerFactory.CreateLogger(GetType());
            Service = applicationService;
        }


        //public InternalAssociateController(EGMSAssociateRepository repository)
        //{
        //    _repository = repository;
        //}


        // PUT: api/InternalAssociate/5
        [HttpPut("{id}")]
#pragma warning disable 1998
        public async Task<ActionResult<InternalAssociate>> PutAssociate([FromBody]UpdateInternalAssociateDto item)
#pragma warning restore 1998
        {
            Result<DUNSNumber> dunsNumberOrError = DUNSNumber.Create(item.DUNSNumber);
            Result<LongName> longNameOrError = LongName.Create(item.LongName);
            Result<ShortName> shortNameOrError = ShortName.Create(item.ShortName);

            Result result = Result.Combine(dunsNumberOrError, longNameOrError, shortNameOrError);

            //if (result.IsFailure)
            //    return Error(result.Error);

            InternalAssociate internalAssociate = new InternalAssociate(dunsNumberOrError.Value, longNameOrError.Value, shortNameOrError.Value, InternalAssociateType.LDC_FACILITY);

            _repository.UpdateInternalAssociate(internalAssociate);

            return NoContent();
        }


        // POST:  api/InternalAssociate/5/OperatingContext
        // TO DO:  We don't need both creates.  Also, we should probably just return an InternalAssociate?

        [HttpPost("{id}")]
        public async Task<ActionResult<InternalOperatingContext>> AddOperatingContext(long id)
        {
            InternalAssociate internalAssociate = _repository.GetInternalAssociate(id);

            if (internalAssociate == null)
            {
                return NotFound();
            }

            InternalOperatingContext context = internalAssociate.AddOperatingContext();

            _repository.AddInternalOperatingContext(internalAssociate, context);   

            return CreatedAtAction("Create", new { id = context.Id }, context);
        }


        // POST: api/InternalAssociate
        [HttpPost]
#pragma warning disable 1998
        public async Task<ActionResult<InternalAssociate>> Create([FromBody]CreateInternalAssociateDto item)
#pragma warning restore 1998
        {
            Result<DUNSNumber> dunsNumberOrError = DUNSNumber.Create(item.DUNSNumber);
            Result<LongName> longNameOrError = LongName.Create(item.LongName);
            Result<ShortName> shortNameOrError = ShortName.Create(item.ShortName);

            Result result = Result.Combine(dunsNumberOrError, longNameOrError, shortNameOrError);

            //if (result.IsFailure)
            //    return Error(result.Error);

            InternalAssociate internalAssociate = new InternalAssociate(dunsNumberOrError.Value, longNameOrError.Value, shortNameOrError.Value, InternalAssociateType.LDC_FACILITY);

            _repository.AddInternalAssociate(internalAssociate);

            return CreatedAtAction("Create", new { id = internalAssociate.Id }, internalAssociate);
        }

        // DELETE: api/InternalAssociate/5
        [HttpDelete("{id}")]
#pragma warning disable 1998
        public async Task<ActionResult<InternalAssociate>> DeleteBusinessAssociate(int id)
#pragma warning restore 1998
        {
            InternalAssociate internalAssociate = _repository.GetInternalAssociate(id);

            if (internalAssociate == null)
            {
                return NotFound();
            }

            _repository.DeleteInternalAssociate(internalAssociate);

            return internalAssociate;
        }

        // ReSharper disable once UnusedMember.Local
        // ReSharper disable once UnusedParameter.Local
        private bool BusinessAssociateExists(int id)
        {
            return true;
            //return _context.BusinessAssociates.Any(e => e.Id == id);
        }
    }
}
