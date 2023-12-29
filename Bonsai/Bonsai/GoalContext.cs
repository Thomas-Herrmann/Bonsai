using Microsoft.EntityFrameworkCore;

namespace Bonsai
{
    internal class GoalContext : DbContext
    {
        public static string DatabaseName => "bonsai";
    }
}