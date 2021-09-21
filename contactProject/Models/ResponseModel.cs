using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactProject.Models
{
    public class ResponseModel
    {
        public ContactModel Contact { get; set; }
        public List<ErrorsModel> Errors { get; set; }
    }

    public class ErrorsModel
    {
        public string Field { get; set; }
        public string Code { get; set; }
        public string Message { get; set; }
    }
}
