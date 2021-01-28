using Dataservices;
using Dataservices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Userservices.Repository
{
   public class SQLAdminRepo : IAdminRepo
    {
        private readonly Bakers_DBcontext _context;

        public SQLAdminRepo(Bakers_DBcontext context)
        {
            _context = context;
                
        }
        public void CreateAdmin(Admins admins)
        {
            if (admins == null)
            {
                throw new ArgumentNullException(nameof(admins));
            }
            
            _context.admins.Add(admins);
           
        }

        public IEnumerable<Admins> GetAllAdmins()
        {
            return _context.admins.ToList();
        }

        public Admins GetAdminsById(int id)
        {
            return _context.admins.FirstOrDefault(p=> p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateAdmin(Admins admins)
        {
            
        }

        public void DeleteAdmin(Admins admins)
        {
            if (admins == null)
            {
                throw new ArgumentNullException(nameof(admins));
            }
            _context.admins.Remove(admins);
        }
    }
}
