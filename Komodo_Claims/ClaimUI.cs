using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Claims
{
    class ClaimUI
    {
        ClaimRepo _claimDirectory = new ClaimRepo();


        public void Run()
        {
            Seed();
            _claimDirectory.MakeClaimQueue();
            RunMenu();
        }

        public void RunMenu()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Claims Menu.\n" +
                    "What would you like to do?\n" +
                    "1) View all current claims.\n" +
                    "2) View Claim by ID Number, Not implemented yet\n" +
                    "3) View Claims in queue.\n" +
                    "4) Add a new claim.\n" +
                    "5) Update a current claim, Not implemeted yet\n" +
                    "6) Delete a claim, Not implemented yet\n" +
                    "7) Exit");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        ViewClaimsInQueue();
                        break;
                    case "2":
                        break;
                    case "3":
                        ViewClaimQueue();
                        break;
                    case "4":
                        AddNewClaim();
                        break;
                    case "5":
                        break;
                    case "6":
                        break;
                    case "7":
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a number 1-6");
                        break;
                }

            }
            
        }
        public void ViewClaimsInQueue()
        {
            _claimDirectory.WriteQueue();
        }
        public void ViewClaimQueue()
        {
            Queue<ClaimProp> claimQueue = _claimDirectory.GetClaimQueue();
            bool isViewingQueue = true;
            int viewQueue = 0;
            while (isViewingQueue)
            {
                ClaimProp myclaim = claimQueue.Peek();
                if (viewQueue == 0)
                {
                    Console.WriteLine($"Claim ID: {myclaim.ClaimId}\n" +
                        $"Type: {myclaim.ClaimType}\n" +
                        $"Description: {myclaim.ClaimDescription}\n" +
                        $"Amount: {myclaim.ClaimAmount}\n" +
                        $"Date Of Incident: {myclaim.DateOfIncident.ToString("MM/dd/yy")}\n" +
                        $"Date Of Claim: {myclaim.DateOfClaim.ToString("MM/dd/yy")}\n" +
                        $"Is a Vaild Claim: {myclaim.IsValid}\n");

                    Console.WriteLine("Do you want to deal with this claim now? Y/N");

                    string userInput = Console.ReadLine();

                    switch (userInput.ToLower())
                    {
                        case "yes":
                        case "y":
                            claimQueue.Dequeue();
                            viewQueue++;
                            break;
                        case "no":
                        case "n":
                            isViewingQueue = false;
                            viewQueue = 0;
                            break;
                        default:
                            Console.WriteLine("Please enter Yes or No.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Would you like to view the next item in queue? Y/N");

                    string userInput = Console.ReadLine();

                    switch (userInput.ToLower())
                    {
                        case "yes":
                        case "y":
                            NextClaim();
                            isViewingQueue = false;
                            viewQueue = 0;
                            break;
                        case "no":
                        case "n":
                            isViewingQueue = false;
                            viewQueue = 0;
                            break;
                        default:
                            Console.WriteLine("Please enter Yes or No.");
                            break;
                    }



                }
            }

        }

        public void NextClaim()
        {
            Queue<ClaimProp> claimQueue = _claimDirectory.GetClaimQueue();
            bool isViewingQueue = true;
            ClaimProp myclaim = claimQueue.Peek();
            while (isViewingQueue)
            {
                Console.WriteLine($"Claim ID: {myclaim.ClaimId}\n" +
                    $"Type: {myclaim.ClaimType}\n" +
                    $"Description: {myclaim.ClaimDescription}\n" +
                    $"Amount: {myclaim.ClaimAmount}\n" +
                    $"Date Of Incident: {myclaim.DateOfIncident.ToString("MM/dd/yy")}\n" +
                    $"Date Of Claim: {myclaim.DateOfClaim.ToString("MM/dd/yy")}\n" +
                    $"Is a Vaild Claim: {myclaim.IsValid}\n");

                Console.WriteLine("Do you want to deal with this claim now? Y/N");

                string userInput = Console.ReadLine();

                switch (userInput.ToLower())
                {
                    case "yes":
                    case "y":
                        claimQueue.Dequeue();
                        break;
                    case "no":
                    case "n":
                        isViewingQueue = false;
                        break;
                    default:
                        Console.WriteLine("Please enter Yes or No.");
                        break;
                }
            }

        }

        public void AddNewClaim()
        {
            ClaimProp claim = new ClaimProp();
            Console.WriteLine("What is the Claim ID number");

            claim.ClaimId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("What Type is the Claim?\n" +
                "1)Home\n" +
                "2)Theft\n" +
                "3)Car\n");

            string type = Console.ReadLine();
            int typeID = int.Parse(type);
            claim.ClaimType = (ClaimType)typeID;

            Console.WriteLine("Write a short Description of incident");
            claim.ClaimDescription = Console.ReadLine();

            Console.WriteLine("What is the estimated amount of damage");
            claim.ClaimAmount = Console.ReadLine();

            Console.WriteLine("Date incident happened. plese use mm/dd/yy format");
            claim.DateOfIncident = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("Date claim was submitted. plese use mm/dd/yy format");
            claim.DateOfClaim = Convert.ToDateTime(Console.ReadLine());

            _claimDirectory.AddClaim(claim);
            Console.WriteLine("Claim as been added");
            Console.ReadKey();


        }









        public void Seed()
        {
            ClaimProp claimOne = new ClaimProp(1, ClaimType.Car, "Car accident on 465", "$400.00", Convert.ToDateTime("04/25/2018"), Convert.ToDateTime("04/27/2018"));
            _claimDirectory.AddClaimToDirectory(claimOne);

            ClaimProp claimTwo = new ClaimProp(2, ClaimType.Home, "House fire in kitchen", "$4000.00", Convert.ToDateTime("04/11/2018"), Convert.ToDateTime("04/12/2018"));
            _claimDirectory.AddClaimToDirectory(claimTwo);

            ClaimProp claimThree = new ClaimProp(3, ClaimType.Theft, "Stolen pancakes", "$4.00", Convert.ToDateTime("04/27/2018"), Convert.ToDateTime("06/01/2018"));
            _claimDirectory.AddClaimToDirectory(claimThree);
        }





    }
    //For #1, a claims agent could see all items in the queue listed out like this:

    //ClaimID  Type    Description      Amount       DateOfAccident  DateOfClaim IsValid
    //1	Car    Car     accident on 465.	$400.00	     4/25/18	      4/27/18	true
    //2	Home   House   fire in kitchen. $4000.00	 4/11/18	      4/12/18	true
    //3	Theft  Stolen  pancakes.        $4.00	     4/27/18	      6/01/18	false


 /*  Here are the details for the next claim to be handled:
        ClaimID: 1
        Type: Car
        Description: Car Accident on 464.
        Amount: $400.00
        DateOfAccident: 4/25/18
        DateOfClaim: 4/27/18
        IsValid: True
    Do you want to deal with this claim now(y/n)? y
When the agent presses 'y', the claim will be pulled off the top of the queue. If the agent presses 'n', it will go back to the main menu.

For #3, when a claims agent enters new data about a claim they will be prompted for questions about it:

    Enter the claim id: 4
    Enter the claim type: Car
    Enter a claim description: Wreck on I-70.
    Amount of Damage: $2000.00
    Date Of Accident: 4/27/18
    Date of Claim: 4/28/18
    This claim is valid.*/




}
