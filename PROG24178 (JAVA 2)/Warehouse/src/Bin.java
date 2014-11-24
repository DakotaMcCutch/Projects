/**
 * Created by Dakota on 1/13/14.
 */

class Bin
{
    private int capacity;
    private int noItem;
    private int overflow;
    private int iCount;
    private int count=0;

    public Bin (int capacity, int noItem)
    {
        this.capacity = capacity;
        this.noItem = noItem;
    }

    public Bin ()
    {
        this.capacity = 100;
        this.noItem = 0;
    }

    public int getCapacity ()
    {
        return capacity;
    }

    public int getItemCount ()
    {
        return noItem;
    }

    public void addItems (int count)
    {
        if (count + noItem > capacity)
        {
            overflow = (noItem + count) - capacity;
            noItem = noItem + (count - overflow);
        }
        else
        {
            noItem = noItem + count;
        }
    }

    public int retrieveItems (int count)
    {
        if (noItem - count < 0)
        {
            iCount = count - noItem;
            noItem = noItem - noItem;
        }
        else
        {
            iCount = 0;
            noItem = noItem - count;
        }
        return iCount;
    }

    public void setItemCount (int itemCount)
    {
        if (itemCount > capacity)
        {
            overflow = itemCount - capacity;
            noItem = noItem + (overflow - itemCount);
        }
        else
        {
            noItem = itemCount;
        }
    }

    public int getOverflow ()
    {
        return overflow;
    }

    @ Override
    public String toString ()
    {
        return ("Bin Capacity=" + "\t" + capacity + "\t" + "Current Items=" + "\t" + noItem + "\n");
    }
}
