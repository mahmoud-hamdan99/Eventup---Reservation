using System;
using System.Collections.Generic;
using System.Text;

namespace EventReservation.Core.DTO
{
  public class ExternalAuthDto
    {
        public string Provider { get; set; }
        public string IdToken { get; set; }
    }

}
