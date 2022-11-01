using FinalProjectAPI.DTO;
using FinalProjectDB.Models;
using FinalProjectModels.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PurchaseReturnsController : ControllerBase
    {
        private readonly FinalProjectEntity context;

        public PurchaseReturnsController(FinalProjectEntity _context)
        {
            context = _context;
        }

        [HttpGet("Get")]
        public IActionResult GetAll()
        {
            List<مرتجع_شراء> purchaseReturn = context.مرتجع_شراء.ToList();
            return Ok(purchaseReturn);
        }

        [HttpGet("GetById/{id:int}", Name = "GetOnePurchaseReturnRoute")]
        public IActionResult GetById(int id)
        {
            مرتجع_شراء purchaseReturn = context.مرتجع_شراء.FirstOrDefault(s => s.رقم_الصنف == id);
            if (purchaseReturn != null)
            {
                PurchaseRetrnsDTO prDTO = new PurchaseRetrnsDTO
                {
                    رقم_الصنف = purchaseReturn.رقم_الصنف,
                    اسم_الصنف = purchaseReturn.اسم_الصنف,
                    السعر = purchaseReturn.السعر,
                    الكميه = purchaseReturn.الكميه,
                    وحده = purchaseReturn.وحده,
                    الاجمالي = purchaseReturn.الاجمالي,
                    النهائي = purchaseReturn.النهائي,
                };

                return Ok(prDTO);
            }

            return BadRequest("لا يوجد مرتجع شراء بهذا الرقم!");
        }

        [HttpPost("Add")]
        public IActionResult AddNewPurchaseReturn(PurchaseRetrnsDTO newPurchaseReturn)
        {
            if (ModelState.IsValid)
            {
                مرتجع_شراء pReturn = new مرتجع_شراء
                {
                    اسم_الصنف = newPurchaseReturn.اسم_الصنف,
                    وحده = newPurchaseReturn.وحده,
                    السعر = newPurchaseReturn.السعر,
                    الكميه = newPurchaseReturn.الكميه,
                    الاجمالي = newPurchaseReturn.الاجمالي,
                    النهائي = newPurchaseReturn.النهائي,
                };
                context.مرتجع_شراء.Add(pReturn);

                context.SaveChanges();
                string url = Url.Link("GetOnePurchaseReturnRoute", new { id = pReturn.رقم_الصنف });
                return Created(url, newPurchaseReturn);
            }

            return BadRequest(ModelState);
        }

        [HttpPut("Update/{id:int}")]
        public IActionResult UpdatePurchaseReturn(int id, PurchaseRetrnsDTO newPurchaseReturn)
        {
            if (ModelState.IsValid)
            {
                مرتجع_شراء oldPurchaseReturn = context.مرتجع_شراء.FirstOrDefault(s => s.رقم_الصنف == id);
                if (oldPurchaseReturn != null)
                {
                    oldPurchaseReturn.اسم_الصنف = newPurchaseReturn.اسم_الصنف;
                    oldPurchaseReturn.السعر = newPurchaseReturn.السعر;
                    oldPurchaseReturn.وحده = newPurchaseReturn.وحده;
                    oldPurchaseReturn.الكميه = newPurchaseReturn.الكميه;
                    oldPurchaseReturn.الاجمالي = newPurchaseReturn.الاجمالي;
                    oldPurchaseReturn.النهائي = newPurchaseReturn.النهائي;

                    context.SaveChanges();
                    return StatusCode(204, "تم تعديل مرتجع الشراء بنجاح");
                }

                return BadRequest("لا يوجد مرتجع شراء بهذا الرقم!");
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("Delete/{id:int}")]
        public IActionResult Remove(int id)
        {
            مرتجع_شراء purchaseReturn = context.مرتجع_شراء.FirstOrDefault(s => s.رقم_الصنف == id);
            if (purchaseReturn != null)
            {
                try
                {
                    context.Remove(purchaseReturn);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }

                return StatusCode(204, "تم حذف مرتجع الشراء بنجاح");
            }

            return BadRequest("لا يوجد مرتجع شراء بهذا الرقم!");
        }
    }
}
