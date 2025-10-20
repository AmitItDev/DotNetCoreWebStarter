namespace SysproConnector.TestClient
{
    partial class frmSysproConnectorTestClient
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.rtbMessages = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnIsLoggedIn = new System.Windows.Forms.Button();
            this.btnLogOff = new System.Windows.Forms.Button();
            this.btnCreateSalesOrder = new System.Windows.Forms.Button();
            this.btnUpdateSalesOrder = new System.Windows.Forms.Button();
            this.btnUpdatePatient = new System.Windows.Forms.Button();
            this.btnCreatePatient = new System.Windows.Forms.Button();
            this.btnGetUnitPrice = new System.Windows.Forms.Button();
            this.btnTakeJobOffOnHold = new System.Windows.Forms.Button();
            this.btnPlaceJobOnHold = new System.Windows.Forms.Button();
            this.btnGetFunderInformation = new System.Windows.Forms.Button();
            this.btnSaveJobNotes = new System.Windows.Forms.Button();
            this.btnCreateUnappliedPayment = new System.Windows.Forms.Button();
            this.btnCancelSalesOrder = new System.Windows.Forms.Button();
            this.btnConvertForwardOrderToScheduledOrder = new System.Windows.Forms.Button();
            this.btnUpdateOrderStatus = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.rtbResponse = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rtbResult = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSysproUrl = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rtbMessages
            // 
            this.rtbMessages.Location = new System.Drawing.Point(12, 348);
            this.rtbMessages.Name = "rtbMessages";
            this.rtbMessages.ReadOnly = true;
            this.rtbMessages.Size = new System.Drawing.Size(702, 195);
            this.rtbMessages.TabIndex = 0;
            this.rtbMessages.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 329);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Messages";
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(12, 12);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(136, 23);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnIsLoggedIn
            // 
            this.btnIsLoggedIn.Location = new System.Drawing.Point(154, 12);
            this.btnIsLoggedIn.Name = "btnIsLoggedIn";
            this.btnIsLoggedIn.Size = new System.Drawing.Size(136, 23);
            this.btnIsLoggedIn.TabIndex = 3;
            this.btnIsLoggedIn.Text = "IsLoggedIn";
            this.btnIsLoggedIn.UseVisualStyleBackColor = true;
            this.btnIsLoggedIn.Click += new System.EventHandler(this.btnIsLoggedIn_Click);
            // 
            // btnLogOff
            // 
            this.btnLogOff.Location = new System.Drawing.Point(296, 12);
            this.btnLogOff.Name = "btnLogOff";
            this.btnLogOff.Size = new System.Drawing.Size(136, 23);
            this.btnLogOff.TabIndex = 4;
            this.btnLogOff.Text = "LogOff";
            this.btnLogOff.UseVisualStyleBackColor = true;
            this.btnLogOff.Click += new System.EventHandler(this.btnLogOff_Click);
            // 
            // btnCreateSalesOrder
            // 
            this.btnCreateSalesOrder.Location = new System.Drawing.Point(438, 12);
            this.btnCreateSalesOrder.Name = "btnCreateSalesOrder";
            this.btnCreateSalesOrder.Size = new System.Drawing.Size(136, 23);
            this.btnCreateSalesOrder.TabIndex = 5;
            this.btnCreateSalesOrder.Text = "CreateSalesOrder";
            this.btnCreateSalesOrder.UseVisualStyleBackColor = true;
            this.btnCreateSalesOrder.Click += new System.EventHandler(this.btnCreateSalesOrder_Click);
            // 
            // btnUpdateSalesOrder
            // 
            this.btnUpdateSalesOrder.Location = new System.Drawing.Point(580, 12);
            this.btnUpdateSalesOrder.Name = "btnUpdateSalesOrder";
            this.btnUpdateSalesOrder.Size = new System.Drawing.Size(136, 23);
            this.btnUpdateSalesOrder.TabIndex = 6;
            this.btnUpdateSalesOrder.Text = "UpdateSalesOrder";
            this.btnUpdateSalesOrder.UseVisualStyleBackColor = true;
            this.btnUpdateSalesOrder.Click += new System.EventHandler(this.btnUpdateSalesOrder_Click);
            // 
            // btnUpdatePatient
            // 
            this.btnUpdatePatient.Location = new System.Drawing.Point(580, 70);
            this.btnUpdatePatient.Name = "btnUpdatePatient";
            this.btnUpdatePatient.Size = new System.Drawing.Size(136, 23);
            this.btnUpdatePatient.TabIndex = 11;
            this.btnUpdatePatient.Text = "UpdatePatient";
            this.btnUpdatePatient.UseVisualStyleBackColor = true;
            this.btnUpdatePatient.Click += new System.EventHandler(this.btnUpdatePatient_Click);
            // 
            // btnCreatePatient
            // 
            this.btnCreatePatient.Location = new System.Drawing.Point(438, 70);
            this.btnCreatePatient.Name = "btnCreatePatient";
            this.btnCreatePatient.Size = new System.Drawing.Size(136, 23);
            this.btnCreatePatient.TabIndex = 10;
            this.btnCreatePatient.Text = "CreatePatient";
            this.btnCreatePatient.UseVisualStyleBackColor = true;
            this.btnCreatePatient.Click += new System.EventHandler(this.btnCreatePatient_Click);
            // 
            // btnGetUnitPrice
            // 
            this.btnGetUnitPrice.Location = new System.Drawing.Point(296, 70);
            this.btnGetUnitPrice.Name = "btnGetUnitPrice";
            this.btnGetUnitPrice.Size = new System.Drawing.Size(136, 23);
            this.btnGetUnitPrice.TabIndex = 9;
            this.btnGetUnitPrice.Text = "GetUnitPrice";
            this.btnGetUnitPrice.UseVisualStyleBackColor = true;
            this.btnGetUnitPrice.Click += new System.EventHandler(this.btnGetUnitPrice_Click);
            // 
            // btnTakeJobOffOnHold
            // 
            this.btnTakeJobOffOnHold.Location = new System.Drawing.Point(154, 70);
            this.btnTakeJobOffOnHold.Name = "btnTakeJobOffOnHold";
            this.btnTakeJobOffOnHold.Size = new System.Drawing.Size(136, 23);
            this.btnTakeJobOffOnHold.TabIndex = 8;
            this.btnTakeJobOffOnHold.Text = "TakeJobOffOnHold";
            this.btnTakeJobOffOnHold.UseVisualStyleBackColor = true;
            this.btnTakeJobOffOnHold.Click += new System.EventHandler(this.btnTakeJobOffOnHold_Click);
            // 
            // btnPlaceJobOnHold
            // 
            this.btnPlaceJobOnHold.Location = new System.Drawing.Point(12, 70);
            this.btnPlaceJobOnHold.Name = "btnPlaceJobOnHold";
            this.btnPlaceJobOnHold.Size = new System.Drawing.Size(136, 23);
            this.btnPlaceJobOnHold.TabIndex = 7;
            this.btnPlaceJobOnHold.Text = "PlaceJobOnHold";
            this.btnPlaceJobOnHold.UseVisualStyleBackColor = true;
            this.btnPlaceJobOnHold.Click += new System.EventHandler(this.btnPlaceJobOnHold_Click);
            // 
            // btnGetFunderInformation
            // 
            this.btnGetFunderInformation.Location = new System.Drawing.Point(12, 99);
            this.btnGetFunderInformation.Name = "btnGetFunderInformation";
            this.btnGetFunderInformation.Size = new System.Drawing.Size(136, 23);
            this.btnGetFunderInformation.TabIndex = 17;
            this.btnGetFunderInformation.Text = "GetFunderInformation";
            this.btnGetFunderInformation.UseVisualStyleBackColor = true;
            this.btnGetFunderInformation.Click += new System.EventHandler(this.btnGetFunderInformation_Click);
            // 
            // btnSaveJobNotes
            // 
            this.btnSaveJobNotes.Location = new System.Drawing.Point(580, 41);
            this.btnSaveJobNotes.Name = "btnSaveJobNotes";
            this.btnSaveJobNotes.Size = new System.Drawing.Size(136, 23);
            this.btnSaveJobNotes.TabIndex = 16;
            this.btnSaveJobNotes.Text = "SaveJobNotes";
            this.btnSaveJobNotes.UseVisualStyleBackColor = true;
            this.btnSaveJobNotes.Click += new System.EventHandler(this.btnSaveJobNotes_Click);
            // 
            // btnCreateUnappliedPayment
            // 
            this.btnCreateUnappliedPayment.Location = new System.Drawing.Point(438, 41);
            this.btnCreateUnappliedPayment.Name = "btnCreateUnappliedPayment";
            this.btnCreateUnappliedPayment.Size = new System.Drawing.Size(136, 23);
            this.btnCreateUnappliedPayment.TabIndex = 15;
            this.btnCreateUnappliedPayment.Text = "CreateUnappliedPayment";
            this.btnCreateUnappliedPayment.UseVisualStyleBackColor = true;
            this.btnCreateUnappliedPayment.Click += new System.EventHandler(this.btnCreateUnappliedPayment_Click);
            // 
            // btnCancelSalesOrder
            // 
            this.btnCancelSalesOrder.Location = new System.Drawing.Point(296, 41);
            this.btnCancelSalesOrder.Name = "btnCancelSalesOrder";
            this.btnCancelSalesOrder.Size = new System.Drawing.Size(136, 23);
            this.btnCancelSalesOrder.TabIndex = 14;
            this.btnCancelSalesOrder.Text = "CancelSalesOrder";
            this.btnCancelSalesOrder.UseVisualStyleBackColor = true;
            this.btnCancelSalesOrder.Click += new System.EventHandler(this.btnCancelSalesOrder_Click);
            // 
            // btnConvertForwardOrderToScheduledOrder
            // 
            this.btnConvertForwardOrderToScheduledOrder.Location = new System.Drawing.Point(154, 41);
            this.btnConvertForwardOrderToScheduledOrder.Name = "btnConvertForwardOrderToScheduledOrder";
            this.btnConvertForwardOrderToScheduledOrder.Size = new System.Drawing.Size(136, 23);
            this.btnConvertForwardOrderToScheduledOrder.TabIndex = 13;
            this.btnConvertForwardOrderToScheduledOrder.Text = "ConvertForwardOrder";
            this.btnConvertForwardOrderToScheduledOrder.UseVisualStyleBackColor = true;
            this.btnConvertForwardOrderToScheduledOrder.Click += new System.EventHandler(this.btnConvertForwardOrderToScheduledOrder_Click);
            // 
            // btnUpdateOrderStatus
            // 
            this.btnUpdateOrderStatus.Location = new System.Drawing.Point(12, 41);
            this.btnUpdateOrderStatus.Name = "btnUpdateOrderStatus";
            this.btnUpdateOrderStatus.Size = new System.Drawing.Size(136, 23);
            this.btnUpdateOrderStatus.TabIndex = 12;
            this.btnUpdateOrderStatus.Text = "UpdateOrderStatus";
            this.btnUpdateOrderStatus.UseVisualStyleBackColor = true;
            this.btnUpdateOrderStatus.Click += new System.EventHandler(this.btnUpdateOrderStatus_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 224);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Response";
            // 
            // rtbResponse
            // 
            this.rtbResponse.Location = new System.Drawing.Point(12, 240);
            this.rtbResponse.Name = "rtbResponse";
            this.rtbResponse.ReadOnly = true;
            this.rtbResponse.Size = new System.Drawing.Size(702, 77);
            this.rtbResponse.TabIndex = 18;
            this.rtbResponse.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 172);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Result";
            // 
            // rtbResult
            // 
            this.rtbResult.Location = new System.Drawing.Point(12, 188);
            this.rtbResult.Name = "rtbResult";
            this.rtbResult.ReadOnly = true;
            this.rtbResult.Size = new System.Drawing.Size(702, 24);
            this.rtbResult.TabIndex = 20;
            this.rtbResult.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "SYSPRO Webservice URL";
            // 
            // txtSysproUrl
            // 
            this.txtSysproUrl.Location = new System.Drawing.Point(12, 145);
            this.txtSysproUrl.Name = "txtSysproUrl";
            this.txtSysproUrl.Size = new System.Drawing.Size(702, 20);
            this.txtSysproUrl.TabIndex = 24;
            this.txtSysproUrl.Text = "http://oaplcloudapp01/sysprowebservices";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(154, 99);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(136, 23);
            this.button1.TabIndex = 25;
            this.button1.Text = "GetAttachments";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmSysproConnectorTestClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 554);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtSysproUrl);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.rtbResult);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rtbResponse);
            this.Controls.Add(this.btnGetFunderInformation);
            this.Controls.Add(this.btnSaveJobNotes);
            this.Controls.Add(this.btnCreateUnappliedPayment);
            this.Controls.Add(this.btnCancelSalesOrder);
            this.Controls.Add(this.btnConvertForwardOrderToScheduledOrder);
            this.Controls.Add(this.btnUpdateOrderStatus);
            this.Controls.Add(this.btnUpdatePatient);
            this.Controls.Add(this.btnCreatePatient);
            this.Controls.Add(this.btnGetUnitPrice);
            this.Controls.Add(this.btnTakeJobOffOnHold);
            this.Controls.Add(this.btnPlaceJobOnHold);
            this.Controls.Add(this.btnUpdateSalesOrder);
            this.Controls.Add(this.btnCreateSalesOrder);
            this.Controls.Add(this.btnLogOff);
            this.Controls.Add(this.btnIsLoggedIn);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rtbMessages);
            this.Name = "frmSysproConnectorTestClient";
            this.Text = "Syspro Connector Test Client";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbMessages;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnIsLoggedIn;
        private System.Windows.Forms.Button btnLogOff;
        private System.Windows.Forms.Button btnCreateSalesOrder;
        private System.Windows.Forms.Button btnUpdateSalesOrder;
        private System.Windows.Forms.Button btnUpdatePatient;
        private System.Windows.Forms.Button btnCreatePatient;
        private System.Windows.Forms.Button btnGetUnitPrice;
        private System.Windows.Forms.Button btnTakeJobOffOnHold;
        private System.Windows.Forms.Button btnPlaceJobOnHold;
        private System.Windows.Forms.Button btnGetFunderInformation;
        private System.Windows.Forms.Button btnSaveJobNotes;
        private System.Windows.Forms.Button btnCreateUnappliedPayment;
        private System.Windows.Forms.Button btnCancelSalesOrder;
        private System.Windows.Forms.Button btnConvertForwardOrderToScheduledOrder;
        private System.Windows.Forms.Button btnUpdateOrderStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox rtbResponse;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox rtbResult;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSysproUrl;
        private System.Windows.Forms.Button button1;
    }
}

