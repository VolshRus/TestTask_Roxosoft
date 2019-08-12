using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using WebApp.Exceptions;
using WebApp.Interfaces;
using WebApp.Requests;
using WebApp.Responses;

namespace WebApp.Controllers
{
    /// <summary>
    /// Public API to work with orders
    /// </summary>
    [Route("api/orders/")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        /// <summary>.ctor</summary>
        /// <param name="ordersService"></param>
        public OrdersController(IOrdersService ordersService, IMapper mapper, ILogger<OrdersController> logger)
        {
            _mapper = mapper;
            _logger = logger;
            _ordersService = ordersService;
        }

        /// <summary>
        /// Orders list with lazy-loading support
        /// </summary>
        /// <param name="request">Validation model</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("v1/list/get")]
        [Produces("application/json")]
        [Consumes("application/json")]
        public async Task<IActionResult> GetListAsync([FromQuery]OrdersListRequest request, CancellationToken cancellationToken)
        {
            try
            {
                int finalAmount = request.Amount ?? int.MaxValue;
                var result = await _ordersService.GetOrdersAsync(request.Start, finalAmount, cancellationToken);
                var response = _mapper.Map<ICollection<OrderResponse>>(result);

                return Ok(response);
            }
            catch (EmptyQueryResultException)
            {
                return NoContent();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "InternalError");
                return StatusCode(500, "InternalError");
            }

        }

        /// <summary>
        /// Order details with product list
        /// </summary>
        /// <param name="request">Validation model</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("v1/detail/get")]
        [Produces("application/json")]
        [Consumes("application/json")]
        public async Task<IActionResult> GetOrderDetailedAsync([FromQuery]OrderDetailedRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _ordersService.GetOrderDetailedAsync(request.Id, cancellationToken);
                return Ok(result);
            }
            catch (EmptyQueryResultException)
            {
                return NoContent();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "InternalError");
                return StatusCode(500, "InternalError");
            }

        }

        private readonly IOrdersService _ordersService;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
    }
}
