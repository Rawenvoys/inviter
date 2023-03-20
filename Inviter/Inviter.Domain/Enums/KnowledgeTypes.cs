using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inviter.Domain.Enums
{
    [Flags]
    public enum KnowledgeTypes 
    {
        None = 0,
        AnaFamily = 1,
        LucasFamily = 2,
        AnaFriend = 4,
        LucasFriend = 8,

        BothFriend = AnaFriend | LucasFriend,
        Ana = AnaFamily | AnaFriend,
        Lucas = LucasFamily | LucasFriend
    }
}
