using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.EMMA;
using vteCore.Shared.Models;

namespace vteCore.dbService;


[NotMapped]
[MetadataType(typeof(CoreUserMeta))]
public class UserModel: CoreUser,IUser
{
    
}

public class UserMap: BaseDto<UserModel, CoreUser>
{

    public override void AddCustomMappings()
    {
        SetCustomMappings()
            .Map(dest => dest.UserName, src => src.UserName)
            .Map(dest => dest.IsAdmin, src => src.IsDivisionAdmin || src.IsDataAdmin || src.IsControlAdmin)
            .Map(dest => dest.AdminScope, src => src.IsControlAdmin ? nameof(AdminScopeType.Full) : (src.IsDataAdmin ? nameof(AdminScopeType.Archive) : (src.IsDivisionAdmin ? nameof(AdminScopeType.Division) : "")))
            .Map(dest => dest.updatedAt, src => DateTime.Now)
            .Ignore(dest => dest.IsReset)
            .Ignore(dest => dest.Disabled)            
            .Ignore(dest => dest.EncPassword)
            .Ignore(dest => dest.Id)
            ;


        SetCustomMappingsReverse()
            .Map(dest => dest.UserId, src => src.UserId ?? src.UserName.ToLower())
            .Map(dest => dest.Email, src => src.UserName.ToLower() + "@unknown.com")
            .Map(dest => dest.UserName, src => src.UserName)
            .Map(dest => dest.IsDivisionAdmin, src => src.AdminScope == nameof(AdminScopeType.Division) && src.IsAdmin)
            .Map(dest => dest.IsDataAdmin, src => src.AdminScope == nameof(AdminScopeType.Archive) && src.IsAdmin)
            .Map(dest => dest.IsControlAdmin, src => src.AdminScope == nameof(AdminScopeType.Full) && src.IsAdmin);




    }
}

