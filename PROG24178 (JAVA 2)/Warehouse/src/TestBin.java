/*
 * TestBin.java
 *
 */


/**
 * This is a test driver for the bin class. If this
 * won't compile in the same directory as your Bin
 * class there is probably a problem with the way
 * you have named you methods in Bin.
 * @author joe
 */
public class TestBin
{

    /** Creates a new instance of Main */
    public TestBin ()
    {
    }


    /**
     * Main driver of program to test Bin class.
     * @param args the command line arguments
     */
    public static void main (String[] args)
    {
        // Please note that when you are just using
        // numbers to test routines you typically
        // do not consider them as magic numbers.

        Bin binOne = new Bin (200, 100);
        Bin binTwo = new Bin (300, 250);
        Bin binThree = new Bin (125, 30);
        Warehouse test = new Warehouse ();
        int capacity, currentItems, overflow;
        try
        {
            test.addBin (binOne);
            test.addBin (binTwo);
            test.addBin (binThree);
            capacity = test.getCapacity ();
            currentItems = test.getTotalInventory();
            System.out.println(test);
            test.addItems(100);
            System.out.println(test);
             test.retrieveItems (2500);
            System.out.println(test);

        }

        catch(OverflowException ofe)
        {
        }

        catch (NotEnoughItemsException neie)
        {
        }

    }
}
