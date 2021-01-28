using AutoMapper;
using Dataservices.Dtos;
using Dataservices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Userservices.Repository;

namespace BakeInHeaven.ServicesClass
{
    public class CRUDservice
    {

        private readonly IAdminRepo _admin;
        private readonly IDelicacyRepo _delicacy;
        private readonly IDelicacy_ScheduleRepo _delicacy_Schedule;
        private readonly IMapper _mapper;
        private readonly IOrdersRepo _order;
        public CRUDservice(IAdminRepo admin, IDelicacyRepo delicacy, IDelicacy_ScheduleRepo delicacy_Schedule, IOrdersRepo orders, IMapper mapper)
        {
            _admin = admin;
            _delicacy = delicacy;
            _delicacy_Schedule = delicacy_Schedule;
            _mapper = mapper;
            _order = orders;

        }


        //public IEnumerable<Dataserv> GetAllItems(Type type)
        //{ if (type==)
           
        //    return (_mapper.Map<IEnumerable<AdminReadDtos>>(Admins));
        //}

        
        //public ActionResult<AdminReadDtos> GetAdminById(int id)
        //{
        //    var admin = _admin.GetAdminsById(id);
        //    if (admin == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(_mapper.Map<AdminReadDtos>(admin));
        //}

        
        
        //public ActionResult<AdminReadDtos> CreateAdmin(AdminCreatDtos admins)
        //{
        //    var adminmodel = _mapper.Map<Admins>(admins);
        //    _admin.CreateAdmin(adminmodel);
        //    _admin.SaveChanges();
        //    return Ok(_mapper.Map<AdminReadDtos>(adminmodel));
        //}

        

        //public ActionResult UpdateAdmin(int id, AdminCreatDtos adminCreatDtos)
        //{
        //    var AdminModelfromRepo = _admin.GetAdminsById(id);
        //    if (AdminModelfromRepo == null)
        //    {
        //        return NotFound();
        //    }
        //    _mapper.Map(adminCreatDtos, AdminModelfromRepo);
        //    _admin.UpdateAdmin(AdminModelfromRepo);
        //    _admin.SaveChanges();
        //    return NoContent();

        //}
        
 
        //public ActionResult DeleteAdmin(int id)
        //{
        //    var AdminModelfromRepo = _admin.GetAdminsById(id);
        //    if (AdminModelfromRepo == null)
        //    {
        //        return NotFound();
        //    }
        //    _admin.DeleteAdmin(AdminModelfromRepo);
        //    _admin.SaveChanges();
        //    return NoContent();
        //}



    }
}
