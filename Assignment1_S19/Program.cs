using System;

namespace Assignment1_S19
{
    class Program
    {
        public static void Main()
        {
            int a = 35, b = 15;
            Console.WriteLine("\n The prime numbers between: " + a + " " + b);
            printPrimeNumbers(a, b);

            int n1 = 5;
            double r1 = getSeriesResult(n1);
            Console.WriteLine("\n The sum of the series is: " + r1);


            long n2 = 15;
            long r2 = decimalToBinary(n2);
            Console.WriteLine("\n Binary conversion of the decimal number " + n2 + " is: " + r2);


            long n3 = 1111;
            long r3 = binaryToDecimal(n3);
            Console.WriteLine("\n Decimal conversion of the binary number " + n3 + " is: " + r3);


            int n4 = 5;
            Console.WriteLine("\n The print triangle function of" + n4 + "values is: ");
            printTriangle(n4);

            //int[] arr = new int[] { 1, 2, 3, 2, 2, 1, 3, 2 };
            int[] arr = new int[] { 1, 2, 3 };
            Console.WriteLine("\n The compute frequency function of given array" + arr + " is: ");
            computeFrequency(arr);

            // write your self-reflection here as a comment
            /*  After working on these functions, it helped to brush up the coding logics and
             * helped in learning the basic syntax of C#. As part of Recommendation, I think, 
             * we can modify the functions to ask the user to enter the input and then compute 
             * the values rather than giving the hardcore values for each function. */

            Console.ReadKey();

        }

        /*
         * Function to print the prime numbers between two integers
         * 
         */
        public static void printPrimeNumbers(int x, int y)
        {
            try
            {
                int count = 0;
                int startNum = 0;
                int endNum = 0;

                //Handled the logic of invalid numbers, i.e. negative numbers
                if (x > 0 && y > 0)
                {
                    if (x < y)
                    {
                        startNum = x;
                        endNum = y;
                    }
                    else
                    {
                        startNum = y;
                        endNum = x;
                    }

                    for (int i = startNum; i <= endNum; i++)
                    {
                        for (int j = 2; j < i; j++)
                        {
                            /*Dividing each integer by 2,3,4... to eliminate non-prime numbers
                            *and count the difference for the next prime number
                            */
                            if (i % j != 0)
                            {
                                count += 1;
                            }
                        }
                        //Printing prime numbers here
                        if (count == (i - 2))
                        {
                            Console.Write(i + "\t");
                        }

                        count = 0;
                    }

                }
            }
            catch
            {
                Console.WriteLine("Exception occured while computing printPrimeNumbers()");
            }
        }

        /*
         * Function to print the series of (i!)/(i+1) 
         * 
         */
        public static double getSeriesResult(int n)
        {
            double sum = 0;
            try
            {
                
                if (n > 0)
                {
                    for (int i = 1; i <= n; i++)
                    {
                        /*
                         * Converting the values of factorial and denominator to Double and doing a division
                         * and adding each of the individual values to create the final sum of the series.
                         * 
                         * Created another function factorial to find the factorial value of given number.
                         */
                        sum += Convert.ToDouble(factorial(i)) / Convert.ToDouble((i + 1));

                        //Rounding off the sum to two decimal values
                        sum = Math.Round(sum, 2);
                    }
                }
                else
                {
                    Console.WriteLine("Enter a positive value to be converted to a binary number");
                }
                return sum;
            }
            catch
            {
                Console.WriteLine("Exception occured while computing getSeriesResult()");
            }

            return sum;
        }

        /*
        * Function to calculate factorial value
        * 
        */
        public static int factorial(int n)
        {
            int res = 1;
            /*
             * A for loop to multiply all the numbers starting from 2 till the end number 
             * in order to calculate the factorial
             */
            for (int i = 2; i <= n; i++)
                res *= i;
            return res;
        }

        /*
        * Function to convert the decimal value to binary value 
        * 
        */
        public static long decimalToBinary(long n)
        {
            try
            {
                long remainder;
                string result = string.Empty;

                /*
                 * A while loop to find the remainder till the quotient doesn't become zero
                 * and then concatenating all the remainder values to create a binary value
                 */
                while (n > 0)
                {
                    remainder = n % 2;
                    n /= 2;
                    result = remainder.ToString() + result;
                }
                long strvalue = Convert.ToInt64(result);
                return strvalue;
            }
            catch
            {
                Console.WriteLine("Exception occured while computing decimalToBinary()");
            }

            return 0;
        }

        /*
        * Function to convert the binary value to decimal value
        * 
        */
        public static long binaryToDecimal(long n)
        {
            try
            {
                long binary_val, decimal_val = 0, base_val = 1, rem;
                binary_val = n;


                /*
                 * A while loop to  divide the binary number by 10 and multiple the tens digit by 2
                 * and add the value to the remainder and run this logic the quotient becomes zero
                 */
                while (n > 0)
                {
                    rem = n % 10;
                    if (rem == 0 || rem == 1)
                    {

                        decimal_val = decimal_val + rem * base_val;
                        n = n / 10;
                        base_val = base_val * 2;
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid binary number");
                        break;
                    }
                }
                

                return decimal_val;
            }
            catch
            {
                Console.WriteLine("Exception occured while computing binaryToDecimal()");
            }

            return 0;
        }

        /*
        * Function to print a triangle where total count of stars represnt the number
        * 
        */
        public static void printTriangle(int n)
        {
            try
            {
                int i, j, k;
                for (i = 1; i <= n; i++)
                {
                    //A for loop to provide the initial space before the star
                    for (j = 1; j <= n - i; j++)
                    {
                        Console.Write(" ");
                    }

                    /*A for loop to print the stars starting from 1 in 1st row and 
                     * increment the number of stars by 1 in the next row
                     */
                    for (k = 1; k <= i; k++)
                    {
                        Console.Write("*");
                        Console.Write(" ");
                    }

                    Console.WriteLine("");
                }
            }
            catch
            {
                Console.WriteLine("Exception occured while computing printTriangle()");
            }
        }

        /*
        * Function to compute the frequency of each number in an array
        * 
        */
        public static void computeFrequency(int[] a)
        {
            try
            {
                int n = a.Length;
                int[] freq = new int[100];
                int i, j, count;
                int temp = 0;

                
                for (i = 0; i < n; i++)
                {
                    count = 1;
                    for (j = i+1; j < n; j++)
                    {
                        /* If condition to find the duplicate number */
                        if (a[i] == a[j])
                        {

                            if (i == 0)
                            {
                                temp = a[i];
                                count++;
                                freq[i] = count;
                            }
                            else if (temp != a[i])
                            {
                                temp = a[i];
                                count++;
                                freq[i] = count;
                            }
                            else
                            {
                                /* To not to count frequency of same number again */
                               freq[i] = 0;
                            }
                        }
                        else
                        {
                            freq[i] = count;
                        }
                       
                    }

                    ///* Validation to check if frequency of current number is not counted */
                    if (freq[i] != 0)
                    {
                        freq[i] = count;
                    }
                }

                /*
                 * To print frequency of each number
                 */
                for (i = 0; i < n; i++)
                {
                    if (freq[i] != 0)
                    {
                        Console.WriteLine("Number   Frequency\n");
                        Console.WriteLine(a[i] + "           " + freq[i] + "\n");
                    }
                }
            }
            catch
            {
                Console.WriteLine("Exception occured while computing computeFrequency()");
            }
        }

    }
}

