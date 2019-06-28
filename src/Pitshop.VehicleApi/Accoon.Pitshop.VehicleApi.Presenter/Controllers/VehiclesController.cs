using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Accoon.Pitshop.VehicleApi.Application.UserCases.Customer.GetCustomer;
using Accoon.Pitshop.VehicleApi.Application.UserCases.Customer.GetCustomerList;
using Accoon.Pitshop.VehicleApi.Application.UserCases.Vehicle.CreateVehicle;
using Accoon.Pitshop.VehicleApi.Application.UserCases.Vehicle.GetVehicleList;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Accoon.Pitshop.VehicleApi.Presenter.Controllers
{
    public class VehiclesController : BaseController
    {
        private readonly ILogger<VehiclesController> logger;

        public VehiclesController(ILogger<VehiclesController> logger)
        {
            this.logger = logger;
        }

        [Route("")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateVehicleCommand createVehicleCommand)
        {
            logger.LogInformation("start : ");
            var vehicle = await Mediator.Send(createVehicleCommand);
            logger.LogInformation("added " + vehicle.VehicleId);
            return CreatedAtAction(nameof(Get), new { id = vehicle.VehicleId }, null);
        }

        [Route("{id:guid}")]
        [HttpGet]
        [ProducesResponseType(typeof(GetVehicleModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetVehicleModel>> Get([FromRoute] Guid id)
        {
            var vehicle = await Mediator.Send(new GetVehicleQuery() { Id = id });
            if (vehicle == null)
            {
                return NotFound();
            }

            return Ok(vehicle);
        }

        [Route("")]
        [HttpGet]
        [ProducesResponseType(typeof(GetVehiclesListViewModel), StatusCodes.Status200OK)]
        public async Task<ActionResult<GetVehiclesListViewModel>> Get()
        {
            logger.LogInformation("start : ");
            var vehicleListModel = await Mediator.Send(new GetVehicleListQuery());
            return Ok(vehicleListModel);
        }
    }
}