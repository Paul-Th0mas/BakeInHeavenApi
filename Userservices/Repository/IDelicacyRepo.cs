using Dataservices.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Userservices.Repository
{
    public interface IDelicacyRepo
    {
        bool SaveChanages();
        IEnumerable<delicacys> GetAllDelicacy();
        delicacys GetDelicacysByID(int id);
        void CreateDelicacy(delicacys delicacys);
        void UpdateDelicacy(delicacys delicacys);
        void DeleteDelicacy(delicacys delicacys);
    }
}
