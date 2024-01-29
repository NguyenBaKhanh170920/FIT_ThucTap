// See https://aka.ms/new-console-template for more information
Console.WriteLine("Enter first number:");
int i1 = int.Parse(Console.ReadLine());
Console.WriteLine("Enter second number:");
int i2 = int.Parse(Console.ReadLine());
//Console.WriteLine("{0} and {1}", i1, i2);
while (true)
{
    Console.WriteLine("Select operation(+,-,*,/):");
    string op = Console.ReadLine();
    switch (op)
    {
        case "+":
            Console.WriteLine("Ket qua phep cong:{0}", i1 + i2); break;
        case "-":
            Console.WriteLine("Ket qua phep tru:{0}", i1 - i2); break;
        case "*":
            Console.WriteLine("Ket qua phep nhan:{0}", i1 * i2); break;
        case "/":
            if (i2 == 0)
            {
                Console.WriteLine("Ko the chia cho 0");
            }
            else
            {
                Console.WriteLine("Ket qua phep chia:{0}", i1 / i2);
                Console.WriteLine("Phan du phep chia:{0}", i1 % i2);

            }
            break;
        default:
            Console.WriteLine("Unknown operaion");
            break;
    }
}



