// Program 1A
// CIS 200-75
// Fall 2014
// Due: 10/13/2014
// By: Andrew L. Wright

// File: TestParcels.cs
// This is a simple, console application designed to exercise the Parcel hierarchy.
// It creates several different Parcels and prints them.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prog1
{
    class TestParcels
    {
        // Precondition:  None
        // Postcondition: Parcels have been created and displayed
        static void Main(string[] args)
        {
            // Test Data - Magic Numbers OK
            Address a1 = new Address("John Smith", "123 Any St.", "Apt. 45", 
                "Louisville", "KY", 40202); // Test Address 1
            Address a2 = new Address("Jane Doe", "987 Main St.",
                "Beverly Hills", "CA", 90210); // Test Address 2
            Address a3 = new Address("James Kirk", "654 Roddenberry Way",
                "El Paso", "TX", 79901); // Test Address 3
            Address a4 = new Address("John fgdg", "678 Pau Place", "Apt. 7",
                "Portland", "ME", 04101); // Test Address 4
            Address a5 = new Address("John fgdvdf", "678 Pau Place", "Apt. 7",
                "Portland", "ME", 94859); // Test Address 5
            Address a6 = new Address("John gfdvds", "678 Pau Place", "Apt. 7",
                "Portland", "ME", 54382); // Test Address 6
            Address a7 = new Address("John jytjryyh", "678 Pau Place", "Apt. 7",
                "Portland", "ME", 12345); // Test Address 7
            Address a8 = new Address("John acsasd", "678 Pau Place", "Apt. 7",
                "Portland", "ME", 09764); // Test Address 8


            Letter letter1 = new Letter(a1, a2, 3.95M);                            // Letter test object
            Letter letter2 = new Letter(a5, a8, 3.95M);                            // Letter test object
            GroundPackage gp1 = new GroundPackage(a3, a4, 14, 10, 5, 12.5);        // Ground test object
            GroundPackage gp2 = new GroundPackage(a3, a4, 14, 10, 5, 12.5);  
            NextDayAirPackage ndap1 = new NextDayAirPackage(a1, a3, 25, 15, 15,    // Next Day test object
                85, 7.50M);
            NextDayAirPackage ndap2 = new NextDayAirPackage(a1, a3, 25, 15, 15,    // Next Day test object
                85, 7.50M);
            TwoDayAirPackage tdap1 = new TwoDayAirPackage(a4, a1, 46.5, 39.5, 28.0, // Two Day test object
                80.5, 'S');
            TwoDayAirPackage tdap2 = new TwoDayAirPackage(a4, a1, 46.5, 39.5, 28.0, // Two Day test object
                80.5, 'S');

            List<Parcel> parcels;      // List of test parcels

            parcels = new List<Parcel>();

            parcels.Add(letter1); // Populate list
            parcels.Add(letter2);
            parcels.Add(gp1);
            parcels.Add(gp2);
            parcels.Add(ndap1);
            parcels.Add(ndap2);
            parcels.Add(tdap1);
            parcels.Add(tdap2);

            Console.WriteLine("Original List:");
            Console.WriteLine("====================");
            foreach (Parcel p in parcels)
            {
                Console.WriteLine(p);
                Console.WriteLine("====================");
            }
            Pause();


            // LINQ statements
            //1. Destination addresses with descending zipcodes
            var destinationDescZip =
                from parcel in parcels
                orderby parcel.DestinationAddress.Zip descending
                select parcel;
            //2. order by cost
            var orderByCost =
                from parcel in parcels
                orderby parcel.CalcCost()
                select parcel;
            //3. order by type
            var orderByParcelType =
                from parcel in parcels
                orderby parcel.GetType().ToString(), parcel.CalcCost() descending
                select parcel;
            //4. get all heavy airpackages
            var heavyAirPackages =
                from parcel in parcels
                where parcel is AirPackage
                let Airpack = (AirPackage)parcel
                where Airpack.IsHeavy()
                orderby Airpack.Weight descending
                select Airpack;

            //print each linq query
            Console.WriteLine("Destination Zip Codes Descending");
            foreach (var parcel in destinationDescZip)
            {
                Console.WriteLine(parcel);
                Console.WriteLine();
            }
            Pause();

            Console.WriteLine("Order By Cost)");
            foreach (var parcel in orderByCost)
            {
                Console.WriteLine(parcel);
                Console.WriteLine();
            }
            Pause();

            Console.WriteLine("Order By Parcel Type");
            foreach (var parcel in orderByParcelType)
            {
                Console.WriteLine(parcel);
                Console.WriteLine();
            }
            Pause();

            Console.WriteLine("Heavy Air Packages");
            foreach (var parcel in heavyAirPackages)
            {
                Console.WriteLine(parcel);
                Console.WriteLine();
            }
            Pause();

       }

        // Precondition:  None
        // Postcondition: Pauses program execution until user presses Enter and
        //                then clears the screen
        public static void Pause()
        {
            Console.WriteLine("Press Enter to Continue...");
            Console.ReadLine();

            Console.Clear(); // Clear screen
        }
        
       
    }
}
