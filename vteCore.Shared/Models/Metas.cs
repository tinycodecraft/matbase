using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vteCore.Shared.Models;

public class CoreUserMeta
{
    [Display(Order = 0, Name = "User Id")]
    public string UserId { get; set; }

    [Display(Order = 1, Name = "User Name")]
    public string UserName { get; set; }


    [Display(Order = 3, Name = "Change Password Required")]
    public string ResetEnabled { get; set; }




    [Display(Order = 4, Name = "Post")]
    public string post { get; set; }




    [Display(Order = 5, Name = "Division")]
    public string Division { get; set; }

    [Display(Order = 6, Name = "Level")]
    public int level { get; set; }

    [Display(Order = 7, Name = "Disabled")]
    public string DisabledEnabled { get; set; }

    [Display(Order = 8, Name = "Is Division Admin")]
    public string DivisionEnabled { get; set; }
    [Display(Order = 9, Name = "Is Data Admin")]
    public string DataEnabled { get; set; }

    [Display(Order = 10, Name = "Is Control Admin")]
    public string ControlEnabled { get; set; }


}


    