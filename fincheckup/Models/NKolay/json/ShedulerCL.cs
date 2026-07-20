using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace fincheckup.Models.NKolay.json
{
    public class ShedulerMain : BaseModel
    {
        public static IEnumerable<AdaptabilityAppointment> Get_Data(int _year)
        {
            return StaticQuery<AdaptabilityAppointment>("SELECT *  FROM    [dbo].[Appointment] where  YEAR([EndDate])=@nyear", new { nyear = _year });
        }
    }
    public class ShedulerCLList
    {
        public IEnumerable<PriorityResource> PriorityResources { get; set; }
        public IEnumerable<AdaptabilityAppointment> AdaptabilityAppointments { get; set; }
    }
    public class ShedulerCL
    {
        public static readonly IEnumerable<PriorityResource> PriorityResources = new[] {
            new PriorityResource {
                Id = 1,
                Text = "Yüksek",
                Color = "#cc5c53"
            },
            new PriorityResource {
                Id = 2,
                Text = "Normal",
                Color = "#ff9747"
            }
        };


    }
    public class Appointment
    {
        [JsonProperty(PropertyName = "AppointmentId")]
        public int AppointmentId { get; set; }
        [JsonProperty(PropertyName = "Text")]
        public string Text { get; set; }
        [JsonProperty(PropertyName = "Description")]
        public string Description { get; set; }
        [JsonProperty(PropertyName = "StartDate")]
        public DateTime StartDate { get; set; }
        [JsonProperty(PropertyName = "EndDate")]
        public DateTime EndDate { get; set; }
        [JsonProperty(PropertyName = "AllDay")]
        public bool AllDay { get; set; }

        [JsonProperty(PropertyName = "PriorityId")]
        public int PriorityId { get; set; }

        [JsonProperty(PropertyName = "Status")]
        public byte Status { get; set; }

    }
    public class AdaptabilityAppointment : Appointment
    {

    }
    public class AdaptabilityAppointmentsResource
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Color { get; set; }
    }
    public class PriorityResource
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Color { get; set; }
    }
}
