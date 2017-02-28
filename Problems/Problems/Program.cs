using System;
using Trees;
using Trees.Lib;

namespace Problems
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Max consequence subsequence: {FindMaxConsquenceSequence()}");
        }

        private static int FindMaxConsquenceSequence()
        {
            /*
                         15
						/  \
					   2   11
					  / 
					 3
					  \
					   4
					  / \
					 5   6
					      \
						   9

             */

            TreeNode<int> fifteen = new TreeNode<int>(15);
            TreeNode<int> two = new TreeNode<int>(2);
            TreeNode<int> eleven = new TreeNode<int>(11);
            TreeNode<int> three = new TreeNode<int>(3);
            TreeNode<int> four = new TreeNode<int>(4);
            TreeNode<int> five = new TreeNode<int>(5);
            TreeNode<int> six = new TreeNode<int>(6);
            TreeNode<int> nine = new TreeNode<int>(9);

            fifteen.Left = two;
            fifteen.Right = eleven;
            two.Left = three;
            three.Right = four;
            four.Left = five;
            four.Right = six;
            six.Right = nine;

            return new MaximumConsequentSubsequence().Find(fifteen);
        }
    }
}

