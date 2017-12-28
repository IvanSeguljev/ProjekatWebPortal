using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projekat.ViewModels
{
    public class OsiromaseniMaterijali
    {
        public int materijalId { get; set; }
        public string materijalNaslov { get; set; }
        public string materijalOpis{ get; set; }
        public string ImgPath
        {
            get
            {
                if (this.ekstenzija == ".pdf")
                    return "~/Content/img/PDFicon.png";
                else if (this.ekstenzija == ".rar")
                    return "~/Content/img/RARicon.png";
                else if (this.ekstenzija == ".txt")
                    return "~/Content/img/TXTicon.png";
                else if (this.ekstenzija == ".jpg")
                    return "~/Content/img/JPGicon.png";
                else if (this.ekstenzija == ".gif")
                    return "~/Content/img/GIFicon.png";
                else if (this.ekstenzija == ".png")
                    return "~/Content/img/PNGicon.png";
                else if (this.ekstenzija == ".zip")
                    return "~/Content/img/ZIPicon.png";
                else if (this.ekstenzija == ".rtf")
                    return "~/Content/img/RTFicon.png";
                else if (this.ekstenzija == ".mp4")
                    return "~/Content/img/MP4icon.png";

                else return "Err";
            }
        }
        public string ekstenzija { get; set; }
        public int tipMaterijalaId { get; set; }

        public int predmetId { get; set; }

    }
}