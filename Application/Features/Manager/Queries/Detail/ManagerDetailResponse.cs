using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Manager.Queries.Detail
{
    public class OrderDetailResponse
    {
        public ManagerUserResponse User { get; set; }
        public ManagerRoleResponse Role { get; set; }
    }

    public class ManagerUserResponse
    {
        public string Username { get; set; }
        public string Phone { get; set; }
    }

    public class ManagerRoleResponse
    {
        public string Name { get; set; }
    }
}