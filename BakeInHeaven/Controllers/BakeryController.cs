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
        private readonly IOrdersRepo _order;

        //Dependency Injection 
        public BakeryController(IAdminRepo admin, IDelicacyRepo delicacy, IDelicacy_ScheduleRepo delicacy_Schedule, IOrdersRepo orders, IMapper mapper)
        {
            _admin = admin;
            _delicacy = delicacy;
            _delicacy_Schedule = delicacy_Schedule;
            _mapper = mapper;
            _order = orders;

        }


        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //Routes and Endpoints For Admin Table 
        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        [Route("api/Bakery/admin")]
        //GET: All Admin
        [HttpGet]
        public ActionResult<IEnumerable<AdminReadDtos>> GetAllAdmin()
        {
            var admins = _admin.GetAllAdmins();
            return Ok(_mapper.Map<IEnumerable<AdminReadDtos>>(admins));
        }
        //GET:Admin by ID
        [HttpGet("api/Bakery/admin/{id}")]
        public ActionResult<AdminReadDtos> GetAdminById(int id)
        {
            var admin = _admin.GetAdminsById(id);
            if (admin == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<AdminReadDtos>(admin));
        }

        //POST:adding Admin
        [HttpPost("api/Bakery/admin")]
        public ActionResult<AdminReadDtos> CreateAdmin(AdminCreatDtos admins)
        {
            var adminmodel = _mapper.Map<Admins>(admins);
            _admin.CreateAdmin(adminmodel);
            _admin.SaveChanges();
            return Ok(_mapper.Map<AdminReadDtos>(adminmodel));
        }

        //PUT:Updateing Admin details
        [HttpPut("api/Bakery/admin/{id}")]
        public ActionResult UpdateAdmin(int id, AdminCreatDtos adminCreatDtos)
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
        //DELETE:delete Admin
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
        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //Routes and Endpoints For delicacy Table 
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------



        [Route("api/Bakery/delicacy")]
        //GET:get all Delicacy
        [HttpGet]
        public ActionResult<IEnumerable<delicacys>> GetAlldelicacy()
        {
            var delicacys = _mapper.Map<IEnumerable<DelicacyReadDtos>>(_delicacy.GetAllDelicacy());


            return Ok(delicacys);
        }

        //GET:get Delicacy by Id
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
        //POST:Adding Delicacy
        [HttpPost("api/Bakery/delicacy")]
        public ActionResult<DelicacyReadDtos> CreateDelicacy(DelicacyWriteDtos delicacy)
        {
            var deli_model = _mapper.Map<delicacys>(delicacy);
            _delicacy.CreateDelicacy(deli_model);
            _delicacy.SaveChanages();
            return Ok(_mapper.Map<DelicacyReadDtos>(deli_model));
        }
        //PUT:Updating Delicacy
        [HttpPut("api/Bakery/delicacy/{id}")]
        public ActionResult UpdatedDelicacy(int id, DelicacyWriteDtos delicacyWriteDtos)
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
        //DELETE:Delete Delicacy
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
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //Routes and Endpoints For Delicacy_schedule Table 
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------



        [Route("api/Bakery/delicacy_schedule")]
        //GET:Get all delicacy_schedule"
        [HttpGet]
        public ActionResult<IEnumerable<Delicacy_ScheduleReadDtos>> GetAlldelicacy_Schedule()
        {
            var delicacys_schedule = _mapper.Map<IEnumerable<Delicacy_ScheduleReadDtos>>(_delicacy_Schedule.GetAllDelicacy_Scheduleds());
            // delicacys_schedule.ToList().ForEach(i => i.Delicacy_name= _delicacy.GetDelicacysByID(i.Delicacy_id).Name);
            foreach (var i in delicacys_schedule.ToList())
            {
                if (_delicacy.GetDelicacysByID(i.Delicacy_id) == null)
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
        //GET:Get delicacy_schedule by id
        [HttpGet("api/Bakery/delicacy_schedule/{id}")]
        public ActionResult<delicacys> GetDelicacy_ScheduleById(int id)
        {
            var delicacys_schedule = _mapper.Map<Delicacy_ScheduleReadDtos>(_delicacy_Schedule.GetDelicacy_ScheduledById(id));
            if (delicacys_schedule == null)
            {
                return NotFound();
            }
            delicacys_schedule.Delicacy_name = _delicacy.GetDelicacysByID(delicacys_schedule.Delicacy_id).Name;
            return Ok(delicacys_schedule);
        }
        //POST:adding delicacy schedule
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
        //DELETE:Delete the schedule
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
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //Routes and Endpoints for Order Table
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        [Route("api/Bakery/order")]
        //GET:Get all delicacy_schedule"
        [HttpGet]
        public ActionResult<IEnumerable<OrderReadDtos>> GetAllOrder()
        {
            var order = _mapper.Map<IEnumerable<OrderReadDtos>>(_order.GetAllOrders());
            // delicacys_schedule.ToList().ForEach(i => i.Delicacy_name= _order.GetDelicacysByID(i.Delicacy_id).Name);
            foreach (var i in order.ToList())
            {
                if (_order.GetOrdersById(i.Delicacyid) == null)
                {
                    _order.DeleteOrder(_order.GetOrdersById(i.Delicacyid));
                    _order.SaveChanges();
                }
                else
                {
                    i.DelicacyName = _delicacy.GetDelicacysByID(i.Delicacyid).Name;

                }
            }
            return Ok(order);


        }
        //GET:Get delicacy_schedule by id
        [HttpGet("api/Bakery/order/{id}")]
        public ActionResult<Orders> OrderById(int id)
        {
            var order = _mapper.Map<Delicacy_ScheduleReadDtos>(_order.GetOrdersById(id));
            if (order == null)
            {
                return NotFound();
            }
            order.Delicacy_name = _delicacy.GetDelicacysByID(order.Delicacy_id).Name;
            return Ok(order);
        }
        //POST:adding delicacy schedule
        [HttpPost("api/Bakery/order")]
        public ActionResult<OrderReadDtos> CreateOrder(OrderCreateDtos order)
        {
            var order_model = _mapper.Map<Orders>(order);
            _order.CreateOrder(order_model);
            _order.SaveChanges();
            return Ok(_mapper.Map<OrderReadDtos>(order_model));
        }
        [HttpPut("api/Bakery/order/{id}")]
        public ActionResult UpdateOrder(int id, OrderCreateDtos order)
        {
            var OrderModelfromRepo = _order.GetOrdersById(id);
            if (OrderModelfromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(order, OrderModelfromRepo);
            _order.UpdateOrder(OrderModelfromRepo);
            _order.SaveChanges();
            return NoContent();

        }
        //DELETE:Delete the schedule
        [HttpDelete("api/Bakery/order/{id}")]
        public ActionResult DeleteOrder(int id)
        {
            var OrderModelfromRepo = _order.GetOrdersById(id);
            if (OrderModelfromRepo == null)
            {
                return NotFound();
            }
            _order.DeleteOrder(OrderModelfromRepo);
            _order.SaveChanges();
            return NoContent();




        }

    }


}
