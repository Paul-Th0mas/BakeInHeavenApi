using Dataservices;
using Dataservices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Userservices.Repository
{
    public class SQLDelicacy_ScheduleRepo : IDelicacy_ScheduleRepo
    {
        private readonly Bakers_DBcontext _context;

        public SQLDelicacy_ScheduleRepo(Bakers_DBcontext context)
        {
            _context = context;
                
        }
        public void CreateDelicacy_Scheduled(delicacy_Schedules delicacy_Schedules)
        {
            if (delicacy_Schedules == null)
            {
                throw new ArgumentNullException(nameof(delicacy_Schedules));

            }
            _context.Delicacy_Schedules.Add(delicacy_Schedules);
        }

        public void DeleteDelicacy_Scheduled(delicacy_Schedules delicacy_Schedules)
        {
            if (delicacy_Schedules == null)
            {
                throw new ArgumentNullException(nameof(delicacy_Schedules));

            }
            _context.Delicacy_Schedules.Remove(delicacy_Schedules);

        }

        public IEnumerable<delicacy_Schedules> GetAllDelicacy_Scheduleds()
        {   
            
            return _context.Delicacy_Schedules.ToList();
        }

        public delicacy_Schedules GetDelicacy_ScheduledById(int id)
        {
            return _context.Delicacy_Schedules.FirstOrDefault(p=>p.Id==id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges()>=0);
        }

        public void UpdateDelicacy_Scheduled(delicacy_Schedules delicacy_Schedules)
        {
            
        }
    }
}
