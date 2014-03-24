<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestPage.aspx.cs" Inherits="Web.TestPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Label ID="Label1" Text="Unit:" runat="server"></asp:Label>
    <asp:DropDownList ID="dlResponseType" runat="server" Height="25px" Width="136px">
            <asp:ListItem>en_US</asp:ListItem>
            <asp:ListItem>en_UK</asp:ListItem>
            <asp:ListItem>user</asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        <asp:Button ID="btnDownloadBP" runat="server" OnClick="btnDownloadBP_Click" Text="Download OpenApiBP Data" />
        
        <br />
        <br />
        <asp:Button ID="btnDownloadWeight" runat="server" OnClick="btnDownloadWeight_Click"
            Text="Download OpenApiWeight Data" />
        
        <br />
        <br />
        <asp:Button ID="btnDownloadBG" runat="server" OnClick="btnDownloadBG_Click" Text="Download OpenApiBG Data" />
        <br />
        <br />
        <asp:Button ID="btnDownloadBO" runat="server" OnClick="btnDownloadBO_Click" Text="Download OpenApiSpO2 Data" />
        <br />
        <br />
        <asp:Button ID="btnDownloadAR" runat="server" OnClick="btnDownloadAR_Click" Text="Download OpenApiActivity Data" />
        <br />
        <br />
        <asp:Button ID="btnDownloadSR" runat="server" OnClick="btnDownloadSR_Click" Text="Download OpenApiSleep Data" />
        <br />
        <br />
        <asp:Button ID="btnDownloadUser" runat="server" OnClick="btnDownloadUser_Click" Text="Download OpenApiUserInfo Data" />
        <br />
        <br />
        <asp:Button ID="btnDownloadClientBP" runat="server" 
            Text="Download ClientAPP OpenApiBP Data" onclick="btnDownloadClientBP_Click" />
        <br />
        <br />
        <asp:Button ID="btnDownloadClientWeight" runat="server" Text="Download ClientAPP OpenApiWeight Data" onclick="btnDownloadClientWeight_Click" />
        <br />
        <br />
        <asp:Button ID="btnDownloadClientBO" runat="server" Text="Download ClientAPP OpenApiBO Data" onclick="btnDownloadClientBO_Click" />
        <br />
        <br />
        <asp:Button ID="btnDownloadClientBG" runat="server" Text="Download ClientAPP OpenApiBG Data" onclick="btnDownloadClientBG_Click" />
        <br />
        <br />
        <asp:Button ID="btnDownloadClientSR" runat="server" Text="Download ClientAPP OpenApiSleep Data" onclick="btnDownloadClientSR_Click" />
        <br />
        <br />
        <asp:Button ID="btnDownloadClientAR" runat="server" Text="Download ClientAPP OpenApiActivity Data" onclick="btnDownloadClientAR_Click" />
        <br />
        <br />
        <asp:Button ID="btnDownloadClientUser" runat="server" Text="Download ClientAPP OpenApiUserInfo Data" onclick="btnDownloadClientUser_Click" />
        <br />
        <br />      
        <asp:Button ID="btnRefresh" runat="server" OnClick="btnRefresh_Click" Text="Refresh Access Token" />
        <br />
        <br />
        <asp:Literal ID="lOutput" runat="server"></asp:Literal>
        <br />
        <br />
        <asp:Repeater ID="rptBPData" runat="server" Visible="false">
            <HeaderTemplate>
                <table>
                    <thead>
                        <tr>
                            <th style="width: 90px">
                                BP level
                            </th>
                            <th style="width: 90px">
                                HP
                            </th>
                            <th style="width: 90px">
                                HR
                            </th>
                            <th style="width: 90px">
                                IsArr
                            </th>
                            <th style="width: 90px">
                                LP
                            </th>
                            <th style="width: 90px">
                                Lat
                            </th>
                            <th style="width: 90px">
                                Lon
                            </th>
                            <th style="width: 90px">
                                Data ID
                            </th>
                            <th style="width: 90px">
                                Measure date
                            </th>
                            <th style="width: 90px">
                                Last change time
                            </th>
                            <th style="width: 90px">
                                Note
                            </th>
                            <th style="width: 90px">
                                UserID
                            </th>
                        </tr>
                    </thead>
                    <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td bgcolor="#f4f4f4">
                        <%#Eval("BPL")%>
                    </td>
                    <td bgcolor="#f4f4f4">
                        <%#Eval("HP")%>
                    </td>
                    <td bgcolor="#f4f4f4">
                        <%#Eval("HR")%>
                    </td>
                    <td bgcolor="#f4f4f4">
                        <%#Eval("IsArr")%>
                    </td>
                    <td bgcolor="#f4f4f4">
                        <%#Eval("LP")%>
                    </td>
                    <td bgcolor="#f4f4f4">
                        <%#Eval("Lat")%>
                    </td>
                    <td bgcolor="#f4f4f4">
                        <%#Eval("Lon")%>
                    </td>
                    <td bgcolor="#f4f4f4">
                        <%#Eval("DataID")%>
                    </td>
                    <td bgcolor="#f4f4f4">
                        <%#Eval("MDate")%>
                        <td bgcolor="#f4f4f4">
                            <%#Eval("LastChangeTime")%>
                        </td>
                        <td bgcolor="#f4f4f4">
                            <%#Eval("Note")%>
                        </td>
                        <td bgcolor="#f4f4f4">
                            <%#Eval("userid")%>
                        </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </tbody></table>
            </FooterTemplate>
        </asp:Repeater>
        <asp:Repeater ID="rptWeightData" runat="server" Visible="false">
            <HeaderTemplate>
                <table>
                    <thead>
                        <tr>
                            <th style="width: 90px">
                                BMI grade
                            </th>
                            <th style="width: 90px">
                                Bone mineral density
                            </th>
                            <th style="width: 90px">
                                DCI
                            </th>
                            <th style="width: 90px">
                                Body fat
                            </th>
                            <th style="width: 90px">
                                Muscle
                            </th>
                            <th style="width: 90px">
                                Water
                            </th>
                            <th style="width: 90px">
                                Weight
                            </th>
                            <th style="width: 90px">
                                Data only Serial number
                            </th>
                            <th style="width: 90px">
                                Data measurement of time
                            </th>
                            <th style="width: 90px">
                                Last change time
                            </th>
                            <th style="width: 90px">
                                Note
                            </th>
                            <th style="width: 90px">
                                UserID
                            </th>
                        </tr>
                    </thead>
                    <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td bgcolor="#f4f4f4">
                        <%#Eval("BMI")%>
                    </td>
                    <td bgcolor="#f4f4f4">
                        <%#Eval("BoneValue")%>
                    </td>
                    <td bgcolor="#f4f4f4">
                        <%#Eval("DCI")%>
                    </td>
                    <td bgcolor="#f4f4f4">
                        <%#Eval("FatValue")%>
                    </td>
                    <td bgcolor="#f4f4f4">
                        <%#Eval("MuscaleValue")%>
                    </td>
                    <td bgcolor="#f4f4f4">
                        <%#Eval("WaterValue")%>
                    </td>
                    <td bgcolor="#f4f4f4">
                        <%#Eval("WeightValue")%>
                    </td>
                    <td bgcolor="#f4f4f4">
                        <%#Eval("DataID")%>
                    </td>
                    <td bgcolor="#f4f4f4">
                        <%#Eval("MDate")%>
                    </td>
                    <td bgcolor="#f4f4f4">
                        <%#Eval("LastChangeTime")%>
                    </td>
                    <td bgcolor="#f4f4f4">
                        <%#Eval("Note")%>
                    </td>
                    <td bgcolor="#f4f4f4">
                        <%#Eval("userid") %>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </tbody></table>
            </FooterTemplate>
        </asp:Repeater>
        <asp:Repeater ID="rptBGData" runat="server" Visible="false">
            <HeaderTemplate>
                <table>
                    <thead>
                        <tr>
                            <th style="width: 90px">
                                Blood glucose value
                            </th>
                            <th style="width: 90px">
                                Dinner time
                            </th>
                            <th style="width: 90px">
                                Medication time
                            </th>
                            <th style="width: 90px">
                                Measure time
                            </th>
                            <th style="width: 90px">
                                Note
                            </th>
                            <th style="width: 90px">
                                Latitude
                            </th>
                            <th style="width: 90px">
                                Longitude
                            </th>
                            <th style="width: 90px">
                                Data only Serial number
                            </th>
                            <th style="width: 90px">
                                UserID
                            </th>
                        </tr>
                    </thead>
                    <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td bgcolor="#f4f4f4">
                        <%#Eval("BG")%>
                    </td>
                    <td bgcolor="#f4f4f4">
                        <%#Eval("DinnerSituation")%>
                    </td>
                    <td bgcolor="#f4f4f4">
                        <%#Eval("DrugSituation")%>
                    </td>
                    <td bgcolor="#f4f4f4">
                        <%#Eval("MDate")%>
                    </td>
                    <td bgcolor="#f4f4f4">
                        <%#Eval("Note")%>
                    </td>
                    <td bgcolor="#f4f4f4">
                        <%#Eval("Lat")%>
                    </td>
                    <td bgcolor="#f4f4f4">
                        <%#Eval("Lon")%>
                    </td>
                    <td bgcolor="#f4f4f4">
                        <%#Eval("DataID")%>
                    </td>
                    <td bgcolor="#f4f4f4">
                        <%#Eval("userid") %>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </tbody></table>
            </FooterTemplate>
        </asp:Repeater>
        <asp:Repeater ID="rptBOData" runat="server" Visible="false">
            <HeaderTemplate>
                <table>
                    <thead>
                        <tr>
                            <th style="width: 90px">
                                BloodOxygen Value
                            </th>
                            <th style="width: 90px">
                                Heart Rate
                            </th>
                            <th style="width: 90px">
                                Measure Time
                            </th>
                            <th style="width: 90px">
                                Note
                            </th>
                            <th style="width: 90px">
                                Longitude
                            </th>
                            <th style="width: 90px">
                                Latitude
                            </th>
                            <th style="width: 90px">
                                Data only Serial number
                            </th>
                            <th style="width: 90px">
                                UserID
                            </th>
                        </tr>
                    </thead>
                    <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td bgcolor="#f4f4f4">
                        <%#Eval("BO")%>
                    </td>
                    <td bgcolor="#f4f4f4">
                        <%#Eval("HR")%>
                    </td>
                    <td bgcolor="#f4f4f4">
                        <%#Eval("MDate")%>
                    </td>
                    <td bgcolor="#f4f4f4">
                        <%#Eval("Note")%>
                    </td>
                    <td bgcolor="#f4f4f4">
                        <%#Eval("Lon")%>
                    </td>
                    <td bgcolor="#f4f4f4">
                        <%#Eval("Lat")%>
                    </td>
                    <td bgcolor="#f4f4f4">
                        <%#Eval("DataID")%>
                    </td>
                    <td bgcolor="#f4f4f4">
                        <%#Eval("userid") %>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </tbody></table>
            </FooterTemplate>
        </asp:Repeater>
        <asp:Repeater ID="rptARData" runat="server" Visible="false">
            <HeaderTemplate>
                <table>
                    <thead>
                        <tr>
                            <th style="width: 90px">
                                Steps
                            </th>
                            <th style="width: 90px">
                                DistanceTraveled
                            </th>
                            <th style="width: 90px">
                                Measure Time
                            </th>
                            <th style="width: 90px">
                                Note
                            </th>
                            <th style="width: 90px">
                                Longitude
                            </th>
                            <th style="width: 90px">
                                Latitude
                            </th>
                            <th style="width: 90px">
                                Data only Serial number
                            </th>
                            <th style="width: 90px">
                                Calories
                            </th>
                            <th style="width: 90px">
                                UserID
                            </th>
                        </tr>
                    </thead>
                    <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td bgcolor="#f4f4f4">
                        <%#Eval("Steps")%>
                    </td>
                    <td bgcolor="#f4f4f4">
                        <%#Eval("DistanceTraveled")%>
                    </td>
                    <td bgcolor="#f4f4f4">
                        <%#Eval("MDate")%>
                    </td>
                    <td bgcolor="#f4f4f4">
                        <%#Eval("Note")%>
                    </td>
                    <td bgcolor="#f4f4f4">
                        <%#Eval("Lon")%>
                    </td>
                    <td bgcolor="#f4f4f4">
                        <%#Eval("Lat")%>
                    </td>
                    <td bgcolor="#f4f4f4">
                        <%#Eval("DataID")%>
                    </td>
                    <td bgcolor="#f4f4f4">
                        <%#Eval("Calories")%>
                    </td>
                    <td bgcolor="#f4f4f4">
                        <%#Eval("userid") %>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </tbody></table>
            </FooterTemplate>
        </asp:Repeater>
        <asp:Repeater ID="rptSRData" runat="server" Visible="false">
            <HeaderTemplate>
                <table>
                    <thead>
                        <tr>
                            <th style="width: 90px">
                                SleepEfficiency
                            </th>
                            <th style="width: 90px">
                                FallSleep
                            </th>
                            <th style="width: 90px">
                                StartTime
                            </th>
                            <th style="width: 90px">
                                EndTime
                            </th>
                            <th style="width: 90px">
                                Note
                            </th>
                            <th style="width: 90px">
                                Longitude
                            </th>
                            <th style="width: 90px">
                                Latitude
                            </th>
                            <th style="width: 90px">
                                Data only Serial number
                            </th>
                            <th style="width: 90px">
                                HoursSlept
                            </th>
                            <th style="width: 90px">
                                Awake
                            </th>
                            <th style="width: 90px">
                                UserID
                            </th>
                        </tr>
                    </thead>
                    <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td bgcolor="#f4f4f4">
                        <%#Eval("SleepEfficiency")%>
                    </td>
                    <td bgcolor="#f4f4f4">
                        <%#Eval("FallSleep")%>
                    </td>
                    <td bgcolor="#f4f4f4">
                        <%#Eval("StartTime")%>
                    </td>
                    <td bgcolor="#f4f4f4">
                        <%#Eval("EndTime")%>
                    </td>
                    <td bgcolor="#f4f4f4">
                        <%#Eval("Note")%>
                    </td>
                    <td bgcolor="#f4f4f4">
                        <%#Eval("Lon")%>
                    </td>
                    <td bgcolor="#f4f4f4">
                        <%#Eval("Lat")%>
                    </td>
                    <td bgcolor="#f4f4f4">
                        <%#Eval("DataID")%>
                    </td>
                    <td bgcolor="#f4f4f4">
                        <%#Eval("HoursSlept")%>
                    </td>
                    <td bgcolor="#f4f4f4">
                        <%#Eval("Awake")%>
                    </td>
                    <td bgcolor="#f4f4f4">
                        <%#Eval("userid") %>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </tbody></table>
            </FooterTemplate>
        </asp:Repeater>
        <asp:Repeater ID="rptUserData" runat="server" Visible="false">
            <HeaderTemplate>
                <table>
                    <thead>
                        <tr>
                            <th style="width: 90px">
                                UserID
                            </th>
                            <th style="width: 90px">
                                NickName
                            </th>
                            <th style="width: 90px">
                                Gender
                            </th>
                            <th style="width: 90px">
                                Height
                            </th>
                            <th style="width: 90px">
                                Weight
                            </th>
                            <th style="width: 90px">
                                DateOfBirth
                            </th>
                            <th style="width: 90px">
                                Logo
                            </th>                           
                            
                        </tr>
                    </thead>
                    <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td bgcolor="#f4f4f4">
                        <%#Eval("userid")%>
                    </td>
                    <td bgcolor="#f4f4f4">
                        <%#Eval("nickname")%>
                    </td>
                    <td bgcolor="#f4f4f4">
                        <%#Eval("gender")%>
                    </td>
                    <td bgcolor="#f4f4f4">
                        <%#Eval("height")%>
                    </td>
                    <td bgcolor="#f4f4f4">
                        <%#Eval("weight")%>
                    </td>
                    <td bgcolor="#f4f4f4">
                        <%#Eval("dateofbirth")%>
                    </td>
                    <td bgcolor="#f4f4f4">
                        <%#Eval("logo")%>
                    </td>                  
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </tbody></table>
            </FooterTemplate>
        </asp:Repeater>
        <asp:Literal ID="LitUser" runat="server"></asp:Literal>
    </div>
    </form>
</body>
</html>
