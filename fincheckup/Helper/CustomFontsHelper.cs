using fincheckup.Models.Hvvn;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;

namespace fincheckup.Helper
{
    public static class CustomFontsHelper
    {
        static PrivateFontCollection fontCollection;
        public static FontCollection FontCollection
        {
            get
            {
                if (fontCollection == null)
                {
                    var FileDic = "wwwroot\\fonts\\Mulish-Regular.ttf";
                    string filePathZ = WebHelper.path;
                    string FilePath = System.IO.Path.Combine(filePathZ, FileDic);
                    fontCollection = new PrivateFontCollection();
                    fontCollection.AddFontFile(FilePath);
                }
                return fontCollection;
            }
        }

        public static FontFamily GetFamily(string familyName)
        {
            return FontCollection.Families.FirstOrDefault(ff => ff.Name == familyName);
        }
    }
}
