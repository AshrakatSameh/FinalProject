using FinalProjectAPI.DTO;
using FinalProjectDB.Models;
using FinalProjectModels.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BuyingController : ControllerBase
    {
        private readonly FinalProjectEntity context;

        public BuyingController(FinalProjectEntity context)
        {
            this.context = context;
        }

        [HttpGet("Get")]
        public IActionResult GetAll()
        {
            List<شراء> buying = context.شراء.ToList();
            return Ok(buying);
        }

        [HttpGet("GetById/{id:int}", Name = "GetOneBuyingRoute")]
        public IActionResult GetById(int id)
        {
            شراء buy = context.شراء.FirstOrDefault(s => s.رقم_الصنف == id);
            if (buy != null)
            {
                BuyingDTO bDto = new BuyingDTO
                {
                    رقم_الصنف = buy.رقم_الصنف,
                    اسم_الصنف = buy.اسم_الصنف,
                    الاجمالي = buy.الاجمالي,
                    السعر = buy.السعر,
                    الكميه = buy.الكميه,
                    وحده = buy.وحده,
                    ألنهائي = buy.ألنهائي,
                };

                return Ok(bDto);
            }

            return BadRequest("لا يوجد صف شراء بهذا الرقم!");
        }

        [HttpPost("Add")]
        public IActionResult AddNewBuying(BuyingDTO newBuying)
        {
            if (ModelState.IsValid)
            {
                شراء buy = new شراء
                {
                    اسم_الصنف = newBuying.اسم_الصنف,
                    السعر = newBuying.السعر,
                    الكميه = newBuying.الكميه,
                    وحده = newBuying.وحده,
                    الاجمالي = newBuying.الاجمالي,
                    ألنهائي = newBuying.ألنهائي,
                };
                context.شراء.Add(buy);

                context.SaveChanges();
                string url = Url.Link("GetOneBuyingRoute", new { id = buy.رقم_الصنف });
                return Created(url, newBuying);
            }

            return BadRequest(ModelState);
        }

        [HttpPut("Update/{id:int}")]
        public IActionResult UpdateBuying(int id, BuyingDTO newBuying)
        {
            if (ModelState.IsValid)
            {
                شراء oldBuying = context.شراء.FirstOrDefault(s => s.رقم_الصنف == id);
                if (oldBuying != null)
                {
                    oldBuying.اسم_الصنف = newBuying.اسم_الصنف;
                    oldBuying.السعر = newBuying.السعر;
                    oldBuying.الاجمالي = newBuying.الاجمالي;
                    oldBuying.وحده = newBuying.وحده;
                    oldBuying.ألنهائي = newBuying.ألنهائي;
                    oldBuying.الكميه = newBuying.الكميه;

                    context.SaveChanges();
                    return StatusCode(204, "تم تعديل الشراء بنجاح");
                }

                return BadRequest("لا يوجد صف شراء بهذا الرقم!");
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("Delete/{id:int}")]
        public IActionResult Remove(int id)
        {
            شراء buying = context.شراء.FirstOrDefault(s => s.رقم_الصنف == id);
            if (buying != null)
            {
                try
                {
                    context.Remove(buying);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }

                return StatusCode(204, "تم حذف الشراء بنجاح");
            }

            return BadRequest("لا يوجد صف شراء بهذا الرقم!");
        }
    }
}
