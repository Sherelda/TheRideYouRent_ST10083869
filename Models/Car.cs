using System;
using System.Collections.Generic;

namespace TheRideYouRent_ST10083869.Models;

public partial class Car
{
    public string CarNo { get; set; } = null!;

    public string CarMake { get; set; } = null!;

    public string CarModel { get; set; } = null!;

    public string BodyType { get; set; } = null!;

    public int? KmTravelled { get; set; }

    public int? ServiceKm { get; set; }

    public string Available { get; set; } = null!;

    public virtual ICollection<Rental> Rentals { get; set; } = new List<Rental>();

    public virtual ICollection<ReturnCar> ReturnCars { get; set; } = new List<ReturnCar>();
}
