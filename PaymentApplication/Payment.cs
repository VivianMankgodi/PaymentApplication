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
    public partial class frmPayment : Form
    {
        public frmPayment()
        {
            InitializeComponent();
        }

        //here i declare  an array to cantain all the month
        string[] Months = { "Select a month","Janauary", "February", "March", "April", "May", "June", "Julay", "August", "September", "October", "November", "December" };
        //this is the current year
        int year = DateTime.Now.Year;

        //here is the array for credit card type
        string[] CreditCardTypes = { "Visa", "Mastercard", "American Express" };
        private void frmPayment_Load(object sender, EventArgs e)
        {


            //adding items in this two list boxes so that when the fprm load it the items will be added

            //here i use a ForEach (i can even use For)loop to add and display the month values. i used array so that i can have only one add for this combox and it make the code to be simple 
            foreach (var month in Months )
            {
                cboExpirationMonth.Items.Add(month);
               
            }

            //here i want to selected item to be the first item in an array
            cboExpirationMonth.SelectedIndex = 0;


            //here i want to add string item in the combobox to be the first item and selct it
            cboExpirationYear.Items.Add("Select a year");

            //here want to add years 8 in the combo box from the current year until the last year which is the 8th year
            int years = year + 8;
            //so here i use a while loop to loop through the current year until the 8th year this means that while the year is less than the Years then it will loop until the are equal
            while (year < years )
            {
                cboExpirationYear.Items.Add(year);
                year++;
            }

            cboExpirationYear.SelectedIndex = 0;


            //here we add items in a list box
            // here i use a foreach loop to add items in the listbox
            foreach (var card in CreditCardTypes )
            {
                lstCreditCardType.Items.Add(card);
                year++;
            }

        }
        
        //here we create a method For Validation 
        public bool IsValidData()
        {
            if (rdoCreditCard.Checked )
            {
                if (lstCreditCardType.SelectedIndex == -1)
                {
                    MessageBox.Show("You must select a credit card type", "Error");
                    lstCreditCardType.Focus();
                    return false;
                }
            }

            if (txtCardNumber.Text == "")
            {
                MessageBox.Show("You must enter a credit card number", "Error");
                txtCardNumber.Focus();
                return false;
            }
            
            //with this if statement we wnt to check that user selected ant itme expect the first item
            if (cboExpirationMonth.SelectedIndex == 0)
            {
                MessageBox.Show("You must select a month", "Error");
                cboExpirationMonth.Focus();
                return false;
            }

            if (cboExpirationYear.SelectedIndex == 0)
            {
                MessageBox.Show("You msut select a year", "Error");
                cboExpirationYear.Focus();
                return false;
            }

            return true;
        }

        //here we want to call a save method if the data is entered 
        public void SaveData()
        {
            string message = null;
            if (rdoCreditCard.Checked == true )
            {
                message += "Charge to credit card" + "\n";
                message += "\n";
                message += "Card type: " + lstCreditCardType.Text + "\n";
                message += "Card number: " + txtCardNumber.Text + "\n";
                message += "Expiration date: " + cboExpirationMonth.Text + "/" + cboExpirationYear.Text + "\n";
            }
            else
            {
                message += "send bill to customer" + "\n";
            }
           
            bool isDefaultBilling = chkDefault.Checked;
            message += "Defualt billing: " + isDefaultBilling;

            //this we tag this form to display all informtion entered in the Payment form to be display in th e label in Customer form
        this.Tag = message;

            //this allow us to go back to custome form becuase we use dialogbox to display the Payment form so if user click ok it go back to Customer form
            this.DialogResult = DialogResult.OK;

        }

        private void Billing_CHeckedChangged(object sender, System.EventArgs e)
        {
            if (rdoCreditCard.Checked )
            {

                EnableControls();
                
            }
            else
            {
                DisableControls();
            }

        }
        private void  EnableControls()
        {
            lstCreditCardType.Enabled = true;
            txtCardNumber.Enabled = true;
            cboExpirationMonth.Enabled = true;
            cboExpirationYear.Enabled = true;
        }
        private void     DisableControls()
        {
            lstCreditCardType.Enabled = false;
            txtCardNumber.Enabled = false;
            cboExpirationMonth.Enabled = false;
            cboExpirationYear.Enabled = false;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            //here we want to call IsValidData method for validation to check if the user clicked a type of bill radiobutton,  creditcard Type and if the user selected a month and year for expiry date but not first items from the comboboxes
            if (IsValidData())
            {
                this.SaveData();
            } 
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}
