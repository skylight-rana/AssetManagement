using Microsoft.AspNetCore.Mvc;
using AssetManagement.Services.Interfaces;
using AssetManagement.Models.DTOs;

[ApiController]
[Route("api/[controller]")]
public class TicketController : ControllerBase
{
    private readonly ITicketService _service;

    public TicketController(ITicketService service)
    {
        _service = service;
    }

    //Employee raises ticket
    [HttpPost]
    public IActionResult Create(CreateTicketDto dto)
    {
        _service.CreateTicket(dto);
        return Ok("Ticket created successfully");
    }

    //Admin updates ticket
    [HttpPut]
    public IActionResult Update(UpdateTicketDto dto)
    {
        _service.UpdateTicket(dto);
        return Ok("Ticket Updated");
    }

    //Admin View all
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_service.GetAllTickets());
    }

    //Employee View own tickets
    [HttpGet("employee/{employeeId}")]
    public IActionResult GetByEmployee(int employeeId)
    {
        return Ok(_service.GetTicketsByEmployee(employeeId));
    }
}