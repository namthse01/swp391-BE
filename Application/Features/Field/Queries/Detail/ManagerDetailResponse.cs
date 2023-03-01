using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Manager.Queries.Detail
{
    public class ManagerDetailResponse
    {
        public ManagerUserResponse UserId { get; set; }
        public ManagerRoledResponse RoleId { get; set; }
    }

    public class ManagerUserResponse
    {
        public string UserName { get; set; }
        public string UserPhone { get; set; }
    }

    public class ManagerRoledResponse
    {
        public string RoleName { get; set; }
    }
}