using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Komis.Models
{
    public class Meeting
    {
        public int MeetingId { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
        public string ClientData { get; set; }
        public DateTime DateOfMeeting { get; set; }
        public bool IsArchived { get; set; }
    }
}
