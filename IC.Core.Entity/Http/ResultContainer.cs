using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace IC.Core.Entity.Http
{
    public class ResultContainer : ObjectResult
    {
        public ResultContainer(object value) : base(value)
        {
            StatusCode = (int)HttpStatusCode.InternalServerError;
        }

        public ResultContainer(object value, HttpStatusCode statusCode):base(value)
        {
            StatusCode = (int)statusCode;
        }
    }
}
