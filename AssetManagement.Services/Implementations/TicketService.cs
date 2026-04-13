using System;
using System.Collections.Generic;
using System.Text;
using AssetManagement.Models.DTOs;
using AssetManagement.Models.Entities;
using AssetManagement.Repositories.Interfaces;
using AssetManagement.Services.Interfaces;

namespace AssetManagement.Services.Implementations;
public class TicketService : ITicketService
{
    private readonly ITicketRepository _repo;

    public TicketService(ITicketRepository repo)
    {
        _repo = repo; 
    }

    public void CreateTicket(CreateTicketDto dto)
    {
        var ticket = new Ticket
        {
            EmployeeId = dto.EmployeeId,
            AssetId = dto.AssetId,
            IssueDescription = dto.IssueDescription,
            Status = "Open"
        };

        _repo.AddTicket(ticket);
    }

    public void UpdateTicket(UpdateTicketDto dto)
    {
        var ticket = _repo.GetById(dto.TicketId);

        if (ticket == null)
            throw new Exception("Ticket not found");

        ticket.Status = dto.Status;
        ticket.ResolutionNotes = dto.ResolutionNotes;

        _repo.UpdateTicket(ticket);
    }

    public List<TicketResponseDto> GetAllTickets()
    {
        return _repo.GetAllTickets().Select(t => new TicketResponseDto
        {
            Id = t.Id,
            EmployeeId = t.EmployeeId,
            AssetId = t.AssetId,
            IssueDescription = t.IssueDescription,  
            Status = t.Status,
            ResolutionNotes = t.ResolutionNotes
        }).ToList();
    }

    public List<TicketResponseDto> GetTicketsByEmployee(int employeeId)
    {
        return _repo.GetTicketsByEmployee(employeeId).Select(t => new TicketResponseDto
        {
            Id = t.Id,
            EmployeeId = t.EmployeeId,
            AssetId = t.AssetId,
            IssueDescription = t.IssueDescription,
            Status = t.Status,
            ResolutionNotes = t.ResolutionNotes
        }).ToList();
    }
}
