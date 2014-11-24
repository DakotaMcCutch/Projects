package com.example.Fencing;

import android.app.Activity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.CheckBox;
import android.widget.EditText;
import android.widget.TextView;

import java.text.DecimalFormat;

public class MyActivity extends Activity {
    /**
     * Called when the activity is first created.
     */
    private double cost =0;
    private double yield ;
    DecimalFormat myFormat = new DecimalFormat("##.00");
    View.OnClickListener calc = new View.OnClickListener()
    {
        public void onClick (View v)
        {
            final CheckBox weather = (CheckBox) findViewById(R.id.checkBox);
            final TextView feet = (EditText) findViewById(R.id.editText);
            final TextView out = (EditText) findViewById(R.id.editText2);
            yield = Double.parseDouble(feet.getText().toString());

        if (weather.isChecked() == true)
        {
            cost = (10 * yield);
            out.setText("$ " + myFormat.format(cost));
        }
            else
        {
            cost = (8 * yield);
            out.setText("$ " + myFormat.format(cost));
        }
        }

    };
    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.main);
       final Button bCalc = (Button) findViewById(R.id.button);
        bCalc.setOnClickListener(calc);
    }
}
