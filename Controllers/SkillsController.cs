using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace SkillsTracker.Controllers
{
    public class SkillsController : Controller
    {
        [HttpGet]
        [Route("/skills")]
        public IActionResult Index() {
            string html = "<h1>Skills Tracker</h1>" +
                "<h2>Coding Skills to Learn:</h2>" +
                "<ol>" +
                    "<li>JavaScript</li>" +
                    "<li>Python</li>" +
                    "<li>C#</li></ol>";
            return Content(html, "text/html");
        }

        [HttpGet]
        [Route("/skills/form")]
        public IActionResult Tracker()
        {
            string options = "<option value='Learning Basics'>Learning Basics</option>" +
                             "<option value='Making Apps'>Making Apps</option>" +
                             "<option value='Master Coder'>Master Coder</option>";

            // Python label is not appearing & python options are not showing up as options
            //Submit button is not on own line
            string progress = "<form method='post' action='/skills/form/'>" +
                
                                    "<label for='currentDate'>Date:</label><br>" +
                                    "<input type='date' id='currentDate'  name='currentDate' value='2020-11-05'><br>" +
                
                                    "<label for='javascript'>JavaScript:</label><br>" +
                                    "<select id='javascript' name='javascript'>" + options + "</select><br>" +
                
                                    "<label for='python'>Python:</label><br>" +
                                    "<select id='python' name='python'>" + options + "</select><br>" +
                
                                    "<label for='c'>C#:</label><br>" +
                                    "<select id='c' name='c'>" + options + "</select><br>" +
                
                                    "<input type='submit' value='Submit'/>" +
                            "</form>";

            return Content(progress, "text/html");

        }

       [HttpPost]
       [Route("/skills/form")]
        //update Date to <h1> and add list of subitted values
        public IActionResult Progress(string python, string c, string javascript, string currentDate)
        {
            string results = $"<h1>{currentDate}</h1><br><br>" +
                $"<ol>" +
                $"<li>Javascript: {javascript}</li>" +
                $"<li>Python: {python}</li>" +
                $"<li>C#: {c}</li>" +
                $"</ol>";
            return Content(results, "text/html");
        }
    }
}
