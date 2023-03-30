
#region *MAIN*

Console.WriteLine("\tWelcome to Payroll System\n");

#region VARIABLES

String FullName = "";
float GrossSalary = 0;
float Tax = 0;
float NetSalary = 0;

#endregion

#region RUN

#region Payroll
var (fullName, salary, marriage, childCount, disabled) = getInfos(); //get infos about employee

var (grossSalary, mariageAmount, childAmount) = grossSalary_(salary, marriage, childCount); //get gross salary

var (tax_, taxDegree) = tax(disabled, grossSalary); //get tax amount

showAllInfos(fullName, mariageAmount, childAmount, tax_, taxDegree, grossSalary, (grossSalary - tax_)); //show all infos
#endregion

#region ATM

welcomeATM(fullName);

getCash(grossSalary - tax_);

#endregion

#endregion

Console.WriteLine("\t\nProgram ended...");

#endregion


#region *METHODS*

static (String, float, string, int, bool) getInfos()
{
    //fullname
    Console.Write("Please enter the employee's fullname: ");
    string fullname = Console.ReadLine();

    //salary
    Console.Write("Please enter the employee's salary: ");
    float salary = float.Parse(Console.ReadLine());

    //marriage status
    string marriage = "";
    bool flag = true;
    bool flag2 = false;
    String[] marriageTextArray = { "Married", "Single", "Widow" };
    do
    {
        Console.Write("Please enter the employee's marriage status (Married/Single/Widow) : ");
        string marriage_ = Console.ReadLine();

        for (int i = 0; i < marriageTextArray.Length; i++)
        {
            if (marriageTextArray[i].Equals(marriage_))
            {
                flag2 = true;
            }
        }

        if (flag2 != false)
        {
            marriage = marriage_;
            flag = false;
        }
        else
        {
            Console.WriteLine("\nInvalid input...Please try again\n");
        }

    } while (flag);

    //child count
    Console.Write("Please enter the employee's child count: ");
    int childCount = int.Parse(Console.ReadLine());

    //physical status
    bool disabled = false;
    do
    {
        Console.Write("Please enter the employee's physical status (Yes/No) : ");
        string disabled_ = Console.ReadLine();

        if (disabled_.Equals("Yes"))
        {
            disabled = true;
            break;
        }
        else if (disabled_.Equals("No"))
        {
            disabled = false;
            break;
        }
        else
        {
            Console.WriteLine("\nInvalid input...Please try again\n");
        }
    } while (true);

    return (fullname, salary, marriage, childCount, disabled);
}

static (float, float, float) grossSalary_(float salary, string marriage, int childCount)
{
    //marriage?
    float mariageAmount = 0;
    if (marriage.Equals("Married"))
    {
        salary += 50;
        mariageAmount = 50;
    }

    //child
    float childAmount = 0;

    if (childCount != 0)
    {
        if (childCount <= 3)
        {
            if (childCount == 1)
            {
                salary += 30;
                childAmount = 30;
            }
            else if (childCount == 2)
            {
                salary += 55;
                childAmount = 55;
            }
            else if (childCount == 3)
            {
                salary += 75;
                childAmount = 75;
            }
        }
        else
        {
            salary += ((childCount - 3) * 15) + 75;
            childAmount = ((childCount - 3) * 15) + 75;
        }
    }

    return (salary, mariageAmount, childAmount);
}

static (float, string) tax(bool disabled, float grossSalary)
{
    float tax_ = 0;
    String taxDegree = "";

    //if employee is a disabled person
    if (disabled == false)
    {
        if (grossSalary <= 1000)
        {
            tax_ = grossSalary * 15 / 100;
            taxDegree = "15%";
        }
        else if (grossSalary > 1000 && grossSalary <= 2000)
        {
            tax_ = grossSalary * 20 / 100;
            taxDegree = "20%";
        }
        else if (grossSalary > 2000 && grossSalary <= 3000)
        {
            tax_ = grossSalary * 25 / 100;
            taxDegree = "25%";
        }
        else
        {
            tax_ = grossSalary * 30 / 100;
            taxDegree = "30%";
        }
    }
    //if employee is a undisabled person
    else
    {
        if (grossSalary <= 1000)
        {
            tax_ = (grossSalary * 15 / 100) / 2;
            taxDegree = "7.5% for disabled employee";
        }
        else if (grossSalary > 1000 && grossSalary <= 2000)
        {
            tax_ = (grossSalary * 20 / 100) / 2;
            taxDegree = "10% for disabled employee";
        }
        else if (grossSalary > 2000 && grossSalary <= 3000)
        {
            tax_ = (grossSalary * 25 / 100) / 2;
            taxDegree = "12.5% for disabled employee";
        }
        else
        {
            tax_ = (grossSalary * 30 / 100) / 2;
            taxDegree = "15% for disabled employee";
        }
    }

    return (tax_, taxDegree);
}

static void showAllInfos(string fullName, float mariageAmount, float childAmount, float tax, string taxDegree, float grossSalary, float netSalary)
{
    sleepTime(550, 4);

    Console.WriteLine(
        $"\n{fullName.ToUpper()}'s payroll informations...\n" +
        $"\nMarriage amount: {mariageAmount}" +
        $"\nAmount for child: {childAmount}" +
        $"\nTax degree: {taxDegree}" +
        $"\nTax amount: {tax}" +
        $"\nGross salary: {grossSalary}" +
        $"\nNet salary: {netSalary}"
        );
}

static void welcomeATM(string fullName)
{
    Console.WriteLine("\n\nIn order to continue please press any key");
    Console.ReadLine();

    Console.WriteLine("\tWelcome to ATM\n");

    do
    {
        Console.Write("Please enter your name: ");
        string client = Console.ReadLine();

        if (client.Equals(fullName))
        {
            break;
        }
        else
        {
            Console.WriteLine("\nNot fount selected client...Please try again\n");
        }
    } while (true);
}

static void getCash(float netSalary)
{
    Console.Write("\nDo you want to get cash? (Yes/No): ");
    string result = Console.ReadLine();

    if (result.Equals("Yes"))
    {
        Console.WriteLine("\nCash output will be like below...\n");

        float banknote = 0;
        int[] banknoteArray = { 200, 100, 50, 20, 10, 5, 1 };

        for (int i = 0; i < banknoteArray.Length; i++)
        {
            if (netSalary > banknoteArray[i])
            {
                banknote = (int)(netSalary / banknoteArray[i]);
                Console.WriteLine($"{banknote} bills of {banknoteArray[i]} dollars");
                netSalary -= banknote * banknoteArray[i];
            }
        }
    }

}

static void sleepTime(int millis, int count)
{
    Console.Write("\nPlease wait a minute ");

    for (int i = 1; i <= count; i++)
    {
        Thread.Sleep(millis);
        Console.Write(". ");
    }

    Console.WriteLine("\n");
}

#endregion

static void testMethod()
{

}