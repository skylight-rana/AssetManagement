using System;
using System.Collections.Generic;
using System.Text;
using AssetManagement.Data.Context;
using AssetManagement.Models.Entities;
using AssetManagement.Repositories.Interfaces;

namespace AssetManagement.Repositories.Implementations;
public class TicketRepository : ITicketRepository
{
    private readonly AppDbContext _context;

    public TicketRepository(AppDbContext context)
    {
        _context = context; 
    }

    public void AddTicket(Ticket ticket)
    {
        _context.Tickets.Add(ticket);
        _context.SaveChanges();
    }

    public List<Ticket> GetAllTickets()
    {
        return _context.Tickets.ToList();
    }

    public List<Ticket> GetTicketsByEmployee (int employeeId)
    {
        return _context.Tickets
            .Where(t => t.EmployeeId == employeeId)
            .ToList();
    }

    public Ticket GetById(int id)
    {
        return _context.Tickets.Find(id);
    }

    public void UpdateTicket(Ticket ticket)
    {
        _context.Tickets.Update(ticket);
        _context.SaveChanges();
    }
}
