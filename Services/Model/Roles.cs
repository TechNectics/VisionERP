using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Model
{
     
    public class Permission
    {
        public bool IsEnabled { get; set; }
        public string? PermissionFormatted { get; set; }
        public string? ActionType { get; set; }
        public int PermissionGroupActionMapId { get; set; }
    }

    public class Entity
    {
        public string? EntityName { get; set; }
        public string? EntityFormatted { get; set; }
        public List<Permission>? FirstLinePermission { get; set; }
        public List<Permission>? MorePermissions { get; set; }
    }

    public class GroupData
    {
        public string? Group { get; set; }
        public string? GroupFormatted { get; set; }
        public List<Entity>? Entities { get; set; }
    }
    
    public class RolesData
    {
        public string? EntityName { get; set;}                
        public List<PermissionGroupsEntities> PermissionGroupsEntities { get; set; }

    }
    public class PermissionGroupsEntities
    {
        public int? Id {  get; set; }
        public string? Name {  get; set; }
        public bool? Status { get; set; }
        public List<int?> CheckonClick { get; set; }
        public List<int?> UncheckonClick { get; set; }
        public List<int?> Dependent { get; set; }
                
    }
    public class ActionType
    {
        public int PermissionMapId { get; set; }
        public bool IsEnabled { get; set; }        
        public bool IsLock { get; set; }        
        public bool IsVertical { get; set; }        
        public string FormatedText { get; set; }
        public string Name { get; set; }
        public List<ModuleList>? ModuleList { get; set; } 
        public List<int>? DependentCheck { get; set; }
        public List<int>? DependentUnCheck { get; set; }
    }
    public class ModuleList {
        public string EntityName { get; set; }
        public string GroupName { get; set; }
    }
    public class MoreActionType
    {
        public int PermissionMapId { get; set; }
        public bool IsEnabled { get; set; }     
        public bool IsLock { get; set; }
        public bool IsVertical { get; set; }
        public string FormatedText { get; set; }
        public string Name { get; set; }
        public List<ModuleList> ModuleList { get; set; }

    }
    public class SecondLineActionType
    {
        public int PermissionMapId { get; set; }
        public bool IsEnabled { get; set; }
        public bool IsLock { get; set; }
        public bool IsVertical { get; set; }
        public string FormatedText { get; set; }
        public string Name { get; set; }
        public List<ModuleList> ModuleList { get; set; }
    }
    public class ActionDependencies
    {
        public int? PermissionGroupsActionMapId { get;set; }
        public List<int?> Id { get; set; }
        public int? Status { get; set; }
    }
    public class PermissionGroup
    {
        public string Name { get; set; }
        public bool IsStatus { get; set; }
    }
    public class RolesDataById
    {
    public string? RoleName { get; set; }
    public string? Description { get; set; }    
    public List<PermissionGroupById> PermissionGroupById { get; set; }
    }
    public class PermissionGroupById
    {                
        public string? EntityName { get; set; }
        public List<GetByIdPermissionGroupsEntities> PermissionGroupsEntities { get; set; }

    }
    public class GetByIdPermissionGroupsEntities
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public bool? Status { get; set; }
        public List<int?> CheckonClick { get; set; }
        public List<int?> UncheckonClick { get; set; }
        public List<int?> Dependent { get; set; }

    }
    public class ActionTypeGetById
    {
        public int PermissionMapId { get; set; }
        public bool IsEnabled { get; set; }
        public bool IsLock { get; set; }
        public bool IsVertical { get; set; }
        public string FormatedText { get; set; }
        public string Name { get; set; }
        public List<ModuleListById> ModuleListById { get; set; }
    }
    public class ModuleListById
    {
        public string EntityName { get; set; }
        public string GroupName { get; set; }
    }
    public class MoreActionTypeById
    {
        public int PermissionMapId { get; set; }
        public bool IsEnabled { get; set; }
        public bool IsLock { get; set; }
        public bool IsVertical { get; set; }
        public string FormatedText { get; set; }
        public string Name { get; set; }
        public List<ModuleListById> ModuleListById { get; set; }

    }
    public class SecondLineActionTypeById
    {
        public int PermissionMapId { get; set; }
        public bool IsEnabled { get; set; }
        public bool IsLock { get; set; }
        public bool IsVertical { get; set; }
        public string FormatedText { get; set; }
        public string Name { get; set; }
        public List<ModuleListById> ModuleListById { get; set; }
    }
    public class AddRoles 
    {
        public string RoleName { get; set; }
        public string Description { get; set; }
        //public bool IsAccountant { get; set; }
        public List<PermissionRolesList> RolesList { get; set; }
    }
    public class PermissionRolesList
    {
        public int PermissionMapId { get; set; }
        public bool IsEnabled { get; set; }        
    }
    public class RolesList
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
    public class RolesDropDown
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class FetchUserPermissions
    {
        public int PermissionGroupActionMapId { get; set; }
        public bool Status { get; set; }
        public int CompanyId { get; set; }
    }
    public class FilterUserPermissionCompanyWiseData
    {
        public string PageName { get; set; }
        public bool View { get; set; }
        public bool Create { get; set; }
        public bool Edit { get; set; }
        public bool Delete { get; set; }
    }
    public class StaticPages
    {
        public string Page
        {
            get;set;
        }
    }
}
