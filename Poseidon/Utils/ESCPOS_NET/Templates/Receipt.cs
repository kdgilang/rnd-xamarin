using ESCPOS_NET.Emitters;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ESCPOS_NET.Templates
{
    public static partial class Receipt
    {
        private static ICommandEmitter e = new EPSON();

        //private static string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

        //private static string folder = Path.Combine(path, "images");

        //private static string file = Path.Combine(folder, "relix-logo.png");



        private static byte[] ImageDataFromResourceAsync(string r)
        {

            Assembly a = Assembly.GetExecutingAssembly();

            using (Stream resFilestream = a.GetManifestResourceStream(r))
            {
                if (resFilestream == null) return null;
                byte[] buffer = new byte[resFilestream.Length];
                resFilestream.Read(buffer, 0, buffer.Length);
                return buffer;
            }
        }

        public static byte[][] Template() => new byte[][]
        {
            e.CenterAlign(),
            e.PrintLine(),
            //e.PrintImage(ImageDataFromResourceAsync("Poseidon.Images.pd_logo.bmp"), false),
            e.PrintLine(),
            e.SetBarcodeHeightInDots(360),
            e.SetBarWidth(BarWidth.Default),
            e.SetBarLabelPosition(BarLabelPrintPosition.None),
            e.CenterAlign(),
            e.Print2DCode(TwoDimensionCodeType.QRCODE_MODEL2, "0123456789"),
            e.CenterAlign(),
            e.PrintLine(),
            e.PrintLine("RELIX NUSANTARA"),
            e.PrintLine("JL Taman Pancing Gg Boncos No 69"),
            e.PrintLine("Denpasar, Bali, Indonesia"),
            e.PrintLine("081 111 222 444"),
            e.SetStyles(PrintStyle.Underline),
            e.PrintLine("www.github.com/kdgilang"),
            e.SetStyles(PrintStyle.None),
            e.PrintLine(),
            e.LeftAlign(),
            e.PrintLine("Order: 123456789        Date: 02/01/19"),
            e.PrintLine(),
            e.PrintLine(),
            e.SetStyles(PrintStyle.FontB),
            e.PrintLine("1   TRITON LOW-NOISE IN-LINE MICROPHONE PREAMP"),
            e.PrintLine("    TRFETHEAD/FETHEAD                        89.95         89.95"),
            e.PrintLine("----------------------------------------------------------------"),
            e.RightAlign(),
            e.PrintLine("SUBTOTAL         89.95"),
            e.PrintLine("Total Order:         89.95"),
            e.PrintLine("Total Payment:         89.95"),
            e.PrintLine(),
            e.LeftAlign(),
            e.SetStyles(PrintStyle.Bold | PrintStyle.FontB),
            e.PrintLine("SOLD TO:                        SHIP TO:"),
            e.SetStyles(PrintStyle.FontB),
            e.PrintLine("  LUKE PAIREEPINART               LUKE PAIREEPINART"),
            e.PrintLine("  123 FAKE ST.                    123 FAKE ST."),
            e.PrintLine("  DECATUR, IL 12345               DECATUR, IL 12345"),
            e.PrintLine("  (123)456-7890                   (123)456-7890"),
            e.PrintLine("  CUST: 87654321"),
            e.PrintLine(),
            e.PrintLine()
        };
    }
}
