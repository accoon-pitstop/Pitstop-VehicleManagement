﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Accoon.Pitshop.VehicleApi.Application.UserCases.Customer.CreateCustomer;
using Accoon.Pitshop.VehicleApi.Application.UserCases.Customer.GetCustomer;
using Accoon.Pitshop.VehicleApi.Application.UserCases.Customer.GetCustomerList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Accoon.Pitshop.VehicleApi.Presenter.Controllers
{
    public class CustomersController : BaseController
    {
        private readonly ILogger<CustomersController> logger;

        public CustomersController(ILogger<CustomersController> logger)
        {
            this.logger = logger;
        }
        [Route("")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateCustomerCommand createCustomerCommand)
        {
            logger.LogInformation("start : ");
            var customer = await Mediator.Send(createCustomerCommand);
            logger.LogInformation("added " + customer.CustomerId);
            return CreatedAtAction(nameof(Get), new { id = customer.CustomerId }, null);
        }

        [Route("{id:guid}")]
        [HttpGet]
        [ProducesResponseType(typeof(CustomerModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CustomerModel>> Get([FromRoute] Guid id)
        {
            var customer = await Mediator.Send(new GetCustomerQuery() { Id = id });
            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        [Route("")]
        [HttpGet]
        [ProducesResponseType(typeof(CustomerListViewModel), StatusCodes.Status200OK)]
        public async Task<ActionResult<CustomerListViewModel>> Get()
        {
            logger.LogInformation("start : ");
            var customerListModel = await Mediator.Send(new GetCustomersListQuery());
            return Ok(customerListModel);
        }
    }
}