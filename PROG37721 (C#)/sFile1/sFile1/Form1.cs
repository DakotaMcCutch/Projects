using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace sFile1
{
    public partial class Form1 : Form
    {
        string path = "test1.txt";
        int index = -1;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtName.KeyPress += txtName_KeyPress;
            txtPhoneNumber.KeyPress += txtPhoneNumber_KeyPress;
            txtPhoneNumber.ContextMenu = new System.Windows.Forms.ContextMenu();
            txtName.ContextMenu = new System.Windows.Forms.ContextMenu();
            readFile();
        }

        private void txtPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            int c = e.KeyChar;
            int len = txtPhoneNumber.Text.Length;
            txtPhoneNumber.SelectionStart = len;
            if (c != 8)
            {
                if(len ==3 || len ==7)//dash only
                {
                    if (c != 45)
                    {
                        //not dash.....kill char
                        e.Handled = true;
                    }

                }
                else// numeric only
                {
                    if (c < 48 || c >57 )
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            int c = e.KeyChar;
            int len = ((TextBox)sender).Text.Length;
            ((TextBox)sender).SelectionStart = len;
            if (c != 8)
            {
                if ((c < 63 || c >90) && (c < 97 || c > 122) && (c!= 32))
                {
                    //not letter AND not Space
                    e.Handled = true;
                }
                if (len < 2)
                {
                    if (c == 32)
                    {
                        e.Handled = true;
                    }
                    else if (len == 0 && (c > 96 && c < 123))
                    {
                        // first char lower case
                        e.KeyChar = (char) (c-32);
                    }
                    else if  ( len > 0 && (c < 91 && c > 64))
                    {
                        e.KeyChar = (char)(c + 32);
                    }
                }
                else
                {
                    if(((TextBox)sender).Text.IndexOf(" ") == -1)
                    {
                        //no space
                        if(c > 64 && c < 91)//char captial ..... for first
                        {
                            e.KeyChar = (char)(c + 32);//to lower
                        }
                    }
                    else if (c == 32)//space
                    {
                        if(((TextBox)sender).Text.IndexOf(" ") > -1)
                        {
                            //space exists
                            e.Handled = true;
                        }
                    }
                    else if (((TextBox)sender).Text.IndexOf(" ") == len -1)
                    {
                        if (c > 96 && c < 123)
                        {
                            e.KeyChar = (char)(c - 32);
                        }
                    }
                    else if (((TextBox)sender).Text.IndexOf(" ") < len -1)
                    {
                        if (c> 64 && c <91 )
                        {
                            e.KeyChar = (char)(c + 32);
                        }
                    }
                }
            }
        }
        private void readFile()
        {
            listBox1.Items.Clear();
            StreamReader sr = new StreamReader(path);
            string record = sr.ReadLine();
            while (record != null)
            {
                //do somthing with record
                // ListBoxs contain one or more items
                listBox1.Items.Add(record);
                record = sr.ReadLine();
            }
            sr.Close();

        }
        private bool dataGood()
        {
            if (txtName.Text.Length < 1)
            {
                MessageBox.Show ("First Name Required","Missing first Name",MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtName.Focus();
                return false;
            } 
            if (txtName.Text.Length ==1)
            {

                MessageBox.Show("First Name must contain 2 or more characters", "Invalid First Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtName.Focus();
                return false;
            }
            if ( txtName.Text.Length > 1)
            {
                if (txtName.Text.IndexOf (" ") == -1 || txtName.Text.IndexOf(" ") == txtName.Text.Length - 1)
                {
                    MessageBox.Show("Last Name Required", "Missing last Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtName.Focus();
                    return false;
                }
                if (txtName.Text.IndexOf(" ") == txtName.Text.Length - 2)
                {
                    MessageBox.Show("Last Name must contain 2 or more characters", "Invalid Last Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtName.Focus();
                    return false;
                }
            }
            if (txtPhoneNumber.Text.Length < 1)
            {
                MessageBox.Show("Phone Number required!", "missing Phone Number", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPhoneNumber.Focus();
                return false;
            }
            if (txtPhoneNumber.Text.Length !=12)
            {
                MessageBox.Show("Phone Number must conform to pattern above!", "invalid Phone Number", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPhoneNumber.Focus();
                return false;
            }
            return true;
        }
        private void setControlState(string state)
        {
           if(state.Equals("i"))
           {
               cmdInsert.Text = "Insert Record";
               cmdDelete.Enabled = false;
               cmdUpdate.Enabled = false;
               clearText();
           }
           else if (state.Equals("u/d"))
           {
               cmdInsert.Text = "Return to Insert Mode";
               cmdDelete.Enabled = true;
               cmdUpdate.Enabled = true;
           }
        }
        private void clearText()
        {
            txtName.Text = "";
            txtPhoneNumber.Text = "";
            txtName.Focus();
            listBox1.ClearSelected();
        }

        private void cmdInsert_Click(object sender, EventArgs e)
        {
            if(cmdInsert.Text.Equals("Return to Insert Mode"))
            {
                setControlState("i");
                return;
            }
            if (dataGood())
            {
                StreamWriter sw = new StreamWriter(path, true);
                sw.WriteLine(txtName.Text + "," + txtPhoneNumber.Text);
                sw.Close();
                readFile();
                clearText();
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            index = listBox1.SelectedIndex;
            if (index > -1)
            {
                string record = listBox1.Items[index].ToString();

                char[] delim = { ','};
                string[] tokens = record.Split(delim);
                txtName.Text = tokens[0];
                txtPhoneNumber.Text = tokens[1];
                setControlState("u/d");
            }
        }

        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            if(dataGood())
            {
                File.Delete(path);
                StreamWriter sw = new StreamWriter(path, true);
                for (int i = 0; i < listBox1.Items.Count; i++ )
                {
                    if (i != index)
                    {
                        sw.WriteLine(listBox1.Items[i].ToString());
                    }
                    else
                    {
                        sw.WriteLine(txtName.Text + "," + txtPhoneNumber.Text);

                    }
                }
                sw.Close();
                readFile();
                setControlState("i");

            }
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
           if( MessageBox.Show ("Are You Sure You Want To Delete This Record?", "Confirm Record Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning,MessageBoxDefaultButton.Button2)== System.Windows.Forms.DialogResult.Yes)
           {
               File.Delete(path);
               StreamWriter sw = new StreamWriter(path, true);
               for (int i = 0; i < listBox1.Items.Count; i++)
               {
                   if (i != index)
                   {
                       sw.WriteLine(listBox1.Items[i].ToString());
                   }
               }
               sw.Close();
               readFile();
               setControlState("i");
           }
        }

    }
}
