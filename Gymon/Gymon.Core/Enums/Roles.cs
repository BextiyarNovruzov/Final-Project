using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymon.Core.Enums
{
    public enum Roles
    {
        Publisher = 1,
        User = 2,
        Editor = 4,
        Banner = 8,
        Moderator = 16,

        Admin = Publisher | User | Editor | Banner | Moderator
    }
}
