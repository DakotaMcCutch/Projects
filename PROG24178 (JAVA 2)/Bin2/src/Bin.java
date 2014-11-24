/**
 * Created by Dakota on 1/13/14.
 */

class Bin {
    private int capacity;
    private int noItem;
    private int overflow;


    public Bin(int capacity,int noItem)
    {
        this.capacity = capacity;
        this.noItem = noItem;
    }
    public Bin ()
    {
        this.capacity = 100;
        this.noItem = 0;
    }

    public int getCapacity()
    {
        return capacity;
    }
    public  int getItemCount()
    {
        return noItem;
    }
    public void addItems(int count) throws OverflowException
    {
        if(count+noItem>capacity)
        {
            throw new OverflowException();

        }

            noItem = noItem + count;


    }
    public int retrieveItems(int count) throws NotEnoughItemsException
    {
        if(noItem-count<0)
        {
            throw new NotEnoughItemsException();
        }


            noItem = noItem - count;
            System.out.println(count + " Item(s) Were Retrieved From The Bin");

        return noItem;
    }
    public void setItemCount(int itemCount)
    {
        if(itemCount>capacity)
        {
            overflow= itemCount - capacity;
            noItem=noItem+ (overflow-itemCount);

        }
        else {
            noItem = itemCount;
        }

    }
    public int getOverflow()
    {
        return overflow;
    }

    @Override
    public String toString() {
        return ("Capacity=" + "\t" + capacity + "\t" + "Current Items=" + "\t" + noItem);

    }

}
