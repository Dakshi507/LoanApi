using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LoanApi.Models;

public partial class Userdetail
{
    [Key]
    public int UserId { get; set; }

    public string Firstname { get; set; } = null!;

    public string Lastname { get; set; } = null!;
 
    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string role { get; set; }

    public virtual ICollection<Loandetail> Loandetails { get; } = new List<Loandetail>();
}
