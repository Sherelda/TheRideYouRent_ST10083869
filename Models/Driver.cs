using System;
using System.Collections.Generic;

namespace TheRideYouRent_ST10083869.Models;

public partial class Driver
{
    public int DriverId { get; set; }

    public string DriverName { get; set; } = null!;

    public string DriverAddress { get; set; } = null!;

    public string DriverEmail { get; set; } = null!;

    public string? DriverMobile { get; set; }

    public virtual ICollection<Rental> Rentals { get; set; } = new List<Rental>();

    public virtual ICollection<ReturnCar> ReturnCars { get; set; } = new List<ReturnCar>();
}
