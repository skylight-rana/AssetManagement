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
    private readonly IEmployeeRepository _employeeRepo;
    private readonly IAssetRepository _assetRepo;

    public TicketService(
        ITicketRepository repo,
        IEmployeeRepository employeeRepo,
        IAssetRepository assetRepo)
    {
        _repo = repo;
        _employeeRepo = employeeRepo;
        _assetRepo = assetRepo;
    }

    public void CreateTicket(CreateTicketDto dto)
    {
        var ticket = new Ticket
        {
            EmployeeId = dto.EmployeeId,
            AssetId = dto.AssetId,
            IssueDescription = dto.IssueDescription,
            Status = "Open",
            CreatedAt = DateTime.Now
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
        return MapTickets(_repo.GetAllTickets());
    }

    public List<TicketResponseDto> GetTicketsByEmployee(int employeeId)
    {
        return MapTickets(_repo.GetTicketsByEmployee(employeeId));
    }

    private List<TicketResponseDto> MapTickets(List<Ticket> tickets)
    {
        var employees = _employeeRepo.GetAllEmployees();
        var assets = _assetRepo.GetAllAssets();

        return tickets.Select(t =>
        {
            var employee = employees.FirstOrDefault(employee => employee.Id == t.EmployeeId);
            var asset = assets.FirstOrDefault(asset => asset.Id == t.AssetId);

            return new TicketResponseDto
            {
                Id = t.Id,
                EmployeeId = t.EmployeeId,
                AssetId = t.AssetId,
                EmployeeName = employee?.Name,
                AssetName = asset?.Name,
                IssueDescription = t.IssueDescription,
                Status = t.Status,
                ResolutionNotes = t.ResolutionNotes,
                CreatedAt = t.CreatedAt
            };
        }).ToList();
    }
}
