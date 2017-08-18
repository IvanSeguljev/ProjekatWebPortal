using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.IO;

namespace Projekat.Models
{
    public class MaterijalSharingInitializer : DropCreateDatabaseAlways<MaterijalContext>
    {
        protected override void Seed(MaterijalContext context)
        {
            base.Seed(context);
        }


        private byte[] procitajBajtove(string path)
        {
            FileStream fajlNaDisku = new FileStream(HttpRuntime.AppDomainAppPath + path, FileMode.Open);
            byte[] bajtoviFajla;
            using (BinaryReader br = new BinaryReader(fajlNaDisku))
            {
                bajtoviFajla = br.ReadBytes((int)fajlNaDisku.Length);
            }
            return bajtoviFajla;
        }
    }
}