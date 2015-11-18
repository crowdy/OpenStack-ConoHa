<%@ Page Title="Network" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Network.aspx.cs" Inherits="ConoHaWebApplication.Network" %>

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
            <h3>Additional Ip Subnets:</h3>
        </header>
        <p>
            <pre><asp:literal runat="server" ID="ltAddSubnets" /></pre>
        </p>
    </section>

    <section class="contact">
        <header>
            <h3>Local Network Subnets:</h3>
        </header>
        <p>
            <pre><asp:literal runat="server" ID="ltLocalSubnets" /></pre>
        </p>
    </section>

    <section class="contact">
        <header>
            <h3>Ports:</h3>
        </header>
        <p>
            <pre><asp:literal runat="server" ID="ltPorts" /></pre>
        </p>
    </section>

    <section class="contact">
        <header>
            <h3>Security Groups:</h3>
        </header>
        <p>
            <pre><asp:literal runat="server" ID="ltSecurityGroups" /></pre>
        </p>
    </section>


</asp:Content>