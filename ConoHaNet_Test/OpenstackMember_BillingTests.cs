namespace ConoHaNet_Test
{
    using ConoHaNet;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Diagnostics;

    [TestClass()]
    public class OpenstackMember_BillingTests : OpenstackMemberTestBase
    {

        [ClassInitialize()]
        public static void ClassInit(TestContext context)
        {
        }

        [TestInitialize()]
        public void Initialize()
        {
        }

        [TestCleanup()]
        public void Cleanup()
        {
        }

        [TestMethod()]
        public void GetBillingApiEndPointTest()
        {
            var os = new OpenStackMember(UserName, Password, TenantName);
            Assert.IsNotNull(os.AccountServiceProvider);
        }

        [TestMethod()]
        public void ListOrderItemsTest()
        {
            var os = new OpenStackMember(UserName, Password, TenantName); // with tenant
            var items = os.ListOrderItems();
            Assert.IsNotNull(items);
            foreach (var i in items)
            {
                Assert.IsTrue(! string.IsNullOrEmpty(i.Id));
                Trace.WriteLine(string.Format("Id : {0}", i.Id));

                Assert.IsTrue(! string.IsNullOrEmpty(i.ServiceName));
                Trace.WriteLine(string.Format("ServiceName : {0}", i.ServiceName));

                Assert.IsTrue(! string.IsNullOrEmpty(i.ItemStatus));
                Trace.WriteLine(string.Format("ItemStatus : {0}", i.ItemStatus));

                Trace.WriteLine(string.Format("ServiceStartDate : {0}", i.ServiceStartDate));
            }
        }

        [TestMethod()]
        public void GetOrderItemTest()
        {
            var os = new OpenStackMember(UserName, Password, TenantName); // with tenant
            var items = os.ListOrderItems();
            Assert.IsNotNull(items);
            foreach (var i in items)
            {
                var item = os.GetOrderItem(i.Id);
                Assert.IsNotNull(item);
                Trace.WriteLine(string.Format("ItemId : {0}", item.Id));
                Trace.WriteLine(string.Format("ServiceName : {0}", item.ServiceName));
                Trace.WriteLine(string.Format("ItemStatus : {0}", item.Status));
                Trace.WriteLine(string.Format("ServiceStartDate : {0}", item.ServiceStartDate));
                Trace.WriteLine(string.Format("ProductName : {0}", item.ProductName));
                Trace.WriteLine(string.Format("ProductName : {0}", item.UnitPrice));
            }
        }

        [TestMethod()]
        public void ListProductItemsTest()
        {
            var os = new OpenStackMember(UserName, Password, TenantName); // with tenant
            var productitems = os.ListProducts();
            Assert.IsNotNull(productitems);

            foreach (var productitem in productitems)
            {
                Trace.WriteLine("=======================================================");
                Trace.WriteLine(string.Format("ServiceName : {0}", productitem.ServiceName));

                if (productitem.Products != null)
                foreach (var p in productitem.Products)
                {
                    Trace.WriteLine("\t=======================================================");
                    Trace.WriteLine(string.Format("\tProductId : {0}", p.ProductId));
                    Trace.WriteLine(string.Format("\tProductName : {0}", p.ProductName));
                    Trace.WriteLine(string.Format("\tMnemonic : {0}", p.Mnemonic));
                    Trace.WriteLine(string.Format("\tProductPriceId : {0}", p.ProductPriceId));
                    Trace.WriteLine(string.Format("\tUnitPrice : {0}", p.UnitPrice));
                    Trace.WriteLine(string.Format("\tStartDate : {0}", p.StartDate));
                }
            }
        }

        [TestMethod()]
        public void ListPaymentHistoryTest()
        {
            var os = new OpenStackMember(UserName, Password, TenantName); // with tenant
            var paymentHistory = os.ListPaymentHistory();
            Assert.IsNotNull(paymentHistory);
            foreach (var p in paymentHistory)
            {
                Trace.WriteLine(string.Format("DepositAmount : {0}", p.DepositAmount));
                Trace.WriteLine(string.Format("MoneyId : {0}", p.MoneyId));
                Trace.WriteLine(string.Format("UnusedAmount : {0}", p.UnusedAmount));
                Trace.WriteLine(string.Format("ReceivedAmount : {0}", p.ReceivedAmount));
                Trace.WriteLine(string.Format("IsLockeced : {0}", p.IsLockeced));
            }
        }

        [TestMethod()]
        public void GetPaymentSummaryTest()
        {
            var os = new OpenStackMember(UserName, Password, TenantName); // with tenant
            var s = os.GetPaymentSummary();
            Assert.IsNotNull(s);
            Trace.WriteLine(string.Format("TotalDepositAmount : {0}", s.TotalDepositAmount));
            Trace.WriteLine(string.Format("TotalLockedUnusedAmount : {0}", s.TotalLockedUnusedAmount));
            Trace.WriteLine(string.Format("TotalReceivedAmount : {0}", s.TotalReceivedAmount));
            Trace.WriteLine(string.Format("TotalUnusedAmount : {0}", s.TotalUnusedAmount));
        }

        [TestMethod()]
        public void ListBillingInvoicesTest()
        {
            var os = new OpenStackMember(UserName, Password, TenantName); // with tenant
            var invoices = os.ListBillingInvoices();
            Assert.IsNotNull(invoices);
            foreach (var i in invoices)
            {
                Trace.WriteLine(string.Format("AccountId : {0}", i.AccountId));
                Trace.WriteLine(string.Format("BalanceBill : {0}", i.BalanceBill));
                Trace.WriteLine(string.Format("BalanceBillPlasTax : {0}", i.BalanceBillPlasTax));
                Trace.WriteLine(string.Format("Bill : {0}", i.Bill));
                Trace.WriteLine(string.Format("BillPlasTax : {0}", i.BillPlasTax));
                Trace.WriteLine(string.Format("BrandId : {0}", i.BrandId));
                Trace.WriteLine(string.Format("CreatedBy : {0}", i.CreatedBy));
                Trace.WriteLine(string.Format("CreatedDate : {0}", i.CreatedDate));
                Trace.WriteLine(string.Format("Currency : {0}", i.Currency));
                Trace.WriteLine(string.Format("DueDate : {0}", i.DueDate));
            }
        }

        [TestMethod()]
        public void GetBillingInvoiceTest()
        {
            var os = new OpenStackMember(UserName, Password, TenantName); // with tenant
            var invoices = os.ListBillingInvoices();
            Assert.IsNotNull(invoices);
            foreach (var i in invoices)
            {
                var invoice = os.GetBillingInvoice(i.InvoiceId);
                Assert.IsNotNull(invoice);
                Trace.WriteLine(string.Format("AccountId : {0}", invoice.AccountId));
                Trace.WriteLine(string.Format("BalanceBill : {0}", invoice.BalanceBill));
                Trace.WriteLine(string.Format("BalanceBillPlasTax : {0}", invoice.BalanceBillPlasTax));
                Trace.WriteLine(string.Format("Bill : {0}", invoice.Bill));
                Trace.WriteLine(string.Format("BillPlasTax : {0}", invoice.BillPlasTax));
                Trace.WriteLine(string.Format("BrandId : {0}", invoice.BrandId));
                Trace.WriteLine(string.Format("CreatedBy : {0}", invoice.CreatedBy));
                Trace.WriteLine(string.Format("CreatedDate : {0}", invoice.CreatedDate));
                Trace.WriteLine(string.Format("Currency : {0}", invoice.Currency));
                Trace.WriteLine(string.Format("DueDate : {0}", invoice.DueDate));
            }
        }

        [TestMethod()]
        public void ListNotificationsTest()
        {
            var os = new OpenStackMember(UserName, Password, TenantName); // with tenant
            var notifications = os.ListNotifications();
            Assert.IsNotNull(notifications);
            foreach (var n in notifications)
            {
                Trace.WriteLine(string.Format("NotificationCode : {0}", n.NotificationCode));
                Trace.WriteLine(string.Format("DistributionMethod : {0}", n.DistributionMethod));
                Trace.WriteLine(string.Format("LanguageName : {0}", n.LanguageName));
                Trace.WriteLine(string.Format("PageName : {0}", n.PageName));
                Trace.WriteLine(string.Format("ReadStatus : {0}", n.ReadStatus));
                Trace.WriteLine(string.Format("CreatedDate : {0}", n.CreatedDate));
                Trace.WriteLine(string.Format("CreatedBy : {0}", n.CreatedBy));
                Trace.WriteLine(string.Format("LastUpdatedDate : {0}", n.LastUpdatedDate));
                Trace.WriteLine(string.Format("LastUpdatedBy : {0}", n.LastUpdatedBy));
            }
        }

        [TestMethod()]
        public void GetNotificationTest()
        {
            var os = new OpenStackMember(UserName, Password, TenantName); // with tenant
            var notifications = os.ListNotifications();
            Assert.IsNotNull(notifications);
            foreach (var n in notifications)
            {
                var notification = os.GetNotification(n.NotificationCode);
                Trace.WriteLine(string.Format("NotificationCode : {0}", notification.NotificationCode));
                Trace.WriteLine(string.Format("DistributionMethod : {0}", notification.DistributionMethod));
                Trace.WriteLine(string.Format("LanguageName : {0}", notification.LanguageName));
                Trace.WriteLine(string.Format("PageName : {0}", notification.PageName));
                Trace.WriteLine(string.Format("ReadStatus : {0}", notification.ReadStatus));
                Trace.WriteLine(string.Format("CreatedDate : {0}", notification.CreatedDate));
                Trace.WriteLine(string.Format("CreatedBy : {0}", notification.CreatedBy));
                Trace.WriteLine(string.Format("LastUpdatedDate : {0}", notification.LastUpdatedDate));
                Trace.WriteLine(string.Format("LastUpdatedBy : {0}", notification.LastUpdatedBy));
            }
        }

        [TestMethod()]
        public void SetNotificationTest()
        {
            Trace.WriteLine("on ticket");

            var os = new OpenStackMember(UserName, Password, TenantName); // with tenant
            var notifications = os.ListNotifications();
            Assert.IsNotNull(notifications);
            foreach (var n in notifications)
            {
                var notification = os.GetNotification(n.NotificationCode);
                var prevStatus = notification.ReadStatus;

                notification = os.SetNotification(n.NotificationCode, "Unread");
                Assert.AreEqual(notification.ReadStatus, "Unread");

                notification = os.SetNotification(n.NotificationCode, "ReadTitleOnly");
                Assert.AreEqual(notification.ReadStatus, "ReadTitleOnly");

                notification = os.SetNotification(n.NotificationCode, "Read");
                Assert.AreEqual(notification.ReadStatus, "Read");

                notification = os.SetNotification(n.NotificationCode, prevStatus);

                notification = os.GetNotification(n.NotificationCode);
                Assert.AreEqual(notification.ReadStatus, prevStatus);
            }
        }

    }
}