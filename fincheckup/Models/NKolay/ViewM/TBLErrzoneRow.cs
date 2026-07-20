using System;

namespace fincheckup.Models.NKolay.ViewM
{
    public class TBLErrzoneRow
    {
        public int ID { get; set; }

        public string  MainDescription { get; set; }

        public byte ColorDesc { get; set; } = 0;

        public string Description { get; set; } = "";

        public byte ColorDescTax { get; set; } = 0;

        public string DescriptionTax { get; set; } = "";

        public byte ColorDescInside { get; set; } = 0;

        public string DescriptionInside { get; set; } = "";

        public DateTime CreatedDate { get; set; }
    }
}
