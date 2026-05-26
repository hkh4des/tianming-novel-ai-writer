using System.Text.RegularExpressions;

namespace TM.Services.Modules.ProjectData.Implementations.Generation
{
    internal static partial class HumanizeRules
    {

        private static readonly Regex EllipsisRegex = new(
            @"\.{3,}|\u2026+|\u3002{3,}|\u22ef+",
            RegexOptions.Compiled);

        public static string NormalizeEllipsis(string text)
        {
            if (string.IsNullOrEmpty(text)) return text;
            return EllipsisRegex.Replace(text, "\u2026");
        }

        private static readonly Regex DashRegex = new(
            @"-{2,}|[\u2010\u2011\u2012\u2013\u2014\u2015\u2212\ufe58\ufe63\uff0d]+",
            RegexOptions.Compiled);

        public static string NormalizeDash(string text)
        {
            if (string.IsNullOrEmpty(text)) return text;
            return DashRegex.Replace(text, "------");
        }
    }
}
