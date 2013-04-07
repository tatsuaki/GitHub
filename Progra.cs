using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Console_185
{
    class Programs
    {
        static void Main(string[] args)
        {
            string s1 = "abcDEF123zzz   \tzzz";
            Regex rex1 = new Regex("z.*z");

            Console.WriteLine("置換結果:" + rex1.Replace(s1, "zz"));

            string s2 = "20:12:20";

            Regex time = new Regex("(?<hour>\\d{2}):(?<minute>\\d{2}):(?<second>\\d{2})");

            string timeReplacePattern = "${hour} 時 ${minute} 分 ${second} 秒";
            string m2 = time.Replace(s2, timeReplacePattern);
            Console.WriteLine("グループによる置換結果:" + m2);

            string s3 = "Doi Tsuyoshi <DoiDoi@Sample.COM>";
            Regex email = new Regex("(?<account>[a-zA-Z0-9]*)@(?<domain>[a-zA-Z0-9.]+\\.[a-zA-Z0-9]+)");

            string m3 = email.Replace(s3, new MatchEvaluator(MailToLower));
            Console.WriteLine("MatchEvalauatorによる置換結果:" + m3);
        }

        static string MailToLower(Match m)
        {
            return m.Value.ToLower();
        }
    }
}
