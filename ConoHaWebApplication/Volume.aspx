<%@ Page Title="Volume" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Volume.aspx.cs" Inherits="ConoHaWebApplication.VolumePage" %>

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
            <h3>Volumes:</h3>
        </header>
        <p>
            <pre><asp:literal runat="server" ID="ltVolumes" /></pre>
        </p>
    </section>

</asp:Content>