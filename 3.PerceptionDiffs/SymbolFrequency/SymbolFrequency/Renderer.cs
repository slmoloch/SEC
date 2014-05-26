using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace epam.sec.SymbolFrequency
{
    static internal class Renderer
    {
        public static byte[] CreateImage(Dictionary<char, double> frequences, int step)
        {
            var arr = frequences.Select(f => string.Format("{0}\t{1}", f.Key, f.Value)).ToList();

            arr.Insert(0, "letter	frequency");

            File.WriteAllLines(@"../../data.tsv", arr);

            var fullPath = Path.Combine(Path.GetTempPath(), "test.png") ;

            var componentHtml = string.Format(@"component{0}.html", step);

            Run(@"C:\PhantomJs\phantomjs.exe", @"--local-to-remote-url-access=true C:\PhantomJs\examples\rasterize.js http://localhost:8080/" + componentHtml + " " + fullPath);

            return File.ReadAllBytes(fullPath);
        }

        private static void Run(string exe, string arguments)
        {
            var p = new Process
            {
                StartInfo =
                {
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = false,
                    FileName = exe,
                    Arguments = arguments
                }
            };

            p.Start();
            p.WaitForExit();
        }
    }
}