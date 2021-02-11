using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace el.localiza.reservas.mvc.netcore.Shared.Enums
{
    public enum CombustivelEnum
    {
        [Description("Gasolina")]
        Gasolina = 0,

        [Description("Etanol")]
        Etanol = 1,

        [Description("Diesel")]
        Diesel = 2,

        [Description("GNV")]
        GNV = 3,

        [Description("Flex")]
        Flex = 4
    }

    public static class DescricaoCombustivel
    {
        public static string ToDescriptionString(this CombustivelEnum val)
        {
            DescriptionAttribute[] attributes = (DescriptionAttribute[])val
               .GetType()
               .GetField(val.ToString())
               .GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : string.Empty;
        }
    }
}
