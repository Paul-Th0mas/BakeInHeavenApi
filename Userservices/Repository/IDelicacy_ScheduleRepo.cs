using Dataservices.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Userservices.Repository
{
    public interface IDelicacy_ScheduleRepo
    {
        bool SaveChanges();
        IEnumerable<delicacy_Schedules> GetAllDelicacy_Scheduleds();
        delicacy_Schedules GetDelicacy_ScheduledById(int id);
        void CreateDelicacy_Scheduled(delicacy_Schedules delicacy_Schedules);
        void UpdateDelicacy_Scheduled(delicacy_Schedules delicacy_Schedules);
        void DeleteDelicacy_Scheduled(delicacy_Schedules delicacy_Schedules);
    }
}
