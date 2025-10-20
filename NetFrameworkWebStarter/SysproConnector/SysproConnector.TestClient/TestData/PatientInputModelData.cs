using SysproConnector.Infrastructure;
using SysproConnector.Models;
using System;

namespace SysproConnector.TestClient.TestData
{
    internal class PatientInputModelData
    {
        internal PatientInputModel GetPatientInputModelData() =>
            new PatientInputModel() {
                Title                    = "Mr",
                FirstName                = "Faiyaz",
                SurName                  = "Aboobaker",
                MainAddressLine1         = "Romax Court",
                MainAddressLine2         = "136 Jan Hofmeyer Road",
                MainAddressCity          = "Durban",
                MainAddressState         = "KwaZulu Natal",
                MainAddressPostCode      = "4037",
                AlternateAddressLine1    = "Trafalgar Heights",
                AlternateAddressLine2    = "136 Brickfield Road",
                AlternateAddressCity     = "Durban",
                AlternateAddressState    = "KwaZulu Natal",
                AlternateAddressPostCode = "4091",
                RegistrationDate         = DateTime.Now,
                Status                   = OrderStatusOption.FunderApproved,
                Clinic                   = "01",
                TelephoneHome            = "0312006565",
                TelephoneWork            = "0312662745",
                TelephoneMobile          = "0614370537",
                Email                    = "faiyaz@bizsoft.co.za",
                DateOfBirth              = DateTime.Parse("1991-12-24 20:30:00"),
                Gender                   = "Male",
                DefaultFunder            = "000000000080031",
                FunderNumber             = "000000000080031",
                Clinician                = "120"
            };

        internal PatientInputModel GetUpdatedPatientInputModelData(string patientNumber)
        {
            var originalInputData     = GetPatientInputModelData();
            
            //set gender to female
            //set telephone home number to six zeros
            var updatedData           = originalInputData;
            updatedData.PatientNumber = patientNumber;
            updatedData.Gender        = "Female";
            updatedData.TelephoneHome = "000000";


            return updatedData;
        }
    }
}
