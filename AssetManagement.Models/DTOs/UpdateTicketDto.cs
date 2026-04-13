using System;
using System.Collections.Generic;
using System.Text;

namespace AssetManagement.Models.DTOs;
public class UpdateTicketDto
{
    public int TicketId { get; set; }
    public string Status {  get; set; }
    public string ResolutionNotes { get; set; }
}
