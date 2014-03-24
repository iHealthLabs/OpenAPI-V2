using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iHealthlabs.OpenAPI.Sample.Library;
using System.Text;
using iHealthlabs.OpenAPI.Sample.Library.Entity;
using System.Configuration;

namespace Web
{
    public partial class TestPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["code"]))
                {
                    ConnectToiHealthlabs cth = new ConnectToiHealthlabs();
                    bool result = cth.GetAccessToken(Request.QueryString["code"].Trim(), "123", this.Context);

                    if (result)
                    {
                        lOutput.Text = "Congratulations,you have connected to iHealth successfully.";
                    }
                    else
                    {
                        lOutput.Text = cth.Error.Error + "," + cth.Error.ErrorCode + "," + cth.Error.ErrorDescription;
                    }
                }
                else if (!string.IsNullOrEmpty(Request.QueryString["error"]) && !string.IsNullOrEmpty(Request.QueryString["error_description"]))
                {
                    lOutput.Text = "Some errors happened. Details:" + Request.QueryString["error"] + "," + Request.QueryString["error_description"];
                }
                else
                {
                    lOutput.Text = "You must get code first.";
                }
            }
        }

        protected void btnDownloadBP_Click(object sender, EventArgs e)
        {
            ConnectToiHealthlabs cth = new ConnectToiHealthlabs();
            string aBPUnit = dlResponseType.SelectedValue;
            DownloadBPDataResultEntity result = cth.DownloadBPData(this.Context, 1, DateTime.Now.AddDays(-999), DateTime.Now, aBPUnit);
            if (result != null)
            {
                lOutput.Text = GetPagingString(result.PageNumber, result.RecordCount, result.PageLength);
                rptBOData.Visible = false;
                rptARData.Visible = false;
                rptSRData.Visible = false;
                LitUser.Visible = false;
                rptBGData.Visible = false;
                rptWeightData.Visible = false;
                rptBPData.Visible = true;
                rptBPData.DataSource = result.BPDataList;
                rptBPData.DataBind();
            }
            else
            {
                lOutput.Text = "Some errors happened. ";
                if (cth.Error != null)
                {
                    lOutput.Text += "Details:" + cth.Error.Error + "," + cth.Error.ErrorCode + "," + cth.Error.ErrorDescription;
                }
            }
        }

        protected void btnDownloadWeight_Click(object sender, EventArgs e)
        {
            ConnectToiHealthlabs cth = new ConnectToiHealthlabs();
            string aWeightUnit = dlResponseType.SelectedValue;
            DownloadWeightDataResultEntity result = cth.DownloadWeightData(this.Context, null, null, null, aWeightUnit);
            if (result != null)
            {
                lOutput.Text = GetPagingString(result.PageNumber, result.RecordCount, result.PageLength);
                rptBOData.Visible = false;
                rptARData.Visible = false;
                rptSRData.Visible = false;
                LitUser.Visible = false;
                rptBGData.Visible = false;
                rptWeightData.Visible = true;
                rptBPData.Visible = false;
                rptWeightData.DataSource = result.WeightDataList;
                rptWeightData.DataBind();
            }
            else
            {
                lOutput.Text = "Some errors happened. ";
                if (cth.Error != null)
                {
                    lOutput.Text += "Details:" + cth.Error.Error + "," + cth.Error.ErrorCode + "," + cth.Error.ErrorDescription;
                }
            }
        }

        protected void btnDownloadBG_Click(object sender, EventArgs e)
        {
            ConnectToiHealthlabs cth = new ConnectToiHealthlabs();
            string aBGUnit = dlResponseType.SelectedValue;
            DownloadBGDataResultEntity result = cth.DownloadBGData(this.Context, null, null, null, aBGUnit);
            if (result != null)
            {
                lOutput.Text = GetPagingString(result.PageNumber, result.RecordCount, result.PageLength);
                rptBOData.Visible = false;
                rptARData.Visible = false;
                LitUser.Visible = false;
                rptSRData.Visible = false;
                rptBGData.Visible = true;
                rptWeightData.Visible = false;
                rptBPData.Visible = false;
                rptBGData.DataSource = result.BGDataList;
                rptBGData.DataBind();
            }
            else
            {
                lOutput.Text = "Some errors happened. ";
                if (cth.Error != null)
                {
                    lOutput.Text += "Details:" + cth.Error.Error + "," + cth.Error.ErrorCode + "," + cth.Error.ErrorDescription;
                }
            }
        }

        protected void btnDownloadBO_Click(object sender, EventArgs e)
        {
            ConnectToiHealthlabs cth = new ConnectToiHealthlabs();
            string aBOUnit = dlResponseType.SelectedValue;
            DownloadBODataResultEntity result = cth.DownloadBOData(this.Context, null, null, null, aBOUnit);
            if (result != null)
            {
                lOutput.Text = GetPagingString(result.PageNumber, result.RecordCount, result.PageLength);
                rptBOData.Visible = true;
                rptARData.Visible = false;
                LitUser.Visible = false;
                rptSRData.Visible = false;
                rptBGData.Visible = false;
                rptWeightData.Visible = false;
                rptBPData.Visible = false;
                rptBOData.DataSource = result.BODataList;
                rptBOData.DataBind();
            }
            else
            {
                lOutput.Text = "Some errors happened. ";
                if (cth.Error != null)
                {
                    lOutput.Text += "Details:" + cth.Error.Error + "," + cth.Error.ErrorCode + "," + cth.Error.ErrorDescription;
                }
            }
        }

        protected void btnDownloadAR_Click(object sender, EventArgs e)
        {
            ConnectToiHealthlabs cth = new ConnectToiHealthlabs();
            string aARUnit = dlResponseType.SelectedValue;
            DownloadActiveReportDataResultEntity result = cth.DownloadARData(this.Context, null, null, null, aARUnit);
            if (result != null)
            {
                lOutput.Text = GetPagingString(result.PageNumber, result.RecordCount, result.PageLength);
                rptBOData.Visible = false;
                rptARData.Visible = true;
                rptSRData.Visible = false;
                rptBGData.Visible = false;
                LitUser.Visible = false;
                rptWeightData.Visible = false;
                rptBPData.Visible = false;
                rptARData.DataSource = result.ARDataList;
                rptARData.DataBind();
            }
            else
            {
                lOutput.Text = "Some errors happened. ";
                if (cth.Error != null)
                {
                    lOutput.Text += "Details:" + cth.Error.Error + "," + cth.Error.ErrorCode + "," + cth.Error.ErrorDescription;
                }
            }
        }

        protected void btnDownloadSR_Click(object sender, EventArgs e)
        {
            ConnectToiHealthlabs cth = new ConnectToiHealthlabs();
            string aSRUnit = dlResponseType.SelectedValue;
            DownloadSleepReportDataResultEntity result = cth.DownloadSRData(this.Context, null, null, null, aSRUnit);
            if (result != null)
            {
                lOutput.Text = GetPagingString(result.PageNumber, result.RecordCount, result.PageLength);
                rptBOData.Visible = false;
                rptARData.Visible = false;
                rptSRData.Visible = true;
                LitUser.Visible = false;
                rptBGData.Visible = false;
                rptWeightData.Visible = false;
                rptBPData.Visible = false;
                rptSRData.DataSource = result.SRDataList;
                rptSRData.DataBind();
            }
            else
            {
                lOutput.Text = "Some errors happened. ";
                if (cth.Error != null)
                {
                    lOutput.Text += "Details:" + cth.Error.Error + "," + cth.Error.ErrorCode + "," + cth.Error.ErrorDescription;
                }
            }
        }

        protected void btnDownloadUser_Click(object sender, EventArgs e)
        {
            ConnectToiHealthlabs cth = new ConnectToiHealthlabs();
            string aUserUnit = dlResponseType.SelectedValue;
            DownloadUserInfoDataEntity result = cth.DownloadUserData(this.Context, null, null, null, aUserUnit);
            if (result != null)
            {
                lOutput.Text = "";
                rptBOData.Visible = false;
                rptARData.Visible = false;
                rptSRData.Visible = false;
                LitUser.Visible = true;
                rptBGData.Visible = false;
                rptWeightData.Visible = false;
                rptBPData.Visible = false;
                StringBuilder s = new StringBuilder();
                string aaa = s.Append("gender:" + result.gender + "<br />" + "dateofbirth:" + result.dateofbirth + "<br />" + "height:" + result.height + "<br />" + "nickname:" + result.nickname + "<br />" + "UserHeightUnit:" + result.UserHeightUnit + "<br />" + "userid:" + result.userid + "<br />" + "UserWeightUnit:" + result.UserWeightUnit + "<br />" + "weight:" + result.weight).ToString();
                LitUser.Text = aaa;
                LitUser.DataBind();
            }
            else
            {
                lOutput.Text = "Some errors happened. ";
                if (cth.Error != null)
                {
                    lOutput.Text += "Details:" + cth.Error.Error + "," + cth.Error.ErrorCode + "," + cth.Error.ErrorDescription;
                }
            }
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["code"]))
            {
                AccessTokenEntity temp = new AccessTokenEntity();
                ConnectToiHealthlabs cth = new ConnectToiHealthlabs();
                if (new ConnectToiHealthlabs().RefreshAccessToken(Request.QueryString["code"].Trim(), "", this.Context,out temp))
                {
                    rptWeightData.Visible = false;
                    rptBPData.Visible = false;
                    lOutput.Text = "Refreshed successfully.";
                }
                else
                {
                    lOutput.Text = "Some errors happened. ";
                    if (cth.Error != null)
                    {
                        lOutput.Text += "Details:" + cth.Error.Error + "," + cth.Error.ErrorCode + "," + cth.Error.ErrorDescription;
                    }
                }
            }
        }


        private string GetPagingString(int pageNumber, int recordcount, int pageLength)
        {
            int pagesNum = (int)((recordcount + pageLength - 1) / pageLength);
            return string.Format("Page {0} of {1}，Record Count {2}", pageNumber, pagesNum, recordcount);
        }

        protected void btnDownloadClientBP_Click(object sender, EventArgs e)
        {

            ConnectToiHealthlabs cth = new ConnectToiHealthlabs();
            string aBPUnit = dlResponseType.SelectedValue;
            DownloadBPDataResultEntity result = cth.DownloadClientBPData(this.Context, 1, DateTime.Now.AddDays(-999), DateTime.Now, aBPUnit);
            if (result != null)
            {
                lOutput.Text = GetPagingString(result.PageNumber, result.RecordCount, result.PageLength);
                rptBOData.Visible = false;
                rptARData.Visible = false;
                rptSRData.Visible = false;
                LitUser.Visible = false;
                rptBGData.Visible = false;
                rptWeightData.Visible = false;
                rptUserData.Visible = false;
                rptBPData.Visible = true;
                rptBPData.DataSource = result.BPDataList;
                rptBPData.DataBind();
            }
            else
            {
                lOutput.Text = "Some errors happened. ";
                if (cth.Error != null)
                {
                    lOutput.Text += "Details:" + cth.Error.Error + "," + cth.Error.ErrorCode + "," + cth.Error.ErrorDescription;
                }
            }
        }
        protected void btnDownloadClientWeight_Click(object sender, EventArgs e)
        {

            ConnectToiHealthlabs cth = new ConnectToiHealthlabs();
            string aBPUnit = dlResponseType.SelectedValue;
            DownloadWeightDataResultEntity result = cth.DownloadClientWeightData(this.Context, 1, DateTime.Now.AddDays(-999), DateTime.Now, aBPUnit);
            if (result != null)
            {
                lOutput.Text = GetPagingString(result.PageNumber, result.RecordCount, result.PageLength);
                rptBOData.Visible = false;
                rptARData.Visible = false;
                rptSRData.Visible = false;
                LitUser.Visible = false;
                rptBGData.Visible = false;
                rptBPData.Visible = false;
                rptWeightData.Visible = true;
                rptUserData.Visible = false;
                rptWeightData.DataSource = result.WeightDataList;
                rptWeightData.DataBind();
            }
            else
            {
                lOutput.Text = "Some errors happened. ";
                if (cth.Error != null)
                {
                    lOutput.Text += "Details:" + cth.Error.Error + "," + cth.Error.ErrorCode + "," + cth.Error.ErrorDescription;
                }
            }
        }
        protected void btnDownloadClientBG_Click(object sender, EventArgs e)
        {


            ConnectToiHealthlabs cth = new ConnectToiHealthlabs();
            string aBGUnit = dlResponseType.SelectedValue;
            DownloadBGDataResultEntity result = cth.DownloadClientBGData(this.Context, null, null, null, aBGUnit);
            if (result != null)
            {
                lOutput.Text = GetPagingString(result.PageNumber, result.RecordCount, result.PageLength);
                rptBOData.Visible = false;
                rptARData.Visible = false;
                LitUser.Visible = false;
                rptSRData.Visible = false;
                rptBGData.Visible = true;
                rptWeightData.Visible = false;
                rptBPData.Visible = false;
                rptUserData.Visible = false;
                rptBGData.DataSource = result.BGDataList;
                rptBGData.DataBind();
            }
            else
            {
                lOutput.Text = "Some errors happened. ";
                if (cth.Error != null)
                {
                    lOutput.Text += "Details:" + cth.Error.Error + "," + cth.Error.ErrorCode + "," + cth.Error.ErrorDescription;
                }
            }

        }
        protected void btnDownloadClientBO_Click(object sender, EventArgs e)
        {



            ConnectToiHealthlabs cth = new ConnectToiHealthlabs();
            string aBOUnit = dlResponseType.SelectedValue;
            DownloadBODataResultEntity result = cth.DownloadClientBOData(this.Context, null, null, null, aBOUnit);
            if (result != null)
            {
                lOutput.Text = GetPagingString(result.PageNumber, result.RecordCount, result.PageLength);
                rptBOData.Visible = true;
                rptARData.Visible = false;
                LitUser.Visible = false;
                rptSRData.Visible = false;
                rptBGData.Visible = false;
                rptWeightData.Visible = false;
                rptBPData.Visible = false;
                rptUserData.Visible = false;
                rptBOData.DataSource = result.BODataList;
                rptBOData.DataBind();
            }
            else
            {
                lOutput.Text = "Some errors happened. ";
                if (cth.Error != null)
                {
                    lOutput.Text += "Details:" + cth.Error.Error + "," + cth.Error.ErrorCode + "," + cth.Error.ErrorDescription;
                }
            }

        }
        protected void btnDownloadClientAR_Click(object sender, EventArgs e)
        {



            ConnectToiHealthlabs cth = new ConnectToiHealthlabs();
            string aARUnit = dlResponseType.SelectedValue;
            DownloadActiveReportDataResultEntity result = cth.DownloadClientARData(this.Context, null, null, null, aARUnit);
            if (result != null)
            {
                lOutput.Text = GetPagingString(result.PageNumber, result.RecordCount, result.PageLength);
                rptBOData.Visible = false;
                rptARData.Visible = true;
                rptSRData.Visible = false;
                rptBGData.Visible = false;
                LitUser.Visible = false;
                rptWeightData.Visible = false;
                rptBPData.Visible = false;
                rptUserData.Visible = false;
                rptARData.DataSource = result.ARDataList;
                rptARData.DataBind();
            }
            else
            {
                lOutput.Text = "Some errors happened. ";
                if (cth.Error != null)
                {
                    lOutput.Text += "Details:" + cth.Error.Error + "," + cth.Error.ErrorCode + "," + cth.Error.ErrorDescription;
                }
            }

        }
        protected void btnDownloadClientSR_Click(object sender, EventArgs e)
        {


            ConnectToiHealthlabs cth = new ConnectToiHealthlabs();
            string aSRUnit = dlResponseType.SelectedValue;
            DownloadSleepReportDataResultEntity result = cth.DownloadClientSRData(this.Context, null, null, null, aSRUnit);
            if (result != null)
            {
                lOutput.Text = GetPagingString(result.PageNumber, result.RecordCount, result.PageLength);
                rptBOData.Visible = false;
                rptARData.Visible = false;
                rptSRData.Visible = true;
                LitUser.Visible = false;
                rptBGData.Visible = false;
                rptWeightData.Visible = false;
                rptBPData.Visible = false;
                rptUserData.Visible = false;
                rptSRData.DataSource = result.SRDataList;
                rptSRData.DataBind();
            }
            else
            {
                lOutput.Text = "Some errors happened. ";
                if (cth.Error != null)
                {
                    lOutput.Text += "Details:" + cth.Error.Error + "," + cth.Error.ErrorCode + "," + cth.Error.ErrorDescription;
                }
            }

        }
        protected void btnDownloadClientUser_Click(object sender, EventArgs e)
        {


            ConnectToiHealthlabs cth = new ConnectToiHealthlabs();
            string aUserUnit = dlResponseType.SelectedValue;
            DownloadUserInfoResultEntity result = cth.DownloadClientUserData(this.Context, null, null, null, aUserUnit);
            if (result != null)
            {
                lOutput.Text = GetPagingString(result.PageNumber, result.RecordCount, result.PageLength);
                rptBOData.Visible = false;
                rptARData.Visible = false;
                rptSRData.Visible = false;
                LitUser.Visible = false;
                rptBGData.Visible = false;
                rptWeightData.Visible = false;
                rptBPData.Visible = false;
                rptUserData.Visible = false;
                rptUserData.Visible = true;
                rptUserData.DataSource = result.UserInfoList;
                rptUserData.DataBind();
            }
            else
            {
                lOutput.Text = "Some errors happened. ";
                if (cth.Error != null)
                {
                    lOutput.Text += "Details:" + cth.Error.Error + "," + cth.Error.ErrorCode + "," + cth.Error.ErrorDescription;
                }
            }

        }
    }
}
