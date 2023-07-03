using System;
using System.Collections.Generic;

namespace TheRideYouRent_ST10083869.Models;

public partial class Late
{ 
    public Late(int Fee, int LateDays, int Fine)
{
    this.LateDays = LateDays;
    this.Fee = Fee;
    this.Fine = Fine;
}
    public int LatefeeId { get; set; }

    public int LateDays { get; set; }
    public int Fee { get; set; }
    public int Fine { get; set; }
    public int Multiple()
    {
    return LateDays * Fee;
    }


}
