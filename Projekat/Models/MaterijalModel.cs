using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.ComponentModel;
using System.Web.Mvc;

namespace Projekat.Models
{
    public class MaterijalModel
    {
        [Key]
        public int materijalId { get; set; }

        [DisplayName("Materijal")]
        [MaxLength]
        public byte[] materijalFile { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string fileMimeType { get; set; }

        //[DataType(DataType.MultilineText)]
        public string materijalOpis { get; set; }

        //[DataType(DataType.DateTime)]
        //[DisplayName("Created Date")]
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yy}", ApplyFormatInEditMode = true)]
        //public DateTime CreatedDate { get; set; }


        //public string UserName { get; set; }
     //   public PredmetModel Predmet { get; set; }

      //  public int predmetId { get; set; }


        public string materijalEkstenzija { get; set; }

        public string materijalNaziv { get; set; }

        public string ImgPath
        {
            get
            {
                if (this.materijalEkstenzija == ".pdf")
                    return "~/Content/img/PDFicon.png";
                else if (this.materijalEkstenzija == ".rar")
                    return "~/Content/img/RARicon.png";
                else if (this.materijalEkstenzija == ".txt")
                    return "~/Content/img/TXTicon.png";
                else if (this.materijalEkstenzija == ".jpg")
                    return "~/Content/img/JPGicon.png";
                else if (this.materijalEkstenzija == ".gif")
                    return "~/Content/img/GIF2icon.png";
                else if (this.materijalEkstenzija == ".png")
                    return "~/Content/img/PNGicon.png";
                else if (this.materijalEkstenzija == ".zip")
                    return "~/Content/img/ZIPicon.png";
                else if (this.materijalEkstenzija == ".rtf")
                    return "~/Content/img/RTFicon.png";
                else if (this.materijalEkstenzija == ".mp4")
                    return "~/Content/img/MP4icon.png";

                else return "Err";
            }
        }

        public PredmetModel PredmetModel { get; set; }

       [ForeignKey("PredmetModel")]
        public int predmetId { get; set; }

        public TipMaterijalModel TipMaterijalModel { get; set; }


        [ForeignKey("TipMaterijalModel")]
        public int tipMaterijalId { get; set; }

    }
}