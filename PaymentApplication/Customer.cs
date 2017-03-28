using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaymentApplication
{
    public partial class frmCustomer : Form
    {
        public frmCustomer()
        {
            InitializeComponent();
        }

        //declaring variables
        //this variable will indicate whether the data that's currently displayed in the form has been saved
        bool isDataSaved = true;

        private void frmCustomer_Load(object sender, EventArgs e)
        {
            //here when a form load it adds 3 names in a customer combobox
            // Adding names in a combobox
            cboNames.Items.Add("Tebeila Vivian");
            cboNames.Items.Add("Mike Smith");
            cboNames.Items.Add("Nacy Jones");
        }

        //here we create a method that will be wired(used) in both Label and combobox events
        private void DataChanged(Object sender,  System.EventArgs e)
        {
            //here we set this variable to false any time when customer combobox and payment methid label is changed
            isDataSaved = false;
        }
        private void btnSelectPayment_Click(object sender, EventArgs e)
        {
            //here we display a payment form 
            frmPayment payment = new frmPayment();
            DialogResult displayForm = payment.ShowDialog();

            //here we want if the user click OK button in the dialogbox the payment data will be displayed in the Payment Methods Label that is autosized this label is in customer form
            if (displayForm == DialogResult.OK )
            {
                //the data that will be displayed will be stored in Tag property of Payment Form
                lblPayment.Text = (string)payment.Tag;
            }
        }

        //creeating a method that will check if user selected a customer and selected a payment
        //this method is for validation
        public bool IsValidData()
        {
            //here we want to check if user selected a customer and we will use Selectedindex to check if is 0 greater than 0 becuase index start from 0 then if is is less than 0 it show a error message
            if (cboNames.SelectedIndex == -1)
            {
                MessageBox.Show("You must select a customer", "Customer Error");
                cboNames.Focus();
                return false;
            }

            //here we check if user clicked the select payment button because if the user click the select payment button it mus display information into the labelPayment and then go to payment form
            if (lblPayment.Text == "")
            {
                MessageBox.Show("You must enter a payment", "payment error");
                //lblPayment.Focus();
                return false;
            }

            //it return true if the user selected a customer and clicked  select_payment button
            return true;
        }

        //this method clear everything from this controls after a user click save button and if the is data selected and entered in the label payment method
        private void SaveData()
        {//clear controls
            cboNames.SelectedIndex = -1;
            lblPayment.Text = "";
            isDataSaved = true;
            cboNames.Focus();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            //here we call the IsValidData method so that we can save what user entered payment and selected customer
            if (IsValidData())
            {
                SaveData();
            }
          
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCustomer_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isDataSaved == false)
            {
                string message = "This form contains unsaved data. \n\n" + "Do you want to save it?";

                //here if the user want to close the application without click Save button to save the data that thye have enterd it will ask if they want save the data or not then it show option Yes, No and Cancel
                DialogResult button = MessageBox.Show(message, "Customerr", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);


                //here it will check if the user click Yes button in the message box then it will go and Validate using IsValidData method to check if user has entered something to be save  then if they have enterred something in both combobox and label  then it save the data and clear the toolboxes(controls) then if not it cancel by before it cancel it give you an error message 
                if (button == DialogResult.Yes)
                {
                    if (IsValidData())
                    {
                        this.SaveData();

                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }
                if (button == DialogResult.Cancel )
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
