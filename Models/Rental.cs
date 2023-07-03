using System;
using System.Collections.Generic;

namespace TheRideYouRent_ST10083869.Models;

public partial class Rental
{
    public int RentalId { get; set; }

    public string? CarNo { get; set; }

    public string? InspectorId { get; set; }

    public int? DriverId { get; set; }

    public string? DriverName { get; set; }

    public int? RentalFee { get; set; }

    public DateTime Startdate { get; set; }

    public DateTime EndDate { get; set; }

    public virtual Car? CarNoNavigation { get; set; }

    public virtual Driver? Driver { get; set; }

    public virtual Inspector? Inspector { get; set; }
}
