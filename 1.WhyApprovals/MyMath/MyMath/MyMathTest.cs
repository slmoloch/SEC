using ApprovalTests;
using ApprovalTests.Reporters;
using NUnit.Framework;

namespace MyMath
{
    [TestFixture]
    [UseReporter(typeof(DiffReporter))]
    class MyMathTest
    {
        [Test]
        public void ShouldAddTwoNumbers()
        {
            Assert.That(MyMath.Add(2, 3), Is.EqualTo(5));
        }

        [Test]
        public void ShouldExplain()
        {
            var explain = MyMath.Explain(4, 5);

            Approvals.Verify(explain);
        }
    }
}