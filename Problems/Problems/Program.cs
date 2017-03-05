using System;
using System.Collections.Generic;
using ArraysAndStrings;
using Graphs;
using Trees;
using Trees.Lib;

namespace Problems
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"\n\nMax consequence subsequence: {FindMaxConsquenceSequence()}");

            Console.WriteLine("\n\nBoundary nodes:");
            GetBoundaryNodes().ForEach(Console.WriteLine);

            Console.WriteLine($"\n\nIslands in matrix: {FindIslands()}");
            Console.WriteLine($"\n\nLeast common ancestor: {Lca()}");

            var k = 5;
            Console.WriteLine($"\n\nFind all elements summing upto {k}:");
            FindAllPathsOfSumK(k).ForEach(l =>
            {
                Console.WriteLine();
                l.ForEach(x => Console.Write("\t" + x));
            });

            var inputString = "xyzddd";
            Console.WriteLine($"\n\nLongest palindromic substring for {inputString} is {new LongestPalidromicSubstring().Find(inputString)}");
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

        private static List<int> GetBoundaryNodes()
        {
            /*
                                          3
										 / \
										9   7
									   / \ /
									  2  1 8
									 /  / \ \
									13 4   0 6
									      / \
										 18 20

             */

            TreeNode<int> three = new TreeNode<int>(3);
            TreeNode<int> nine = new TreeNode<int>(9);
            TreeNode<int> seven = new TreeNode<int>(7);
            TreeNode<int> two = new TreeNode<int>(2);
            TreeNode<int> one = new TreeNode<int>(1);
            TreeNode<int> eight = new TreeNode<int>(8);
            TreeNode<int> thirteen = new TreeNode<int>(13);
            TreeNode<int> four = new TreeNode<int>(4);
            TreeNode<int> zero = new TreeNode<int>(0);
            TreeNode<int> six = new TreeNode<int>(6);
            TreeNode<int> eighteen = new TreeNode<int>(18);
            TreeNode<int> twenty = new TreeNode<int>(20);

            three.Left = nine;
            three.Right = seven;
            nine.Left = two;
            nine.Right = one;
            seven.Left = eight;
            two.Left = thirteen;
            one.Left = four;
            one.Right = zero;
            eight.Right = six;
            zero.Left = eighteen;
            zero.Right = twenty;

            return new GetBoundaryNodes().Get(three);
        }

        private static int FindIslands()
        {
            var matrix = new int[,]
            {
                {1, 1, 1, 1},
                {0, 1, 0, 0},
                {0, 0, 0, 0},
                {0, 0, 0, 1}
            };

            return new IslandsInMatrix().Find(matrix, 4, 4);
        }

        private static int Lca()
        {
            /*

                                          3
										 / \
										9   7
									   / \ /
									  2  1 8
									 /  / \ \
									13 4   0 6
									      / \
										 18 20

             */

            TreeNode<int> three = new TreeNode<int>(3);
            TreeNode<int> nine = new TreeNode<int>(9);
            TreeNode<int> seven = new TreeNode<int>(7);
            TreeNode<int> two = new TreeNode<int>(2);
            TreeNode<int> one = new TreeNode<int>(1);
            TreeNode<int> eight = new TreeNode<int>(8);
            TreeNode<int> thirteen = new TreeNode<int>(13);
            TreeNode<int> four = new TreeNode<int>(4);
            TreeNode<int> zero = new TreeNode<int>(0);
            TreeNode<int> six = new TreeNode<int>(6);
            TreeNode<int> eighteen = new TreeNode<int>(18);
            TreeNode<int> twenty = new TreeNode<int>(20);

            three.Left = nine;
            three.Right = seven;
            nine.Left = two;
            nine.Right = one;
            seven.Left = eight;
            two.Left = thirteen;
            one.Left = four;
            one.Right = zero;
            eight.Right = six;
            zero.Left = eighteen;
            zero.Right = twenty;

            return new LeastCommonAncestor().Find(three, 13, 4).Data;
        }

        private static List<List<int>> FindAllPathsOfSumK(int k)
        {
            /*
                                   1
                                /     \
                              3        -1
                            /   \     /   \
                           2     1   4     5                        
                                /   / \     \                    
                               1   1   2     6    
             */


            TreeNode<int> oneOne = new TreeNode<int>(1);
            TreeNode<int> three = new TreeNode<int>(3);
            TreeNode<int> minusOne = new TreeNode<int>(-1);
            TreeNode<int> twoOne = new TreeNode<int>(2);
            TreeNode<int> oneTwo = new TreeNode<int>(1);
            TreeNode<int> four = new TreeNode<int>(4);
            TreeNode<int> five = new TreeNode<int>(5);
            TreeNode<int> oneThree = new TreeNode<int>(1);
            TreeNode<int> oneFour = new TreeNode<int>(1);
            TreeNode<int> twoTwo = new TreeNode<int>(2);
            TreeNode<int> six = new TreeNode<int>(6);

            oneOne.Left = three;
            oneOne.Right = minusOne;
            three.Left = twoOne;
            three.Right = oneTwo;
            minusOne.Left = four;
            minusOne.Right = five;
            oneTwo.Left = oneThree;
            four.Left = oneFour;
            four.Right = twoTwo;
            five.Right = six;

            return new AllKSumPaths().Get(oneOne, k);
        }
    }
}

