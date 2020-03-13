using System.Threading.Tasks;
using BusinessAssociate.API.DTOs;
using BusinessAssociate.API.Utils;
using CSharpFunctionalExtensions;
using EGMS.BusinessAssociate.Domain;
using EGMS.BusinessAssociate.Domain.Enums;
using EGMS.BusinessAssociate.Domain.ValueObjects;
using Microsoft.AspNetCore.Mvc;

namespace BusinessAssociate.API.BusinessAssociate
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExternalAssociateController : BaseController <ExternalAssociate>
    {
        private readonly EGMSAssociateRepository _repository;


        public ExternalAssociateController(EGMSAssociateRepository repository)
        {
            _repository = repository;
        }

        // PUT: api/ExternalAssociate/5
        [HttpPut("{id}")]
#pragma warning disable 1998
        public async Task<ActionResult<ExternalAssociate>> PutAssociate([FromBody]UpdateExternalAssociateDto item)
#pragma warning restore 1998
        {
            Result<DUNSNumber> dunsNumberOrError = DUNSNumber.Create(item.DUNSNumber);
            Result<LongName> longNameOrError = LongName.Create(item.LongName);
            Result<ShortName> shortNameOrError = ShortName.Create(item.ShortName);

            Result result = Result.Combine(dunsNumberOrError, longNameOrError, shortNameOrError);

            if (result.IsFailure)
                return Error(result.Error);

            ExternalAssociate externalAssociate = new ExternalAssociate(dunsNumberOrError.Value, longNameOrError.Value, shortNameOrError.Value, ExternalAssociateType.SELF_PROVIDER);

            _repository.UpdateExternalAssociate(externalAssociate);

            return NoContent();
        }

        // POST: api/ExternalAssociate
        [HttpPost]
#pragma warning disable 1998
        public async Task<ActionResult<ExternalAssociate>> Create([FromBody]CreateExternalAssociateDto item)
#pragma warning restore 1998
        {
            Result<DUNSNumber> dunsNumberOrError = DUNSNumber.Create(item.DUNSNumber);
            Result<LongName> longNameOrError = LongName.Create(item.LongName);
            Result<ShortName> shortNameOrError = ShortName.Create(item.ShortName);

            Result result = Result.Combine(dunsNumberOrError, longNameOrError, shortNameOrError);

            if (result.IsFailure)
                return Error(result.Error);

            ExternalAssociate externalAssociate = new ExternalAssociate(dunsNumberOrError.Value, longNameOrError.Value, shortNameOrError.Value, ExternalAssociateType.SELF_PROVIDER);

            _repository.AddExternalAssociate(externalAssociate);

            CreatedAtActionResult createdAtActionResult = CreatedAtAction("Create", new { id = externalAssociate.Id }, externalAssociate);

            return createdAtActionResult;
        }

        // DELETE: api/ExternalAssociate/5
        [HttpDelete("{id}")]
#pragma warning disable 1998
        public async Task<ActionResult<EGMSAssociate>> DeleteBusinessAssociate(int id)
#pragma warning restore 1998
        {
            var externalAssociate = _repository.GetExternalAssociate(id);

            if (externalAssociate == null)
            {
                return NotFound();
            }

            _repository.DeleteExternalAssociate(externalAssociate);

            return externalAssociate;
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
