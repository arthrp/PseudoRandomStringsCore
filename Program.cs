using System;
using System.Collections.Generic;
using CommandLine;

namespace PseudoRandomStringsCore
{
    class Program
    {
        private const int CODE_ERR = 1;
        private const int OK = 0;

        static void Main(string[] args)
        {
            var opts = Parser.Default.ParseArguments<StringOptions, EmailOptions, NameOptions>(args)
            	.MapResult(
                (StringOptions op) => HandleStringOptions(op),
                (EmailOptions op) => HandleEmailOptions(op),
                (NameOptions op) => HandleNameOptions(op),
                errs => CODE_ERR);


            Console.WriteLine("Finished");
        }

        static int HandleStringOptions(StringOptions opts)
        {
            var str = new RandomHelper().GenerateWeakAlphanumericString(opts.Length);
            Console.WriteLine(str);
            return OK;
        }

        static int HandleEmailOptions(EmailOptions opts)
        {
            if(opts.TotalLength < 6)
                throw new ArgumentException("Email length must be at least 6 characters");

            var email = new RandomHelper().GenerateEmail(opts.TotalLength);
            Console.WriteLine(email);
            return OK;
        }

        static int HandleNameOptions(NameOptions opts)
        {
            var name = new RandomHelper().GetRandomName(opts.NameType);
            Console.WriteLine(name);
            return OK;
        }
    }
}
