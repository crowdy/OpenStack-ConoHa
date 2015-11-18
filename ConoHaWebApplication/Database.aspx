<%@ Page Title="Database" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Database.aspx.cs" Inherits="ConoHaWebApplication.DatabasePage" %>

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
            <h3>DbService:</h3>
        </header>
        <p>
            <pre><asp:literal runat="server" ID="ltDbService" /></pre>
        </p>
    </section>

    <section class="contact">
        <header>
            <h3>Database:</h3>
        </header>
        <p>
            <pre><asp:literal runat="server" ID="ltDatabases" /></pre>
        </p>
    </section>

</asp:Content>