using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAD.ImmoWin.Business.Services
{
    public static class Enums
    {
        public static List<String> GetDescriptions<T>()
        {
            List<DescriptionAttribute> attributes =
                typeof(T)
                .GetMembers()
                .SelectMany(member => member.GetCustomAttributes(typeof(DescriptionAttribute), true).Cast<DescriptionAttribute>())
                .ToList();
            return attributes.Select(x => x.Description).ToList();
        }
    }
}
