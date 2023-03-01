using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public class Enums
    {
        public enum FieldStatus
        {
            Empty = 0,
            Booked,
            InActive,
            Active
        }

        public enum FieldSlot
        {
            [Description("6-8H")] H6_8 = 1,
            [Description("8-10H")] H8_10 = 2,
            [Description("10-12H")] H10_12 = 3,
            [Description("12-14H")] H12_14 = 4,
            [Description("14-16H")] H14_16 = 5,
            [Description("16-18H")] H16_18 = 6,
            [Description("18-20H")] H18_20 = 7,
        }
    }
}