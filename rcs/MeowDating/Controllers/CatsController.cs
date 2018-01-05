using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeowDating.Controllers
{ 
    using System.Data.Entity.Migrations;

    using MeowDating.Models;

    public class CatsController : Controller
    {
       // GET: Cats
       public ActionResult Index()
       {
           using (var catDb = new CatDb())
           {
                //Iegūt kaku sarakstu no kaķu datubāzes
                var CatListFromDb = catDb.CatProfiles.ToList();
                //izveidot skatu tam iekšā padodot kaķu sarakstu
                return View(CatListFromDb);
           }

       }

       public ActionResult AddCat()
       {
          return View();
       }

       [HttpPost]
 
        public ActionResult AddCat(CatProfile userCreatedCat)
        {

             if (ModelState.IsValid == false)
             {
                return RedirectToAction("Index");
             }
             //Izveidot savienojumu ar datubāzi
             using (var catDb = new CatDb())
             {
                //Pievienojam kaķi kaķu tabulā
                catDb.CatProfiles.Add(userCreatedCat);
                //saglabājam izmaiņas datubazē
                catDb.SaveChanges();
             }
       
             //pavēlam browserim atgriezties index lapā (t.i.parlādēt to)
             return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult EditCat(CatProfile catProfile)
        {
            using (var catDb = new CatDb())
            {
                catDb.Entry(catProfile).CurrentValues.SetValues(catProfile);
                catDb.SaveChanges();
            }

            //pavēlam browserim atgriezties index lapā (t.i.parlādēt to)
            return RedirectToAction("index");

        }
  
        public ActionResult EditCat(int editableCatId)
        {
            using (var catDb = new CatDb())
            {
                var editableCatId = catDb.CatProfiles.First(catProfile => catProfile.CatId == editableCatId);
                return View("EditCat", editableCatId);
            }
        }

        public ActionResult DeleteCats(int delatableCatId)
        {
            using (var catDb = new CatDb())
            {
                //atrast kaķi kuram pieder norādītais identifikātors
                var deletableCat = catDb.CatProfiles.First(record => record.CatId == delatableCatId);
                
                //izdzest kaki no tabulas
                catDb.CatProfiles.Remove(deletableCat);

                //saglabāt veiktās izmaiņas datubāze
                catDb.SaveChanges();

                // pavēlam browserim atgriezties Index lapā (t.i. pārlādēt to)
                return RedirectToAction("Index");
            }
        }
    }
}