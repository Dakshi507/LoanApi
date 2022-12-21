using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace LoanApi.Models;

public partial class Loandetail
{
    [Key]
    public int Loanid { get; set; }
    [MinLength(5)]
    public int Loannumber { get; set; }

    public string Propertyaddress { get; set; } = null!;

    public int Loanamount { get; set; }

    public string Loantype { get; set; } = null!;

    public string LoanTerm { get; set; } = null!;

    public int? UserId { get; set; }
    
    public string Firstname { get; set; }
    
    public string Lastname { get; set; } 
    public virtual Userdetail? User { get; set; }
}
