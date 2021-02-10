using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace el.localiza.reservas.mvc.netcore.Shared.Enums
{
    public enum CategoriaEnum
    {
        [Description("Básico")]
        Basico = 0,

        [Description("Completo")]
        Completo = 1,

        [Description("Luxo")]
        Luxo = 2
    }

    public static class DescricaoCategoria
    {
        public static string ToDescriptionString(this CategoriaEnum val)
        {
            DescriptionAttribute[] attributes = (DescriptionAttribute[])val
               .GetType()
               .GetField(val.ToString())
               .GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : string.Empty;
        }
    }
}
