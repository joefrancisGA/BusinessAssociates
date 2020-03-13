using System.Threading.Tasks;
using BusinessAssociate.Messages;
using BusinessAssociates.EventSourcing;
using BusinessAssociates.WebApi;
using EGMS.BusinessAssociate.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BusinessAssociate.API.BusinessAssociate
{
    [Route("/ia")]
    [ApiController]
    public class InternalAssociateCommandApi : CommandApi <InternalAssociate>
    {
        //private readonly EGMSAssociateRepository _repository;

        public InternalAssociateCommandApi(ApplicationService<InternalAssociate> applicationService, ILoggerFactory loggerFactory) : base(applicationService, loggerFactory)
        {
        }
        
        // ReSharper disable once UnusedMember.Local
        // ReSharper disable once UnusedParameter.Local
        private bool BusinessAssociateExists(int id)
        {
            return true;
            //return _context.BusinessAssociates.Any(e => e.Id == id);
        }

        [HttpPost]
        public Task<IActionResult> Post(Commands.V1.Create command)
            => HandleCommand(command);

        // DELETE: api/InternalAssociate/5
        [Route("delete"), HttpPost]
        public Task<IActionResult> Delete(Commands.V1.Delete command)
            => HandleCommand(command);

        //[Route("image"), HttpPost]
        //public Task<IActionResult> Post(Events.V1.UploadImage command)
        //    => HandleCommand(command);

        //[Route("title"), HttpPut]
        //public Task<IActionResult> Put(Events.V1.ChangeTitle command)
        //    => HandleCommand(command);

        //[Route("text"), HttpPut]
        //public Task<IActionResult> Put(Events.V1.UpdateText command)
        //    => HandleCommand(command);

        //[Route("price"), HttpPut]
        //public Task<IActionResult> Put(Events.V1.UpdatePrice command)
        //    => HandleCommand(command);

        //[Route("requestpublish"), HttpPut]
        //public Task<IActionResult> Put(Events.V1.RequestToPublish command)
        //    => HandleCommand(command);

        //[Route("publish"), HttpPut]
        //public Task<IActionResult> Put(Events.V1.Publish command)
        //    => HandleCommand(command);

    }
}
