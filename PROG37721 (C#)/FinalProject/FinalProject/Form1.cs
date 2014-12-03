﻿using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FinalProject
{
    public partial class Form1 : Form
    {
        private SqlConnection conn = null;
        private SqlDataAdapter da = null;
        private DataSet ds = null;
        private int rowIndex = -1;
        private string gender = "";
        private string marital = "";
        private string relation = "";
        private string dentConsent = "No";
        private string physConsent = "No";

        public Form1()
        {
            InitializeComponent();
        }

        private void startUp()
        {
            dtpDOB.MinDate = DateTime.Today.AddYears(-99);
            dtpDOB.MaxDate = DateTime.Today;
            dtpDOB.Text = DateTime.Today.ToString();
            dtpDOB.CustomFormat = "MM/dd/yyyy";
            dtpDOB.Format = DateTimePickerFormat.Custom;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            startUp();
            setControlState("i");
            dg1.Click += dg1_Click;
            dg1.KeyDown += dg1_KeyDown;
            dtpDOB.ValueChanged += dtpDOB_ValueChanged;
            txtName.KeyPress += txtName_KeyPress;
            txtGuardName.KeyPress += txtName_KeyPress;
            txtEmergName.KeyPress += txtName_KeyPress;
            txtFormerDent.KeyPress += txtName_KeyPress;
            txtDoctor.KeyPress += txtName_KeyPress;
            txtHomePhoneNum.KeyPress += txtPhoneNum_KeyPress;
            txtMobilePhoneNum.KeyPress += txtPhoneNum_KeyPress;
            txtEmergHome.KeyPress += txtPhoneNum_KeyPress;
            txtEmergMobile.KeyPress += txtPhoneNum_KeyPress;
            txtInsurancePhoneNum.KeyPress += txtPhoneNum_KeyPress;
            txtDoctorNum.KeyPress += txtPhoneNum_KeyPress;
            txtDentNum.KeyPress += txtPhoneNum_KeyPress;
            txtSSNum.KeyPress += txtSSNum_KeyPress;
            txtProv.KeyPress += txtProv_KeyPress;
            txtInsurProv.KeyPress += txtProv_KeyPress;
            txtPolicyNum.KeyPress += txtPolicyNum_KeyPress;
            txtCity.KeyPress += txtCity_KeyPress;
            txtInsurCity.KeyPress += txtCity_KeyPress;
            txtStreet.KeyPress += txtStreet_KeyPress;
            txtInsurStreet.KeyPress += txtStreet_KeyPress;
            txtInCompany.KeyPress += txtInCompany_KeyPress;
            txtAptNum.KeyPress += txtAptNum_KeyPress;
            txtInsurOfficeNum.KeyPress += txtAptNum_KeyPress;
            txtZip.KeyPress += txtZip_KeyPress;
            txtInsurZip.KeyPress += txtZip_KeyPress;
            txtEmpSch.KeyPress += txtEmpSch_KeyPress;
            txtPatientId.KeyPress += txtPatientId_KeyPress;

            TextBox[] t = { txtPatientId, txtName, txtGuardName, txtStreet, txtAptNum, txtCity, txtProv, txtZip, txtHomePhoneNum, txtMobilePhoneNum, txtEmpSch, txtEmergName, txtEmergHome, txtEmergMobile, txtInCompany, txtSSNum, txtPolicyNum, txtInsurStreet, txtInsurOfficeNum, txtInsurCity, txtInsurProv, txtInsurZip, txtPolicyNum, txtInsurancePhoneNum, txtFormerDent, txtDentNum, txtDoctor, txtDoctorNum };

            foreach (TextBox tb in t)
            {
                tb.ContextMenu = new System.Windows.Forms.ContextMenu();

                tb.ShortcutsEnabled = false;
            }
            getData();
        }

        private void dtpDOB_ValueChanged(object sender, EventArgs e)
        {
            SendKeys.Send("{Right}");
        }

        private void dg1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                setControlState("i");
            }
            else if (e.KeyCode == Keys.Tab)
            {
                populateGrid();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                populateGrid();
            }
        }

        private void txtPatientId_KeyPress(object sender, KeyPressEventArgs e)
        {
            int c = e.KeyChar;
            int len = ((TextBox)sender).Text.Length;
            ((TextBox)sender).SelectionStart = len;
            if (c != 8)
            {
                if (c < 48 || c > 57)
                {
                    e.Handled = true;
                }
            }
        }

        private void txtEmpSch_KeyPress(object sender, KeyPressEventArgs e)
        {
            int c = e.KeyChar;
            int len = ((TextBox)sender).Text.Length;
            ((TextBox)sender).SelectionStart = len;
            int iCount = ((TextBox)sender).Text.Split(' ').Length - 1;
            int iAnd = ((TextBox)sender).Text.Split('&').Length - 1;
            int iDot = ((TextBox)sender).Text.Split('.').Length - 1;
            if (c != 8)
            {
                if ((c < 63 || c > 90) && (c < 97 || c > 122) && (c != 32) && (c != 38) && (c != 46) && (c < 48 || c > 57))
                {
                    e.Handled = true;
                }
                if (c != 8)
                {
                    if (c == 32)
                    {
                        if (((TextBox)sender).Text.Length < 1)
                        {
                            e.Handled = true;
                        }
                        if (iCount >= 1 && ((TextBox)sender).Text.LastIndexOf(" ") == len - 1)
                        {
                            e.Handled = true;
                        }
                    }
                    else if (c == 38)
                    {
                        if (((TextBox)sender).Text.Length < 1)
                        {
                            e.Handled = true;
                        }
                        if (iAnd >= 1 && ((TextBox)sender).Text.LastIndexOf("&") == len - 1)
                        {
                            e.Handled = true;
                        }
                    }
                    else if (c == 46)
                    {
                        if (((TextBox)sender).Text.Length < 1)
                        {
                            e.Handled = true;
                        }
                        if (iDot >= 1 && ((TextBox)sender).Text.LastIndexOf(".") == len - 1)
                        {
                            e.Handled = true;
                        }
                    }
                    else if (len > 150)
                    {
                        e.Handled = true;
                    }
                    else
                    {
                        if ((c < 65 || c > 90) && (c < 97 || c > 122) && (c < 48 || c > 57))// not Letter
                        {
                            e.Handled = true;
                        }
                        if ((((TextBox)sender).Text.LastIndexOf(" ") == len - 1) && (c > 96 && c < 123))//space first char lower
                        {
                            e.KeyChar = (char)(c - 32);
                        }
                        else if ((((TextBox)sender).Text.LastIndexOf(" ") < len - 1) && (c > 64 && c < 91))//space first char uppercase
                        {
                            e.KeyChar = (char)(c + 32);
                        }
                    }
                }
            }
        }

        private void txtZip_KeyPress(object sender, KeyPressEventArgs e)
        {
            int c = e.KeyChar;
            int len = ((TextBox)sender).Text.Length;
            ((TextBox)sender).SelectionStart = len;
            if (c != 8)
            {
                if ((c < 63 || c > 90) && (c < 97 || c > 122) && (c != 32) && (c < 48 || c > 57))
                {
                    e.Handled = true;
                }
                else
                {
                    if ((len == 0) || (len == 2) || (len == 5))
                    {
                        if (c > 96 && c < 123)
                        {
                            e.KeyChar = (char)(c - 32);
                        }
                        else
                        {
                            e.Handled = true;
                        }
                    }
                    else if (len == 3)
                    {
                        if ((c != 32))
                        {
                            if ((c < 48 || c > 57))
                            {
                                e.Handled = true;
                            }
                            else
                            {
                                SendKeys.SendWait(" ");
                            }
                        }
                    }
                    else if ((len == 1) || (len == 4) || (len == 6))
                    {
                        if (c < 48 || c > 57)
                        {
                            e.Handled = true;
                        }
                    }
                    if (len > 6)
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        private void txtAptNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            int c = e.KeyChar;
            int len = ((TextBox)sender).Text.Length;
            ((TextBox)sender).SelectionStart = len;
            if (c != 8)
            {
                if (c < 48 || c > 57)
                {
                    e.Handled = true;
                }
            }
        }

        private void txtInCompany_KeyPress(object sender, KeyPressEventArgs e)
        {
            int c = e.KeyChar;
            int len = ((TextBox)sender).Text.Length;
            ((TextBox)sender).SelectionStart = len;
            int iCount = ((TextBox)sender).Text.Split(' ').Length - 1;
            int iAnd = ((TextBox)sender).Text.Split('&').Length - 1;
            int iDot = ((TextBox)sender).Text.Split('.').Length - 1;
            if (c != 8)
            {
                if ((c < 63 || c > 90) && (c < 97 || c > 122) && (c != 32) && (c != 38) && (c != 46) && (c < 48 || c > 57))
                {
                    e.Handled = true;
                }
                if (c != 8)
                {
                    if (c == 32)
                    {
                        if (((TextBox)sender).Text.Length < 1)
                        {
                            e.Handled = true;
                        }
                        if (iCount >= 1 && ((TextBox)sender).Text.LastIndexOf(" ") == len - 1)
                        {
                            e.Handled = true;
                        }
                    }
                    else if (c == 38)
                    {
                        if (((TextBox)sender).Text.Length < 1)
                        {
                            e.Handled = true;
                        }
                        if (iAnd >= 1 && ((TextBox)sender).Text.LastIndexOf("&") == len - 1)
                        {
                            e.Handled = true;
                        }
                    }
                    else if (c == 46)
                    {
                        if (((TextBox)sender).Text.Length < 1)
                        {
                            e.Handled = true;
                        }
                        if (iDot >= 1 && ((TextBox)sender).Text.LastIndexOf(".") == len - 1)
                        {
                            e.Handled = true;
                        }
                    }
                    else if (len > 150)
                    {
                        e.Handled = true;
                    }
                    else
                    {
                        if ((c < 65 || c > 90) && (c < 97 || c > 122) && (c < 48 || c > 57))// not Letter
                        {
                            e.Handled = true;
                        }
                        if ((((TextBox)sender).Text.LastIndexOf(" ") == len - 1) && (c > 96 && c < 123))//space first char lower
                        {
                            e.KeyChar = (char)(c - 32);
                        }
                        else if ((((TextBox)sender).Text.LastIndexOf(" ") < len - 1) && (c > 64 && c < 91))//space first char uppercase
                        {
                            e.KeyChar = (char)(c + 32);
                        }
                    }
                }
            }
        }

        private void txtStreet_KeyPress(object sender, KeyPressEventArgs e)
        {
            int c = e.KeyChar;
            int len = ((TextBox)sender).Text.Length;
            ((TextBox)sender).SelectionStart = len;
            int iCount = ((TextBox)sender).Text.Split(' ').Length - 1;
            if (c != 8)
            {
                if (c == 32)
                {
                    if (((TextBox)sender).Text.Length < 1)
                    {
                        e.Handled = true;
                    }
                    if (iCount == 1 && ((TextBox)sender).Text.IndexOf(" ") == len - 1)
                    {
                        e.Handled = true;
                    }
                }
                else
                {
                    if (((TextBox)sender).Text.IndexOf(" ") == -1 && (c < 48 || c > 57))//not a number
                    {
                        e.Handled = true;
                    }
                    else if ((c > 47 || c < 58) && (((TextBox)sender).Text.IndexOf(" ") == -1) && len > 8)//limit the street number
                    {
                        e.Handled = true;
                    }
                    else if (((TextBox)sender).Text.LastIndexOf(" ") > -1)//first space
                    {
                        if (((TextBox)sender).Text.LastIndexOf(" ") == -1 && (c < 48 || c > 57))//not a number
                        {
                            e.Handled = true;
                        }
                        else if ((((TextBox)sender).Text.LastIndexOf(" ") > -1) && (c > 47 && c < 58))
                        {
                            e.Handled = true;
                        }
                        if ((c < 65 || c > 90) && (c < 97 || c > 122))// not Letter
                        {
                            e.Handled = true;
                        }
                        if ((((TextBox)sender).Text.LastIndexOf(" ") == len - 1) && (c > 96 && c < 123))//space first char lower
                        {
                            e.KeyChar = (char)(c - 32);
                        }
                        else if ((((TextBox)sender).Text.LastIndexOf(" ") < len - 1) && (c > 64 && c < 91))//space first char uppercase
                        {
                            e.KeyChar = (char)(c + 32);
                        }
                    }
                }
            }
        }

        private void txtCity_KeyPress(object sender, KeyPressEventArgs e)
        {
            int c = e.KeyChar;
            int len = ((TextBox)sender).Text.Length;
            ((TextBox)sender).SelectionStart = len;
            if (c != 8)
            {
                if ((c < 63 || c > 90) && (c < 97 || c > 122) && (c != 32))
                {
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
                        e.KeyChar = (char)(c - 32);
                    }
                    else if (len > 0 && (c < 91 && c > 64))
                    {
                        e.KeyChar = (char)(c + 32);
                    }
                }
                else
                {
                    if (c == 32)
                    {
                        e.Handled = true;
                    }
                    else if (len == 0 && (c > 96 && c < 123))
                    {
                        e.KeyChar = (char)(c - 32);
                    }
                    else if (len > 0 && (c < 91 && c > 64))
                    {
                        e.KeyChar = (char)(c + 32);
                    }
                }
            }
        }

        private void txtPolicyNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            int c = e.KeyChar;
            int len = ((TextBox)sender).Text.Length;
            ((TextBox)sender).SelectionStart = len;
            if (c != 8)
            {
                if (c < 48 || c > 57)
                {
                    e.Handled = true;
                }
            }
        }

        private void txtProv_KeyPress(object sender, KeyPressEventArgs e)
        {
            int c = e.KeyChar;
            int len = ((TextBox)sender).Text.Length;
            ((TextBox)sender).SelectionStart = len;
            if (c != 8)
            {
                if ((c < 63 || c > 90) && (c < 97 || c > 122) && (c != 32))
                {
                    e.Handled = true;
                }
                if (len > 1)
                {
                    e.Handled = true;
                }
                else
                {
                    if (c == 32)
                    {
                        e.Handled = true;
                    }
                    else if (len >= 0 && (c > 96 && c < 123))
                    {
                        e.KeyChar = (char)(c - 32);
                    }
                }
            }
        }

        private void txtSSNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            int c = e.KeyChar;
            int len = ((TextBox)sender).Text.Length;
            ((TextBox)sender).SelectionStart = len;
            if (c != 8)
            {
                if (len == 3 || len == 7)
                {
                    if (c != 32)
                    {
                        if ((c < 48 || c > 57))
                        {
                            e.Handled = true;
                        }
                        else
                        {
                            SendKeys.SendWait(" ");
                        }
                    }
                }
                else
                {
                    if (c < 48 || c > 57)
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        private void txtPhoneNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            int c = e.KeyChar;
            int len = ((TextBox)sender).Text.Length;
            ((TextBox)sender).SelectionStart = len;
            if (c != 8)
            {
                if (len == 3 || len == 7)
                {
                    if (c != 45)
                    {
                        if ((c < 48 || c > 57))
                        {
                            e.Handled = true;
                        }
                        else
                        {
                            SendKeys.SendWait("-");
                        }
                    }
                }
                else
                {
                    if (c < 48 || c > 57)
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
                if ((c < 63 || c > 90) && (c < 97 || c > 122) && (c != 32))
                {
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
                        e.KeyChar = (char)(c - 32);
                    }
                    else if (len > 0 && (c < 91 && c > 64))
                    {
                        e.KeyChar = (char)(c + 32);
                    }
                }
                else
                {
                    if (((TextBox)sender).Text.IndexOf(" ") == -1)
                    {
                        if (c > 64 && c < 91)
                        {
                            e.KeyChar = (char)(c + 32);
                        }
                    }
                    else if (c == 32)
                    {
                        if (((TextBox)sender).Text.IndexOf(" ") > -1)
                        {
                            e.Handled = true;
                        }
                    }
                    else if (((TextBox)sender).Text.IndexOf(" ") == len - 1)
                    {
                        if (c > 96 && c < 123)
                        {
                            e.KeyChar = (char)(c - 32);
                        }
                    }
                    else if (((TextBox)sender).Text.IndexOf(" ") < len - 1)
                    {
                        if (c > 64 && c < 91)
                        {
                            e.KeyChar = (char)(c + 32);
                        }
                    }
                }
            }
        }

        private void dg1_Click(object sender, EventArgs e)
        {
            populateGrid();
        }

        private void populateGrid()
        {
            if (dg1.Rows.Count != 0)
            {
                dg1.CurrentRow.Selected = true;
                rowIndex = dg1.CurrentRow.Index;
                // align rowIndex with index of selection in DataSet table
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (ds.Tables[0].Rows[i].RowState != DataRowState.Deleted)
                    {
                        if (dg1.CurrentRow.Cells[0].Value.ToString().Equals(ds.Tables[0].Rows[i][0].ToString()))
                        {
                            rowIndex = i;
                            break;
                        }
                    }
                }

                TextBox[] t = { txtPatientId, txtName, txtGuardName, txtStreet, txtAptNum, txtCity, txtProv, txtZip, txtHomePhoneNum, txtMobilePhoneNum, txtEmpSch, txtEmergName, txtEmergHome, txtEmergMobile, txtInCompany, txtSSNum, txtPolicyNum, txtInsurStreet, txtInsurOfficeNum, txtInsurCity, txtInsurProv, txtInsurZip, txtInsurancePhoneNum, txtFormerDent, txtDentNum, txtDoctor, txtDoctorNum };
                int iCount = 0;
                for (int i = 0; i < t.Length + 6; i++)
                {
                    if ((i == 2) || (i == 3) || (i == 4) || (i == 26) || (i == 29) || (i == 32))
                    {
                        if (i == 2)
                        {
                            dtpDOB.Value = Convert.ToDateTime((dg1.CurrentRow.Cells[2].Value.ToString()));
                            if ((dg1.CurrentRow.Cells[3].Value.ToString()).Equals("Male"))
                            {
                                optMale.Checked = true;
                            }
                            else if ((dg1.CurrentRow.Cells[3].Value.ToString()).Equals("Female"))
                            {
                                optFemale.Checked = true;
                            }

                            if (dg1.CurrentRow.Cells[4].Value.ToString().Equals("Child"))
                            {
                                optChild.Checked = true;
                            }
                            else if (dg1.CurrentRow.Cells[4].Value.ToString().Equals("Single"))
                            {
                                optSingle.Checked = true;
                            }
                            else if (dg1.CurrentRow.Cells[4].Value.ToString().Equals("Married"))
                            {
                                optMarried.Checked = true;
                            }
                            else if (dg1.CurrentRow.Cells[4].Value.ToString().Equals("Divorced"))
                            {
                                optDivorced.Checked = true;
                            }
                            else if (dg1.CurrentRow.Cells[4].Value.ToString().Equals("Widow"))
                            {
                                optWidow.Checked = true;
                            }
                            if (dg1.CurrentRow.Cells[26].Value.ToString().Equals("Self"))
                            {
                                optSelf.Checked = true;
                            }
                            else if (dg1.CurrentRow.Cells[26].Value.ToString().Equals("Spouse"))
                            {
                                optSpouse.Checked = true;
                            }
                            else if (dg1.CurrentRow.Cells[26].Value.ToString().Equals("Dependent"))
                            {
                                optDependent.Checked = true;
                            }
                            if (dg1.CurrentRow.Cells[29].Value.ToString().Equals("Yes"))
                            {
                                chkDentConsent.Checked = true;
                            }
                            else
                            {
                                chkDentConsent.Checked = false;
                            }
                            if (dg1.CurrentRow.Cells[32].Value.ToString().Equals("Yes"))
                            {
                                chkDocConsent.Checked = true;
                            }
                            else
                            {
                                chkDocConsent.Checked = false;
                            }
                        }
                    }
                    else
                    {
                        t[iCount].Text = dg1.CurrentRow.Cells[i].Value.ToString();
                        iCount++;
                    }
                    setControlState("u/d");
                }
            }
        }

        private void cmdInsert_Click(object sender, EventArgs e)
        {
            getOptions();
            string[] columns = { "id", "Name", "DOB", "Gender", "MaritalStatus", "GuardianName", "AStreet", "AAptNum", "ACity", "AProvince", "AZip", "HomePhone", "MobilePhone", "Employer", "EmergName", "EmergHome", "EmergMobile", "InCompany", "SSNum", "PolicyNum", "InStreet", "InOffNum", "InCity", "InProvince", "InZip", "PolicyNum", "InPhone", "Relationship", "DentName", "DentPhone", "DentConsent", "PhysName", "PhysPhone", "PhysConsent" };

            TextBox[] t = { txtPatientId, txtName, txtGuardName, txtStreet, txtAptNum, txtCity, txtProv, txtZip, txtHomePhoneNum, txtMobilePhoneNum, txtEmpSch, txtEmergName, txtEmergHome, txtEmergMobile, txtInCompany, txtSSNum, txtPolicyNum, txtInsurStreet, txtInsurOfficeNum, txtInsurCity, txtInsurProv, txtInsurZip, txtPolicyNum, txtInsurancePhoneNum, txtFormerDent, txtDentNum, txtDoctor, txtDoctorNum };
            if (validInfo())
            {
                getOptions();
                if (validPrimaryKey("i"))
                {
                    string connStr = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|Database.mdf;Integrated Security=True";
                    SqlConnection conn = new SqlConnection(connStr);
                    conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    string sql = "SELECT [id] FROM [Patients] WHERE [id] = '" + txtPatientId.Text + "'";
                    cmd.CommandText = sql;
                    DataRow dr = ds.Tables["Patients"].NewRow();
                    SqlDataReader dataReader = cmd.ExecuteReader();

                    if (dataReader.HasRows)
                    {
                        dataReader.Close();
                        conn.Close();
                    }
                    else
                    {
                        dr["id"] = Convert.ToInt32(txtPatientId.Text);
                        int iCount = 0;
                        for (int i = 0; i < columns.Length; i++)
                        {
                            if (i == 2)
                            {
                                dr[columns[i]] = dtpDOB.Text.ToString();
                            }
                            else if (i == 3)
                            {
                                dr[columns[i]] = gender;
                            }
                            else if (i == 4)
                            {
                                dr[columns[i]] = marital;
                            }
                            else if (i == 27)
                            {
                                dr[columns[i]] = relation;
                            }
                            else if (i == 30)
                            {
                                dr[columns[i]] = dentConsent;
                            }
                            else if (i == 33)
                            {
                                dr[columns[i]] = physConsent;
                            }
                            else
                            {
                                dr[columns[i]] = t[iCount].Text;
                                iCount++;
                            }
                        }
                        ds.Tables["Patients"].Rows.Add(dr);
                        da.Update(ds, "Patients");
                        formatGrid();
                        clearText();
                    }
                }
                else
                {
                    return;
                }
            }
        }

        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            string[] columns = { "id", "Name", "DOB", "Gender", "MaritalStatus", "GuardianName", "AStreet", "AAptNum", "ACity", "AProvince", "AZip", "HomePhone", "MobilePhone", "Employer", "EmergName", "EmergHome", "EmergMobile", "InCompany", "SSNum", "PolicyNum", "InStreet", "InOffNum", "InCity", "InProvince", "InZip", "PolicyNum", "InPhone", "Relationship", "DentName", "DentPhone", "DentConsent", "PhysName", "PhysPhone", "PhysConsent" }
        ;

            TextBox[] t = { txtPatientId, txtName, txtGuardName, txtStreet, txtAptNum, txtCity, txtProv, txtZip, txtHomePhoneNum, txtMobilePhoneNum, txtEmpSch, txtEmergName, txtEmergHome, txtEmergMobile, txtInCompany, txtSSNum, txtPolicyNum, txtInsurStreet, txtInsurOfficeNum, txtInsurCity, txtInsurProv, txtInsurZip, txtPolicyNum, txtInsurancePhoneNum, txtFormerDent, txtDentNum, txtDoctor, txtDoctorNum }
        ;
            if (validInfo())
            {
                getOptions();
                if (validPrimaryKey("u"))
                {
                    DataRow dr = ds.Tables[0].Rows[rowIndex];
                    dr["id"] = Convert.ToInt32(txtPatientId.Text);
                    int iCount = 0;
                    for (int i = 0; i < columns.Length; i++)
                    {
                        if (i == 2)
                        {
                            dr[columns[i]] = dtpDOB.Text.ToString();
                        }
                        else if (i == 3)
                        {
                            dr[columns[i]] = gender;
                        }
                        else if (i == 4)
                        {
                            dr[columns[i]] = marital;
                        }
                        else if (i == 27)
                        {
                            dr[columns[i]] = relation;
                        }
                        else if (i == 30)
                        {
                            dr[columns[i]] = dentConsent;
                        }
                        else if (i == 33)
                        {
                            dr[columns[i]] = physConsent;
                        }
                        else
                        {
                            dr[columns[i]] = t[iCount].Text;
                            iCount++;
                        }
                    }
                    da.Update(ds, "Patients");
                    clearText();
                    setControlState("i");
                    formatGrid();
                    dg1.ClearSelection();
                }
            }
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to delete this record?", "Confirm Record Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
                {
                    ds.Tables[0].Rows[rowIndex].Delete();
                    da.Update(ds, "Patients");
                }
            }
            catch (IndexOutOfRangeException)
            {
                MessageBox.Show("No Record Selected!", "Delete Record Error");
                return;
            }
            setControlState("i");
            formatGrid();
            dg1.ClearSelection();
        }

        private void clearText()
        {
            TextBox[] t = { txtPatientId, txtName, txtGuardName, txtStreet, txtAptNum, txtCity, txtProv, txtZip, txtHomePhoneNum, txtMobilePhoneNum, txtEmpSch, txtEmergName, txtEmergHome, txtEmergMobile, txtInCompany, txtSSNum, txtPolicyNum, txtInsurStreet, txtInsurOfficeNum, txtInsurCity, txtInsurProv, txtInsurZip, txtPolicyNum, txtInsurancePhoneNum, txtFormerDent, txtDentNum, txtDoctor, txtDoctorNum };

            foreach (TextBox tb in t)
            {
                tb.Clear();
            }
            optMale.Enabled = true;
            optChild.Enabled = true;
            optSelf.Enabled = true;
            dtpDOB.Text = DateTime.Today.ToString();
            chkDentConsent.Checked = false;
            chkDocConsent.Checked = false;
        }

        private bool validPrimaryKey(String state)
        {
            if (state.Equals("i"))
            {
                for (int i = 0; i < dg1.Rows.Count; i++)
                {
                    if (txtPatientId.Text.Equals(dg1.Rows[i].Cells[0].Value.ToString()))
                    {
                        MessageBox.Show("This Patient ID exists. Enter a unique Patient ID number.", "Primary Key Violation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtPatientId.Focus();
                        return false;
                    }
                }
                return true;
            }
            else if (state.Equals("u"))
            {
                for (int i = 0; i < dg1.Rows.Count; i++)
                {
                    if (i != dg1.CurrentRow.Index)
                    {
                        if (txtPatientId.Text.Equals(dg1.Rows[i].Cells[0].Value.ToString()))
                        {
                            MessageBox.Show("This Patient ID exists. Enter a unique Patient ID number.", "Primary Key Violation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtPatientId.Focus();
                            return false;
                        }
                        else if (txtPatientId.Text.Equals(""))
                        {
                            MessageBox.Show("No Patiet Selected!", "Update Record Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtPatientId.Focus();
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        private bool validInfo()
        {
            //id
            if (txtPatientId.Text.Length < 1)
            {
                MessageBox.Show("Valid Patient Id Required", "Invalid Id", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPatientId.Focus();
                return false;
            }
            //name
            if (txtName.Text.Length <= 1)
            {
                MessageBox.Show("Name is required with 3 minimum letters", "Invalid Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtName.Focus();
                return false;
            }
            if (txtName.Text.Length > 1)
            {
                if (txtName.Text.IndexOf(" ") == -1 || txtName.Text.IndexOf(" ") == txtName.Text.Length - 1)
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
            //guardian
            if (txtGuardName.Text.Length <= 2)
            {
                MessageBox.Show("Guardian Name is required with 3 minimum letters", "Invalid Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtGuardName.Focus();
                return false;
            }
            if (txtGuardName.Text.Length > 1)
            {
                if (txtGuardName.Text.IndexOf(" ") == -1 || txtGuardName.Text.IndexOf(" ") == txtGuardName.Text.Length - 1)
                {
                    MessageBox.Show("Guardians Last Name Required", "Missing last Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtGuardName.Focus();
                    return false;
                }
                if (txtGuardName.Text.IndexOf(" ") == txtGuardName.Text.Length - 2)
                {
                    MessageBox.Show("Guardian Last Name must contain 2 or more characters", "Invalid Last Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtGuardName.Focus();
                    return false;
                }
            }
            //street
            if (txtStreet.Text.Length <= 3)
            {
                MessageBox.Show("Street is required with 3 minimum letters", "Invalid Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtStreet.Focus();
                return false;
            }
            if (txtStreet.Text.Length > 1)
            {
                if (txtStreet.Text.IndexOf(" ") == -1 || txtStreet.Text.IndexOf(" ") == txtStreet.Text.Length - 1)
                {
                    MessageBox.Show("Street Name Required", "Missing last Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtStreet.Focus();
                    return false;
                }
                if (txtStreet.Text.IndexOf(" ") == txtStreet.Text.Length - 2)
                {
                    MessageBox.Show("Street Name must contain 2 or more characters", "Invalid Last Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtStreet.Focus();
                    return false;
                }
            }
            //apt
            //[optional]
            if (txtAptNum.Text.Length > 10)
            {
                MessageBox.Show("Apartment Number must be max 10 digits", "Invalid Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAptNum.Focus();
                return false;
            }

            //city
            if (txtCity.Text.Length <= 3)
            {
                MessageBox.Show("City is required with 3 minimum letters", "Invalid Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCity.Focus();
                return false;
            }
            //province
            if (txtProv.Text.Length < 1)
            {
                MessageBox.Show("Province Must Be The Provinces Two Letter Idetification Code", "Insurance Address Format", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtProv.Focus();
                return false;
            }
            else
            {
                if (validProv(txtProv.Text) != true)
                {
                    MessageBox.Show("Province Must Be The Provinces Two Letter Idetification Code", "Insurance Address Format", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtProv.Focus();
                    return false;
                }
            }
            //zip
            if (txtZip.Text.Length < 7)
            {
                MessageBox.Show("Zip Code is required with 6 digits and a space exactly", "Invalid Phone Number", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtZip.Focus();
                return false;
            }
            //home phone
            if (txtHomePhoneNum.Text.Length < 11)
            {
                MessageBox.Show("Home Phone Number is required with 10 digits exactly", "Invalid Phone Number", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtHomePhoneNum.Focus();
                return false;
            }
            //mobile
            if (txtMobilePhoneNum.Text.Length < 11)
            {
                MessageBox.Show("Mobile Phone Number is required with 10 digits exactly", "Invalid Phone Number", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMobilePhoneNum.Focus();
                return false;
            }
            //employer or school
            //not required

            //emergency name
            if (txtEmergName.Text.Length <= 1)
            {
                MessageBox.Show("Emergency Name is required with 3 minimum letters", "Invalid Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmergName.Focus();
                return false;
            }
            if (txtEmergName.Text.Length > 1)
            {
                if (txtEmergName.Text.IndexOf(" ") == -1 || txtEmergName.Text.IndexOf(" ") == txtEmergName.Text.Length - 1)
                {
                    MessageBox.Show("Last Name in Emergency section Required", "Missing last Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEmergName.Focus();
                    return false;
                }
                if (txtEmergName.Text.IndexOf(" ") == txtEmergName.Text.Length - 2)
                {
                    MessageBox.Show("Last Name in Emergency section must contain 2 or more characters", "Invalid Last Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEmergName.Focus();
                    return false;
                }
            }
            //emergency home phone number
            if (txtEmergHome.Text.Length < 11)
            {
                MessageBox.Show("Emergency Home Phone Number is required with 10 digits exactly", "Invalid Phone Number", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmergHome.Focus();
                return false;
            }
            //emergency mobile number

            if (txtEmergMobile.Text.Length < 11)
            {
                MessageBox.Show("Emergency Contact Mobile Phone is required with 10 digits exactly", "Invalid Phone Number", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmergMobile.Focus();
                return false;
            }
            //insurance company
            if (txtInCompany.Text.Length <= 1)
            {
                MessageBox.Show("Insurance company Name is required with 3 minimum letters", "Invalid Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtInCompany.Focus();
                return false;
            }
            //SIN
            if (txtSSNum.Text.Length < 10)
            {
                MessageBox.Show("Policy Holders Social Secuirty Number Must Be 9 Numbers In Length And Match ### ### ### Format", "SSN Format", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSSNum.Focus();
                return false;
            }
            if (txtSSNum.Text.Length == 11)
            {
                if (validSin() != true)
                {
                    MessageBox.Show("Policy Holders Social Secuirty Number Must Be Valid", "SSN Format", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSSNum.Focus();
                    return false;
                }
            }
            //policy Number
            if (txtPolicyNum.Text.Length < 1)
            {
                MessageBox.Show("Insurance Policy Number Required", "Invalid Policy Number", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPolicyNum.Focus();
                return false;
            }
            //street
            if (txtInsurStreet.Text.Length <= 3)
            {
                MessageBox.Show("Insurance Street is required with 3 minimum letters", "Invalid Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtInsurStreet.Focus();
                return false;
            }
            if (txtInsurStreet.Text.Length > 1)
            {
                if (txtInsurStreet.Text.IndexOf(" ") == -1 || txtInsurStreet.Text.IndexOf(" ") == txtInsurStreet.Text.Length - 1)
                {
                    MessageBox.Show("Insurance Street Name Required", "Missing last Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtInsurStreet.Focus();
                    return false;
                }
                if (txtInsurStreet.Text.IndexOf(" ") == txtInsurStreet.Text.Length - 2)
                {
                    MessageBox.Show("Insurance Street Name must contain 2 or more characters", "Invalid Last Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtInsurStreet.Focus();
                    return false;
                }
            }
            //office
            if (txtInsurOfficeNum.Text.Length > 10)
            {
                MessageBox.Show("Office Number Max 10 digits", "Invalid Office Number", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtInsurOfficeNum.Focus();
                return false;
            }

            //city
            if (txtInsurCity.Text.Length <= 3)
            {
                MessageBox.Show("Insurance City is required with 3 minimum letters", "Invalid Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtInsurCity.Focus();
                return false;
            }
            //province
            if (txtInsurProv.Text.Length < 1)
            {
                MessageBox.Show("The Province Of Insurance Company Must Be The Provinces Two Letter Idetification Code", "Insurance Address Format", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtInsurProv.Focus();
                return false;
            }
            else
            {
                if (validProv(txtInsurProv.Text) != true)
                {
                    MessageBox.Show("The Province Of Insurance Company Must Be The Provinces Two Letter Idetification Code", "Insurance Address Format", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtInsurProv.Focus();
                    return false;
                }
            }
            //zip
            if (txtInsurZip.Text.Length < 7)
            {
                MessageBox.Show("Zip Code of the insurance company is required with 6 digits and a space exactly", "Invalid Phone Number", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtInsurZip.Focus();
                return false;
            }
            //company phone number
            if (txtInsurancePhoneNum.Text.Length < 11)
            {
                MessageBox.Show("Insurance company Phone Number is required with 10 digits exactly", "Invalid Phone Number", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtInsurancePhoneNum.Focus();
                return false;
            }
            //former dentist
            if (txtFormerDent.Text.Length <= 1)
            {
                MessageBox.Show("Former Dentist Name is required with 3 minimum letters", "Invalid Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFormerDent.Focus();
                return false;
            }
            if (txtFormerDent.Text.Length > 1)
            {
                if (txtFormerDent.Text.IndexOf(" ") == -1 || txtFormerDent.Text.IndexOf(" ") == txtFormerDent.Text.Length - 1)
                {
                    MessageBox.Show("Former Dentist Last Name Required", "Missing last Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtFormerDent.Focus();
                    return false;
                }
                if (txtFormerDent.Text.IndexOf(" ") == txtFormerDent.Text.Length - 2)
                {
                    MessageBox.Show("Former Dentist Last Name must contain 2 or more characters", "Invalid Last Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtFormerDent.Focus();
                    return false;
                }
            }
            //former dent phone number
            if (txtDentNum.Text.Length < 11)
            {
                MessageBox.Show("Fromer Dentist Phone Number is required with 10 digits exactly", "Invalid Phone Number", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDentNum.Focus();
                return false;
            }
            //doctor name
            if (txtDoctor.Text.Length <= 1)
            {
                MessageBox.Show("Doctors Name is required with 3 minimum letters", "Invalid Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDoctor.Focus();
                return false;
            }
            if (txtDoctor.Text.Length > 1)
            {
                if (txtDoctor.Text.IndexOf(" ") == -1 || txtDoctor.Text.IndexOf(" ") == txtDoctor.Text.Length - 1)
                {
                    MessageBox.Show("Doctors Last Name Required", "Missing last Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDoctor.Focus();
                    return false;
                }
                if (txtDoctor.Text.IndexOf(" ") == txtDoctor.Text.Length - 2)
                {
                    MessageBox.Show("Doctors Last Name must contain 2 or more characters", "Invalid Last Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDoctor.Focus();
                    return false;
                }
            }
            // docor number
            if (txtDoctorNum.Text.Length < 11)
            {
                MessageBox.Show("Doctor Phone Number is required with 10 digits exactly", "Invalid Phone Number", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDoctorNum.Focus();
                return false;
            }
            return true;
        }

        private bool validProv(string prov)
        {
            string[] testProvs = { "ON", "QC", "NS", "NB", "MB", "BC", "PE", "SK", "AB", "NL", "NT", "YT", "NU" };
            for (int i = 0; i < testProvs.Length; i++)
            {
                if (prov.Equals(testProvs[i]))
                {
                    return true;
                }
            }
            return false;
        }

        private bool validSin()
        {
            int num1 = Convert.ToInt32(txtSSNum.Text.ToString().Substring(0, 1)) * 1;
            int num2 = Convert.ToInt32(txtSSNum.Text.ToString().Substring(1, 1)) * 2;
            int num3 = Convert.ToInt32(txtSSNum.Text.ToString().Substring(2, 1)) * 1;
            int num4 = Convert.ToInt32(txtSSNum.Text.ToString().Substring(4, 1)) * 2;
            int num5 = Convert.ToInt32(txtSSNum.Text.ToString().Substring(5, 1)) * 1;
            int num6 = Convert.ToInt32(txtSSNum.Text.ToString().Substring(6, 1)) * 2;
            int num7 = Convert.ToInt32(txtSSNum.Text.ToString().Substring(8, 1)) * 1;
            int num8 = Convert.ToInt32(txtSSNum.Text.ToString().Substring(9, 1)) * 2;
            int num9 = Convert.ToInt32(txtSSNum.Text.ToString().Substring(10, 1)) * 1;
            if (num1 > 9)
            {
                num1 = num1 - 9;
            }
            if (num2 > 9)
            {
                num2 = num2 - 9;
            }
            if (num3 > 9)
            {
                num3 = num3 - 9;
            }
            if (num4 > 9)
            {
                num4 = num4 - 9;
            }
            if (num5 > 9)
            {
                num5 = num5 - 9;
            }
            if (num6 > 9)
            {
                num6 = num6 - 9;
            }
            if (num7 > 9)
            {
                num7 = num7 - 9;
            }
            if (num8 > 9)
            {
                num8 = num8 - 9;
            }
            if (num9 > 9)
            {
                num9 = num9 - 9;
            }
            int fin = num1 + num2 + num3 + num4 + num5 + num6 + num7 + num8 + num9;
            if (fin % 10 != 0)
            {
                return false;
            }
            return true;
        }

        private void getData()
        {
            string connStr = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|Database.mdf;Integrated Security=True;";
            try
            {
                conn = new SqlConnection(connStr);
                string sql = "SELECT * FROM [Patients]";
                da = new SqlDataAdapter(sql, conn);
                SqlCommandBuilder cb = new SqlCommandBuilder(da);
                ds = new DataSet();
                conn.Open();
                da.Fill(ds, "Patients");
                conn.Close();

                //bind and display
                bindingSource1.DataSource = ds;
                bindingSource1.DataMember = "Patients";
                dg1.DataSource = bindingSource1;
                dg1.ClearSelection();
            }
            catch (SqlException ex)
            {
                if (conn != null)
                {
                    conn.Close();
                }
                MessageBox.Show(ex.Message, "Error Reading Data");
            }
        }

        private void getOptions()
        {
            //gender

            if (optMale.Checked)
            {
                gender = "Male";
            }
            if (optFemale.Checked)
            {
                gender = "Female";
            }
            //Marital Status

            if (optChild.Checked)
            {
                marital = "Child";
            }
            if (optSingle.Checked)
            {
                marital = "Single";
            }
            if (optMarried.Checked)
            {
                marital = "Married";
            }
            if (optDivorced.Checked)
            {
                marital = "Divorced";
            }
            if (optWidow.Checked)
            {
                marital = "Widow";
            }
            //relationship

            if (optSelf.Checked)
            {
                relation = "Self";
            }
            if (optSpouse.Checked)
            {
                relation = "Spouse";
            }
            if (optDependent.Checked)
            {
                relation = "Dependant";
            }
            //dent consent

            if (chkDentConsent.Checked)
            {
                dentConsent = "Yes";
            }
            //Phys consent

            if (chkDocConsent.Checked)
            {
                physConsent = "Yes";
            }
        }

        private void formatGrid()
        {
            dg1.Sort(dg1.Columns["id"], ListSortDirection.Ascending);
        }

        private void setControlState(string state)
        {
            if (state.Equals("i"))
            {
                clearText();
                txtPatientId.Enabled = true;
                lblInsertMessage.Text = "";
                cmdInsert.Enabled = true;
                cmdUpdate.Enabled = false;
                cmdDelete.Enabled = false;
                cmdUpdate.Hide();
                cmdDelete.Hide();
                cmdInsert.Show();
            }
            else if (state.Equals("u/d"))
            {
                txtPatientId.Enabled = false;
                lblInsertMessage.Text = "Press Esc To Go Back To Insert Mode";
                cmdInsert.Enabled = false;
                cmdUpdate.Enabled = true;
                cmdDelete.Enabled = true;
                cmdUpdate.Show();
                cmdDelete.Show();
                cmdInsert.Hide();
            }
        }
    }
}