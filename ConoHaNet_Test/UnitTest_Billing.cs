using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConoHaNet;
using System.Diagnostics;
using System.Linq;
using ConoHaNet.Objects.Servers;
using System;

namespace ConoHaNet_Test
{
    [TestClass]
    public class UnitTest_Billing
    {
        string username = "gncu26535051"; // input your user name like gncu12345678
        string password = "P@ssWord1234-"; // input your own password
        string tenantname = "gnct26535051"; // input your own tenant name like gnct12345678
        string tenantid = "8b11719e50dd4dc4932a8930364f60c9"; // input your tenant id, which is 32 characters
        string region = "tyo1";

        [TestMethod]
        public void Test_ListBilling()
        {
            var osm = new OpenStackMember(
            username,
            password,
            tenantname,
            tenantid,
            defaultregion: region,
            bLazyProviderSetting: false
            );

            foreach(var invoice in osm.ListBillingInvoices())
            {
                Trace.WriteLine("=================================");
                // Trace.WriteLine(String.Format("AccountId : {0}", invoice.AccountId));
                // Trace.WriteLine(String.Format("BalanceBill : {0}", invoice.BalanceBill));
                // Trace.WriteLine(String.Format("BalanceBillPlasTax : {0}", invoice.BalanceBillPlasTax));
                // Trace.WriteLine(String.Format("Bill : {0}", invoice.Bill));
                Trace.WriteLine(String.Format("BillPlasTax : {0}", invoice.BillPlasTax));
                // Trace.WriteLine(String.Format("BrandId : {0}", invoice.BrandId));
                // Trace.WriteLine(String.Format("CreatedBy : {0}", invoice.CreatedBy));
                // Trace.WriteLine(String.Format("CreatedDate : {0}", invoice.CreatedDate));
                // Trace.WriteLine(String.Format("Currency : {0}", invoice.Currency));
                Trace.WriteLine(String.Format("DueDate : {0}", invoice.DueDate));
                Trace.WriteLine(String.Format("InvoiceDate : {0}", invoice.InvoiceDate));
                Trace.WriteLine(String.Format("InvoiceId : {0}", invoice.InvoiceId));
                // Trace.WriteLine(String.Format("InvoiceId : {0}", invoice.Status));
                // Trace.WriteLine(String.Format("InvoiceType : {0}", invoice.InvoiceType));
                /*
                if (invoice.Items != null)
                {
                    Trace.WriteLine(String.Format("Items.Count : {0}", invoice.Items.Count()));
                    foreach (var item in invoice.Items)
                    {
                        Trace.WriteLine("\t=============================");
                        Trace.WriteLine(String.Format("\tProductName : {0}", item.ProductName));
                        Trace.WriteLine(String.Format("\tServiceName : {0}", item.ServiceName));
                        Trace.WriteLine(String.Format("\tAccountId : {0}", item.ServiceStartDate));
                        Trace.WriteLine(String.Format("\tStatus : {0}", item.Status));
                        Trace.WriteLine(String.Format("\tUnitPrice : {0}", item.UnitPrice));
                    }
                }
                */
                // Trace.WriteLine(String.Format("LastUpdatedBy : {0}", invoice.LastUpdatedBy));
                // Trace.WriteLine(String.Format("LastUpdatedDate : {0}", invoice.LastUpdatedDate));
                Trace.WriteLine(String.Format("PaymentMethodType : {0}", invoice.PaymentMethodType));
                // Trace.WriteLine(String.Format("ReceiveType : {0}", invoice.ReceiveType));
                // Trace.WriteLine(String.Format("Tax : {0}", invoice.Tax));
            }

        }
    }
}
