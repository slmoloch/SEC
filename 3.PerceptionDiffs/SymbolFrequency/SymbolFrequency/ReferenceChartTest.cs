using System.Collections.Generic;
using ApprovalTests;
using ApprovalTests.Reporters;
using NUnit.Framework;

namespace epam.sec.SymbolFrequency
{
    [TestFixture]
    [UseReporter(typeof(TortoiseImageDiffReporter), typeof(ClipboardReporter))]
    public class ReferenceChartTest
    {
        [Test]
        public void ShouldDisplayAxis()
        {
            Test(new Dictionary<char, double>());
        }

        [Test]
        public void ShouldDisplayBar()
        {
            var dictionary = new Dictionary<char, double> { { 'A', 0.5 } };

            Test(dictionary);
        }

        [Test]
        public void ShouldDisplayMultipleBars()
        {
            var frequences = new Dictionary<char, double>
            {
                {'A', 0.08167},
                {'C', 0.02782},
                {'B', 0.01492},
                {'D', 0.04253},
                {'E', 0.12702},
                {'F', 0.02288},
                {'G', 0.02015},
                {'H', 0.06094},
                {'I', 0.06966},
                {'J', 0.00153},
                {'K', 0.00772},
                {'L', 0.04025},
                {'M', 0.02406},
                {'N', 0.06749},
                {'O', 0.07507},
                {'P', 0.01929},
                {'Q', 0.00095},
                {'R', 0.05987},
                {'S', 0.06327},
                {'T', 0.09056},
                {'U', 0.02758},
                {'V', 0.00978},
                {'W', 0.02360},
                {'X', 0.00150},
                {'Y', 0.01974},
                {'Z', 0.00074}
            };

            Test(frequences);
        }

        private static void Test(Dictionary<char, double> data)
        {
            var image = Renderer.CreateImage(data, 2);

            Approvals.VerifyBinaryFile(image, "png");
        }
    }
}
