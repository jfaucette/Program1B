// Program 1A
// CIS 200-75
// Fall 2014
// Due: 10/13/2014
// By: Andrew L. Wright

// File: TwoDayAirPackage.cs
// The TwoDayAirPackage class is a concrete derived class from AirPackage. It adds
// a delivery type.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class TwoDayAirPackage : AirPackage
{
    private char deliveryType;          // Code representing two day air package's delivery type

    // Precondition:  pLength >= 0, pWidth >= 0, pHeight >=0,
    //                pWeight >= 0, delType in VALID_TYPES
    // Postcondition: The two day air package is created with the specified values for
    //                origin address, destination address, length, width,
    //                height, weight, and delivery type
    public TwoDayAirPackage(Address originAddress, Address destAddress,
        double pLength, double pWidth, double pHeight, double pWeight, char delType)
        : base(originAddress, destAddress, pLength, pWidth, pHeight, pWeight)
    {
        DeliveryType = delType;
    }

    public char DeliveryType
    {
        // Precondition:  None
        // Postcondition: The two day air package's delivery type has been returned
        get
        {
            return deliveryType;
        }

        // Precondition:  None
        // Postcondition: The two day air package's delivery type has been set to the
        //                specified value
        set
        {
            char type; // Delivery type as upper case

            type = char.ToUpper(value);
            if (type == 'E' || type == 'S')
                deliveryType = type;
            else
                throw new ArgumentOutOfRangeException("DeliveryType", value,
                    "DeliveryType must be 'E' or 'S'");
        }
    }

    // Precondition:  None
    // Postcondition: The two day air package's cost has been returned
    public override decimal CalcCost()
    {
        const decimal DIM_FACTOR = .25M;       // Dimension coefficient in cost equation
        const decimal WEIGHT_FACTOR = .25M;    // Weight coefficient in cost equation
        const decimal DISCOUNT_FACTOR = 0.90M; // Discount factor in cost equation
        const char DISCOUNT_TYPE = 'S';        // Delivery type earning discount

        decimal cost; // Running total of cost of package

        cost = (DIM_FACTOR * (decimal)TotalDimension +
            WEIGHT_FACTOR * (decimal)Weight);

        if (DeliveryType == DISCOUNT_TYPE)
            cost *= DISCOUNT_FACTOR;

        return cost;
    }

    // Precondition:  None
    // Postcondition: A String with the two day air package's data has been returned
    public override string ToString()
    {
        string type; // DeliveryType as string

        if (DeliveryType == 'S')
            type = "Saver";
        else // must be 'E'
            type = "Early";

        return String.Format("TwoDay{0}{3}Delivery Type: {1}{3}Cost: {2:C}",
            base.ToString(), type, CalcCost(), System.Environment.NewLine);
    }
}
