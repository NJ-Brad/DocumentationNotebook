using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DocumentationNotebook
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // https://www.google.com/maps

            //string absUrl = ConvertToAbsoluteUrl("https://www.google.com", "maps");
            //string absUrl = ConvertToAbsoluteUrl("https://www.google.com", "/maps");

            string absUrl = ConvertToAbsoluteUrl(@"S:\Source\MarkDownEditorControl\MarkDownEditorControl\bin\Debug", @"..\..\Controls");

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new NotebookForm());
        }

        // https://stackoverflow.com/questions/3681052/get-absolute-url-from-relative-path-refactored-method
        public static string ConvertToAbsoluteUrl(string baseUrl, string relativeUrl)
        {
            if (!IsAbsoluteUrl(relativeUrl))
            {
                // https://docs.microsoft.com/en-us/dotnet/api/system.uri.-ctor?view=net-5.0
                return new System.Uri(new Uri(baseUrl), relativeUrl).AbsoluteUri;
            }
            else
                return relativeUrl;
        }

        private static bool IsAbsoluteUrl(string url)
        {
            Uri result;
            return Uri.TryCreate(url, UriKind.Absolute, out result);
        }
    }
}
