using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaStore.Domain.ValueObjects
{
    public class AppSession
    {
        public static string? JwtToken { get; set; }
    }
}
