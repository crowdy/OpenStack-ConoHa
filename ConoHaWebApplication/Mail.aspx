<%@ Page Title="Mail" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Mail.aspx.cs" Inherits="ConoHaWebApplication.MailPage" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %>.</h1>
    </hgroup>

    <section class="contact">
        <header>
            <h3>Summary:</h3>
        </header>
        <p>
            <pre><asp:literal runat="server" ID="ltSummary" /></pre>
        </p>
    </section>

    <section class="contact">
        <header>
            <h3>MailService:</h3>
        </header>
        <p>
            <pre><asp:literal runat="server" ID="ltMailService" /></pre>
        </p>
    </section>

</asp:Content>