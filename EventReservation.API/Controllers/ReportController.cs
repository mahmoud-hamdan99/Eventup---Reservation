using Dapper;
using EventReservation.Core.Data;
using EventReservation.Core.DTO;
using EventReservation.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PdfSharpCore;
using PdfSharpCore.Pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TheArtOfDev.HtmlRenderer.PdfSharp;

namespace EventReservation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {


        private readonly IReportService _reportService;
        private readonly IUserService _userService;
        
        public ReportController(IReportService reportService, IUserService userService)
        {
            _reportService = reportService;
            _userService = userService;
        }


        [HttpGet("GeneratePDF")]
      public IActionResult GeneratePDF([FromHeader]ReportIntervalDTO reportInterval)
        {
         
            var document = new PdfDocument();

            IEnumerable<EventInfoDTO> result = _reportService.EventAcceptedInterval(reportInterval);
            if (result.Count()!= 0)
            {


                string htmlstring = " <h1 style='color:#04AA6D;text-shadow: 3px 3px 2px gray;display:inline;'> EventReservation Report </h1> <img style='float:right;width:50px;height:50px;box-shadow:3px 7px 5px #dddd;' src='https://res.cloudinary.com/dczqrvtip/image/upload/v1650658376/Logo_2_rlkfzy.png‏'><br><br>";



                htmlstring += "<br><br>The Event Information Between " + "<strong>" + reportInterval.startDate + "</strong>" + "  And "
                   + "<strong>" + reportInterval.endDate + "</strong>" + "    :   <br><br>" +
                   "";

                htmlstring += "<table style='width:100%;padding: 4px;font-size:0.50vw; border-collapse: collapse;'> <thead> <tr> ";

                htmlstring += "<th style='width:12%;  border: 1px solid #04AA6D;padding: 8px; background-color: #04AA6D;color:white;'>Event  Type</th>";
                htmlstring += "<th style='width:12%;  border: 1px solid #04AA6D;padding: 8px; background-color: #04AA6D;color:white;'>Start Date</th>";
                htmlstring += "<th style='width:12%;  border: 1px solid #04AA6D;padding: 8px; background-color: #04AA6D;color:white;'>End Date</th>";
                htmlstring += "<th style='width:12%;  border: 1px solid #04AA6D;padding: 8px; background-color: #04AA6D;color:white;'>Status</th>";
                htmlstring += "<th style='width:12%;  border: 1px solid #04AA6D;padding: 8px; background-color: #04AA6D;color:white;'>Name Of Hall</th>";
                htmlstring += "<th style='width:12%;  border: 1px solid #04AA6D;padding: 8px; background-color: #04AA6D;color:white;'>Use Of Hall</th>";
                htmlstring += "<th style='width:12%;  border: 1px solid #04AA6D;padding: 8px; background-color: #04AA6D;color:white;'>Reservation Price</th>";
                htmlstring += "<th style='width:12%;  border: 1px solid #04AA6D;padding: 8px; background-color: #04AA6D;color:white;'>Number of Person</th>";



                htmlstring += "</tr></thead>  <tbody>";
                dynamic sumprice = 0;
                dynamic acceptinterval = 0;
                dynamic pendinginterval = 0;

                foreach (EventInfoDTO obj in result)
                {

                    if (obj.status == "Accepted")
                    {
                        sumprice += obj.totalprice;
                        acceptinterval++;
                    }
                    if (obj.status == "Pending")
                    {
                        pendinginterval++;
                    }

                    htmlstring += "<tr><td style = 'width:12%;padding: 8px;text-align:left;border:1px solid #dddd;'> " + obj.eventtype + " </td> ";

                    htmlstring += "<td style = 'width:12%;padding: 8px;text-align:left;border:1px solid #dddd;'> " + obj.Startdate + " </td> ";
                    htmlstring += "<td style = 'width:12%;padding: 8px;text-align:left;border:1px solid #dddd;'> " + obj.Enddate + " </td> ";
                    htmlstring += "<td style = 'width:12%;padding: 8px;text-align:left;border:1px solid #dddd;'> " + obj.status + " </td> ";
                    htmlstring += "<td style = 'width:12%;padding: 8px;text-align:left;border:1px solid #dddd;'> " + obj.name + " </td> ";
                    htmlstring += "<td style = 'width:12%;padding: 8px;text-align:left;border:1px solid #dddd;'> " + obj.usage + " </td> ";
                    htmlstring += "<td style = 'width:12%;padding: 8px;text-align:left;border:1px solid #dddd;'> " + obj.totalprice + " </td> ";
                    htmlstring += "<td style = 'width:12%;padding: 8px;text-align:left;border:1px solid #dddd;'> " + obj.NoPerson + " </td></tr> ";

                }

                htmlstring += "</tbody></table><br><br>";
                htmlstring += "The Accept Event In Interval Dates :  " + acceptinterval + "<br><br>" +
                    "And The Pending Event In  Interval Dates  Is  : " + pendinginterval + "<br><br>" +
                    "The Total Reservation Price In Interval Dates :    " + sumprice;
                PdfGenerator.AddPdfPages(document, htmlstring, PageSize.A4);

                Byte[] res = null;
                using (MemoryStream ms = new MemoryStream())
                {
                    document.Save(ms);
                    res = ms.ToArray();
                }

                return File(res, "application/pdf");
            }
            return NoContent();
        }
    




    [HttpGet("GenerateUserReport")]
    public IActionResult GenerateUserReport()
    {
        var document = new PdfDocument();
            dynamic cntuser = 0;
            var allUser = _userService.GetAllUsers().Result;
            var user = from data in allUser
                       where data.Position == "NormalUser"
                       select new UsertoResultDto
                       {
                           Userid = data.Userid,
                           Firstname = data.Firstname,
                           Lastname = data.Lastname,

                           Email = data.Email,
                           Birthdate = data.Birthdate,
                           Position = data.Position,
                          

                       };



          string htmlstring = " <h1 style='color:#04AA6D;text-shadow: 3px 3px 2px gray;display:inline;'> EventUp Reservation Report </h1> <img style='float:right;width:50px;height:50px;box-shadow:3px 7px 5px #dddd;' src='https://res.cloudinary.com/dczqrvtip/image/upload/v1650658376/Logo_2_rlkfzy.png‏'><br><br>";
            htmlstring += "<h3>All Users Signed In Event Up Website</h3>";
            
         htmlstring += "<table style='width:100%;padding: 4px; border-collapse: collapse;'> <thead> <tr> ";

        htmlstring += "<th style='width:20%;  border: 1px solid #04AA6D;padding: 8px; background-color: #04AA6D;color:white;'>FirstName</th>";
        htmlstring += "<th style='width:20%;  border: 1px solid #04AA6D;padding: 8px; background-color: #04AA6D;color:white;'>Last Name</th>";
            htmlstring += "<th style='width:20%;  border: 1px solid #04AA6D;padding: 8px; background-color: #04AA6D;color:white;'>Birth Date</th>";

            htmlstring += "<th style='width:20%;  border: 1px solid #04AA6D;padding: 8px; background-color: #04AA6D;color:white;'>Email</th>";
        htmlstring += "<th style='width:20%;  border: 1px solid #04AA6D;padding: 8px; background-color: #04AA6D;color:white;'>Position</th>";
     
        htmlstring += "</tr></thead>  <tbody>";
       
        foreach (UsertoResultDto obj in user)
        {


            htmlstring += "<tr><td style = 'width:20%;padding: 8px;text-align:left;border:1px solid #dddd;'> " + obj.Firstname + " </td> ";

            htmlstring += "<td style = 'width:20%;padding: 8px;text-align:left;border:1px solid #dddd;'> " + obj.Lastname + " </td> ";
            htmlstring += "<td style = 'width:20%;padding: 8px;text-align:left;border:1px solid #dddd;'> " + obj.Birthdate + " </td> ";
                htmlstring += "<td style = 'width:20%;padding: 8px;text-align:left;border:1px solid #dddd;'> " + obj.Email + " </td> ";

            htmlstring += "<td style = 'width:20%;padding: 8px;text-align:left;border:1px solid #dddd;'> " + obj.Position + " </td> ";
            htmlstring += "<td style = 'width:20%;padding: 8px;text-align:left;border:1px solid #dddd;'> " + obj.Username + " </td> "

            + " </tr>";




        }

        htmlstring += "</tbody></table><br><br>";

            htmlstring += "<h4>The Number of user  : " + user.Count() + "</h4>";



            PdfGenerator.AddPdfPages(document, htmlstring, PageSize.A4);

        Byte[] res = null;
        using (MemoryStream ms = new MemoryStream())
        {
            document.Save(ms);
            res = ms.ToArray();
        }

        return File(res, "application/pdf");
    }
}
}
