<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Reading.aspx.vb" Inherits="GleamTech.VideoUltimateExamples.WebForms.VB.ReadingPage" %>
<%@ Register TagPrefix="GleamTech" Namespace="GleamTech.Examples" Assembly="GleamTech.Core" %>
<%@ Import Namespace="GleamTech.AspNet" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>Reading video frames</title>
    <asp:PlaceHolder runat="server">
        <link href="<%=ResourceManager.GetUrl(PageCssBundle)%>" rel="stylesheet" />
        <script src="<%=ResourceManager.GetUrl(PageJsBundle)%>"></script>
    </asp:PlaceHolder>
</head>
<body style="margin: 20px;">

    <GleamTech:ExampleFileSelectorControl ID="exampleFileSelector" runat="server"
        InitialFile="MP4 Video.mp4" />
    
    <table class="info" style="min-width: 300px;">
        <caption>Current Frame</caption>
        <tr>
            <td style="text-align: center;">
                <img id="videoFrame" src="<%=FrameDownloaderUrl%>" style="max-width: 600px;"/>
            </td>
        </tr>
        <tr>
            <td><div id="timeSlider"></div></td>
        </tr>
    </table>
    
    <script type="text/javascript">
        createTimeSlider("timeSlider", "videoFrame", <%=TotalSeconds%>);
    </script>

</body>
</html>
