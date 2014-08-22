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
        <asp:Button ID="btnDownloadFOOD" runat="server" OnClick="btnDownloadFOOD_Click" Text="Download OpenApiFood Data" />
        <br />
        <br />
        <asp:Button ID="btnDownloadSPORT" runat="server" OnClick="btnDownloadSPORT_Click"
            Text="Download OpenApiSport Data" />
        <br />
        <br />
        <asp:Button ID="btnDownloadUser" runat="server" OnClick="btnDownloadUser_Click" Text="Download OpenApiUserInfo Data" />
        <br />
        <br />
        <asp:Button ID="btnDownloadClientBP" runat="server" Text="Download ClientAPP OpenApiBP Data"
            OnClick="btnDownloadClientBP_Click" />
        <br />
        <br />
        <asp:Button ID="btnDownloadClientWeight" runat="server" Text="Download ClientAPP OpenApiWeight Data"
            OnClick="btnDownloadClientWeight_Click" />
        <br />
        <br />
        <asp:Button ID="btnDownloadClientBO" runat="server" Text="Download ClientAPP OpenApiBO Data"
            OnClick="btnDownloadClientBO_Click" />
        <br />
        <br />
        <asp:Button ID="btnDownloadClientBG" runat="server" Text="Download ClientAPP OpenApiBG Data"
            OnClick="btnDownloadClientBG_Click" />
        <br />
        <br />
        <asp:Button ID="btnDownloadClientSR" runat="server" Text="Download ClientAPP OpenApiSleep Data"
            OnClick="btnDownloadClientSR_Click" />
        <br />
        <br />
        <asp:Button ID="btnDownloadClientAR" runat="server" Text="Download ClientAPP OpenApiActivity Data"
            OnClick="btnDownloadClientAR_Click" />
        <br />
        <br />
        <asp:Button ID="btnDownloadClientFOOD" runat="server" OnClick="btnDownloadClientFOOD_Click"
            Text="Download ClientAPP OpenApiFood Data" />
        <br />
        <br />
        <asp:Button ID="btnDownloadClientSPORT" runat="server" OnClick="btnDownloadClientSPORT_Click"
            Text="Download ClientAPP OpenApiSport Data" />
        <br />
        <br />
        <asp:Button ID="btnDownloadClientUser" runat="server" Text="Download ClientAPP OpenApiUserInfo Data"
            OnClick="btnDownloadClientUser_Click" />
        <br />
        <br />
        <asp:Button ID="btnRefresh" runat="server" OnClick="btnRefresh_Click" Text="Refresh Access Token" />
        <br />
        <br />
        <asp:Literal ID="lOutput" runat="server"></asp:Literal>
        <br />
        <br />
        <asp:HiddenField ID="hidNextUrl" runat="server" />
        <asp:HiddenField ID="hidPrevUrl" runat="server" />
        <asp:Button ID="BtnBPPrev" runat="server" Visible="false" Text="Prev" OnClick="BPPrev_Click" />
        <asp:Button ID="BtnBPNext" runat="server" Visible="false" Text="Next" OnClick="BPNext_Click" />
        <asp:Button ID="BtnWeightPrev" runat="server" Visible="false" Text="Prev" OnClick="WeightPrev_Click" />
        <asp:Button ID="BtnWeightNext" runat="server" Visible="false" Text="Next" OnClick="WeightNext_Click" />
        <asp:Button ID="BtnBGPrev" runat="server" Text="Next" Visible="false" OnClick="BGPrev_Click" />
        <asp:Button ID="BtnBGNext" runat="server" Text="Prev" Visible="false" OnClick="BGNext_Click" />
        <asp:Button ID="BtnSpo2Prev" runat="server" Text="Next" Visible="false" OnClick="Spo2Prev_Click" />
        <asp:Button ID="BtnSpo2Next" runat="server" Text="Prev" Visible="false" OnClick="Spo2Next_Click" />
        <asp:Button ID="BtnActivityPrev" runat="server" Text="Next" Visible="false" OnClick="ActivityPrev_Click" />
        <asp:Button ID="BtnActivityNext" runat="server" Text="Prev" Visible="false" OnClick="ActivityNext_Click" />
        <asp:Button ID="BtnSleepPrev" runat="server" Text="Next" Visible="false" OnClick="SleepPrev_Click" />
        <asp:Button ID="BtnSleepNext" runat="server" Text="Prev" Visible="false" OnClick="SleepNext_Click" />
        <asp:Button ID="BtnSportPrev" runat="server" Text="Next" Visible="false" OnClick="SportPrev_Click" />
        <asp:Button ID="BtnSportNext" runat="server" Text="Prev" Visible="false" OnClick="SportNext_Click" />
        <asp:Button ID="BtnFoodPrev" runat="server" Text="Next" Visible="false" OnClick="FoodPrev_Click" />
        <asp:Button ID="BtnFoodNext" runat="server" Text="Prev" Visible="false" OnClick="FoodNext_Click" />
        <asp:Button ID="BtnUserPrev" runat="server" Text="Next" Visible="false" OnClick="UserPrev_Click" />
        <asp:Button ID="BtnUserNext" runat="server" Text="Prev" Visible="false" OnClick="UserNext_Click" />
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
                                Data Source
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
                    <th style="width: 90px">
                        <%#Eval("DataSource")%>
                    </th>
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
                                Data Source
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
                    <th style="width: 90px">
                        <%#Eval("DataSource")%>
                    </th>
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
                                Last Change Time
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
                                Data Source
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
                        <%#Eval("LastChangeTime")%>
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
                    <th style="width: 90px">
                        <%#Eval("DataSource")%>
                    </th>
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
                                Last Change Time
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
                                Data Source
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
                        <%#Eval("LastChangeTime")%>
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
                    <th style="width: 90px">
                        <%#Eval("DataSource")%>
                    </th>
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
                                Last Change Time
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
                                Data Source
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
                        <%#Eval("LastChangeTime")%>
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
                    <th style="width: 90px">
                        <%#Eval("DataSource")%>
                    </th>
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
                                Last Change Time
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
                                Data Source
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
                        <%#Eval("LastChangeTime")%>
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
                    <th style="width: 90px">
                        <%#Eval("DataSource")%>
                    </th>
                    <td bgcolor="#f4f4f4">
                        <%#Eval("userid") %>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </tbody></table>
            </FooterTemplate>
        </asp:Repeater>
        <asp:Repeater ID="rptFoodData" runat="server" Visible="false">
            <HeaderTemplate>
                <table>
                    <thead>
                        <tr>
                            <th style="width: 90px">
                                FoodName
                            </th>
                            <th style="width: 90px">
                                AmountFood
                            </th>
                            <th style="width: 90px">
                                Calories
                            </th>
                            <th style="width: 90px">
                                FoodKind
                            </th>
                            <th style="width: 90px">
                                DataID
                            </th>
                            <th style="width: 90px">
                                MDate
                            </th>
                            <th style="width: 90px">
                                Last Change Time
                            </th>
                            <th style="width: 90px">
                                Lat
                            </th>
                            <th style="width: 90px">
                                Lon
                            </th>
                            <th style="width: 90px">
                                TimeZone
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
                        <%#Eval("FoodName")%>
                    </td>
                    <td bgcolor="#f4f4f4">
                        <%#Eval("Amount")%>
                    </td>
                    <td bgcolor="#f4f4f4">
                        <%#Eval("Calories")%>
                    </td>
                    <td bgcolor="#f4f4f4">
                        <%#Eval("FoodKind")%>
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
                        <%#Eval("Lat")%>
                    </td>
                    <td bgcolor="#f4f4f4">
                        <%#Eval("Lon")%>
                    </td>
                    <td bgcolor="#f4f4f4">
                        <%#Eval("TimeZone")%>
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
        <asp:Repeater ID="rptSportData" runat="server" Visible="false">
            <HeaderTemplate>
                <table>
                    <thead>
                        <tr>
                            <th style="width: 90px">
                                SportName
                            </th>
                            <th style="width: 90px">
                                SportStartTime
                            </th>
                            <th style="width: 90px">
                                SportEndTime
                            </th>
                            <th style="width: 90px">
                                Last Change Time
                            </th>
                            <th style="width: 90px">
                                Calories
                            </th>
                            <th style="width: 90px">
                                DateID
                            </th>
                            <th style="width: 90px">
                                Lat
                            </th>
                            <th style="width: 90px">
                                Lon
                            </th>
                            <th style="width: 90px">
                                TimeZone
                            </th>
                            <th style="width: 90px">
                                Data Source
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
                        <%#Eval("SportName")%>
                    </td>
                    <td bgcolor="#f4f4f4">
                        <%#Eval("SportStartTime")%>
                    </td>
                    <td bgcolor="#f4f4f4">
                        <%#Eval("SportEndTime")%>
                    </td>
                    <td bgcolor="#f4f4f4">
                        <%#Eval("LastChangeTime")%>
                    </td>
                    <td bgcolor="#f4f4f4">
                        <%#Eval("Calories")%>
                    </td>
                    <td bgcolor="#f4f4f4">
                        <%#Eval("DataID")%>
                    </td>
                    <td bgcolor="#f4f4f4">
                        <%#Eval("Lat")%>
                    </td>
                    <td bgcolor="#f4f4f4">
                        <%#Eval("Lon")%>
                    </td>
                    <td bgcolor="#f4f4f4">
                        <%#Eval("TimeZone")%>
                    </td>
                    <th style="width: 90px">
                        <%#Eval("DataSource")%>
                    </th>
                    <td bgcolor="#f4f4f4">
                        <%#Eval("userid")%>
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
        <br />
        <asp:Literal ID="LitUser" runat="server"></asp:Literal>
        <br />
        ------------------------------------------------------------------------------------------------------------------------
        <br />
        <div>
            Type Select:
            <asp:DropDownList ID="dlDataType" runat="server" Height="25px" Width="136px">
                <asp:ListItem Value="BP">BPData</asp:ListItem>
                <asp:ListItem Value="BG">BGData</asp:ListItem>
                <asp:ListItem Value="WEIGHT">WEIGHTData</asp:ListItem>
                <asp:ListItem Value="BO">BOData</asp:ListItem>
                <asp:ListItem Value="AM">AMData</asp:ListItem>
                <asp:ListItem Value="SLEEP">SLEEPData</asp:ListItem>
            </asp:DropDownList>
            <asp:CheckBox ID="chxml" runat="server" Text="xml Format" />
            <asp:Button ID="btnProduce" runat="server" OnClick="btnProduce_Click" Text="Produce Data" /><br />
            <br />
            <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" Height="100px" Width="589px"></asp:TextBox><br />
            <br />
            <table>
                <tr>
                    <td>
                        <asp:Button ID="btnUploadBP" runat="server" OnClick="btnUploadBP_Click" Text="Upload OpenApiBP Data" /><br />
                        <br />
                        <asp:Button ID="btnUploadBG" runat="server" OnClick="btnUploadBG_Click" Text="Upload OpenApiBG Data" /><br />
                        <br />
                        <asp:Button ID="btnUploadWeight" runat="server" OnClick="btnUploadWeight_Click" Text="Upload OpenApiWeight Data" /><br />
                        <br />
                        <asp:Button ID="btnUploadBO" runat="server" OnClick="btnUploadBO_Click" Text="Upload OpenApiSpO2 Data" /><br />
                        <br />
                        <asp:Button ID="btnUploadAM" runat="server" OnClick="btnUploadAM_Click" Text="Upload OpenApiActivity Data" /><br />
                        <br />
                        <asp:Button ID="btnUploadSLEEP" runat="server" OnClick="btnUploadSLEEP_Click" Text="Upload OpenApiSleep Data" /><br />
                        <br />
                    </td>
                    <td>
                        <asp:Button ID="btnUpdataBP" runat="server" OnClick="btnUpdataBP_Click" Text="Updata OpenApiBP Data" /><br />
                        <br />
                        <asp:Button ID="btnUpdataBG" runat="server" OnClick="btnUpdataBG_Click" Text="Updata OpenApiBG Data" /><br />
                        <br />
                        <asp:Button ID="btnUpdataWeight" runat="server" OnClick="btnUpdataWeight_Click" Text="Updata OpenApiWeight Data" /><br />
                        <br />
                        <asp:Button ID="btnUpdataBO" runat="server" OnClick="btnUpdataBO_Click" Text="Updata OpenApiSpO2 Data" /><br />
                        <br />
                        <asp:Button ID="btnUpdataAM" runat="server" OnClick="btnUpdataAM_Click" Text="Updata OpenApiActivity Data" /><br />
                        <br />
                        <asp:Button ID="btnUpdataSLEEP" runat="server" OnClick="btnUpdataSLEEP_Click" Text="Updata OpenApiSleep Data" /><br />
                        <br />
                    </td>
                </tr>
            </table>
            <asp:TextBox ID="txtBody" runat="server" TextMode="MultiLine" Height="200px" Width="589px"></asp:TextBox><br />
            <br />
            <br />
        </div>
    </div>
    </form>
</body>
</html>
