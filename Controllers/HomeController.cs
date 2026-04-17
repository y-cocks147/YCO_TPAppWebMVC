using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using TPLOCAL1.Models;
using TPLOCAL1.Models.Helpers;
using static System.Runtime.InteropServices.JavaScript.JSType;

//Subject is find at the root of the project and the logo in the wwwroot/ressources folders of the solution
//--------------------------------------------------------------------------------------
//Careful, the MVC model is a so-called convention model instead of configuration,
//The controller must imperatively be name with "Controller" at the end !!!
namespace TPLOCAL1.Controllers
{
    public class HomeController : Controller
    {
        //methode "naturally" call by router
        public ActionResult Index(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                //retourn to the Index view (see routing in Program.cs)
                return View();
            else
            {
                //Call different pages, according to the id pass as parameter
                switch (id)
                {
                    case "OpinionList":
                        //TODO : code reading of the xml files provide
                        return View(id);
                    case "Form":
                        //TODO DONE : call the Form view with data model empty
                        ViewData["GenderList"] = ConvertEnumToItem.GetGenderSelectList();
                        ViewData["TrainingTypeList"] = ConvertEnumToItem.GetTrainingTypeSelectList();
                        return View(id);
                    default:
                        //retourn to the Index view (see routing in Program.cs)
                        return View();
                }
            }
        }


        //methode to send datas from form to validation page
        [HttpPost]
        public ActionResult ValidationFormulaire([Bind("LastName,FirstName,Gender,Address,ZipCode,Town,EmailAddress," +
                                                        "TrainingStartDate,TrainingType," +
                                                        "CobolTrainingOpinion,ObjectTrainingOpinion")] FormModel formModel)
        {
            //TODO DONE : test if model's fields are set
            //if not, display an error message and stay on the form page
            //else, call ValidationForm with the datas set by the user
            if (formModel == null)
            {
                return View("Form");
            }

            if (!ModelState.IsValid)
            {
                if(formModel.LastName == null)
                {
                    ModelState.AddModelError("", "LastName is required");
                }

                if (formModel.FirstName == null)
                {
                    ModelState.AddModelError("", "FirstName is required");
                }

                if (formModel.Gender == 0)
                {
                    ModelState.AddModelError("", "Select an option for Gender");
                }

                if (formModel.Address == null || formModel.Address.Length < 5)
                {
                    ModelState.AddModelError("", "Address too short");
                }

                Regex zipCodeRegex = new Regex(@"^\d{5}$"); // ! regular expression already used in form desciption. might put it in a class for easier access 
                if (formModel.ZipCode == null || !zipCodeRegex.IsMatch(formModel.ZipCode))
                {
                    ModelState.AddModelError("", "ZipCode is not valid");
                }

                if (formModel.Town == null)
                {
                    ModelState.AddModelError("", "Town is required");
                }

                Regex emailAdressRegex = new Regex(@"^([\w]+)@([\w]+)\.([\w]+)$"); // ! regular expression already used in form desciption. might put it in a class for easier access 
                if (formModel.EmailAddress == null || !emailAdressRegex.IsMatch(formModel.EmailAddress))
                {
                    ModelState.AddModelError("", "EmailAddress is not valid");
                }

                DateTime refDate = new(2021, 1, 1); // might put it in a class for easier acces  
                if (formModel.TrainingStartDate.Date >= refDate)
                {
                    ModelState.AddModelError("", $"TrainingStartDate should be before {refDate.ToString("dd/MM/yyyy")}");
                }

                if (formModel.TrainingType == 0)
                {
                    ModelState.AddModelError("", "Select an option for TrainingType");
                }

                if (formModel.CobolTrainingOpinion == null)
                {
                    ModelState.AddModelError("", "CobolTrainingOpinion is required");
                }

                if (formModel.ObjectTrainingOpinion == null)
                {
                    ModelState.AddModelError("", "ObjectTrainingOpinion is required");
                }
                return View("Form", formModel);
            }

            

            return View("ValidationFormulaire", formModel);

        }
    }
}