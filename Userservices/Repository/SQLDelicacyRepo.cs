using Dataservices;
using Dataservices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Userservices.Repository
{
    public class SQLDelicacyRepo : IDelicacyRepo

    {
        private readonly Bakers_DBcontext _context;

        public SQLDelicacyRepo(Bakers_DBcontext context)
        {
            _context = context;

        }
        public void CreateDelicacy(delicacys delicacys)
        {
            if (delicacys == null)
            {
                throw new ArgumentNullException(nameof(delicacys));
            }
            _context.Delicacys.Add(delicacys);
        }

        public void DeleteDelicacy(delicacys delicacys)
        {
            if (delicacys == null)
            {
                throw new ArgumentNullException(nameof(delicacys));
            }
            _context.Delicacys.Remove(delicacys);
        }

        public IEnumerable<delicacys> GetAllDelicacy()
        {
            return _context.Delicacys.ToList();
        }

        public delicacys GetDelicacysByID(int id)
        {
            return _context.Delicacys.FirstOrDefault(p => p.Id == id);

        }

        public bool SaveChanages()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateDelicacy(delicacys delicacys)
        {
            
        }
    }
}
