<%@ Page Title="Image" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Image.aspx.cs" Inherits="ConoHaWebApplication.Image" %>

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
            <h3>Images(private only):</h3>
        </header>
        <p>
            <pre><asp:literal runat="server" ID="ltImages" /></pre>
        </p>
    </section>

</asp:Content>