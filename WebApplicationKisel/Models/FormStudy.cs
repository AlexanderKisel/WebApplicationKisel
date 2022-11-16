using System.ComponentModel;

namespace WebApplicationKisel.Models
{
    public enum FormStudy
    {
        [Description("Очная")]
        Och,
        [Description("Заочная")]
        Zaoch,
        [Description("Очно-заочная")]
        Och_Zaoch,
    }
}
