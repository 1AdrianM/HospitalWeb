using System;
using System.Collections.Generic;

namespace Proyecto_Hospital.Models;

public partial class Appointment
{
    public int Id { get; set; }

    public int ValueAPt { get; set; }

    public string? Apartment { get; set; }

    public string? Name { get; set; }

    public string? Gender { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public DateTime? Fecha { get; set; }
}

