using Portal.API.Data;

namespace Portal.API.Controllers
{
    public class ResultsController
    {
        private readonly IPortalRepository _repo;
        public ResultsController(IPortalRepository repo)
        {
            _repo = repo;
        }
        
    }
}