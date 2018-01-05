using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeowDating.Controllers
{
    using System.Data.Entity;
    using MeowDating.Models;
    using System.IO;
    
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
                return View(userCreatedCat);
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
        public ActionResult EditCat(CatProfile catProfile, HttpPostedFileBase uploadedPicture)
        {
            if (ModelState.IsValid == false)
            {
                return View(catProfile);
            }

            using (var catDb = new CatDb())
            {
                //Izveidojam jaunu profila bildes jaunu eksamplāru, ko ierakstīt datu bāzē
                var ProfilePic = new File();
                //saglabājam pic nosaukumu
                ProfilePic.FileName = Path.GetFileName(uploadedPicture.FileName);
                //saglabajam bildes tipu
                ProfilePic.ContentType = uploadedPicture.ContentType;
                
                //Izmantojam BinaryReader lai pārvestu bildi baitos
                using (var reader = new BinaryReader(uploadedPicture.InputStream))
                {
                    ProfilePic.Content = reader.ReadBytes(uploadedPicture.ContentLength);
                }

                Profile.catProfileId = catProfile.CatId;
                ProfilePic.CatProfile = catProfile;

                catDb.Files.Add(ProfilePic);

                catProfile.ProfilePicture = ProfilePic;
                catDb.Entry(catProfile).State = EntityState.Modified;
                catDb.SaveChanges();
            }

            //pavēlam browserim atgriezties index lapā (t.i.parlādēt to)
            return RedirectToAction("index");

        }
  
        public ActionResult EditCat(int editableCatId)
        {
            using (var catDb = new CatDb())
            {
                var editableCat = catDb.CatProfiles.First(catProfile => catProfile.CatId == editableCatId);
                return View("EditCat", editableCat);
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