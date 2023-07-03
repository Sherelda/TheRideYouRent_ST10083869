using System;
using System.Collections.Generic;

namespace TheRideYouRent_ST10083869.Models;

public partial class Inspector
{
    public string InspectorId { get; set; } = null!;

    public string InspectorName { get; set; } = null!;

    public string InspectorEmail { get; set; } = null!;

    public string? InspectorMobile { get; set; }

    public virtual ICollection<Rental> Rentals { get; set; } = new List<Rental>();

    public virtual ICollection<ReturnCar> ReturnCars { get; set; } = new List<ReturnCar>();
}
