using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoWareWMS
{
    public partial class ReceipForm : Form
    {
        public ReceipForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Set the receipt information
        /// </summary>
        /// <param name="check">"checkin" or "checkout"</param>
        /// <param name="finalfee">note: 0 for check in</param>
        /// <param name="inventoryID"></param>
        /// <param name="category"></param>
        /// <param name="description"></param>
        /// <param name="feeCategory"></param>
        /// <param name="warehouse"></param>
        /// <param name="feeAddressWarehouse"></param>
        /// <param name="date1">checkin date</param>
        /// <param name="date2">checkout date. Null if the pop up receipt is for checkin</param>
        public void SetLabel(string check, string finalfee, string inventoryID, 
            string category, string description, Dictionary<string, string> feeCategory,
            string warehouse, Dictionary<string, string> feeAddressWarehouse, string date1, string date2)
        {
            label_invNO.Text = inventoryID;
            label_category.Text = category;
            label_fee_category.Text = feeCategory["fee"];
            label_description.Text = description;
            label_warehouse.Text = warehouse;
            label_fee_warehouse.Text = feeAddressWarehouse["fee"];
            string address = "";
            address += feeAddressWarehouse["street"] + Environment.NewLine;
            address += feeAddressWarehouse["city"] + ", ";
            address += feeAddressWarehouse["country"] + Environment.NewLine;
            address += feeAddressWarehouse["tel"];
            label_address.Text = address;
            label_date.Text = date1;
            if (check == "checkin")
            {
                label_check_inout.Text = "Check In" + Environment.NewLine + "Receipt";
                ulabel_finalfee.Visible = false;
                label_finalfee.Visible = false;
                ulabel_datein_checkout.Visible = false;
                label_datein_checkout.Visible = false;
                ulabel_date.Text = "Date :";
            }
            else
            {
                label_check_inout.Text = "Check Out" + Environment.NewLine + "Receipt";
                ulabel_finalfee.Visible = true;
                label_finalfee.Visible = true;
                label_finalfee.Text = finalfee;
                ulabel_datein_checkout.Visible = true;
                label_datein_checkout.Visible = true;
                label_datein_checkout.Text = date2;
                ulabel_date.Text = "Date Out :";
                label_date.Text = date1;
            }
        }

    }
}
