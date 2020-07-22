using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity; /*pr use les données de typ entityFramework(manipuler nos classes)*/
using projetCatalogueProduit.Models;/*use les classes qui st ds notr projet*/
namespace projetCatalogueProduit.Controllers
{
    public class CategorieController : Controller
    {
        BD_CATALOGUE_PRODUITEntities db = new BD_CATALOGUE_PRODUITEntities();
        // GET: Categorie
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AjoutCategorie()
        {
            try
            {
                /*ViewBag.listeCategoriecontiendra tte les categ de la bd*/
                ViewBag.listeCategorie = db.CAT_CATEGORIE.ToList();

                return View();

            }
            catch (Exception e)
            {
                return HttpNotFound();
            }
        }

        /*cette action doit porter le meme nom q celui ci haut(AjoutCategorie) a la difference qu'elle a l'annotation httpPost pr recuperer toutes les infos venant du formulaires avec la method post(ds le form)*/
        [HttpPost] 
        public ActionResult AjoutCategorie(CAT_CATEGORIE categorie)/*cette action recevra tjr un param de typ cat_cat...*/
        {
            try
            {
                if (ModelState.IsValid) {/*si le model d'enreg est valid on ajoute la cat qui a été entré puis on la sauvegarde*/
                    db.CAT_CATEGORIE.Add(categorie);
                    db.SaveChanges();
                }
                /*après cette action on doit rediriger a la page du debut,on ne retourne pas une nvelle View mais la vue par defaut AjoutCat si en haut .donc pas de return View() ici*/
                return RedirectToAction("AjoutCategorie");
            }
            catch (Exception e)
            {
                return HttpNotFound();
            }
        }
    }
}