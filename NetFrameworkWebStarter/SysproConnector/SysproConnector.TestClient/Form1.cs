using SysproConnector.Models;
using System;
using System.Windows.Forms;
using Newtonsoft.Json;
using OAPL.DAL.Repository;
using System.Collections.Generic;
using OAPL.Models.Order;
using System.Configuration;
using System.Net.Http;

namespace SysproConnector.TestClient
{
    public partial class frmSysproConnectorTestClient : Form
    {
        private SysproConnectorTests SysproConnectorTests;

        public frmSysproConnectorTestClient()
        {
            InitializeComponent();
            this.SysproConnectorTests = new SysproConnectorTests();
        }

        private void btnLogin_Click(object sender, EventArgs e)
            => setResultsView(SysproConnectorTests.Logon(txtSysproUrl.Text));

        private void btnIsLoggedIn_Click(object sender, EventArgs e)
        {
            rtbResult.Text   = "This method call, correctly, does not return this property";
            rtbResponse.Text = SysproConnectorTests.IsLoggedOn().ToString();
            rtbMessages.Text = "This method call, correctly, does not return this property";
        }

        private void btnLogOff_Click(object sender, EventArgs e)
        {
            SysproConnectorTests.LogOff();
            rtbResult.Text   = "This method call, correctly, does not return this property";
            rtbResponse.Text = "This method call, correctly, does not return this property";
            rtbMessages.Text = "This method call, correctly, does not return this property";
        }

        private void btnCreateSalesOrder_Click(object sender, EventArgs e)
            => setResultsView(SysproConnectorTests.CreateSalesOrder());

        private void btnUpdateSalesOrder_Click(object sender, EventArgs e)
            => setResultsView(SysproConnectorTests.UpdateSalesOrder());

        private void btnUpdateOrderStatus_Click(object sender, EventArgs e)
            => setResultsView(SysproConnectorTests.UpdateOrderStatus());

        private void btnConvertForwardOrderToScheduledOrder_Click(object sender, EventArgs e)
            => setResultsView(SysproConnectorTests.ConvertForwardOrderToScheduledOrder());

        private void btnCancelSalesOrder_Click(object sender, EventArgs e)
            => setResultsView(SysproConnectorTests.CancelSalesOrder());

        private void btnCreateUnappliedPayment_Click(object sender, EventArgs e)
            => setResultsView(SysproConnectorTests.CreateUnappliedPayment());

        private void btnSaveJobNotes_Click(object sender, EventArgs e)
            => setResultsView(SysproConnectorTests.SaveJobNotes());

        private void btnPlaceJobOnHold_Click(object sender, EventArgs e)
            => setResultsView(SysproConnectorTests.PlaceJobOnHold());

        private void btnTakeJobOffOnHold_Click(object sender, EventArgs e)
            => setResultsView(SysproConnectorTests.TakeJobOffOnHold());

        private void btnGetUnitPrice_Click(object sender, EventArgs e)
            => setResultsView(SysproConnectorTests.GetUnitPrice());

        private void btnCreatePatient_Click(object sender, EventArgs e)
            => setResultsView(SysproConnectorTests.CreatePatient());

        private void btnUpdatePatient_Click(object sender, EventArgs e)
            => setResultsView(SysproConnectorTests.UpdatePatient());

        private void btnGetFunderInformation_Click(object sender, EventArgs e)
            => setResultsView(SysproConnectorTests.GetFunderInformation());

        private void setResultsView(ResponseModel result)
        {
            rtbResult.Clear();
            rtbResponse.Clear();
            rtbMessages.Clear();

            rtbResult.Text   = JsonConvert.SerializeObject(result.RequestStatus, Formatting.Indented);
            rtbResponse.Text = JsonConvert.SerializeObject(result.ResponseData, Formatting.Indented);
            rtbMessages.Text = JsonConvert.SerializeObject(result.ResponseMessages, Formatting.Indented);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string salesOrder = "000000000769749";
                string host = "http://oaplcloudapp01:85";

                ResponseModel response;

                response = SysproConnectorTests.GetAttachment(salesOrder, host, "PF");
                MessageBox.Show(response.ResponseMessages[0]);

                response = SysproConnectorTests.GetAttachment(salesOrder, host, "PH");
                MessageBox.Show(response.ResponseMessages[0]);

                response = SysproConnectorTests.GetAttachment(salesOrder, host, "RF");
                MessageBox.Show(response.ResponseMessages[0]);

                response = SysproConnectorTests.GetAttachment(salesOrder, host, "SC");
                MessageBox.Show(response.ResponseMessages[0]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
