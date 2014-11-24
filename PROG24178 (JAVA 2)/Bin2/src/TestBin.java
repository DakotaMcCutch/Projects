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
public class TestBin {

    /** Creates a new instance of Main */
    public TestBin() {
    }

    /**
     * Main driver of program to test Bin class.
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        // Please note that when you are just using
        // numbers to test routines you typically
        // do not consider them as magic numbers.

        Bin binOne = new Bin();
        Bin binTwo = new Bin(200,100);
        int capacity, currentItems, overflow;

        try
        {
            capacity = binTwo.getCapacity();
            currentItems = binTwo.getItemCount();
            System.out.println("Bin 2 Capacity= " + capacity
                    + " Current Items=  " + currentItems );
            binOne.setItemCount(20);
            System.out.println("Bin 1 " + binOne);
            binTwo.addItems(46);
            System.out.println("Bin 2 " + binTwo);
            binTwo.retrieveItems(23);
            System.out.println("Bin 2 " + binTwo);
            binTwo.addItems(199);
            overflow=binTwo.getOverflow();
            System.out.println("Bin two overflow =" + overflow);
        }

    catch(OverflowException d)
    {
    }
    catch (NotEnoughItemsException neie)
    {
    }
   }
}
