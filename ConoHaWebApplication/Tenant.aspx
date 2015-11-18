<%@ Page Title="Tenant" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Tenant.aspx.cs" Inherits="ConoHaWebApplication.Tenant" %>

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
            <h3>User Access:</h3>
        </header>
        <p>
            <pre><asp:literal runat="server" ID="ltUserAccess" /></pre>
        </p>
    </section>

        <section class="contact">
        <header>
            <h3>Owner User:</h3>
        </header>
        <p>
            <pre><asp:literal runat="server" ID="ltOwnerUser" /></pre>
        </p>
    </section>

</asp:Content>