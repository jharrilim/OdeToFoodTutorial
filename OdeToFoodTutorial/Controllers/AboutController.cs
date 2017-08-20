using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace OdeToFoodTutorial.Controllers
{

	[Route("company/[controller]/[action]")]
    public class AboutController
    {

		public string Phone()
		{
			return "123-456-7890";
		}

		public string Address()
		{
			return "1 Yonge Street";
		}
    }
}
