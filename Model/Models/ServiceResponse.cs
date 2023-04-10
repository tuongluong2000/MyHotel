using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class ServiceResponse
    {
        public bool IsSuccess { get; set; } = true;
        public object Data { get; set; }
    }
}
