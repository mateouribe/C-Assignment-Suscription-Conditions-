using System;

public class AssignmentTwo
{
    public static decimal AddPercentage(decimal value, decimal percentage)
    {
        return (value * percentage) + value;
    }
    public static decimal GetTenPercentageDiscount(decimal value)
    {
        return value - (value * 0.10m);
    }

    public static void Main(string[] args)
    {
        System.Console.WriteLine("Please enter your age");
        int userAge = int.Parse(System.Console.ReadLine());
        decimal paymentAmount = 0;
        decimal paymentTotal = 0;
        decimal tax;
        bool? isReferred = null;
        string? currency = null;
        string? month = null;
        decimal discountedPayment = paymentAmount;

        //Step 1 - if user is not at least 14 then do not allow registation
        if (userAge <= 13)
        {
            Console.WriteLine("You have to be 14 or older to register. Please try again in " + (14 - userAge) + " years");
        } else
        {
            //Validate the currency answer is valid
            while(currency == null)
            {
                System.Console.WriteLine("Please enter which currency you want to pay with (USD, CAD or BITCOIN)");
                string currencyAnswer = System.Console.ReadLine().ToUpper();

                if(currencyAnswer == "USD" || currencyAnswer == "CAD" || currencyAnswer == "BITCOIN")
                {
                    currency = currencyAnswer;
                } else
                {
                    System.Console.WriteLine("Please enter a valid answer.");
                }
            } 


            //Validate if an user is reffered and if he enters a valid answer
            while (isReferred == null)
            {
                System.Console.WriteLine("Are you referred by an existing client? please only answer yes or no");
                string refferedAnswer = System.Console.ReadLine().ToUpper();

                //Si sí es respuesta valida
                if(refferedAnswer == "YES" || refferedAnswer == "NO")
                {
                    if(refferedAnswer == "YES")
                    {
                        isReferred = true;
                    } else if (refferedAnswer == "NO")
                    {
                        isReferred = false;
                    }                    
                }
                //Si no es respuesta valida
                else
                {
                    System.Console.WriteLine("Please enter a valid answer.");    
                }
            }

            //Depending on age payment amount
            if(userAge <= 19)
            {
                paymentAmount = 10;
            } else if(userAge >= 20 && userAge <= 29)
            {
                paymentAmount = AssignmentTwo.AddPercentage(35.50m, 0.13m);
            }
            else if (userAge >= 30 && userAge <= 64)
            {
                paymentAmount = AssignmentTwo.AddPercentage(70.50m, 0.13m);
            } else
            {
                paymentAmount = 0;
            }

            if(isReferred == true)
            {
                paymentAmount -= 25;
            }

            //Ask for month of suscriptions

            while(month == null)
            {
                System.Console.WriteLine("Please enter the month you wish to start your subscription.");
                string monthAnswer = System.Console.ReadLine().ToUpper();

                if (monthAnswer == "JANUARY" || monthAnswer == "FEBRUARY" || monthAnswer == "MARCH" || monthAnswer == "APRIL" || monthAnswer == "MAY" || monthAnswer == "JUNE" || monthAnswer == "JULY" || monthAnswer == "AUGUST" || monthAnswer == "SEPTEMBER" || monthAnswer == "OCTOBER" || monthAnswer == "NOVEMBER" || monthAnswer == "DECEMBER" )
                {
                    switch (month)
                    {
                        case "JANUARY":
                        case "FEBRUARY":
                            
                            discountedPayment = paymentAmount - 10;
                            break;
                        case "MARCH":
                            discountedPayment = AssignmentTwo.GetTenPercentageDiscount(paymentAmount);
                            break;
                        case "APRIL":
                        case "MAY":
                            discountedPayment = (paymentAmount + 20) + AssignmentTwo.AddPercentage(paymentAmount, 0.13m);
                            break;

                        default:
                            discountedPayment = paymentAmount;
                            break;
                    }
                    month = monthAnswer;
                } else
                {
                    System.Console.WriteLine("Please enter a valid answer");
                }
            };



           

            //Calculate 9% tax
            tax = discountedPayment * 0.09m;

            //Total order
            paymentTotal = discountedPayment + tax;


            //Print
            System.Console.WriteLine("ANSWER: " + "\n" + "\n" + "Applicant's age: " + userAge + "\n" + "Registation Month: " + month + "\n" + "Reg. fee: " + paymentAmount + currency + "\n" + "Total adjustment: " + discountedPayment + currency + "\n" + "Total tax calculated: " + tax + currency + "\n" + "Final Total: " + paymentTotal + currency);
        };

        
    }
}
