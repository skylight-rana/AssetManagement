using System;
using System.Collections.Generic;
using System.Text;
using AssetManagement.Models.DTOs;

namespace AssetManagement.Services.Interfaces;
public interface ITicketService
{
    void CreateTicket(CreateTicketDto dto);
    void UpdateTicket(UpdateTicketDto dto);
    List<TicketResponseDto> GetAllTickets();
    List<TicketResponseDto> GetTicketsByEmployee(int employeeId);
}