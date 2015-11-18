<%@ Page Title="Server" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Server.aspx.cs" Inherits="ConoHaWebApplication.ServerPage" %>

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
            <h3>Servers:</h3>
        </header>
        <p>
            <pre><asp:literal runat="server" ID="ltServers" /></pre>
        </p>
    </section>

</asp:Content>