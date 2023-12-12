using System;
using System.Collections.Generic;

namespace Proyecto_Hospital.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }
}
