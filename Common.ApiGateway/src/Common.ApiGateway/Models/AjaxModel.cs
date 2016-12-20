using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.ApiGateway.Models
{
    public class AjaxModel<T>
    {
        public AjaxResult Result { get; set; }

        public string Message { get; set; }

        public T Data { get; set; }

        public bool IsAjaxModel
        {
            get
            {
                return true;
            }
        } // used to check in angular interceptor
    }
}
