using MVC_Ajax_helper_metodları.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;

namespace MVC_Ajax_helper_metodları.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            List<string> veriler = new List<string>() { "Teknoloji", "Sağlık", "Giyim", "Gıda" };
            Session["liste"]= veriler;
            return View();
        }
        public PartialViewResult VeriYukle()//biz butona basınca partial page e attı ilk ama biz bu verileri  ana sayfada yazsın istiyoruz artı bu verileri yükle ve action resultun tipi get unutma 
        {
            List<string> veriler = (List<string>)
                 Session["liste"];
            

            System.Threading.Thread.Sleep(3000);

            return PartialView("_PartialPageVeriler",veriler);
        }
        public MvcHtmlString VeriSil(int id) //buradan dönen şeyi gelip normalde action çağrırken sonuç dönüyor bunu alıp insertion mod alıyor nasıl değiştireceğimizi seçtik replace with yani li nin kendisi ile deiğişiyor veri silden gelen veri ile değişiyor yani boş bir şey ile değiştirip silmiş gibi yapıyor
        {
            List<string> veriler = (List<string>)
                 Session["liste"];
            veriler.RemoveAt(id);
            Session["liste"] = veriler;

            return MvcHtmlString.Empty;
        }
        List<Kisi> kisiler = new List<Kisi>();
        public ActionResult Index2()
        {

            if (Session["kisiler"] != null)
            {
                kisiler = (List<Kisi>)Session["kisiler"];
            }
            else
            {
                kisiler = new List<Kisi>();
            }
           ViewBag.kisiler = kisiler;
            

            return View(new Kisi()); 
        }
        [HttpPost]

        public PartialViewResult Index2(Kisi kisi)
        {
            kisi.Id=Guid.NewGuid();// id yi yapıp kisiye yolladık partial da
           

            if (Session["kisiler"]!=null)
            {
                kisiler = (List<Kisi>)Session["kisiler"];
            }
            kisiler.Add(kisi);
            Session["kisiler"]= kisiler;

            

            return PartialView("_PartialPageKisiler",kisi);
        }
        public ActionResult test()
        {
            return View();
        }


    }
}