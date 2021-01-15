using Dataservices.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Userservices.Repository
{
    public interface IAdminRepo
    {
        bool SaveChanges();
        IEnumerable<Admins> GetAllAdmins();
        Admins GetAdminsById(int id);
        void CreateAdmin(Admins admins);
        void UpdateAdmin(Admins admins);
        void DeleteAdmin(Admins admins);
    }
}
