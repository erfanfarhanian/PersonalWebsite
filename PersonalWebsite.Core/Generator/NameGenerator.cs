using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalWebsite.Core.Generator
{
    class NameGenerator
    {
        public static string GenerateUniqCode()
        {
            return Guid.NewGuid().ToString().Replace("-", "");
        }
    }
}
