using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace rFile1
{

    /*
     * 0-9 = 48 - 57
     * A-Z = 65 - 90
     * a-z = 97 - 122
     * . = 46
     * BackSpace = 8
     */
    public partial class Form1 : Form
    {
        private FileStream raFile = null;
        private DataTable myTable = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                raFile = new FileStream("accounts.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                if(raFile.Length != 4400)
                {
                    initializeFile();
                }
                createDataTableAndDisplay();
                readFile();
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message, "File load Error");
            }
            //key downs
           // listBox1.KeyDown += listBox1_KeyDown;
            txtBalance.KeyDown += txtBalance_KeyDown;
            dg1.KeyDown += dg1_KeyDown;
            //key pressess
            txtBalance.KeyPress += txtBalance_KeyPress;
            txtLastName.KeyPress += txtLastName_KeyPress;
            txtFirstName.KeyPress += txtFirstName_KeyPress;
            txtActNum.KeyPress += txtActNum_KeyPress;
            //clicks
            dg1.Click += dg1_Click;

            for(int i = 0; i < dg1.Columns.Count; i++)
            {
                dg1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            dg1.Columns["Balance"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dg1.ColumnHeadersDefaultCellStyle.BackColor = Color.Blue;
        }

        private void createDataTableAndDisplay()
        {
            //create table
            myTable = TableFactory.makeTable();
            // bind and display (desktop specific)
            bindingSource1.DataSource = myTable;
            dg1.DataSource = bindingSource1;

        }

        void txtBalance_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                setControlState("i");
            }
        }

        void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                setControlState("i");
            }
        }

        private void initializeFile()
        {
            MessageBox.Show("initializeFile() called");
            AccountRecordRA ra = new AccountRecordRA();
            try
            {
                //position file pointer
                raFile.Seek(0, SeekOrigin.Begin);
                for (int i = 0; i < 100; i++)
                {
                    ra.Write(raFile);
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message, "Error initializing file.");
            }
        }

        private void readFile()
        {
            //listBox1.Items.Clear();
            myTable.Rows.Clear();
            AccountRecordRA ra = new AccountRecordRA();
            try
            {
                //postion the file pointer
                raFile.Seek(0, SeekOrigin.Begin);
                for(int i = 0; i < 100; i++)
                {
                    ra.Read(raFile);
                    if(ra.Account > 0)
                    {
                        DataRow dr = myTable.NewRow();
                        dr["Account"] = ra.Account;
                        dr["FirstName"] = ra.FirstName;
                        dr["LastName"] = ra.LastName;
                        dr["Balance"] = ra.Balance.ToString("c");

                        myTable.Rows.Add(dr);

                       // listBox1.Items.Add(ra.Account + ";" + ra.FirstName + ";" + ra.LastName + ";" + ra.Balance.ToString("c"));//when you display a number as currency it is not a number its a string
                    }
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message, "ERROR Reading The File");
            }
        }

        private void cmdInsert_Click(object sender, EventArgs e)
        {
            if (dataGood())
            {
                int acct = Convert.ToInt32(txtActNum.Text);
                if (isValidAccount(acct))
                {
                    string fn = txtFirstName.Text;
                    string ln = txtLastName.Text;
                    double bal = Convert.ToDouble(txtBalance.Text);
                    AccountRecordRA ra = new AccountRecordRA(acct, fn, ln, bal);
                    try
                    {
                        //postion file pointer 
                        raFile.Seek((acct-1)* 44, SeekOrigin.Begin);
                        ra.Write(raFile);
                        readFile();
                        clearText();
                    }
                    catch (IOException ex)
                    {
                        MessageBox.Show(ex.Message, "error inserting Record");                       
                    }
                }
            }
        }

        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            if (dataGood())
            {
                int acct = Convert.ToInt32(txtActNum.Text);
                string fn = txtFirstName.Text;
                string ln = txtLastName.Text;
                string sBal = txtBalance.Text;

                if (sBal[0] == '$')
                {
                    sBal = sBal.Remove(0,1);// returns string

                }

                double bal = Convert.ToDouble(sBal);
                AccountRecordRA ra = new AccountRecordRA(acct, fn, ln, bal);
                try
                {
                    //positon file pointer
                    raFile.Seek((acct - 1) * 44, SeekOrigin.Begin);
                    ra.Write(raFile);
                    clearText();
                    readFile();
                }
                catch (IOException ex)
                {

                    MessageBox.Show(ex.Message, "ERROR Updateing Record");
                }
                setControlState("i");
            }
            
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure That You Want To Delete This Records", " Confirm Record Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning,MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
            {
                int acct = Convert.ToInt32(txtActNum.Text);
                AccountRecordRA ra = new AccountRecordRA();
                try
                {
                     //positon file pointer
                    raFile.Seek((acct - 1) * 44, SeekOrigin.Begin);
                    ra.Write(raFile);
                    clearText();
                    readFile();
                }
                catch (IOException ex)
                {

                    MessageBox.Show(ex.Message, "ERROR Deleting Record ");
                }
            }
            setControlState("i");
        }

        private void clearText()
        {
            txtActNum.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtBalance.Text = "";
            txtActNum.Focus();
            //listBox1.ClearSelected();

        }

        private bool dataGood()
        {
            if (txtActNum.Text.Length < 1)
            {
                MessageBox.Show("Account number required!", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtActNum.Focus();
                return false;
            }

            if (txtActNum.Text.Length == 3 && (Convert.ToInt32(txtActNum.Text) > 100))
            {
                MessageBox.Show("Account number must be between 1 to 100!", "Invalid Account Number", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtActNum.Focus();
                return false;
            }

            if (txtActNum.Text.Length < 1)
            {
                MessageBox.Show("First Name required!", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtActNum.Focus();
                return false;
            }

            if (txtLastName.Text.Length < 1)
            {
                MessageBox.Show("Last Name required!", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLastName.Focus();
                return false;
            }

            if (txtBalance.Text.Length < 1)
            {
                MessageBox.Show("Balance required!", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBalance.Focus();
                return false;
            }

            if (txtBalance.Text.Length == 1)
            {
                if (txtBalance.Text[0] == '$')
                {
                    MessageBox.Show("Balance value must be all numbers", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtActNum.Focus();
                    return false;
                }
            }

            return true;
        }

        private bool isValidAccount(int acct)
        {
            //for (int i = 0; i < listBox1.Items.Count; i++)
            //{
            //    int len = listBox1.Items[i].ToString().IndexOf(";");
            //    String sAcct = listBox1.Items[i].ToString().Substring(0, len);

            //    if (acct == Convert.ToInt32(sAcct))
            //    {
            //        MessageBox.Show("This Account exists!\nEnter new account number", "Invalid account number", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        txtAcct.Focus();
            //        return false;
            //    }
            //}






            // (this and the next for loop) iterate through all rows in datagridview to ensure unique Account Number
            //for (int i = 0; i < dg1.Rows.Count; i++)
            //{
            //    if(acct == Convert.ToInt32(dg1.Rows[i].Cells[0].Value))
            //    {
            //        MessageBox.Show("This Account exists!\nEnter new account number", "Invalid account number", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        txtAcct.Focus();
            //        return false;
            //    }
            //}

            for (int i = 0; i < myTable.Rows.Count; i++)
            {
                // treated like a 2D array acct == Convert.ToInt32(myTable.Rows[i].ItemArray[0] ([i] = row, [0] = column)
                if (acct == Convert.ToInt32(myTable.Rows[i][0]))
                {
                    MessageBox.Show("This Account exists!\nEnter new account number", "Invalid account number", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtActNum.Focus();
                    return false;
                }
            }

            return true;
        }

        private void setControlState(string state)
        {
            if (state.Equals("i"))
            {
                txtActNum.Enabled = true;
                txtFirstName.Enabled =true;
                txtLastName.Enabled = true;
                cmdInsert.Enabled = true;
                cmdDelete.Enabled = false;
                cmdUpdate.Enabled = false;
                lblActNum.Text = "Select An Item Below To Update or Delete";
                clearText();
            }
            else if (state.Equals("u/d"))
            {
                txtActNum.Enabled = false;
                txtFirstName.Enabled = false;
                txtLastName.Enabled = false;
                cmdInsert.Enabled = false;
                cmdDelete.Enabled = true;
                cmdUpdate.Enabled = true;
                lblActNum.Text = "Press Esc To Return To Insert Mode ";
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (listBox1.SelectedIndex > -1)
            //{
            //    string record = listBox1.Items[listBox1.SelectedIndex].ToString();
            //    string [] tokens = record.Split(new char[] { ';'});
            //    txtActNum.Text = tokens[0];
            //    txtFirstName.Text = tokens[1];
            //    txtLastName.Text = tokens[2];
            //    txtBalance.Text = tokens[3];
            //    setControlState("u/d");
            //}
        }

        void dg1_Click(object sender, EventArgs e)
        {
            txtActNum.Text = dg1.CurrentRow.Cells["Account"].Value.ToString();
            txtFirstName.Text = dg1.CurrentRow.Cells["FirstName"].Value.ToString();
            txtLastName.Text = dg1.CurrentRow.Cells["LastName"].Value.ToString();
            txtBalance.Text = dg1.CurrentRow.Cells["Balance"].Value.ToString();
            setControlState("u/d");
        }

        void txtActNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            int c = e.KeyChar;
            int len = ((TextBox)sender).Text.Length; ((TextBox)sender).SelectionStart = len;
            if (c != 8)
            {
                if (len == 0 && (c < 49 || c > 58))
                {
                    e.Handled = true;
                }
                else if (len > 0 && (c < 48 || c > 57))
                {
                    e.Handled = true;
                }
            }
        }

        void txtFirstName_KeyPress(object sender, KeyPressEventArgs e)
        {
            /*
     * 0-9 = 48 - 57
     * A-Z = 65 - 90
     * a-z = 97 - 122
     * . = 46
     * BackSpace = 8
     */
            int c = e.KeyChar;
            int len = ((TextBox)sender).Text.Length;
            ((TextBox)sender).SelectionStart = len;
            if (c != 8)
            {
                if ((c < 65 || c > 90) && (c < 97 || c > 122))
                {
                    e.Handled = true;
                }
                else if (len == 0 && (c > 96 && c < 123))
                {
                    e.KeyChar = (char)(c - 32);
                }
                else if (len > 0 && (c > 64 && c < 91))
                {
                    e.KeyChar = (char)(c + 32);
                }
            }
        }
            void dg1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                setControlState("i");
            }
        }

        void txtLastName_KeyPress(object sender, KeyPressEventArgs e)
        {
            int c = e.KeyChar;
            int len = ((TextBox)sender).Text.Length;
            ((TextBox)sender).SelectionStart = len;
            if (c != 8)
            {
                if ((c < 65 || c > 90) && (c < 97 || c > 122))
                {
                    e.Handled = true;
                }
                else if (len == 0 && (c > 96 && c < 123))
                {
                    e.KeyChar = (char)(c - 32);
                }
                else if (len > 0 && (c > 64 && c < 91))
                {
                    e.KeyChar = (char)(c + 32);
                }
            }
        }

        void txtBalance_KeyPress(object sender, KeyPressEventArgs e)
        {
            int c = e.KeyChar;
            int len = ((TextBox)sender).Text.Length;

            // set selection to length of textbox
            ((TextBox)sender).SelectionStart = len;
            if(c != 8)
            {
                // if length is 0 and c is not a numeric value
                if (len == 0 && (c < 48 || c > 57))
                {
                    // does not accept anything other than a number - handled = true 
                    // effectively does nothing
                    e.Handled = true;
                }
                // this logic will be on MID-TERM
                /*
                 * IF NOT NUMBER
                 *   IF DECIMAL
                 *     IF DECIMAL ALREADY EXISTS
                 *        KILL CHAR
                 * ELSE
                 *   KILL CHAR
                 */

                // else if a number between 0 and 9
                else if (c < 48 || c > 57)
                {
                    // if a decimal
                    if (c == 46)
                    {
                        // if decimal exists
                        if (((TextBox)sender).Text.IndexOf(".") > -1)
                        {
                            // kill extra decimal
                            e.Handled = true;
                        }
                    }
                    else
                    {
                        // kill characters
                        e.Handled = true;
                    }

                }
                // accept only 2 places after decimal point
                else if (((TextBox)sender).Text.IndexOf(".") > -1)
                {
                    // if anything is attempted beyond 2 decimal places, kill it
                    if (len == ((TextBox)sender).Text.IndexOf(".") + 3)
                    {
                        e.Handled = true;
                    }
                }
            }
        }
    }
}