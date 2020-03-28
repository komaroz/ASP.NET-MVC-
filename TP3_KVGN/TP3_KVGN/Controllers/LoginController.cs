using System.Linq;
using System.Web.Mvc;
using TP3_KVGN.Models;

namespace TP3_KVGN.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Autoriser(user userModel)
        {

            using (BD_CatalogueEntities db = new BD_CatalogueEntities())
            {

                var userDetails = db.users.Where(x => x.login == userModel.login && x.motdepasse == userModel.motdepasse).FirstOrDefault();

                if (userDetails == null)
                {
                    userModel.LoginErrorMessage = "Nom d'utilisateur ou mot de passe n'existe pas";
                    return View("Index", userModel);
                }
                else
                {
                    Session["login"] = userDetails.login;
                    Session["id"] = userDetails.id_user;

                    return userDetails.type_compte.Equals("admin")
                        ? RedirectToAction("Index", "Admin")
                        : RedirectToAction("Index", "users");
                }
            }
        }
    }
}