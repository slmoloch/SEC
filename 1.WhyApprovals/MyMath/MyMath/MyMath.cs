namespace MyMath
{
    public class MyMath
    {
        public static int Add(int a, int b)
        {
            return a + b;
        }

        public static string Explain(int a, int b)
        {
            return string.Format(@"If you have {0} apples and I have {1} apples, " +
                "how many apples do we have together? " + 
                "Together we have {2} apples. " + 
                "In math, this is expressed as {0}+{1}={2}", a, b, Add(a,b));
        }
    }
}
