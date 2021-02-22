using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Premier.Controllers
{
    [Microsoft.AspNetCore.Components.Route("api/[controller]")]

    public class ValuesControler : Controller
    {
        public string[] Get()
        {
            return new[] {"Hello  it's time"};
        }
    }
}
