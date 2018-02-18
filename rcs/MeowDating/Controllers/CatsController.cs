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
    using File = MeowDating.Models.File;
    
    public class CatsController : Controller
    {
       // GET: Cats
       public ActionResult Index()
       {
           using (var catDb = new CatDb())
           {
                //Iegūt kaku sarakstu no kaķu datubāzes
                var CatListFromDb = catDb.CatProfiles.Include(CatProf => CatProf.ProfilePicture).ToList();
                //izveidot skatu tam iekšā padodot kaķu sarakstu
                return View(CatListFromDb);
           }

       }

       public ActionResult AddCat()
       {
          return View();
       }



       [HttpPost]
 
        public ActionResult AddCat(CatProfile userCreatedCat, HttpPostedFileBase uploadedPicture)
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
                
                if (uploadedPicture != null)
                {
                    //Izveidot jaunu  profila bildes datubāzes eksemplāru, ko ierakstīt datu bāzē
                    var ProfilePic = new File();
                    //Saglabājam bildes faila nosaukumu
                    ProfilePic.FileName = Path.GetFileName(uploadedPicture.FileName);
                    // saglabājam bildes tipu
                    ProfilePic.ContentType = uploadedPicture.ContentType;
                    // izmantojam BinaryReader lai pārvērstu bildi baitos
                    using (var reader = new BinaryReader(uploadedPicture.InputStream))
                    {
                        // saglabājam baitus datubāzes ierakstā
                        ProfilePic.Content = reader.ReadBytes(uploadedPicture.ContentLength);
                    }
                    // pasakam profila bildei, kurš kaķa profils ir kaķa profils, kam šī bilde pieder
                    ProfilePic.CatProfileId = userCreatedCat.CatId;
                    ProfilePic.CatProfile = userCreatedCat;

                    // pievienojam profila bildes datubāzes ierakstu Files tabulai
                    catDb.Files.Add(ProfilePic);

                    // saglabājam profila bildi datubāzē, lai iegūtu FileId priekš profila bildes ieraksta
                    catDb.SaveChanges();

                    // paskam kaķu profilam, kas ir viņa profila bilde
                    userCreatedCat.ProfilePicture = ProfilePic;

                    // saglabājam izmaiņas datubāzē
                    catDb.SaveChanges();
                }
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
                //ja ir pievienota profila bilde
                if (uploadedPicture != null)
                {
                    //Atrodam šobrīdējo bildi, ja tāda ir
                    var currentPic = catDb.Files.FirstOrDefault(fileRecord => fileRecord.CatProfileId == catProfile.CatId);
                    if (currentPic != null)
                    {
                        catDb.Files.Remove(currentPic);
                    }
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

                    //Pasakam kurs kaķa profils it tas kuram pieder bilde
                    ProfilePic.CatProfileId = catProfile.CatId;
                    ProfilePic.CatProfile = catProfile;

                    //Pievienojam datubāzes files ierakstu tabulai
                    catDb.Files.Add(ProfilePic);

                    //Pasakam kaķa profila, kas ir viņa bilde
                    catProfile.ProfilePicture = ProfilePic;
                }

                catDb.Entry(catProfile).State = EntityState.Modified;
                catDb.SaveChanges();
            }

            //pavēlam browserim atgriezties index lapā (t.i.parlādēt to)
            return RedirectToAction("Index");

        }
  
        public ActionResult EditCat(int editableCatId)
        {
            using (var catDb = new CatDb())
            {
                var editableCat = catDb.CatProfiles.Include(catRecord => catRecord.ProfilePicture).First(catProfile => catProfile.CatId == editableCatId);
                return View("EditCat", editableCat);
            }
        }

        public ActionResult DeleteCats(int delatableCatId)
        {
            using (var catDb = new CatDb())
            {
                //atrast kaķi kuram pieder norādītais identifikātors
                var deletableCat = catDb.CatProfiles.Include(CatProf => CatProf.ProfilePicture).First(record => record.CatId == delatableCatId);
                
                //atrast kaķa bildi ja tada ir
                if (deletableCat.ProfilePicture != null)
                {
                    //izdzēst bildi
                    catDb.Files.Remove(deletableCat.ProfilePicture);
                }

                //izdzest kaki no tabulas
                catDb.CatProfiles.Remove(deletableCat);

                //saglabāt veiktās izmaiņas datubāze
                catDb.SaveChanges();
            }
            // pavēlam browserim atgriezties Index lapā (t.i. pārlādēt to)
            return RedirectToAction("Index");
        }
    }
}