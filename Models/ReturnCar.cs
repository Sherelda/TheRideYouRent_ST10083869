using System;
using System.Collections.Generic;

namespace TheRideYouRent_ST10083869.Models;

public partial class ReturnCar
{
    public int ReturnId { get; set; }

    public string? CarNo { get; set; }

    public string? InspectorId { get; set; }

    public int? DriverId { get; set; }

    public string DriverName { get; set; } = null!;

    public DateTime ReturnDate { get; set; }

    public int? ElapsedDate { get; set; }

    public int? Fine { get; set; }

    public virtual Car? CarNoNavigation { get; set; }

    public virtual Driver? Driver { get; set; }

    public virtual Inspector? Inspector { get; set; }
}
