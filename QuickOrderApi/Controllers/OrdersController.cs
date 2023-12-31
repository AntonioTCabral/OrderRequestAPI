﻿using Microsoft.AspNetCore.Mvc;
using QuickOrderApplication.DTOs;
using QuickOrderApplication.Interfaces.Services;

namespace QuickOrderApi.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrdersController(IOrderService orderService)
    {
        _orderService = orderService;
    }
    
    [HttpPost]
    public async Task<IActionResult> PlaceOrder([FromBody] OrderDto order)
    {
        var result = await _orderService.PlaceOrderAsync(order);
        return Ok(result);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _orderService.GetAllAsync();
        return Ok(result);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _orderService.GetByIdAsync(id);

        if (result is null)
            return NotFound("Order not found!");

        return Ok(result);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _orderService.DeleteAsync(id);
        return Ok();
    }

}