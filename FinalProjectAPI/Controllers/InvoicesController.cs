using FinalProjectAPI.DTO;
using FinalProjectDB.Models;
using FinalProjectModels.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Security.Principal;

namespace FinalProjectAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {
        private readonly FinalProjectEntity context;

        public InvoicesController(FinalProjectEntity _context)
        {
            context = _context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<الفواتير> invoices = context.الفواتير.Include(i => i.البضاعه).ToList();

            var invsDTO = new List<InvoicesDTO>();

            foreach (var invoice in invoices)
            {
                invsDTO.Add(new InvoicesDTO
                {
                    رقم_الفاتوره = invoice.رقم_الفاتوره,
                    التاريخ = invoice.التاريخ,
                    الحساب = invoice.الحساب,
                    طريقه_الحساب = invoice.طريقه_الحساب,
                    الكميه = invoice.الكميه,
                    الخصم = invoice.الخصم,
                    النهائي = invoice.النهائي,
                    درج_النقديه = invoice.درج_النقديه,
                    ارقام_البضاعة = invoice.البضاعه.Select(p => p.رقم_الصنف).ToList(),
                });
            }

            return Ok(invsDTO);
        }

        [HttpGet("{id:int}", Name = "GetOneInvoiceRoute")]
        public IActionResult GetById(int id)
        {
            الفواتير invoice = context.الفواتير.Include(i => i.البضاعه)
                    .FirstOrDefault(i => i.رقم_الفاتوره == id);

            if(invoice != null)
            {
                InvoicesDTO invDTO = new InvoicesDTO
                {
                    رقم_الفاتوره = invoice.رقم_الفاتوره,
                    التاريخ = invoice.التاريخ,
                    الحساب = invoice.الحساب,
                    طريقه_الحساب = invoice.طريقه_الحساب,
                    الكميه = invoice.الكميه,
                    الخصم = invoice.الخصم,
                    النهائي = invoice.النهائي,
                    درج_النقديه = invoice.درج_النقديه,
                    ارقام_البضاعة = invoice.البضاعه.Select(p => p.رقم_الصنف).ToList(),
                };

                return Ok(invDTO);
            }

            return BadRequest("لا يوجد فاتورة بهذا الرقم!");
        }

        [HttpPut("{id:int}")]
        public IActionResult UodateInvoice(int id, [FromBody]InvoicesDTO NewInvoice)
        {
            if (ModelState.IsValid)
            {
                الفواتير Oldinvoice = context.الفواتير.Include(i => i.البضاعه)
                        .FirstOrDefault(i => i.رقم_الفاتوره == id);

                if(Oldinvoice != null)
                {
                    Oldinvoice.التاريخ = NewInvoice.التاريخ;
                    Oldinvoice.الحساب = NewInvoice.الحساب;
                    Oldinvoice.طريقه_الحساب = NewInvoice.طريقه_الحساب;
                    Oldinvoice.الكميه = NewInvoice.الكميه;
                    Oldinvoice.الخصم = NewInvoice.الخصم;
                    Oldinvoice.النهائي = NewInvoice.النهائي;
                    Oldinvoice.درج_النقديه = NewInvoice.درج_النقديه;

                    List<البضاعه> prds = new List<البضاعه>();

                    foreach (var num in NewInvoice.ارقام_البضاعة)
                    {
                        prds.Add(context.البضاعه.FirstOrDefault(p => p.رقم_الصنف == num));
                    }

                    Oldinvoice.البضاعه = prds;
                    context.SaveChanges();

                    return StatusCode(204, "تم تعديل الفاتورة بنجاح");
                }

                return BadRequest("لا يوجد فاتورة بهذا الرقم!");
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("{id:int}")]
        public IActionResult RemoveInvoice(int id)
        {
            if (ModelState.IsValid)
            {
                الفواتير invoice = context.الفواتير.FirstOrDefault(i => i.رقم_الفاتوره == id);
                if(invoice != null)
                {
                    try
                    {
                        context.الفواتير.Remove(invoice);
                        context.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        return BadRequest(ex.Message);
                    }

                    return StatusCode(204, "تم حذف الحساب بنجاح");
                }

                return BadRequest("لا يوجد فاتورة بهذا الرقم!");
            }

            return BadRequest(ModelState);
        }
    }
}
