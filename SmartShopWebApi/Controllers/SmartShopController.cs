using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SmartShopWebApi.Models;

namespace SmartShopWebApi.Controllers
{
    [RoutePrefix("api/products")]
    public class SmartShopController : ApiController
    {
        MySmartShopEntities1 ssEntity = new MySmartShopEntities1();
        [HttpGet]
        [Route("allproducts")]

        public IQueryable<tbl_products> GetAllProducts()
        {
            try
            {
                return ssEntity.tbl_products;
            }
            catch (Exception)
            {

                throw;
            }
            
        }
        [HttpGet]
        [Route("GetProductDetailsById/{id:int}")]
        public IHttpActionResult GetProductDetails(int id)
        {
            tbl_products Obj = new tbl_products();
            try
            {
                Obj = ssEntity.tbl_products.Find(id);
                if(Obj == null)
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return Ok(Obj);
        }
        // TODO this
        [HttpPost]
        [Route("InsertProductDetails")]
        public IHttpActionResult PostEmployee(tbl_products data)
        {
            // ModelSate review for next lesson 
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                ssEntity.tbl_products.Add(data);
                ssEntity.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return Ok(data);
        }
        [HttpPut]
        [Route("UpdateProductDetails")]
        public IHttpActionResult PutProduct(tbl_products product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                tbl_products objPro = new tbl_products();
                objPro = ssEntity.tbl_products.Find(product.pro_id);
                if (objPro != null)
                {
                    objPro.pro_name = product.pro_name;
                    objPro.pro_img = product.pro_img;
                    objPro.pro_details = product.pro_details;
                    objPro.pro_price = product.pro_price;
                    objPro.pro_quantity = product.pro_quantity;
                }
                this.ssEntity.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            return Ok(product);
        }

        [HttpDelete]
        [Route("DeleteProductDetails/{id:int}")]
        public IHttpActionResult DeleteProduct(int id)
        {
            tbl_products myPro = ssEntity.tbl_products.Find(id);
            if (myPro == null)
            {
                return NotFound();
            }
            ssEntity.tbl_products.Remove(myPro);
            ssEntity.SaveChanges();
            return Ok(myPro);
        }

    }
}
