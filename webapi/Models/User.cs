using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace webapi.Models;

public partial class User
{
    public int Userid { get; set; }

    
    public string Login { get; set; }


	public string Password { get; set; }

    public bool? Active { get; set; }
}
