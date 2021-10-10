using System.Collections;

namespace Enumerator
{
    /// <summary>
    /// EnumerableとEnumerator
    /// </summary>
    public class EnumerableEnumerator
    {
        public static string PrintEnumerator(IEnumerator enumerator)
        {
            string res = "";

            while (enumerator.MoveNext())
            {
                res += enumerator.Current.ToString();
            }

            //enumerator.Reset();

            return res;
        }

        public static string PrintEnumerable(IEnumerable enumerable)
        {
            string res = "";

            foreach (var value in enumerable)
            {
                res += value.ToString();
            }

            return res;
        }
    }
}
