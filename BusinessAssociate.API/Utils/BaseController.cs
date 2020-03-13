
using Microsoft.AspNetCore.Mvc;

namespace BusinessAssociate.API.Utils
{
    public class BaseController <T> : Controller
    {
        //private readonly UnitOfWork _unitOfWork;

        //public BaseController(UnitOfWork unitOfWork)
        //{
        //    _unitOfWork = unitOfWork;
        //}

        protected BaseController()
        {
            //throw new System.NotImplementedException();
        }

        protected new IActionResult Ok()
        {
            //_unitOfWork.Commit();
            return base.Ok(Envelope.Ok());
        }

        protected IActionResult Ok(T result)
        {
            //_unitOfWork.Commit();
            return base.Ok(Envelope.Ok(result));
        }

        protected ActionResult<T> Error(string errorMessage)
        {
            return BadRequest(Envelope.Error(errorMessage));
        }
    }
}
