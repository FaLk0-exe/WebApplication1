using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharm.DAL
{
    public static class StatusHelper
    {
        public static string GetTitle(long id)
        {
            return id switch
            {
                1 => "Очікує обробки",
                2 => "Підтверджено",
                3 => "Відхилено",
                _ => ""
            };
        }
    }
}
