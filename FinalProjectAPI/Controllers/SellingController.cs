using FinalProjectAPI.DTO;
using FinalProjectDB.Models;
using FinalProjectModels.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SellingController : ControllerBase
    {
        private readonly FinalProjectEntity context;

        public SellingController(FinalProjectEntity _context)
        {
            context = _context;
        }

        [HttpGet("Get")]
        public IActionResult GetAll()
        {
            List<بيع> sellings = context.بيع.ToList();
            return Ok(sellings);
        }

        [HttpGet("GetById/{id:int}", Name = "GetOneSellingRoute")]
        public IActionResult GetById(int id)
        {
            بيع sell = context.بيع.FirstOrDefault(s => s.رقم_الصنف == id);
            if(sell != null)
            {
                sellingDTO sDto = new sellingDTO
                {
                    رقم_الصنف = sell.رقم_الصنف,
                    اسم_الصنف = sell.اسم_الصنف,
                    الاجمالي = sell.الاجمالي,
                    السعر = sell.السعر,
                    الكميه = sell.الكميه,
                    وحده = sell.وحده,
                    النهائي = sell.النهائي
                };

                return Ok(sDto);
            }

            return BadRequest("لا يوجد صف بيع بهذا الرقم!");
        }

        [HttpPost("Add")]
        public IActionResult AddNewSelling(sellingDTO newSelling)
        {
            if(ModelState.IsValid)
            {
                بيع sell = new بيع
                {
                    اسم_الصنف = newSelling.اسم_الصنف,
                    السعر = newSelling.السعر,
                    الكميه = newSelling.الكميه,
                    وحده = newSelling.وحده,
                    الاجمالي = newSelling.الاجمالي,
                    النهائي = newSelling.النهائي,
                };
                context.بيع.Add(sell);

                context.SaveChanges();
                string url = Url.Link("GetOneSellingRoute", new { id = sell.رقم_الصنف });
                return Created(url, newSelling);
            }

            return BadRequest(ModelState);
        }

        [HttpPut("Update/{id:int}")]
        public IActionResult UpdateSelling(int id, sellingDTO newSelling)
        {
            if(ModelState.IsValid)
            {
                بيع oldSelling = context.بيع.FirstOrDefault(s => s.رقم_الصنف == id);
                if(oldSelling != null)
                {
                    oldSelling.اسم_الصنف = newSelling.اسم_الصنف;
                    oldSelling.السعر = newSelling.السعر;
                    oldSelling.الاجمالي = newSelling.الاجمالي;
                    oldSelling.وحده = newSelling.وحده;
                    oldSelling.النهائي = newSelling.النهائي;
                    oldSelling.الكميه = newSelling.الكميه;

                    context.SaveChanges();
                    return StatusCode(204, "تم تعديل البيع بنجاح");
                }

                return BadRequest("لا يوجد صف بيع بهذا الرقم!");
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("Delete/{id:int}")]
        public IActionResult Remove(int id)
        {
            بيع selling = context.بيع.FirstOrDefault(s => s.رقم_الصنف == id);
            if (selling != null)
            {
                try
                {
                    context.Remove(selling);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }

                return StatusCode(204, "تم حذف البيع بنجاح");
            }

            return BadRequest("لا يوجد صف بيع بهذا الرقم!");
        }
    }
}
