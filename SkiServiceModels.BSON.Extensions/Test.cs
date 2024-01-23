using SkiServiceModels.BSON.DTOs.Requests;
using SkiServiceModels.BSON.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiServiceModels.BSON.Extensions
{
    internal class Test
    {
        public Test()
        {
            var state = new UpdateStateRequest()
            {
                Name = "Test"
            };
        }
    }
}
