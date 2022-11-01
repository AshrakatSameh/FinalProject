using FinalProjectAPI.DTO;
using FinalProjectDB.Models;
using FinalProjectModels.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SalesReturnsController : ControllerBase
    {
        private readonly FinalProjectEntity context;

        public SalesReturnsController(FinalProjectEntity _context)
        {
            context = _context;
        }

        [HttpGet("Get")]
        public IActionResult GetAll()
        {
            List<مرتجع_بيع> salesReturns = context.مرتجع_بيع.ToList();
            return Ok(salesReturns);
        }

        [HttpGet("GetById/{id:int}", Name = "GetOneSellingReturnRoute")]
        public IActionResult GetById(int id)
        {
            مرتجع_بيع salesReturn = context.مرتجع_بيع.FirstOrDefault(s => s.رقم_الصنف == id);
            if(salesReturn != null)
            {
                SalesRetrnsDTO srDTO = new SalesRetrnsDTO
                {
                    رقم_الصنف = salesReturn.رقم_الصنف,
                    اسم_الصنف = salesReturn.اسم_الصنف,
                    السعر = salesReturn.السعر,
                    الكميه = salesReturn.الكميه,
                    وحده = salesReturn.وحده,
                    الاجمالي = salesReturn.الاجمالي,
                    ألنهائي = salesReturn.ألنهائي,
                };

                return Ok(srDTO);
            }

            return BadRequest("لا يوجد مرتجع بيع بهذا الرقم!");
        }

        [HttpPost("Add")]
        public IActionResult AddNewSellingReturn(sellingDTO newSellingReturn)
        {
            if(ModelState.IsValid)
            {
                مرتجع_بيع sReturn = new مرتجع_بيع
                {
                    اسم_الصنف = newSellingReturn.اسم_الصنف,
                    وحده = newSellingReturn.وحده,
                    السعر = newSellingReturn.السعر,
                    الكميه = newSellingReturn.الكميه,
                    الاجمالي = newSellingReturn.الاجمالي,
                    ألنهائي = newSellingReturn.النهائي,
                };
                context.مرتجع_بيع.Add(sReturn);

                context.SaveChanges();
                string url = Url.Link("GetOneSellingReturnRoute", new { id = sReturn.رقم_الصنف });
                return Created(url, newSellingReturn);
            }

            return BadRequest(ModelState);
        }

        [HttpPut("Update/{id:int}")]
        public IActionResult UpdateSellingReturn(int id, sellingDTO newSellingReturn)
        {
            if(ModelState.IsValid)
            {
                مرتجع_بيع oldSellingReturn = context.مرتجع_بيع.FirstOrDefault(s => s.رقم_الصنف == id);
                if(oldSellingReturn != null)
                {
                    oldSellingReturn.اسم_الصنف = newSellingReturn.اسم_الصنف;
                    oldSellingReturn.السعر = newSellingReturn.السعر;
                    oldSellingReturn.وحده = newSellingReturn.وحده;
                    oldSellingReturn.الكميه = newSellingReturn.الكميه;
                    oldSellingReturn.الاجمالي = newSellingReturn.الاجمالي;
                    oldSellingReturn.ألنهائي = newSellingReturn.النهائي;

                    context.SaveChanges();
                    return StatusCode(204, "تم تعديل مرتجع البيع بنجاح");
                }

                return BadRequest("لا يوجد مرتجع بيع بهذا الرقم!");
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("Delete/{id:int}")]
        public IActionResult Remove(int id)
        {
            مرتجع_بيع sellingReturn = context.مرتجع_بيع.FirstOrDefault(s => s.رقم_الصنف == id);
            if(sellingReturn != null)
            {
                try
                {
                    context.Remove(sellingReturn);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }

                return StatusCode(204, "تم حذف مرتجع البيع بنجاح");
            }

            return BadRequest("لا يوجد مرتجع بيع بهذا الرقم!");
        }
    }
}
