using WebApplication1.Models;

namespace WebApplication1.Extension
{
    public static class PriorityExtension
    {
        static readonly Dictionary<Priority, string> _priorityCssClasses = new()
        {
            [Priority.High] = "badge bg-danger",
            [Priority.Medium] = "badge bg-warning",
            [Priority.Low] = "badge bg-success",

        };
        public static string ToCssClass (this Priority priority) => _priorityCssClasses[priority];
    }
}
