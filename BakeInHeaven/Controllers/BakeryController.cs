using AutoMapper;
using Dataservices.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Userservices.Repository;
using Dataservices.Dtos;

namespace BakeInHeaven.Controllers
{
    
    
    [ApiController]
    public class BakeryController : ControllerBase
    {
        private readonly IAdminRepo _admin;
        private readonly IDelicacyRepo _delicacy;
        private readonly IDelicacy_ScheduleRepo _delicacy_Schedule;
        private readonly IMapper _mapper;

        public BakeryController(IAdminRepo admin,IDelicacyRepo delicacy,IDelicacy_ScheduleRepo delicacy_Schedule,IMapper mapper)
        {
            _admin = admin;
            _delicacy = delicacy;
            _delicacy_Schedule = delicacy_Schedule;
            _mapper = mapper;

        }



        //Routes and Endpoints For Admin Table 
        [Route("api/Bakery/admin")]
        [HttpGet]
        public ActionResult<IEnumerable<AdminReadDtos>> GetAllAdmin()
        {
            var admins = _admin.GetAllAdmins();
            return Ok(_mapper.Map<IEnumerable<AdminReadDtos>>(admins));
        }
        
        [HttpGet("api/Bakery/admin/{id}")]
        public ActionResult<AdminReadDtos> GetAdminById(int id)
        {
            var admin = _admin.GetAdminsById(id);
            if(admin==null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<AdminReadDtos>(admin));
        }
        [HttpPost("api/Bakery/admin")]
        public ActionResult<AdminReadDtos> CreateAdmin(AdminCreatDtos admins)
        {
            var adminmodel = _mapper.Map<Admins>(admins);
            _admin.CreateAdmin(adminmodel);
            _admin.SaveChanges();
            return Ok(_mapper.Map<AdminReadDtos>(adminmodel));
         }

        [HttpPut("api/Bakery/admin/{id}")]
        public ActionResult UpdateAdmin(int id,AdminCreatDtos adminCreatDtos)
        {
            var AdminModelfromRepo = _admin.GetAdminsById(id);
            if (AdminModelfromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(adminCreatDtos, AdminModelfromRepo);
            _admin.UpdateAdmin(AdminModelfromRepo);
            _admin.SaveChanges();
            return NoContent();

        }
        [HttpDelete("api/Bakery/admin/{id}")]
        public ActionResult DeleteAdmin(int id)
        {
            var AdminModelfromRepo = _admin.GetAdminsById(id);
            if (AdminModelfromRepo == null)
            {
                return NotFound();
            }
            _admin.DeleteAdmin(AdminModelfromRepo);
            _admin.SaveChanges();
            return NoContent();
        }

        //Routes and Endpoints For delicacy Table 
        [Route("api/Bakery/delicacy")]
        [HttpGet]
        public ActionResult<IEnumerable<delicacys>> GetAlldelicacy()
        {
            var delicacys = _mapper.Map<IEnumerable<DelicacyReadDtos>>(_delicacy.GetAllDelicacy());
            
            
            return Ok(delicacys);
        }

        [HttpGet("api/Bakery/delicacy/{id}")]
        public ActionResult<delicacys> GetDelicacyById(int id)
        {
            var delicacys = _mapper.Map<DelicacyReadDtos>(_delicacy.GetDelicacysByID(id));
            if (delicacys == null)
            {
                return NotFound();
            }
            return Ok(delicacys);
        }
        [HttpPost("api/Bakery/delicacy")]
        public ActionResult<DelicacyReadDtos> CreateDelicacy(DelicacyWriteDtos delicacy)
        {
            var deli_model = _mapper.Map<delicacys>(delicacy);
            _delicacy.CreateDelicacy(deli_model);
            _delicacy.SaveChanages();
            return Ok(_mapper.Map<DelicacyReadDtos>(deli_model));
        }
        [HttpPut("api/Bakery/delicacy/{id}")]
        public ActionResult UpdatedDelicacy(int id, DelicacyWriteDtos  delicacyWriteDtos)
        {
            var DeliModelfromRepo = _delicacy.GetDelicacysByID(id);
            if (DeliModelfromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(delicacyWriteDtos, DeliModelfromRepo);
            _delicacy.UpdateDelicacy(DeliModelfromRepo);
            _delicacy.SaveChanages();
            return NoContent();

        }
        [HttpDelete("api/Bakery/delicacy/{id}")]
        public ActionResult DeleteDelicacy(int id)
        {
            var AdminModelfromRepo = _delicacy.GetDelicacysByID(id);
            if (AdminModelfromRepo == null)
            {
                return NotFound();
            }
            _delicacy.DeleteDelicacy(AdminModelfromRepo);
            _delicacy.SaveChanages();
            return NoContent();
        }



        //Routes and Endpoints For Delicacy_schedule Table 

        [Route("api/Bakery/delicacy_schedule")]
        [HttpGet]
        public ActionResult<IEnumerable<Delicacy_ScheduleReadDtos>> GetAlldelicacy_Schedule()
        {
            var delicacys_schedule = _mapper.Map<IEnumerable<Delicacy_ScheduleReadDtos>>(_delicacy_Schedule.GetAllDelicacy_Scheduleds());
           // delicacys_schedule.ToList().ForEach(i => i.Delicacy_name= _delicacy.GetDelicacysByID(i.Delicacy_id).Name);
           foreach(var i  in delicacys_schedule.ToList())
            {if (_delicacy.GetDelicacysByID(i.Delicacy_id) == null)
                {
                    _delicacy_Schedule.DeleteDelicacy_Scheduled(_delicacy_Schedule.GetDelicacy_ScheduledById(i.Delicacy_id));
                    _delicacy_Schedule.SaveChanges();
                }
                else
                {
                    i.Delicacy_name = _delicacy.GetDelicacysByID(i.Delicacy_id).Name;

                }
            }
            return Ok(delicacys_schedule);
  

        }
        [HttpGet("api/Bakery/delicacy_schedule/{id}")]
        public ActionResult<delicacys> GetDelicacy_ScheduleById(int id)
        {
            var delicacys_schedule =_mapper.Map<Delicacy_ScheduleReadDtos>(_delicacy_Schedule.GetDelicacy_ScheduledById(id));
            if (delicacys_schedule == null)
            {
                return NotFound();
            }
            delicacys_schedule.Delicacy_name = _delicacy.GetDelicacysByID(delicacys_schedule.Delicacy_id).Name;
            return Ok(delicacys_schedule);
        }
        [HttpPost("api/Bakery/delicacy_schedule")]
        public ActionResult<Delicacy_ScheduleReadDtos> CreateSchedule(Delicacy_ScheduleWriteDtos delicacy_schedule)
        {
            var deli_sch_model = _mapper.Map<delicacy_Schedules>(delicacy_schedule);
            _delicacy_Schedule.CreateDelicacy_Scheduled(deli_sch_model);
            _delicacy_Schedule.SaveChanges();
            return Ok(_mapper.Map<Delicacy_ScheduleReadDtos>(deli_sch_model));
        }
        [HttpPut("api/Bakery/delicacy_schedule/{id}")]
        public ActionResult UpdateDelicacy_Schedule(int id, Delicacy_ScheduleWriteDtos delicacy_ScheduleWriteDtos)
        {
            var Deli_schdlModelfromRepo = _delicacy_Schedule.GetDelicacy_ScheduledById(id);
            if (Deli_schdlModelfromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(delicacy_ScheduleWriteDtos, Deli_schdlModelfromRepo);
            _delicacy_Schedule.UpdateDelicacy_Scheduled(Deli_schdlModelfromRepo);
            _delicacy_Schedule.SaveChanges();
            return NoContent();

        }
        [HttpDelete("api/Bakery/delicacy_schedule/{id}")]
        public ActionResult DeleteDelicacy_Schedule(int id)
        {
            var Deli_schdlModelfromRepo = _delicacy_Schedule.GetDelicacy_ScheduledById(id);
            if (Deli_schdlModelfromRepo == null)
            {
                return NotFound();
            }
            _delicacy_Schedule.DeleteDelicacy_Scheduled(Deli_schdlModelfromRepo);
            _delicacy_Schedule.SaveChanges();
            return NoContent();
        }

    }

}
