using CarLeasingExperiments.Car;
using CarLeasingExperiments.Entities;
using CarLeasingExperiments.State;
using CarLeasingExperiments.Transitions;
using Microsoft.AspNetCore.Mvc;

namespace CarLeasingExperiments.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarController : ControllerBase
    {
        private readonly ICarTransitionManager _transitionManager;

        public CarController(
            ICarTransitionManager transitionManager
        )
        {
            _transitionManager = transitionManager;
        }

        [HttpPost]
        public void Submit([FromQuery]string carId, [FromBody] BToCTransitionData data)
        {
            UserEntity currentUserEntity = new UserEntity(); //get from DB
            CarEntity carEntity = new CarEntity(); // get from DB

            _transitionManager.Transit(currentUserEntity, carEntity, StateEnum.StateA, data);
        }
    }
}
