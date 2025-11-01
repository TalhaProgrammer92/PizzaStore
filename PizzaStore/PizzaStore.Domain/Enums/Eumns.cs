using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaStore.Domain.Enums
{
    public enum Size
    {
        Small = 0,
        Medium = 1,
        Large = 2,
        ExtraLarge = 3
    }

    public enum Role
    {
        Customer = 0,
        Admin = 1
    }

    public enum PaymentMethod
    {
        Cash = 0,
        CreditCard = 1,
        DebitCard = 2,
        JazzCash = 3,
        EasyPaisa = 4,
        UPaisa = 5
    }
}
