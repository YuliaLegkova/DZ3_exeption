using System;
using System.Collections;


Console.WriteLine("Решаем квадратное урванение:");
Console.WriteLine("a*x^2+b*x+c=0");
Console.WriteLine("Введите целые значения а, b и с");

int a2 = 0;
int b2 = 0;
int c2 = 0;

bool getcheck = false;

while (!getcheck)

{
    bool getcheck1 = false;
    bool getcheck2 = false;
    bool getcheck3 = false;
    var a1 = GetABC("Введите значение а:");
    var b1 = GetABC("Введите значение b:");
    var c1 = GetABC("Введите значение c:");

    try
    {
        a2 = Convert.ToInt32(a1);
        getcheck1 = true;
    }
    catch (Exception)
    {
        FormatData($"Неверный формат параметра a", Severity.Error);
    }

    try
    {
        b2 = Convert.ToInt32(b1);
        getcheck2 = true;
    }
    catch (Exception)
    {
        FormatData($"Неверный формат параметра b", Severity.Error);
    }

    try
    {
        c2 = Convert.ToInt32(c1);
        getcheck3 = true;
    }
    catch (Exception)
    {
        FormatData($"Неверный формат параметра c", Severity.Error);
    }
    Console.WriteLine("a = " + a1);
    Console.WriteLine("b = " + b1);
    Console.WriteLine("c = " + c1);
    getcheck = getcheck1 && getcheck2 && getcheck3;
}

void FormatData(string message, Severity severity)
{
    Console.BackgroundColor = severity == Severity.Error ? ConsoleColor.Red : ConsoleColor.Yellow;
    Console.ForegroundColor = severity == Severity.Error ? ConsoleColor.White : ConsoleColor.Black;
    Console.WriteLine(new string('-', 50));
    Console.WriteLine(message);
    Console.WriteLine(new string('-', 50));
    Console.ResetColor();
}

int a = a2;
int b = b2;
int c = c2;


double d = Math.Pow(b, 2) - (4 * a * c);

double d1 = Math.Sqrt(d);

var x1 = 0.0;
var x2 = 0.0;

try
{
    if (d == 0)
    {
        EquationSolver(ref x1, ref x2);
        Console.WriteLine("Корень уравнения:  x = {0} ", x1);
    }

    else if (d > 0)
    {
        EquationSolver(ref x1, ref x2);
        Console.WriteLine("Корни уравнения: x1 = {0}, x2 = {1}", x1, x2);
    }

    else
    {
        throw new EquationSolverException($"Вещественных значений не найдено");
    }
}
catch (EquationSolverException)
{
    FormatData($"Вещественных значений не найдено", Severity.Warning);
}


static string GetABC(string v)
{
    Console.WriteLine(v);
    string str = Console.ReadLine();
    return str;
}

void EquationSolver(ref double x1, ref double x2)
{
    x1 = ((-b) + d1) / (2 * a);
    x2 = ((-b) - d1) / (2 * a);
}

enum Severity
{
    Warning,
    Error
}

public class EquationSolverException : Exception
{
    public EquationSolverException(string message) : base(message)
    {

    }
}