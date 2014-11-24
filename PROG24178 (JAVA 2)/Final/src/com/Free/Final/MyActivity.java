package com.Free.Final;

import android.app.Activity;
import android.content.Context;
import android.content.res.Configuration;
import android.os.Bundle;
import android.view.MotionEvent;
import android.view.View;
import android.widget.ImageView;
import android.widget.RadioButton;
import android.widget.TextView;


import java.io.*;
import java.util.ArrayList;

public class MyActivity extends Activity {
    /**
     * Called when the activity is first created.
     */
    private String[] sTemp;
    private ArrayList<String> data0= new ArrayList<String>();//name
    private ArrayList<String>data1= new ArrayList<String>();//code
    private ArrayList<String>data2= new ArrayList<String>();//capital
    private ArrayList<String>data3= new ArrayList<String>();//Largest City
    private ArrayList<String>data4= new ArrayList<String>();//joined Canada
    private ArrayList<String>data5= new ArrayList<String>();//Population
    private ArrayList<String>data6= new ArrayList<String>();//Exports
    private ArrayList<String>data7= new ArrayList<String>();//imports
    private ArrayList<String>data8= new ArrayList<String>();//x
    private ArrayList<String>data9= new ArrayList<String>();//y
    private TextView out;
    private RadioButton geo;
    private Context appContext;
    private BufferedReader in;
    private String lay = "";
    private InputStream is;



    View.OnTouchListener TouchListener = new View.OnTouchListener()
    {
        public boolean onTouch(View view, MotionEvent motionEvent)
        {

            out = (TextView) findViewById(R.id.textView);
            geo = (RadioButton) findViewById(R.id.radioButton);
            float x  = motionEvent.getX();
            float y =  motionEvent.getY();
            for (int i=0;i < data0.size();i++)
            {
                if ((x > (Float.parseFloat(data8.get(i))-25) && x <(Float.parseFloat(data8.get(i))+25))&& (y>(Float.parseFloat(data9.get(i))-25)&& y <(Float.parseFloat(data9.get(i))+25)))
                {
                    if (geo.isChecked())
                    {
                        out.setText("Province: " +data0.get(i) +" "+ "Code: " +data1.get(i) + " " + "Capital: "+ data2.get(i) +" "+"Largest City: "+data3.get(i) +" "+ "Joined Canada: " + data4.get(i) + " "+ "Population: " + data5.get(i));
                        break;
                    }
                    else
                    {
                        out.setText("Province: " + data0.get(i) +" "+ "Exports: " + data6.get(i) +" "+ "Imports: " + data7.get(i));
                        break;
                    }
                }
                else
                {
                    out.setText("Touch One Of The Red Dots on Each Provinces");
                }
            }

            return false;
        }
    };
    public void open() {
        try {
            in = new BufferedReader(new InputStreamReader(is));
            boolean bMoreToDo = true;
            while (bMoreToDo) {
                String line;
                line = in.readLine();
                if (line == null) {
                    bMoreToDo = false;
                } else {
                    sTemp = line.split("\\|");
                }
                if (bMoreToDo) {

                    data0.add(sTemp[0]);
                    data1.add(sTemp[1]);
                    data2.add(sTemp[2]);
                    data3.add(sTemp[3]);
                    data4.add(sTemp[4]);
                    data5.add(sTemp[5]);
                    data6.add(sTemp[6]);
                    data7.add(sTemp[7]);
                    data8.add(sTemp[8]);
                    data9.add(sTemp[9]);
                }

            }
            in.close();
        } catch (NullPointerException e) {
            out.setText(e.getMessage());
        } catch (IOException e) {
            out.setText(e.getMessage());
        }
    }
public void screenSize ()
{
    if (((getResources().getConfiguration().screenLayout & Configuration.SCREENLAYOUT_SIZE_LARGE) == Configuration.SCREENLAYOUT_SIZE_LARGE)|| ((getResources().getConfiguration().screenLayout & Configuration.SCREENLAYOUT_SIZE_XLARGE) == Configuration.SCREENLAYOUT_SIZE_XLARGE))
    {
        is = appContext.getResources().openRawResource(R.raw.prov2);
        setContentView(R.layout.large);
    }
    else
    {
        is = appContext.getResources().openRawResource(R.raw.prov);
        setContentView(R.layout.normal);
    }
}

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        appContext = getApplicationContext();
        screenSize();
        out = (TextView) findViewById(R.id.textView);
        open();
        final ImageView map = (ImageView) findViewById(R.id.imageView);
        map.setOnTouchListener(TouchListener);
    }
}