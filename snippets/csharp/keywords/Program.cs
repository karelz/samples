﻿using System;

namespace keywords
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=================    Stack Alloc Examples ======================");
            StackAllocExamples.Examples();
            Console.WriteLine("=================    Generic Where Constraints Examples ======================");
            GenericWhereConstraints.Examples();
            Console.WriteLine("=================    Fixed Memory Examples ======================");
            FixedKeywordExamples.Examples();
        }
    }
}
