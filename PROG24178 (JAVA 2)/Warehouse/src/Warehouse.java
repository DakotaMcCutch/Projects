import java.util.ArrayList;



/**
 * Created by Dakota on 1/16/14.
 */
class Warehouse {
    private int capacity;
    private int noItem;
    private int rCount;
    private int overflow;
    private String name;
    private ArrayList<Bin> warehouse = new ArrayList<Bin>();

    public Warehouse()
    {

    }

    public Warehouse(String name)
    {
        this.name=name;
    }

    public int getCapacity()
    {
        int size = warehouse.size();
        for( int i = 0; i < size ; i++ )
        {

            Bin s = warehouse.get(i);
            this.capacity = this.capacity + (s.getCapacity());
        }

        return capacity;
    }

    public int getTotalInventory()
    {
        int size = warehouse.size();
        this.noItem=0;
        for( int i = 0; i < size ; i++ )
        {

            Bin s = warehouse.get(i);
            this.noItem += (s.getItemCount());
        }

        return noItem;
    }

    public void setName(String name)
    {
        this.name=name;
    }

    public void addItems(int count) throws OverflowException
    {
        if(count+noItem>capacity)
        {
            throw new OverflowException();

        }
        while(count>0)
        {
            int size = warehouse.size();
            for( int i2 = 0; i2 < size ; i2++ )
            {

                Bin s = warehouse.get(i2);
                s.addItems(count);
                count=s.getOverflow();
                noItem= getTotalInventory();
                    warehouse.remove(i2);
                    warehouse.add(i2,s);




            }

        }


   }
    public void addBin (Bin b)//changed to void should be int
    {
        warehouse.add(b);

    }

    public int retrieveItems(int count) throws NotEnoughItemsException
    {
        if(noItem-count<0)
        {
            throw new NotEnoughItemsException();
        }
        rCount=count;
        int size = warehouse.size();
        while(count>0)
        {
            for( int i = 0; i < size ; i++ )
            {

                Bin s = warehouse.get(i);
               count=(s.retrieveItems(count));
                noItem= getTotalInventory();
                warehouse.remove(i);
                warehouse.add(i,s);


            }

        }
       return rCount;
    }
    @Override
    public String toString() {

            String s=("Total Capacity=" + "\t" + capacity + "\t" + "Current Items=" + "\t" + noItem + "\n");
            String bin="";
            int size = warehouse.size();
            for( int i = 0; i < size ; i++ )
            {
                bin += warehouse.get(i);

            }
        return s + bin;
    }

}
