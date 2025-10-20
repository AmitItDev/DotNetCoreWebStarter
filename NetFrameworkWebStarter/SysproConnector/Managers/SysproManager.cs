using System.Collections.Generic;
using System.Linq;
using SysproConnector.SysproSetupService;
using SysproConnector.SysproTransactionService;
using SysproConnector.Models;
using System.Xml;
using SysproConnector.Infrastructure.Messages;
using System;
using SysproConnector.Infrastructure.Helpers;
using SysproConnector.Infrastructure.Settings;
using SysproConnector.Infrastructure.Options;
using SysproConnector.Infrastructure;
using static SysproConnector.Infrastructure.SystemEnum;
using SYSPROWCFServicesClientLibrary40;

namespace SysproConnector.Managers
{
    internal class SysproManager
    {
        private transactionclass SysproTransactions;
        private setupclass SysproSetup;
        private LoginInputModel LoginInputModel;
        private SYSPROWCFServicesPrimitiveClient client;
        private int RetryTransection = 0;
        List<string> lstLoginException = new List<string>();

        internal SysproManager(LoginInputModel loginInputModel, int? SysproWCFBinding = null)
        {
            LoginInputModel = loginInputModel;

            int sYSPROWCFBinding = 3;
            if (SysproWCFBinding.HasValue)
            {
                sYSPROWCFBinding = SysproWCFBinding.Value;
            }

            client = new SYSPROWCFServicesPrimitiveClient(loginInputModel.WebServiceUrl, (SYSPROWCFBinding)sYSPROWCFBinding);

            lstLoginException.Add("The supplied UserID is invalid");
            lstLoginException.Add("expired");
            lstLoginException.Add("Login");
        }
        #region Login/LogOut Methods
        internal ResponseModel Logon(bool isTest = false)
        {
            var result = new ResponseModel();
            string sysproLoginSessionId = string.Empty;
            try
            {
                sysproLoginSessionId = client.Logon(LoginInputModel.Operator, LoginInputModel.OperatorPassword, LoginInputModel.CompanyCode, LoginInputModel.CompanyPassword,
                   "05", "NoDebug", "0", "");

                if (!string.IsNullOrWhiteSpace(sysproLoginSessionId))
                {
                    var sysproLogonProfile = client.GetLogonProfile(sysproLoginSessionId).Trim();
                    result.ResponseData = new LoginOutputModel()
                    {
                        SessionId = sysproLoginSessionId.Trim(),
                        Role = GetUserRole(sysproLogonProfile),
                        DefaultBranch = GetUserDefaultArBranch(sysproLogonProfile)
                    };

                    DynamicSessionStorage.GlobalOperator = LoginInputModel.Operator;

                    result.RequestStatus = true;
                    if (isTest)
                    {
                        Logoff(sysproLoginSessionId.Trim());
                    }
                }
                else
                    result.ResponseData = new LoginOutputModel();
            }
            catch (Exception exception)
            {
                result.ResponseMessages.Add(exception.Message.ToString());
                result.ResponseData = string.Empty;
                result.RequestStatus = false;
            }

            Logger.LogSysproActivity(new LogDataModel()
            {
                LogId = 0,
                SourceUser = this.LoginInputModel.WMSUser,
                SysproOperator = this.LoginInputModel.Operator,
                SysproCompany = this.LoginInputModel.CompanyCode,
                Action = EnumManager.GetEnumDescription((SysproAction)Convert.ToChar("P")),
                BusinessObject = "Logon",
                SysproInput = "",
                SysproOutput = (string)result.ResponseData.ToString(),
                SysproParameter = "",
                SysproKey = sysproLoginSessionId,
                SourceKey = "",
                AdditionData = "Login: " + RetryTransection,
                ErrorMessage = string.Join(" || ", result.ResponseMessages),
                Status = result.RequestStatus ? "Success" : "Failed"
            });

            return result;
        }

        internal bool IsLoggedOn(string sessionId)
        {
            try
            {
                var sysproLogonProfile = client.GetLogonProfile(sessionId);
            }
            catch (Exception exception)
            {
                if (exception.Message.Contains(SysproGeneralSettings.LogonProfileExpiredMessage))
                    return false;
            };
            return true;
        }

        internal void Logoff(string sessionId)
        {
            try { client.Logoff(sessionId); }
            catch { }

            Logger.LogSysproActivity(new LogDataModel()
            {
                LogId = 0,
                SourceUser = this.LoginInputModel.WMSUser,
                SysproOperator = this.LoginInputModel.Operator,
                SysproCompany = this.LoginInputModel.CompanyCode,
                Action = EnumManager.GetEnumDescription((SysproAction)Convert.ToChar("P")),
                BusinessObject = "Logoff",
                SysproInput = "",
                SysproOutput = "",
                SysproParameter = "",
                SysproKey = "",
                SourceKey = sessionId,
                AdditionData = "Login: " + RetryTransection,
                ErrorMessage = "",
                Status = "Success"
            });
        }

        internal ResponseModel LogonIfNotLoggedIn(string sessionId)
        {
            var result = new ResponseModel();

            if (string.IsNullOrEmpty(sessionId))
            {
                result = this.Logon();
                if (!result.RequestStatus)
                {
                    throw new Exception(result.ResponseMessages.Count > 0 ? string.Join(" <br/>", result.ResponseMessages) : "Syspro Interface Error: There are some Problem in Login to Syspro.");
                }
                result.ResponseMessages.Add(AuthenticationMessages.CreatedNewSession(((LoginOutputModel)result.ResponseData).SessionId));
            }
            else if (!this.IsLoggedOn(sessionId))
            {
                result = this.Logon();

                if (!result.RequestStatus)
                {
                    throw new Exception(result.ResponseMessages.Count > 0 ? string.Join(" <br/>", result.ResponseMessages) : "Syspro Interface Error: There are some Problem in Login to Syspro.");
                }

                result.ResponseMessages.Add(AuthenticationMessages.CreatedNewSession(((LoginOutputModel)result.ResponseData).SessionId));
            }
            else
            {
                result.ResponseData = new LoginOutputModel() { SessionId = sessionId.Trim() };
                result.RequestStatus = true;
            }

            return result;
        }
        #endregion

        internal ResponseModel PostTransaction(string businessObject, string parameterXML, string documentXML, string sessionId, string action, string OrderNumber
            , string rePostId = "", int SysproActivityLog = 0, string JobNumber = "", string AdditionData = "")
        {
            string SourceKey = OrderNumber;
            RetryTransection++;
            var result = LogonIfNotLoggedIn(sessionId);

            if (!result.RequestStatus)
            {
                result.ResponseMessages = new List<string> { AuthenticationMessages.SysproUserNotLoggedOn, "Session Id: " + sessionId };
            }
            else
            {
                var msg = result.ResponseMessages.FirstOrDefault(a => a.ToLower().Contains("New Session ID created".ToLower()));
                if (!string.IsNullOrEmpty(msg))
                    result.ResponseMessages.Remove(msg);
                try
                {
                    result.ResponseData = client.TransactionPost(((LoginOutputModel)result.ResponseData).SessionId, businessObject, parameterXML, documentXML);
                    var postErrors = GetResponseErrors((string)result.ResponseData);
                    result.ResponseMessages.AddRange(postErrors);
                    result.RequestStatus = !postErrors.Any();
                    result.ResponseMessages.AddRange(GetResponseWarnings((string)result.ResponseData));
                }
                catch (Exception exception)
                {
                    if (RetryTransection <= 3)
                    {
                        if (exception.Message.ToLower().Contains("The supplied UserID is invalid".ToLower()))
                        {
                            result = PostTransaction(businessObject, parameterXML, documentXML, sessionId, action, OrderNumber, rePostId, SysproActivityLog);
                            return result;
                        }
                    }

                    result.ResponseMessages.Add(exception.Message.ToString());
                    result.ResponseData = string.Empty;
                    result.RequestStatus = false;
                }
            }

            if (businessObject == "SORTOI" && result.RequestStatus)
            {
                var newSalesOrderNumber = GetSalesOrderNumber(result);
                DynamicSessionStorage.GlobalAssistedSearchParam = newSalesOrderNumber;
                DynamicSessionStorage.GlobalTransactionReference = newSalesOrderNumber;
                OrderNumber = newSalesOrderNumber;
            }
            if (result.RequestStatus && businessObject == "SORTCH")
            {
                OrderNumber = GetCreditNoteNumber(result);
            }
            if (result.RequestStatus && businessObject == "SORTTR")
            {
                OrderNumber = GetSalesOrderNumberSORTTR(result);
            }
            if (result.RequestStatus && businessObject == "SORTBO")
            {
                OrderNumber = GetSalesOrderNumberSORTBO(result);
            }
            if (result.RequestStatus && businessObject == "SORTIC")
            {
                OrderNumber = GetSalesOrderNumberSORTIC(result);
            }
            if (result.RequestStatus && businessObject == "WIPTJB" && action == "A")
            {
                OrderNumber = GetJobNumber(result);
            }

            if (SysproActivityLog == 0)
            {
                Logger.LogSysproActivity(new LogDataModel()
                {
                    LogId = 0,
                    SourceUser = this.LoginInputModel.WMSUser,
                    SysproOperator = this.LoginInputModel.Operator,
                    SysproCompany = this.LoginInputModel.CompanyCode,
                    Action = EnumManager.GetEnumDescription((SysproAction)Convert.ToChar(action)),
                    BusinessObject = businessObject,
                    SysproInput = documentXML,
                    SysproOutput = (string)result.ResponseData,
                    SysproParameter = parameterXML,
                    SysproKey = OrderNumber,
                    SourceKey = SourceKey,
                    AdditionData = "Login: " + RetryTransection,
                    ErrorMessage = string.Join(" || ", result.ResponseMessages),
                    Status = result.RequestStatus ? "Success" : "Failed"
                });
            }
            else
            {
                Logger.UpdateSysproActivity(new LogDataModel()
                {
                    LogId = SysproActivityLog,
                    SourceUser = this.LoginInputModel.WMSUser,
                    SysproOperator = this.LoginInputModel.Operator,
                    SysproCompany = this.LoginInputModel.CompanyCode,
                    Action = EnumManager.GetEnumDescription((SysproAction)Convert.ToChar(action)),
                    BusinessObject = businessObject,
                    SysproInput = documentXML,
                    SysproOutput = (string)result.ResponseData,
                    SysproParameter = parameterXML,
                    SysproKey = OrderNumber,
                    SourceKey = SourceKey,
                    AdditionData = AdditionData + ", Login: " + RetryTransection,
                    ErrorMessage = string.Join(" || ", result.ResponseMessages),
                    Status = result.RequestStatus ? "Success" : "Failed"
                });
            }

            return result;
        }

        //internal ResponseModel BuildTransaction(string businessObject, string parameterXML, string sessionId, string action)
        //{
        //    var result = LogonIfNotLoggedIn(sessionId);

        //    if (!result.RequestStatus)
        //    {
        //        result.ResponseMessages = new List<string> { AuthenticationMessages.SysproUserNotLoggedOn, "Session Id: " + sessionId };
        //    }
        //    else
        //    {
        //        try
        //        {
        //            result.ResponseData = SysproTransactions.Build(((LoginOutputModel)result.ResponseData).SessionId, businessObject, parameterXML);
        //            var postErrors = GetResponseErrors((string)result.ResponseData);
        //            result.ResponseMessages.AddRange(postErrors);
        //            result.RequestStatus = !postErrors.Any();
        //            result.ResponseMessages.AddRange(GetResponseWarnings((string)result.ResponseData));
        //        }
        //        catch (Exception exception)
        //        {
        //            result.ResponseMessages.Add(exception.Message.ToString());
        //            result.ResponseData = string.Empty;
        //            result.RequestStatus = false;
        //        }
        //    }

        //    Logger.LogSysproActivity(new LogDataModel()
        //    {
        //        LogId = 0,
        //        SourceUser = this.LoginInputModel.WMSUser,
        //        SysproOperator = this.LoginInputModel.Operator,
        //        SysproCompany = this.LoginInputModel.CompanyCode,
        //        Action = EnumManager.GetEnumDescription((SysproAction)Convert.ToChar(action)),
        //        BusinessObject = businessObject,
        //        SysproInput = string.Empty,
        //        SysproOutput = (string)result.ResponseData,
        //        SysproParameter = parameterXML,
        //        SysproKey = string.Empty,
        //        SourceKey = string.Empty,
        //        AdditionData = string.Empty,
        //        ErrorMessage = string.Join(" || ", result.ResponseMessages),
        //        Status = result.RequestStatus ? "Success" : "Failed",
        //    });

        //    return result;
        //}

        internal ResponseModel SetupTransaction(string businessObject, string parameterXML, string documentXML, string sessionId, string action, LineCommandOptions setupCommand, string TransectionRef, string rePostId = "", int SysproActivityLog = 0)
        {
            string actionName = "";
            RetryTransection++;
            var result = LogonIfNotLoggedIn(sessionId);

            if (!result.RequestStatus)
            {
                result.ResponseMessages = new List<string> { AuthenticationMessages.SysproUserNotLoggedOn, "Session Id: " + sessionId };
            }
            else
            {
                try
                {
                    switch (setupCommand)
                    {
                        case LineCommandOptions.Added:
                            result.ResponseData = SysproSetup.Add(((LoginOutputModel)result.ResponseData).SessionId, businessObject, parameterXML, documentXML);
                            actionName = "Add";
                            break;

                        case LineCommandOptions.Changed:
                            result.ResponseData = SysproSetup.Update(((LoginOutputModel)result.ResponseData).SessionId, businessObject, parameterXML, documentXML);
                            actionName = "Update";
                            break;

                        case LineCommandOptions.Deleted:
                            result.ResponseData = SysproSetup.Delete(((LoginOutputModel)result.ResponseData).SessionId, businessObject, parameterXML, documentXML);
                            actionName = "Delete";
                            break;

                        default:
                            break;
                    }

                    var setupErrors = GetResponseErrors((string)result.ResponseData);
                    result.ResponseMessages.AddRange(setupErrors);
                    result.RequestStatus = !setupErrors.Any();
                    result.ResponseMessages.AddRange(GetResponseWarnings((string)result.ResponseData));
                }
                catch (Exception exception)
                {
                    if (RetryTransection <= 3)
                    {
                        if (exception.Message.ToLower().Contains("The supplied UserID is invalid".ToLower()))
                        {
                            result = SetupTransaction(businessObject, parameterXML, documentXML, sessionId, action, setupCommand, TransectionRef, rePostId, SysproActivityLog);
                            return result;
                        }
                    }
                    result.ResponseMessages.Add(exception.Message.ToString());
                    result.ResponseData = string.Empty;
                    result.RequestStatus = false;
                }
            }
            if (SysproActivityLog == 0)
            {
                //Logger.LogSysproActivity(new LogDataModel()
                //{
                //    Operator = this.LoginInputModel.Operator,
                //    Action = action,
                //    BusinessObject = businessObject,
                //    InputParameters = documentXML,
                //    Output = (string)result.ResponseData,
                //    InputSettings = parameterXML,
                //    GlobalRequestConnectorData = DynamicSessionStorage.GlobalRequestConnectorData,
                //    GlobalAssistedSearchParam = DynamicSessionStorage.GlobalAssistedSearchParam,
                //    Messages = string.Join(" || ", result.ResponseMessages),
                //    TransactionResult = result.RequestStatus,
                //    TransactionReference = DynamicSessionStorage.GlobalTransactionReference,
                //    WMSUser = this.LoginInputModel.WMSUser
                //});

                Logger.LogSysproActivity(new LogDataModel()
                {
                    LogId = 0,
                    SourceUser = this.LoginInputModel.WMSUser,
                    SysproOperator = this.LoginInputModel.Operator,
                    SysproCompany = this.LoginInputModel.CompanyCode,
                    Action = actionName,
                    BusinessObject = businessObject,
                    SysproInput = documentXML,
                    SysproOutput = (string)result.ResponseData,
                    SysproParameter = parameterXML,
                    SysproKey = string.Empty,
                    SourceKey = TransectionRef,
                    AdditionData = "Login: " + RetryTransection,
                    ErrorMessage = string.Join(" || ", result.ResponseMessages),
                    Status = result.RequestStatus ? "Success" : "Failed",
                });
            }
            else
            {
                Logger.UpdateSysproActivity(new LogDataModel()
                {
                    LogId = SysproActivityLog,
                    SourceUser = this.LoginInputModel.WMSUser,
                    SysproOperator = this.LoginInputModel.Operator,
                    SysproCompany = this.LoginInputModel.CompanyCode,
                    Action = actionName,
                    BusinessObject = businessObject,
                    SysproInput = documentXML,
                    SysproOutput = (string)result.ResponseData,
                    SysproParameter = parameterXML,
                    SysproKey = string.Empty,
                    SourceKey = TransectionRef,
                    AdditionData = "Login: " + RetryTransection,
                    ErrorMessage = string.Join(" || ", result.ResponseMessages),
                    Status = result.RequestStatus ? "Success" : "Failed",
                });

                //Logger.UpdateSysproActivity(new LogDataModel()
                //{
                //    LogId = SysproActivityLog,
                //    Operator = this.LoginInputModel.Operator,
                //    Action = action,
                //    BusinessObject = businessObject,
                //    InputParameters = documentXML,
                //    Output = (string)result.ResponseData,
                //    InputSettings = parameterXML,
                //    GlobalRequestConnectorData = string.Empty,
                //    GlobalAssistedSearchParam = rePostId,
                //    Messages = string.Join(" || ", result.ResponseMessages),
                //    TransactionResult = result.RequestStatus,
                //    TransactionReference = DynamicSessionStorage.GlobalTransactionReference,
                //    WMSUser = this.LoginInputModel.WMSUser
                //});
            }

            return result;
        }

        //internal ResponseModel QueryTransaction(string businessObject, string documentXML, string sessionId, string action)
        //{
        //    var result = LogonIfNotLoggedIn(sessionId);

        //    if (!result.RequestStatus)
        //    {
        //        result.ResponseMessages = new List<string> { AuthenticationMessages.SysproUserNotLoggedOn, "Session Id: " + sessionId };
        //    }
        //    else
        //    {
        //        try
        //        {
        //            result.ResponseData = SysproQuery.Query(sessionId, businessObject, documentXML);
        //            var queryErrors = GetResponseErrors((string)result.ResponseData);
        //            result.ResponseMessages.AddRange(queryErrors);
        //            result.RequestStatus = !queryErrors.Any();
        //            result.ResponseMessages.AddRange(GetResponseWarnings((string)result.ResponseData));
        //        }
        //        catch (Exception exception)
        //        {
        //            result.ResponseMessages.Add(exception.Message.ToString());
        //            result.ResponseData = string.Empty;
        //            result.RequestStatus = false;
        //        }
        //    }

        //    Logger.LogSysproActivity(new LogDataModel()
        //    {
        //        LogId = 0,
        //        SourceUser = this.LoginInputModel.WMSUser,
        //        SysproOperator = this.LoginInputModel.Operator,
        //        SysproCompany = this.LoginInputModel.CompanyCode,
        //        Action = EnumManager.GetEnumDescription((SysproAction)Convert.ToChar(action)),
        //        BusinessObject = businessObject,
        //        SysproInput = documentXML,
        //        SysproOutput = (string)result.ResponseData,
        //        SysproParameter = string.Empty,
        //        SysproKey = string.Empty,
        //        SourceKey = string.Empty,
        //        AdditionData = string.Empty,
        //        ErrorMessage = string.Join(" || ", result.ResponseMessages),
        //        Status = result.RequestStatus ? "Success" : "Failed",
        //    });

        //    //Logger.LogSysproActivity(new LogDataModel()
        //    //{
        //    //    Operator = this.LoginInputModel.Operator,
        //    //    Action = action,
        //    //    BusinessObject = businessObject,
        //    //    InputParameters = documentXML,
        //    //    Output = (string)result.ResponseData,
        //    //    InputSettings = string.Empty,
        //    //    GlobalRequestConnectorData = DynamicSessionStorage.GlobalRequestConnectorData,
        //    //    GlobalAssistedSearchParam = DynamicSessionStorage.GlobalAssistedSearchParam,
        //    //    Messages = string.Join(" || ", result.ResponseMessages),
        //    //    TransactionResult = result.RequestStatus,
        //    //    TransactionReference = DynamicSessionStorage.GlobalTransactionReference,
        //    //    WMSUser = this.LoginInputModel.WMSUser
        //    //});

        //    return result;
        //}

        //internal string BuildTransaction(string businessObject, string documentXML, string sessionId) => SysproTransactions.Build(sessionId, businessObject, documentXML);



        #region XML Parse method
        private List<string> GetResponseErrors(string xmlData)
        {
            var errorList = new List<string>();
            var xmlDocument = new XmlDocument();

            xmlDocument.LoadXml(xmlData);

            if (xmlDocument.GetElementsByTagName("ErrorDescription") != null)
            {
                foreach (XmlNode errorNode in xmlDocument.GetElementsByTagName("ErrorDescription"))
                { errorList.Add(errorNode.InnerText); }
            }

            if (xmlDocument.GetElementsByTagName("InvalidRtf") != null)
            {
                foreach (XmlNode errorNode in xmlDocument.GetElementsByTagName("InvalidRtf"))
                { errorList.Add(errorNode.InnerText); }
            }

            return errorList;
        }

        private List<string> GetResponseWarnings(string xmlData)
        {
            var warningList = new List<string>();
            var xmlDocument = new XmlDocument();

            xmlDocument.LoadXml(xmlData);

            if (xmlDocument.GetElementsByTagName("WarningDescription") != null)
            {
                foreach (XmlNode warningNode in xmlDocument.GetElementsByTagName("WarningDescription"))
                { warningList.Add(warningNode.InnerText); }
            }

            return warningList;
        }

        private string GetUserRole(string xmlData)
        {

            var xmlDocument = new XmlDocument();

            xmlDocument.LoadXml(xmlData);

            return xmlDocument.SelectSingleNode("UserInfo/OperatorGroup").InnerText;
        }

        private string GetOperatorName(string xmlData)
        {
            var xmlDocument = new XmlDocument();

            xmlDocument.LoadXml(xmlData);

            return xmlDocument.SelectSingleNode("UserInfo/Operator").InnerText;
        }

        private string GetUserDefaultArBranch(string xmlData)
        {
            var xmlDocument = new XmlDocument();

            xmlDocument.LoadXml(xmlData);

            return xmlDocument.SelectSingleNode("UserInfo/DefaultArBranch").InnerText;
        }

        private string GetCreditNoteNumber(ResponseModel responseData)
        {
            var result = DynamicSessionStorage.GlobalAssistedSearchParam;

            XmlDocument xmldoc = new XmlDocument();
            xmldoc.LoadXml((string)responseData.ResponseData);
            var creditNoteNode = xmldoc.SelectSingleNode("socreditnoteheader/Item/ValidationStatus/CreditNoteDetails/CreditNoteCreated");
            if (creditNoteNode != null || creditNoteNode.InnerText != null)
            {
                result = creditNoteNode.InnerText;
            }

            return result;
        }

        private string GetSalesOrderNumber(ResponseModel responseData) //duplicated from sale manager as hotfix to log new sales order numbers
        {
            var result = DynamicSessionStorage.GlobalAssistedSearchParam;

            XmlDocument xmldoc = new XmlDocument();
            xmldoc.LoadXml((string)responseData.ResponseData);
            var salesOrderNode = xmldoc.SelectSingleNode("SalesOrders/Order/SalesOrder");

            if (salesOrderNode != null || salesOrderNode.InnerText != null)
            {
                //result = StringHelper.AddAsPrefix(salesOrderNode.InnerText, '0', SalesSettings.SalesOrderCharacterCount);
                result = salesOrderNode.InnerText;
            }

            return result;
        }

        private string GetSalesOrderNumberSORTTR(ResponseModel responseData) //duplicated from sale manager as hotfix to log new sales order numbers
        {
            var result = DynamicSessionStorage.GlobalAssistedSearchParam;

            XmlDocument xmldoc = new XmlDocument();
            xmldoc.LoadXml((string)responseData.ResponseData);
            var salesOrderNode = xmldoc.SelectSingleNode("postsalesorderssct/Item/Key/SalesOrder");

            //if (salesOrderNode != null || salesOrderNode.InnerText != null)
            //    result = StringHelper.AddAsPrefix(salesOrderNode.InnerText, '0', SalesSettings.SalesOrderCharacterCount);

            return salesOrderNode.InnerText;
        }

        private string GetSalesOrderNumberSORTBO(ResponseModel responseData) //duplicated from sale manager as hotfix to log new sales order numbers
        {
            var result = DynamicSessionStorage.GlobalAssistedSearchParam;

            XmlDocument xmldoc = new XmlDocument();
            xmldoc.LoadXml((string)responseData.ResponseData);
            var salesOrderNode = xmldoc.SelectSingleNode("PostSorBackOrderRelease/Item/Key/SalesOrder");

            //if (salesOrderNode != null || salesOrderNode.InnerText != null)
            //    result = StringHelper.AddAsPrefix(salesOrderNode.InnerText, '0', SalesSettings.SalesOrderCharacterCount);

            return salesOrderNode.InnerText;
        }

        private string GetSalesOrderNumberSORTIC(ResponseModel responseData) //duplicated from sale manager as hotfix to log new sales order numbers
        {
            var result = DynamicSessionStorage.GlobalAssistedSearchParam;

            XmlDocument xmldoc = new XmlDocument();
            xmldoc.LoadXml((string)responseData.ResponseData);
            var salesOrderNode = xmldoc.SelectSingleNode("postsalesorderinvoice/Item/Key/InvoiceNumber");

            //if (salesOrderNode != null || salesOrderNode.InnerText != null)
            //    result = StringHelper.AddAsPrefix(salesOrderNode.InnerText, '0', SalesSettings.SalesOrderCharacterCount);

            return salesOrderNode.InnerText;
        }

        private string GetJobNumber(ResponseModel responseData)//For taking Job Number
        {
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.LoadXml((string)responseData.ResponseData);

            var JobNumberNode = xmldoc.SelectSingleNode("postjob/Item/Job");

            return JobNumberNode.InnerText;
        }

        #endregion

    }
}
