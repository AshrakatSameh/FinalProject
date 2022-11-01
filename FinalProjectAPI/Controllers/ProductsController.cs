using FinalProjectAPI.DTO;
using FinalProjectDB.Models;
using FinalProjectModels.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalProjectAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly FinalProjectEntity context;

        public ProductsController(FinalProjectEntity _context)
        {
            context = _context;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            List<البضاعه> products = context.البضاعه.Include(p => p.الفواتير)
                .Include(p => p.بيع)
                .Include(p => p.شراء)
                .Include(p => p.مرتجع_بيع)
                .Include(p => p.مرتجع_شراء)
                .ToList();

            var prdsDto = new List<ProductsDTO>();

            foreach (var item in products)
            {
                prdsDto.Add(new ProductsDTO
                {
                    رقم_الصنف = item.رقم_الصنف,
                    اسم_الصنف = item.اسم_الصنف,
                    سعر_البيع = item.سعر_البيع,
                    اجمالي_الكميه = item.اجمالي_الكميه,
                    سعر_الشراء = item.سعر_الشراء,
                    الوصف = item.الوصف,
                    الشراء_رقم_الصنف = item.شراء.رقم_الصنف,
                    البيع_رقم_الصنف = item.بيع.رقم_الصنف,
                    مرتجع_البيع_رقم_الصنف = item.مرتجع_بيع.رقم_الصنف,
                    مرتجع_الشراء_رقم_الصنف = item.مرتجع_شراء.رقم_الصنف,
                    ارقام_الفواتير = item.الفواتير.Select(i => i.رقم_الفاتوره).ToList()
                });
            }

            return Ok(prdsDto);
        }

        [HttpGet("Get/{id:int}", Name = "GetOneProductRoute")]
        public IActionResult GetById(int id)
        {
            البضاعه product = context.البضاعه.Include(p => p.الفواتير)
                                .Include(p => p.بيع).Include(p => p.شراء).Include(p => p.مرتجع_بيع)
                                .Include(p => p.مرتجع_شراء)
                            .FirstOrDefault(p => p.رقم_الصنف == id);

            if (product != null)
            {
                ProductsDTO prdDTO = new ProductsDTO
                {
                    رقم_الصنف = product.رقم_الصنف,
                    اسم_الصنف = product.اسم_الصنف,
                    سعر_البيع = product.سعر_البيع,
                    اجمالي_الكميه = product.اجمالي_الكميه,
                    سعر_الشراء = product.سعر_الشراء,
                    الوصف = product.الوصف,
                    البيع_رقم_الصنف = product.بيع.رقم_الصنف,
                    الشراء_رقم_الصنف = product.شراء.رقم_الصنف,
                    مرتجع_البيع_رقم_الصنف = product.مرتجع_بيع.رقم_الصنف,
                    مرتجع_الشراء_رقم_الصنف = product.مرتجع_شراء.رقم_الصنف,
                    ارقام_الفواتير = product.الفواتير.Select(i => i.رقم_الفاتوره).ToList(),
                };

                return Ok(prdDTO);
            }

            return BadRequest("لا يوجد منتج بهذا الرقم!");
        }

        //[HttpPost("Add")]
        //public IActionResult AddNewProduct(ProductsDTO newProduct)
        //{
        //    if(ModelState.IsValid)
        //    {
        //        البضاعه newprd = new البضاعه {
        //            اسم_الصنف = newProduct.اسم_الصنف,
        //            سعر_الشراء = newProduct.سعر_الشراء,
        //            سعر_البيع = newProduct.سعر_البيع,
        //            الوصف = newProduct.الوصف,
        //            اجمالي_الكميه = newProduct.اجمالي_الكميه,
        //        };
        //        context.البضاعه.Add(newprd);

        //        context.SaveChanges();
        //        string url = Url.Link("GetOneProductRoute", new { id = newprd.رقم_الصنف });
        //        return Created(url, newprd);
        //    }

        //    return BadRequest(ModelState);
        //}

        [HttpPut("{id:int}")]
        public IActionResult UpdateProduct(int id, ProductsDTO newProduct)
        {
            if (ModelState.IsValid)
            {
                البضاعه OldProduct = context.البضاعه.Include(p => p.الفواتير)
                                .Include(p => p.بيع).Include(p => p.شراء).Include(p => p.مرتجع_بيع)
                                .Include(p => p.مرتجع_شراء)
                            .FirstOrDefault(p => p.رقم_الصنف == id);

                if (OldProduct != null)
                {
                    OldProduct.رقم_الصنف = newProduct.رقم_الصنف;
                    OldProduct.اسم_الصنف = newProduct.اسم_الصنف;
                    OldProduct.سعر_البيع = newProduct.سعر_البيع;
                    OldProduct.سعر_الشراء = newProduct.سعر_الشراء;
                    OldProduct.اجمالي_الكميه = newProduct.اجمالي_الكميه;
                    OldProduct.الوصف = newProduct.الوصف;
                    OldProduct.بيع = context.بيع.FirstOrDefault(s => s.رقم_الصنف == newProduct.البيع_رقم_الصنف);
                    OldProduct.شراء = context.شراء.FirstOrDefault(s => s.رقم_الصنف == newProduct.الشراء_رقم_الصنف);
                    OldProduct.مرتجع_بيع = context.مرتجع_بيع.FirstOrDefault(s => s.رقم_الصنف == newProduct.مرتجع_البيع_رقم_الصنف);
                    OldProduct.مرتجع_شراء = context.مرتجع_شراء.FirstOrDefault(s => s.رقم_الصنف == newProduct.مرتجع_الشراء_رقم_الصنف);


                    List<الفواتير> invs = new List<الفواتير>();

                    foreach (var num in newProduct.ارقام_الفواتير)
                    {
                        invs.Add(context.الفواتير.FirstOrDefault(p => p.رقم_الفاتوره == num));
                    }

                    OldProduct.الفواتير = invs;
                    context.SaveChanges();

                    return StatusCode(204, "تم تعديل المنتج بنجاح");
                }

                return BadRequest("لا يوجد منتج بهذا الرقم!");
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Remove(int id)
        {
            if (ModelState.IsValid)
            {
                البضاعه invoice = context.البضاعه.FirstOrDefault(i => i.رقم_الصنف == id);
                if (invoice != null)
                {
                    try
                    {
                        context.البضاعه.Remove(invoice);
                        context.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        return BadRequest(ex.Message);
                    }

                    return StatusCode(204, "تم حذف المنتج بنجاح");
                }

                return BadRequest("لا يوجد منتج بهذا الرقم!");
            }

            return BadRequest(ModelState);
        }
    }
}
