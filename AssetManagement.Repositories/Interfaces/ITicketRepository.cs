using System;
using System.Collections.Generic;
using System.Text;
using AssetManagement.Models.Entities;

namespace AssetManagement.Repositories.Interfaces;
public interface ITicketRepository
{
    void AddTicket(Ticket ticket);
    List<Ticket> GetAllTickets();
    List<Ticket> GetTicketsByEmployee(int employeeId);
    Ticket GetById(int id);
    void UpdateTicket(Ticket ticket);
}
