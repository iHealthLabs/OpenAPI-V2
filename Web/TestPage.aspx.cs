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

        #region BP

        protected void btnDownloadBP_Click(object sender, EventArgs e)
        {
            hidNextUrl.Value = "";
            hidPrevUrl.Value = "";

            ConnectToiHealthlabs cth = new ConnectToiHealthlabs();
            string aBPUnit = dlResponseType.SelectedValue;
            DownloadBPDataResultEntity result = cth.DownloadBPData(this.Context, 1, DateTime.Now.AddDays(-999), DateTime.Now, aBPUnit);
            if (result != null)
            {
                hidNextUrl.Value = result.NextPageUrl;
                hidPrevUrl.Value = result.PrevPageUrl;

                lOutput.Text = GetPagingString(result.PageNumber, result.RecordCount, result.PageLength);
                BPControlProcess();
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

        protected void btnDownloadClientBP_Click(object sender, EventArgs e)
        {
            hidNextUrl.Value = "";
            hidPrevUrl.Value = "";
            ConnectToiHealthlabs cth = new ConnectToiHealthlabs();
            string aBPUnit = dlResponseType.SelectedValue;
            DownloadBPDataResultEntity result = cth.DownloadClientBPData(this.Context, 1, DateTime.Now.AddDays(-999), DateTime.Now, aBPUnit);
            if (result != null)
            {
                hidNextUrl.Value = result.NextPageUrl;
                hidPrevUrl.Value = result.PrevPageUrl;

                lOutput.Text = GetPagingString(result.PageNumber, result.RecordCount, result.PageLength);
                BPControlProcess();
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

        protected void BPPrev_Click(object sender, EventArgs e)
        {
            string Url = hidPrevUrl.Value;
            if (Url != "")
            {
                ConnectToiHealthlabs cth = new ConnectToiHealthlabs();

                Url = HttpUtility.UrlDecode(Url);

                string ResultString = cth.HttpGet(Url);
                if (ResultString.StartsWith("{\"Error\":"))
                {

                    ApiErrorEntity Error = cth.JsonDeserializ<ApiErrorEntity>(ResultString);
                    lOutput.Text = "Some errors happened. ";
                    if (cth.Error != null)
                    {
                        lOutput.Text += "Details:" + Error.Error + "," + Error.ErrorCode + "," + Error.ErrorDescription;
                    }

                }
                else
                {
                    DownloadBPDataResultEntity result = cth.JsonDeserializ<DownloadBPDataResultEntity>(ResultString);
                    lOutput.Text = GetPagingString(result.PageNumber, result.RecordCount, result.PageLength);

                    hidNextUrl.Value = result.NextPageUrl;
                    hidPrevUrl.Value = result.PrevPageUrl;

                    BPControlProcess();
                    rptBPData.DataSource = result.BPDataList;
                    rptBPData.DataBind();
                }
            }
        }

        protected void BPNext_Click(object sender, EventArgs e)
        {

            string Url = hidNextUrl.Value;
            if (Url != "")
            {
                Url = HttpUtility.UrlDecode(Url);
                ConnectToiHealthlabs cth = new ConnectToiHealthlabs();

                string ResultString = cth.HttpGet(Url);
                if (ResultString.StartsWith("{\"Error\":"))
                {
                    ApiErrorEntity Error = cth.JsonDeserializ<ApiErrorEntity>(ResultString);
                    lOutput.Text = "Some errors happened. ";
                    if (cth.Error != null)
                    {
                        lOutput.Text += "Details:" + Error.Error + "," + Error.ErrorCode + "," + Error.ErrorDescription;
                    }
                }
                else
                {
                    DownloadBPDataResultEntity result = cth.JsonDeserializ<DownloadBPDataResultEntity>(ResultString);
                    lOutput.Text = GetPagingString(result.PageNumber, result.RecordCount, result.PageLength);

                    hidNextUrl.Value = result.NextPageUrl;
                    hidPrevUrl.Value = result.PrevPageUrl;

                    BPControlProcess();
                    rptBPData.DataSource = result.BPDataList;
                    rptBPData.DataBind();
                }
            }
        }

        private void BPControlProcess()
        {
            BtnBPNext.Visible = true;
            BtnBPPrev.Visible = true;
            BtnWeightNext.Visible = false;
            BtnWeightPrev.Visible = false;
            BtnBGNext.Visible = false;
            BtnBGPrev.Visible = false;
            BtnSpo2Next.Visible = false;
            BtnSpo2Prev.Visible = false;
            BtnActivityNext.Visible = false;
            BtnActivityPrev.Visible = false;
            BtnSleepNext.Visible = false;
            BtnSleepPrev.Visible = false;
            BtnSportNext.Visible = false;
            BtnSportPrev.Visible = false;
            BtnFoodNext.Visible = false;
            BtnFoodPrev.Visible = false;
            BtnUserNext.Visible = false;
            BtnUserPrev.Visible = false;

            rptBOData.Visible = false;
            rptARData.Visible = false;
            rptSRData.Visible = false;
            LitUser.Visible = false;
            rptBGData.Visible = false;
            rptWeightData.Visible = false;
            rptFoodData.Visible = false;
            rptSportData.Visible = false;
            rptBPData.Visible = true;
            rptUserData.Visible = false;
        }

        protected void btnUploadBP_Click(object sender, EventArgs e)
        {
            string str = TextBox1.Text;
            string post = "Post";
            string querynumber = "number";
            string Type = "";
            if (chxml.Checked == true)
            {
                Type = "xml";
            }
            else
            {
                Type = "json";
            }
            ConnectToiHealthlabs cth = new ConnectToiHealthlabs();

            string result = cth.UploadloadBPData(this.Context, null, null, null, str, post, querynumber, Type);

            txtBody.Text = result;
        }

        protected void btnUpdataBP_Click(object sender, EventArgs e)
        {
            string put = "put";
            string querynumber = "number";
            string str = TextBox1.Text;
            string Type = "";
            if (chxml.Checked == true)
            {
                Type = "xml";
            }
            else
            {
                Type = "json";
            }

            ConnectToiHealthlabs cth = new ConnectToiHealthlabs();
            string result = cth.UpdataloadBPData(this.Context, null, null, null, str, put, querynumber, Type);

            txtBody.Text = result;
        }

        #endregion

        #region Weight

        protected void btnDownloadWeight_Click(object sender, EventArgs e)
        {
            hidNextUrl.Value = "";
            hidPrevUrl.Value = "";
            ConnectToiHealthlabs cth = new ConnectToiHealthlabs();
            string aWeightUnit = dlResponseType.SelectedValue;
            DownloadWeightDataResultEntity result = cth.DownloadWeightData(this.Context, null, null, null, aWeightUnit);
            if (result != null)
            {
                hidNextUrl.Value = result.NextPageUrl;
                hidPrevUrl.Value = result.PrevPageUrl;

                lOutput.Text = GetPagingString(result.PageNumber, result.RecordCount, result.PageLength);

                WeightControlProcess();

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

        protected void btnDownloadClientWeight_Click(object sender, EventArgs e)
        {
            hidNextUrl.Value = "";
            hidPrevUrl.Value = "";
            ConnectToiHealthlabs cth = new ConnectToiHealthlabs();
            string aBPUnit = dlResponseType.SelectedValue;
            DownloadWeightDataResultEntity result = cth.DownloadClientWeightData(this.Context, 1, DateTime.Now.AddDays(-999), DateTime.Now, aBPUnit);
            if (result != null)
            {
                hidNextUrl.Value = result.NextPageUrl;
                hidPrevUrl.Value = result.PrevPageUrl;
                lOutput.Text = GetPagingString(result.PageNumber, result.RecordCount, result.PageLength);
                WeightControlProcess();
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

        protected void WeightPrev_Click(object sender, EventArgs e)
        {
            string Url = hidPrevUrl.Value;
            if (Url != "")
            {
                ConnectToiHealthlabs cth = new ConnectToiHealthlabs();

                Url = HttpUtility.UrlDecode(Url);

                string ResultString = cth.HttpGet(Url);
                if (ResultString.StartsWith("{\"Error\":"))
                {

                    ApiErrorEntity Error = cth.JsonDeserializ<ApiErrorEntity>(ResultString);
                    lOutput.Text = "Some errors happened. ";
                    if (cth.Error != null)
                    {
                        lOutput.Text += "Details:" + Error.Error + "," + Error.ErrorCode + "," + Error.ErrorDescription;
                    }

                }
                else
                {
                    DownloadWeightDataResultEntity result = cth.JsonDeserializ<DownloadWeightDataResultEntity>(ResultString);
                    lOutput.Text = GetPagingString(result.PageNumber, result.RecordCount, result.PageLength);

                    hidNextUrl.Value = result.NextPageUrl;
                    hidPrevUrl.Value = result.PrevPageUrl;

                    WeightControlProcess();
                    rptBPData.DataSource = result.WeightDataList;
                    rptBPData.DataBind();
                }
            }
        }

        protected void WeightNext_Click(object sender, EventArgs e)
        {

            string Url = hidNextUrl.Value;
            if (Url != "")
            {
                Url = HttpUtility.UrlDecode(Url);
                ConnectToiHealthlabs cth = new ConnectToiHealthlabs();

                string ResultString = cth.HttpGet(Url);
                if (ResultString.StartsWith("{\"Error\":"))
                {
                    ApiErrorEntity Error = cth.JsonDeserializ<ApiErrorEntity>(ResultString);
                    lOutput.Text = "Some errors happened. ";
                    if (cth.Error != null)
                    {
                        lOutput.Text += "Details:" + Error.Error + "," + Error.ErrorCode + "," + Error.ErrorDescription;
                    }
                }
                else
                {
                    DownloadWeightDataResultEntity result = cth.JsonDeserializ<DownloadWeightDataResultEntity>(ResultString);
                    lOutput.Text = GetPagingString(result.PageNumber, result.RecordCount, result.PageLength);

                    hidNextUrl.Value = result.NextPageUrl;
                    hidPrevUrl.Value = result.PrevPageUrl;

                    WeightControlProcess();
                    rptBPData.DataSource = result.WeightDataList;
                    rptBPData.DataBind();
                }
            }
        }

        private void WeightControlProcess()
        {
            BtnBPNext.Visible = false;
            BtnBPPrev.Visible = false;
            BtnWeightNext.Visible = true;
            BtnWeightPrev.Visible = true;
            BtnBGNext.Visible = false;
            BtnBGPrev.Visible = false;
            BtnSpo2Next.Visible = false;
            BtnSpo2Prev.Visible = false;
            BtnActivityNext.Visible = false;
            BtnActivityPrev.Visible = false;
            BtnSleepNext.Visible = false;
            BtnSleepPrev.Visible = false;
            BtnSportNext.Visible = false;
            BtnSportPrev.Visible = false;
            BtnFoodNext.Visible = false;
            BtnFoodPrev.Visible = false;
            BtnUserNext.Visible = false;
            BtnUserPrev.Visible = false;

            rptBOData.Visible = false;
            rptARData.Visible = false;
            rptSRData.Visible = false;
            LitUser.Visible = false;
            rptBGData.Visible = false;
            rptWeightData.Visible = true;
            rptFoodData.Visible = false;
            rptSportData.Visible = false;
            rptBPData.Visible = false;
            rptUserData.Visible = false;
        }

        protected void btnUploadWeight_Click(object sender, EventArgs e)
        {
            string post = "Post";
            string querynumber = "number";
            string str = TextBox1.Text;
            string Type = "";
            if (chxml.Checked == true)
            {
                Type = "xml";
            }
            else
            {
                Type = "json";
            }

            ConnectToiHealthlabs cth = new ConnectToiHealthlabs();
            string result = cth.UploadloadWEIGHTData(this.Context, null, null, null, str, post, querynumber, Type);

            txtBody.Text = result;
        }

        protected void btnUpdataWeight_Click(object sender, EventArgs e)
        {
            string put = "put";
            string querynumber = "number";
            string str = TextBox1.Text;
            string Type = "";
            if (chxml.Checked == true)
            {
                Type = "xml";
            }
            else
            {
                Type = "json";
            }

            ConnectToiHealthlabs cth = new ConnectToiHealthlabs();
            string result = cth.UpdataloadWEIGHTData(this.Context, null, null, null, str, put, querynumber, Type);

            txtBody.Text = result;
        }

        #endregion

        #region BG

        protected void btnDownloadBG_Click(object sender, EventArgs e)
        {
            hidNextUrl.Value = "";
            hidPrevUrl.Value = "";
            ConnectToiHealthlabs cth = new ConnectToiHealthlabs();
            string aBGUnit = dlResponseType.SelectedValue;
            DownloadBGDataResultEntity result = cth.DownloadBGData(this.Context, null, null, null, aBGUnit);
            if (result != null)
            {
                hidNextUrl.Value = result.NextPageUrl;
                hidPrevUrl.Value = result.PrevPageUrl;
                lOutput.Text = GetPagingString(result.PageNumber, result.RecordCount, result.PageLength);
                BGControlProcess();
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

        protected void btnDownloadClientBG_Click(object sender, EventArgs e)
        {
            hidNextUrl.Value = "";
            hidPrevUrl.Value = "";

            ConnectToiHealthlabs cth = new ConnectToiHealthlabs();
            string aBGUnit = dlResponseType.SelectedValue;
            DownloadBGDataResultEntity result = cth.DownloadClientBGData(this.Context, null, null, null, aBGUnit);
            if (result != null)
            {
                hidNextUrl.Value = result.NextPageUrl;
                hidPrevUrl.Value = result.PrevPageUrl;
                lOutput.Text = GetPagingString(result.PageNumber, result.RecordCount, result.PageLength);
                BGControlProcess();
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

        protected void BGPrev_Click(object sender, EventArgs e)
        {
            string Url = hidPrevUrl.Value;
            if (Url != "")
            {
                ConnectToiHealthlabs cth = new ConnectToiHealthlabs();

                Url = HttpUtility.UrlDecode(Url);

                string ResultString = cth.HttpGet(Url);
                if (ResultString.StartsWith("{\"Error\":"))
                {

                    ApiErrorEntity Error = cth.JsonDeserializ<ApiErrorEntity>(ResultString);
                    lOutput.Text = "Some errors happened. ";
                    if (cth.Error != null)
                    {
                        lOutput.Text += "Details:" + Error.Error + "," + Error.ErrorCode + "," + Error.ErrorDescription;
                    }

                }
                else
                {
                    DownloadBGDataResultEntity result = cth.JsonDeserializ<DownloadBGDataResultEntity>(ResultString);
                    lOutput.Text = GetPagingString(result.PageNumber, result.RecordCount, result.PageLength);

                    hidNextUrl.Value = result.NextPageUrl;
                    hidPrevUrl.Value = result.PrevPageUrl;

                    BGControlProcess();
                    rptBPData.DataSource = result.BGDataList;
                    rptBPData.DataBind();
                }
            }
        }

        protected void BGNext_Click(object sender, EventArgs e)
        {

            string Url = hidNextUrl.Value;
            if (Url != "")
            {
                Url = HttpUtility.UrlDecode(Url);
                ConnectToiHealthlabs cth = new ConnectToiHealthlabs();

                string ResultString = cth.HttpGet(Url);
                if (ResultString.StartsWith("{\"Error\":"))
                {
                    ApiErrorEntity Error = cth.JsonDeserializ<ApiErrorEntity>(ResultString);
                    lOutput.Text = "Some errors happened. ";
                    if (cth.Error != null)
                    {
                        lOutput.Text += "Details:" + Error.Error + "," + Error.ErrorCode + "," + Error.ErrorDescription;
                    }
                }
                else
                {
                    DownloadBGDataResultEntity result = cth.JsonDeserializ<DownloadBGDataResultEntity>(ResultString);
                    lOutput.Text = GetPagingString(result.PageNumber, result.RecordCount, result.PageLength);

                    hidNextUrl.Value = result.NextPageUrl;
                    hidPrevUrl.Value = result.PrevPageUrl;

                    BGControlProcess();
                    rptBPData.DataSource = result.BGDataList;
                    rptBPData.DataBind();
                }
            }
        }

        private void BGControlProcess()
        {
            BtnBPNext.Visible = false;
            BtnBPPrev.Visible = false;
            BtnWeightNext.Visible = false;
            BtnWeightPrev.Visible = false;
            BtnBGNext.Visible = true;
            BtnBGPrev.Visible = true;
            BtnSpo2Next.Visible = false;
            BtnSpo2Prev.Visible = false;
            BtnActivityNext.Visible = false;
            BtnActivityPrev.Visible = false;
            BtnSleepNext.Visible = false;
            BtnSleepPrev.Visible = false;
            BtnSportNext.Visible = false;
            BtnSportPrev.Visible = false;
            BtnFoodNext.Visible = false;
            BtnFoodPrev.Visible = false;
            BtnUserNext.Visible = false;
            BtnUserPrev.Visible = false;

            rptBOData.Visible = false;
            rptARData.Visible = false;
            rptSRData.Visible = false;
            LitUser.Visible = false;
            rptBGData.Visible = true;
            rptWeightData.Visible = false;
            rptFoodData.Visible = false;
            rptSportData.Visible = false;
            rptBPData.Visible = false;
            rptUserData.Visible = false;
        }

        protected void btnUploadBG_Click(object sender, EventArgs e)
        {
            string post = "Post";
            string querynumber = "number";
            string str = TextBox1.Text;
            string Type = "";
            if (chxml.Checked == true)
            {
                Type = "xml";
            }
            else
            {
                Type = "json";
            }

            ConnectToiHealthlabs cth = new ConnectToiHealthlabs();
            string result = cth.UploadloadBGData(this.Context, null, null, null, str, post, querynumber, Type);

            txtBody.Text = result;
        }

        protected void btnUpdataBG_Click(object sender, EventArgs e)
        {
            string put = "put";
            string querynumber = "number";
            string str = TextBox1.Text;
            string Type = "";
            if (chxml.Checked == true)
            {
                Type = "xml";
            }
            else
            {
                Type = "json";
            }

            ConnectToiHealthlabs cth = new ConnectToiHealthlabs();
            string result = cth.UpdataloadBGData(this.Context, null, null, null, str, put, querynumber, Type);

            txtBody.Text = result;
        }

        #endregion

        #region Spo2

        protected void btnDownloadBO_Click(object sender, EventArgs e)
        {
            hidNextUrl.Value = "";
            hidPrevUrl.Value = "";
            ConnectToiHealthlabs cth = new ConnectToiHealthlabs();
            string aBOUnit = dlResponseType.SelectedValue;
            DownloadBODataResultEntity result = cth.DownloadBOData(this.Context, null, null, null, aBOUnit);
            if (result != null)
            {
                hidNextUrl.Value = result.NextPageUrl;
                hidPrevUrl.Value = result.PrevPageUrl;
                lOutput.Text = GetPagingString(result.PageNumber, result.RecordCount, result.PageLength);
                Spo2ControlProcess();
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

        protected void btnDownloadClientBO_Click(object sender, EventArgs e)
        {
            hidNextUrl.Value = "";
            hidPrevUrl.Value = "";
            ConnectToiHealthlabs cth = new ConnectToiHealthlabs();
            string aBOUnit = dlResponseType.SelectedValue;
            DownloadBODataResultEntity result = cth.DownloadClientBOData(this.Context, null, null, null, aBOUnit);
            if (result != null)
            {
                hidNextUrl.Value = result.NextPageUrl;
                hidPrevUrl.Value = result.PrevPageUrl;
                lOutput.Text = GetPagingString(result.PageNumber, result.RecordCount, result.PageLength);
                Spo2ControlProcess();
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

        protected void Spo2Prev_Click(object sender, EventArgs e)
        {
            string Url = hidPrevUrl.Value;
            if (Url != "")
            {
                ConnectToiHealthlabs cth = new ConnectToiHealthlabs();

                Url = HttpUtility.UrlDecode(Url);

                string ResultString = cth.HttpGet(Url);
                if (ResultString.StartsWith("{\"Error\":"))
                {

                    ApiErrorEntity Error = cth.JsonDeserializ<ApiErrorEntity>(ResultString);
                    lOutput.Text = "Some errors happened. ";
                    if (cth.Error != null)
                    {
                        lOutput.Text += "Details:" + Error.Error + "," + Error.ErrorCode + "," + Error.ErrorDescription;
                    }

                }
                else
                {
                    DownloadBODataResultEntity result = cth.JsonDeserializ<DownloadBODataResultEntity>(ResultString);
                    lOutput.Text = GetPagingString(result.PageNumber, result.RecordCount, result.PageLength);

                    hidNextUrl.Value = result.NextPageUrl;
                    hidPrevUrl.Value = result.PrevPageUrl;

                    Spo2ControlProcess();
                    rptBPData.DataSource = result.BODataList;
                    rptBPData.DataBind();
                }
            }
        }

        protected void Spo2Next_Click(object sender, EventArgs e)
        {

            string Url = hidNextUrl.Value;
            if (Url != "")
            {
                Url = HttpUtility.UrlDecode(Url);
                ConnectToiHealthlabs cth = new ConnectToiHealthlabs();

                string ResultString = cth.HttpGet(Url);
                if (ResultString.StartsWith("{\"Error\":"))
                {
                    ApiErrorEntity Error = cth.JsonDeserializ<ApiErrorEntity>(ResultString);
                    lOutput.Text = "Some errors happened. ";
                    if (cth.Error != null)
                    {
                        lOutput.Text += "Details:" + Error.Error + "," + Error.ErrorCode + "," + Error.ErrorDescription;
                    }
                }
                else
                {
                    DownloadBODataResultEntity result = cth.JsonDeserializ<DownloadBODataResultEntity>(ResultString);
                    lOutput.Text = GetPagingString(result.PageNumber, result.RecordCount, result.PageLength);

                    hidNextUrl.Value = result.NextPageUrl;
                    hidPrevUrl.Value = result.PrevPageUrl;

                    Spo2ControlProcess();
                    rptBPData.DataSource = result.BODataList;
                    rptBPData.DataBind();
                }
            }
        }

        private void Spo2ControlProcess()
        {
            BtnBPNext.Visible = false;
            BtnBPPrev.Visible = false;
            BtnWeightNext.Visible = false;
            BtnWeightPrev.Visible = false;
            BtnBGNext.Visible = false;
            BtnBGPrev.Visible = false;
            BtnSpo2Next.Visible = true;
            BtnSpo2Prev.Visible = true;
            BtnActivityNext.Visible = false;
            BtnActivityPrev.Visible = false;
            BtnSleepNext.Visible = false;
            BtnSleepPrev.Visible = false;
            BtnSportNext.Visible = false;
            BtnSportPrev.Visible = false;
            BtnFoodNext.Visible = false;
            BtnFoodPrev.Visible = false;
            BtnUserNext.Visible = false;
            BtnUserPrev.Visible = false;

            rptBOData.Visible = true;
            rptARData.Visible = false;
            rptSRData.Visible = false;
            LitUser.Visible = false;
            rptBGData.Visible = false;
            rptWeightData.Visible = false;
            rptFoodData.Visible = false;
            rptSportData.Visible = false;
            rptBPData.Visible = false;
            rptUserData.Visible = false;
        }

        protected void btnUploadBO_Click(object sender, EventArgs e)
        {
            string post = "Post";
            string querynumber = "number";
            string str = TextBox1.Text;
            string Type = "";
            if (chxml.Checked == true)
            {
                Type = "xml";
            }
            else
            {
                Type = "json";
            }

            ConnectToiHealthlabs cth = new ConnectToiHealthlabs();
            string result = cth.UploadloadBOData(this.Context, null, null, null, str, post, querynumber, Type);

            txtBody.Text = result;
        }

        protected void btnUpdataBO_Click(object sender, EventArgs e)
        {
            string put = "put";
            string querynumber = "number";
            string str = TextBox1.Text;
            string Type = "";
            if (chxml.Checked == true)
            {
                Type = "xml";
            }
            else
            {
                Type = "json";
            }

            ConnectToiHealthlabs cth = new ConnectToiHealthlabs();
            string result = cth.UpdataloadBOData(this.Context, null, null, null, str, put, querynumber, Type);

            txtBody.Text = result;
        }

        #endregion

        #region Activity

        protected void btnDownloadAR_Click(object sender, EventArgs e)
        {
            hidNextUrl.Value = "";
            hidPrevUrl.Value = "";
            ConnectToiHealthlabs cth = new ConnectToiHealthlabs();
            string aARUnit = dlResponseType.SelectedValue;
            DownloadActiveReportDataResultEntity result = cth.DownloadARData(this.Context, null, null, null, aARUnit);
            if (result != null)
            {
                hidNextUrl.Value = result.NextPageUrl;
                hidPrevUrl.Value = result.PrevPageUrl;
                lOutput.Text = GetPagingString(result.PageNumber, result.RecordCount, result.PageLength);
                ActivityControlProcess();
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

        protected void btnDownloadClientAR_Click(object sender, EventArgs e)
        {
            hidNextUrl.Value = "";
            hidPrevUrl.Value = "";

            ConnectToiHealthlabs cth = new ConnectToiHealthlabs();
            string aARUnit = dlResponseType.SelectedValue;
            DownloadActiveReportDataResultEntity result = cth.DownloadClientARData(this.Context, null, null, null, aARUnit);
            if (result != null)
            {
                hidNextUrl.Value = result.NextPageUrl;
                hidPrevUrl.Value = result.PrevPageUrl;
                lOutput.Text = GetPagingString(result.PageNumber, result.RecordCount, result.PageLength);
                ActivityControlProcess();
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

        protected void ActivityPrev_Click(object sender, EventArgs e)
        {
            string Url = hidPrevUrl.Value;
            if (Url != "")
            {
                ConnectToiHealthlabs cth = new ConnectToiHealthlabs();

                Url = HttpUtility.UrlDecode(Url);

                string ResultString = cth.HttpGet(Url);
                if (ResultString.StartsWith("{\"Error\":"))
                {

                    ApiErrorEntity Error = cth.JsonDeserializ<ApiErrorEntity>(ResultString);
                    lOutput.Text = "Some errors happened. ";
                    if (cth.Error != null)
                    {
                        lOutput.Text += "Details:" + Error.Error + "," + Error.ErrorCode + "," + Error.ErrorDescription;
                    }

                }
                else
                {
                    DownloadActiveReportDataResultEntity result = cth.JsonDeserializ<DownloadActiveReportDataResultEntity>(ResultString);
                    lOutput.Text = GetPagingString(result.PageNumber, result.RecordCount, result.PageLength);

                    hidNextUrl.Value = result.NextPageUrl;
                    hidPrevUrl.Value = result.PrevPageUrl;

                    ActivityControlProcess();
                    rptBPData.DataSource = result.ARDataList;
                    rptBPData.DataBind();
                }
            }
        }

        protected void ActivityNext_Click(object sender, EventArgs e)
        {

            string Url = hidNextUrl.Value;
            if (Url != "")
            {
                Url = HttpUtility.UrlDecode(Url);
                ConnectToiHealthlabs cth = new ConnectToiHealthlabs();

                string ResultString = cth.HttpGet(Url);
                if (ResultString.StartsWith("{\"Error\":"))
                {
                    ApiErrorEntity Error = cth.JsonDeserializ<ApiErrorEntity>(ResultString);
                    lOutput.Text = "Some errors happened. ";
                    if (cth.Error != null)
                    {
                        lOutput.Text += "Details:" + Error.Error + "," + Error.ErrorCode + "," + Error.ErrorDescription;
                    }
                }
                else
                {
                    DownloadActiveReportDataResultEntity result = cth.JsonDeserializ<DownloadActiveReportDataResultEntity>(ResultString);
                    lOutput.Text = GetPagingString(result.PageNumber, result.RecordCount, result.PageLength);

                    hidNextUrl.Value = result.NextPageUrl;
                    hidPrevUrl.Value = result.PrevPageUrl;

                    ActivityControlProcess();
                    rptBPData.DataSource = result.ARDataList;
                    rptBPData.DataBind();
                }
            }
        }

        private void ActivityControlProcess()
        {
            BtnBPNext.Visible = false;
            BtnBPPrev.Visible = false;
            BtnWeightNext.Visible = false;
            BtnWeightPrev.Visible = false;
            BtnBGNext.Visible = false;
            BtnBGPrev.Visible = false;
            BtnSpo2Next.Visible = false;
            BtnSpo2Prev.Visible = false;
            BtnActivityNext.Visible = true;
            BtnActivityPrev.Visible = true;
            BtnSleepNext.Visible = false;
            BtnSleepPrev.Visible = false;
            BtnSportNext.Visible = false;
            BtnSportPrev.Visible = false;
            BtnFoodNext.Visible = false;
            BtnFoodPrev.Visible = false;
            BtnUserNext.Visible = false;
            BtnUserPrev.Visible = false;

            rptBOData.Visible = false;
            rptARData.Visible = true;
            rptSRData.Visible = false;
            LitUser.Visible = false;
            rptBGData.Visible = false;
            rptWeightData.Visible = false;
            rptFoodData.Visible = false;
            rptSportData.Visible = false;
            rptBPData.Visible = false;
            rptUserData.Visible = false;
        }

        protected void btnUploadAM_Click(object sender, EventArgs e)
        {
            string post = "Post";
            string querynumber = "number";
            string str = TextBox1.Text;
            string Type = "";
            if (chxml.Checked == true)
            {
                Type = "xml";
            }
            else
            {
                Type = "json";
            }

            ConnectToiHealthlabs cth = new ConnectToiHealthlabs();
            string result = cth.UploadloadAMData(this.Context, null, null, null, str, post, querynumber, Type);

            txtBody.Text = result;
        }

        protected void btnUpdataAM_Click(object sender, EventArgs e)
        {
            string put = "put";
            string querynumber = "number";
            string str = TextBox1.Text;
            string Type = "";
            if (chxml.Checked == true)
            {
                Type = "xml";
            }
            else
            {
                Type = "json";
            }

            ConnectToiHealthlabs cth = new ConnectToiHealthlabs();
            string result = cth.UpdataloadAMData(this.Context, null, null, null, str, put, querynumber, Type);

            txtBody.Text = result;
        }

        #endregion

        #region Sleep

        protected void btnDownloadSR_Click(object sender, EventArgs e)
        {
            hidNextUrl.Value = "";
            hidPrevUrl.Value = "";
            ConnectToiHealthlabs cth = new ConnectToiHealthlabs();
            string aSRUnit = dlResponseType.SelectedValue;
            DownloadSleepReportDataResultEntity result = cth.DownloadSRData(this.Context, null, null, null, aSRUnit);
            if (result != null)
            {
                hidNextUrl.Value = result.NextPageUrl;
                hidPrevUrl.Value = result.PrevPageUrl;
                lOutput.Text = GetPagingString(result.PageNumber, result.RecordCount, result.PageLength);
                SleepControlProcess();
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

        protected void btnDownloadClientSR_Click(object sender, EventArgs e)
        {
            hidNextUrl.Value = "";
            hidPrevUrl.Value = "";
            ConnectToiHealthlabs cth = new ConnectToiHealthlabs();
            string aSRUnit = dlResponseType.SelectedValue;
            DownloadSleepReportDataResultEntity result = cth.DownloadClientSRData(this.Context, null, null, null, aSRUnit);
            if (result != null)
            {
                hidNextUrl.Value = result.NextPageUrl;
                hidPrevUrl.Value = result.PrevPageUrl;
                lOutput.Text = GetPagingString(result.PageNumber, result.RecordCount, result.PageLength);
                SleepControlProcess();
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

        protected void SleepPrev_Click(object sender, EventArgs e)
        {
            string Url = hidPrevUrl.Value;
            if (Url != "")
            {
                ConnectToiHealthlabs cth = new ConnectToiHealthlabs();

                Url = HttpUtility.UrlDecode(Url);

                string ResultString = cth.HttpGet(Url);
                if (ResultString.StartsWith("{\"Error\":"))
                {

                    ApiErrorEntity Error = cth.JsonDeserializ<ApiErrorEntity>(ResultString);
                    lOutput.Text = "Some errors happened. ";
                    if (cth.Error != null)
                    {
                        lOutput.Text += "Details:" + Error.Error + "," + Error.ErrorCode + "," + Error.ErrorDescription;
                    }

                }
                else
                {
                    DownloadSleepReportDataResultEntity result = cth.JsonDeserializ<DownloadSleepReportDataResultEntity>(ResultString);
                    lOutput.Text = GetPagingString(result.PageNumber, result.RecordCount, result.PageLength);

                    hidNextUrl.Value = result.NextPageUrl;
                    hidPrevUrl.Value = result.PrevPageUrl;

                    SleepControlProcess();
                    rptBPData.DataSource = result.SRDataList;
                    rptBPData.DataBind();
                }
            }
        }

        protected void SleepNext_Click(object sender, EventArgs e)
        {

            string Url = hidNextUrl.Value;
            if (Url != "")
            {
                Url = HttpUtility.UrlDecode(Url);
                ConnectToiHealthlabs cth = new ConnectToiHealthlabs();

                string ResultString = cth.HttpGet(Url);
                if (ResultString.StartsWith("{\"Error\":"))
                {
                    ApiErrorEntity Error = cth.JsonDeserializ<ApiErrorEntity>(ResultString);
                    lOutput.Text = "Some errors happened. ";
                    if (cth.Error != null)
                    {
                        lOutput.Text += "Details:" + Error.Error + "," + Error.ErrorCode + "," + Error.ErrorDescription;
                    }
                }
                else
                {
                    DownloadSleepReportDataResultEntity result = cth.JsonDeserializ<DownloadSleepReportDataResultEntity>(ResultString);
                    lOutput.Text = GetPagingString(result.PageNumber, result.RecordCount, result.PageLength);

                    hidNextUrl.Value = result.NextPageUrl;
                    hidPrevUrl.Value = result.PrevPageUrl;

                    SleepControlProcess();
                    rptBPData.DataSource = result.SRDataList;
                    rptBPData.DataBind();
                }
            }
        }

        private void SleepControlProcess()
        {
            BtnBPNext.Visible = false;
            BtnBPPrev.Visible = false;
            BtnWeightNext.Visible = false;
            BtnWeightPrev.Visible = false;
            BtnBGNext.Visible = false;
            BtnBGPrev.Visible = false;
            BtnSpo2Next.Visible = false;
            BtnSpo2Prev.Visible = false;
            BtnActivityNext.Visible = false;
            BtnActivityPrev.Visible = false;
            BtnSleepNext.Visible = true;
            BtnSleepPrev.Visible = true;
            BtnSportNext.Visible = false;
            BtnSportPrev.Visible = false;
            BtnFoodNext.Visible = false;
            BtnFoodPrev.Visible = false;
            BtnUserNext.Visible = false;
            BtnUserPrev.Visible = false;

            rptBOData.Visible = false;
            rptARData.Visible = false;
            rptSRData.Visible = true;
            LitUser.Visible = false;
            rptBGData.Visible = false;
            rptWeightData.Visible = false;
            rptFoodData.Visible = false;
            rptSportData.Visible = false;
            rptBPData.Visible = false;
            rptUserData.Visible = false;
        }

        protected void btnUploadSLEEP_Click(object sender, EventArgs e)
        {
            string post = "Post";
            string querynumber = "number";
            string str = TextBox1.Text;
            string Type = "";
            if (chxml.Checked == true)
            {
                Type = "xml";
            }
            else
            {
                Type = "json";
            }

            ConnectToiHealthlabs cth = new ConnectToiHealthlabs();
            string result = cth.UploadloadSLEEPData(this.Context, null, null, null, str, post, querynumber, Type);

            txtBody.Text = result;
        }

        protected void btnUpdataSLEEP_Click(object sender, EventArgs e)
        {
            string put = "put";
            string querynumber = "number";
            string str = TextBox1.Text;
            string Type = "";
            if (chxml.Checked == true)
            {
                Type = "xml";
            }
            else
            {
                Type = "json";
            }

            ConnectToiHealthlabs cth = new ConnectToiHealthlabs();
            string result = cth.UpdataloadSLEEPData(this.Context, null, null, null, str, put, querynumber, Type);

            txtBody.Text = result;
        }

        #endregion

        #region Food

        protected void btnDownloadFOOD_Click(object sender, EventArgs e)
        {
            hidNextUrl.Value = "";
            hidPrevUrl.Value = "";
            ConnectToiHealthlabs cth = new ConnectToiHealthlabs();
            string aFoodUnit = dlResponseType.SelectedValue;
            DownloadFoodDataResultEntity result = cth.DownloadFOODData(this.Context, null, null, aFoodUnit);
            if (result != null)
            {
                hidNextUrl.Value = result.NextPageUrl;
                hidPrevUrl.Value = result.PrevPageUrl;

                lOutput.Text = GetPagingString(result.PageNumber, result.RecordCount, result.PageLength);
                FoodControlProcess();
                rptFoodData.DataSource = result.FoodDataList;
                rptFoodData.DataBind();
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

        protected void btnDownloadClientFOOD_Click(object sender, EventArgs e)
        {
            hidNextUrl.Value = "";
            hidPrevUrl.Value = "";
            ConnectToiHealthlabs cth = new ConnectToiHealthlabs();
            string aFoodUnit = dlResponseType.SelectedValue;
            DownloadFoodDataResultEntity result = cth.DownloadClientFOODData(this.Context, null, null, aFoodUnit);
            if (result != null)
            {
                hidNextUrl.Value = result.NextPageUrl;
                hidPrevUrl.Value = result.PrevPageUrl;

                lOutput.Text = GetPagingString(result.PageNumber, result.RecordCount, result.PageLength);
                FoodControlProcess();
                rptFoodData.DataSource = result.FoodDataList;
                rptFoodData.DataBind();
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


        protected void FoodPrev_Click(object sender, EventArgs e)
        {
            string Url = hidPrevUrl.Value;
            if (Url != "")
            {
                ConnectToiHealthlabs cth = new ConnectToiHealthlabs();

                Url = HttpUtility.UrlDecode(Url);

                string ResultString = cth.HttpGet(Url);
                if (ResultString.StartsWith("{\"Error\":"))
                {

                    ApiErrorEntity Error = cth.JsonDeserializ<ApiErrorEntity>(ResultString);
                    lOutput.Text = "Some errors happened. ";
                    if (cth.Error != null)
                    {
                        lOutput.Text += "Details:" + Error.Error + "," + Error.ErrorCode + "," + Error.ErrorDescription;
                    }

                }
                else
                {
                    DownloadFoodDataResultEntity result = cth.JsonDeserializ<DownloadFoodDataResultEntity>(ResultString);
                    lOutput.Text = GetPagingString(result.PageNumber, result.RecordCount, result.PageLength);

                    hidNextUrl.Value = result.NextPageUrl;
                    hidPrevUrl.Value = result.PrevPageUrl;

                    FoodControlProcess();
                    rptBPData.DataSource = result.FoodDataList;
                    rptBPData.DataBind();
                }
            }
        }

        protected void FoodNext_Click(object sender, EventArgs e)
        {

            string Url = hidNextUrl.Value;
            if (Url != "")
            {
                Url = HttpUtility.UrlDecode(Url);
                ConnectToiHealthlabs cth = new ConnectToiHealthlabs();

                string ResultString = cth.HttpGet(Url);
                if (ResultString.StartsWith("{\"Error\":"))
                {
                    ApiErrorEntity Error = cth.JsonDeserializ<ApiErrorEntity>(ResultString);
                    lOutput.Text = "Some errors happened. ";
                    if (cth.Error != null)
                    {
                        lOutput.Text += "Details:" + Error.Error + "," + Error.ErrorCode + "," + Error.ErrorDescription;
                    }
                }
                else
                {
                    DownloadFoodDataResultEntity result = cth.JsonDeserializ<DownloadFoodDataResultEntity>(ResultString);
                    lOutput.Text = GetPagingString(result.PageNumber, result.RecordCount, result.PageLength);

                    hidNextUrl.Value = result.NextPageUrl;
                    hidPrevUrl.Value = result.PrevPageUrl;

                    FoodControlProcess();
                    rptBPData.DataSource = result.FoodDataList;
                    rptBPData.DataBind();
                }
            }
        }

        private void FoodControlProcess()
        {
            BtnBPNext.Visible = false;
            BtnBPPrev.Visible = false;
            BtnWeightNext.Visible = false;
            BtnWeightPrev.Visible = false;
            BtnBGNext.Visible = false;
            BtnBGPrev.Visible = false;
            BtnSpo2Next.Visible = false;
            BtnSpo2Prev.Visible = false;
            BtnActivityNext.Visible = false;
            BtnActivityPrev.Visible = false;
            BtnSleepNext.Visible = false;
            BtnSleepPrev.Visible = false;
            BtnSportNext.Visible = false;
            BtnSportPrev.Visible = false;
            BtnFoodNext.Visible = true;
            BtnFoodPrev.Visible = true;
            BtnUserNext.Visible = false;
            BtnUserPrev.Visible = false;

            rptBOData.Visible = false;
            rptARData.Visible = false;
            rptSRData.Visible = false;
            LitUser.Visible = false;
            rptBGData.Visible = false;
            rptWeightData.Visible = false;
            rptFoodData.Visible = true;
            rptSportData.Visible = false;
            rptBPData.Visible = false;
            rptUserData.Visible = false;
        }

        #endregion

        #region Sport

        protected void btnDownloadSPORT_Click(object sender, EventArgs e)
        {
            hidNextUrl.Value = "";
            hidPrevUrl.Value = "";
            ConnectToiHealthlabs cth = new ConnectToiHealthlabs();
            // string aFoodUnit = dlResponseType.SelectedValue;
            DownloadSportDataReportEntity result = cth.DownloadSPORTData(this.Context, null, null, null);
            if (result != null)
            {
                hidNextUrl.Value = result.NextPageUrl;
                hidPrevUrl.Value = result.PrevPageUrl;
                lOutput.Text = GetPagingString(result.PageNumber, result.RecordCount, result.PageLength);
                SportControlProcess();
                rptSportData.DataSource = result.SPORTDataList;
                rptSportData.DataBind();
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

        protected void btnDownloadClientSPORT_Click(object sender, EventArgs e)
        {
            hidNextUrl.Value = "";
            hidPrevUrl.Value = "";
            ConnectToiHealthlabs cth = new ConnectToiHealthlabs();

            DownloadSportDataReportEntity result = cth.DownloadClientSportData(this.Context, null, null, null);
            if (result != null)
            {
                hidNextUrl.Value = result.NextPageUrl;
                hidPrevUrl.Value = result.PrevPageUrl;
                lOutput.Text = GetPagingString(result.PageNumber, result.RecordCount, result.PageLength);
                SportControlProcess();
                rptSportData.DataSource = result.SPORTDataList;
                rptSportData.DataBind();
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


        protected void SportPrev_Click(object sender, EventArgs e)
        {
            string Url = hidPrevUrl.Value;
            if (Url != "")
            {
                ConnectToiHealthlabs cth = new ConnectToiHealthlabs();

                Url = HttpUtility.UrlDecode(Url);

                string ResultString = cth.HttpGet(Url);
                if (ResultString.StartsWith("{\"Error\":"))
                {

                    ApiErrorEntity Error = cth.JsonDeserializ<ApiErrorEntity>(ResultString);
                    lOutput.Text = "Some errors happened. ";
                    if (cth.Error != null)
                    {
                        lOutput.Text += "Details:" + Error.Error + "," + Error.ErrorCode + "," + Error.ErrorDescription;
                    }

                }
                else
                {
                    DownloadFoodDataResultEntity result = cth.JsonDeserializ<DownloadFoodDataResultEntity>(ResultString);
                    lOutput.Text = GetPagingString(result.PageNumber, result.RecordCount, result.PageLength);

                    hidNextUrl.Value = result.NextPageUrl;
                    hidPrevUrl.Value = result.PrevPageUrl;

                    SportControlProcess();
                    rptBPData.DataSource = result.FoodDataList;
                    rptBPData.DataBind();
                }
            }
        }

        protected void SportNext_Click(object sender, EventArgs e)
        {

            string Url = hidNextUrl.Value;
            if (Url != "")
            {
                Url = HttpUtility.UrlDecode(Url);
                ConnectToiHealthlabs cth = new ConnectToiHealthlabs();

                string ResultString = cth.HttpGet(Url);
                if (ResultString.StartsWith("{\"Error\":"))
                {
                    ApiErrorEntity Error = cth.JsonDeserializ<ApiErrorEntity>(ResultString);
                    lOutput.Text = "Some errors happened. ";
                    if (cth.Error != null)
                    {
                        lOutput.Text += "Details:" + Error.Error + "," + Error.ErrorCode + "," + Error.ErrorDescription;
                    }
                }
                else
                {
                    DownloadFoodDataResultEntity result = cth.JsonDeserializ<DownloadFoodDataResultEntity>(ResultString);
                    lOutput.Text = GetPagingString(result.PageNumber, result.RecordCount, result.PageLength);

                    hidNextUrl.Value = result.NextPageUrl;
                    hidPrevUrl.Value = result.PrevPageUrl;

                    SportControlProcess();
                    rptBPData.DataSource = result.FoodDataList;
                    rptBPData.DataBind();
                }
            }
        }

        private void SportControlProcess()
        {
            BtnBPNext.Visible = false;
            BtnBPPrev.Visible = false;
            BtnWeightNext.Visible = false;
            BtnWeightPrev.Visible = false;
            BtnBGNext.Visible = false;
            BtnBGPrev.Visible = false;
            BtnSpo2Next.Visible = false;
            BtnSpo2Prev.Visible = false;
            BtnActivityNext.Visible = false;
            BtnActivityPrev.Visible = false;
            BtnSleepNext.Visible = false;
            BtnSleepPrev.Visible = false;
            BtnSportNext.Visible = true;
            BtnSportPrev.Visible = true;
            BtnFoodNext.Visible = false;
            BtnFoodPrev.Visible = false;
            BtnUserNext.Visible = false;
            BtnUserPrev.Visible = false;

            rptBOData.Visible = false;
            rptARData.Visible = false;
            rptSRData.Visible = false;
            LitUser.Visible = false;
            rptBGData.Visible = false;
            rptWeightData.Visible = false;
            rptFoodData.Visible = false;
            rptSportData.Visible = true;
            rptBPData.Visible = false;
            rptUserData.Visible = false;
        }

        #endregion

        #region UserInfo

        protected void btnDownloadUser_Click(object sender, EventArgs e)
        {
            ConnectToiHealthlabs cth = new ConnectToiHealthlabs();
            string aUserUnit = dlResponseType.SelectedValue;
            DownloadUserInfoDataEntity result = cth.DownloadUserData(this.Context, null, null, null, aUserUnit);
            if (result != null)
            {
                BtnBPNext.Visible = false;
                BtnBPPrev.Visible = false;
                BtnWeightNext.Visible = false;
                BtnWeightPrev.Visible = false;
                BtnBGNext.Visible = false;
                BtnBGPrev.Visible = false;
                BtnSpo2Next.Visible = false;
                BtnSpo2Prev.Visible = false;
                BtnActivityNext.Visible = false;
                BtnActivityPrev.Visible = false;
                BtnSleepNext.Visible = false;
                BtnSleepPrev.Visible = false;
                BtnSportNext.Visible = false;
                BtnSportPrev.Visible = false;
                BtnFoodNext.Visible = false;
                BtnFoodPrev.Visible = false;
                BtnUserNext.Visible = false;
                BtnUserPrev.Visible = false;

                lOutput.Text = "";
                rptBOData.Visible = false;
                rptARData.Visible = false;
                rptSRData.Visible = false;
                rptUserData.Visible = false;
                LitUser.Visible = true;
                rptBGData.Visible = false;
                rptWeightData.Visible = false;
                rptBPData.Visible = false;
                rptFoodData.Visible = false;
                rptSportData.Visible = false;
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

        protected void btnDownloadClientUser_Click(object sender, EventArgs e)
        {
            hidNextUrl.Value = "";
            hidPrevUrl.Value = "";
            ConnectToiHealthlabs cth = new ConnectToiHealthlabs();
            string aUserUnit = dlResponseType.SelectedValue;
            DownloadUserInfoResultEntity result = cth.DownloadClientUserData(this.Context, null, null, null, aUserUnit);
            if (result != null)
            {
                hidNextUrl.Value = result.NextPageUrl;
                hidPrevUrl.Value = result.PrevPageUrl;
                lOutput.Text = GetPagingString(result.PageNumber, result.RecordCount, result.PageLength);
                UserControlProcess();
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

        protected void UserPrev_Click(object sender, EventArgs e)
        {
            string Url = hidPrevUrl.Value;
            if (Url != "")
            {
                ConnectToiHealthlabs cth = new ConnectToiHealthlabs();

                Url = HttpUtility.UrlDecode(Url);

                string ResultString = cth.HttpGet(Url);
                if (ResultString.StartsWith("{\"Error\":"))
                {

                    ApiErrorEntity Error = cth.JsonDeserializ<ApiErrorEntity>(ResultString);
                    lOutput.Text = "Some errors happened. ";
                    if (cth.Error != null)
                    {
                        lOutput.Text += "Details:" + Error.Error + "," + Error.ErrorCode + "," + Error.ErrorDescription;
                    }

                }
                else
                {
                    DownloadUserInfoResultEntity result = cth.JsonDeserializ<DownloadUserInfoResultEntity>(ResultString);
                    lOutput.Text = GetPagingString(result.PageNumber, result.RecordCount, result.PageLength);

                    hidNextUrl.Value = result.NextPageUrl;
                    hidPrevUrl.Value = result.PrevPageUrl;

                    UserControlProcess();
                    rptBPData.DataSource = result.UserInfoList;
                    rptBPData.DataBind();
                }
            }
        }

        protected void UserNext_Click(object sender, EventArgs e)
        {

            string Url = hidNextUrl.Value;
            if (Url != "")
            {
                Url = HttpUtility.UrlDecode(Url);
                ConnectToiHealthlabs cth = new ConnectToiHealthlabs();

                string ResultString = cth.HttpGet(Url);
                if (ResultString.StartsWith("{\"Error\":"))
                {
                    ApiErrorEntity Error = cth.JsonDeserializ<ApiErrorEntity>(ResultString);
                    lOutput.Text = "Some errors happened. ";
                    if (cth.Error != null)
                    {
                        lOutput.Text += "Details:" + Error.Error + "," + Error.ErrorCode + "," + Error.ErrorDescription;
                    }
                }
                else
                {
                    DownloadUserInfoResultEntity result = cth.JsonDeserializ<DownloadUserInfoResultEntity>(ResultString);
                    lOutput.Text = GetPagingString(result.PageNumber, result.RecordCount, result.PageLength);

                    hidNextUrl.Value = result.NextPageUrl;
                    hidPrevUrl.Value = result.PrevPageUrl;

                    UserControlProcess();
                    rptBPData.DataSource = result.UserInfoList;
                    rptBPData.DataBind();
                }
            }
        }

        private void UserControlProcess()
        {
            BtnBPNext.Visible = false;
            BtnBPPrev.Visible = false;
            BtnWeightNext.Visible = false;
            BtnWeightPrev.Visible = false;
            BtnBGNext.Visible = false;
            BtnBGPrev.Visible = false;
            BtnSpo2Next.Visible = false;
            BtnSpo2Prev.Visible = false;
            BtnActivityNext.Visible = false;
            BtnActivityPrev.Visible = false;
            BtnSleepNext.Visible = false;
            BtnSleepPrev.Visible = false;
            BtnSportNext.Visible = false;
            BtnSportPrev.Visible = false;
            BtnFoodNext.Visible = false;
            BtnFoodPrev.Visible = false;
            BtnUserNext.Visible = true;
            BtnUserPrev.Visible = true;

            rptBOData.Visible = false;
            rptARData.Visible = false;
            rptSRData.Visible = false;
            LitUser.Visible = false;
            rptBGData.Visible = false;
            rptWeightData.Visible = false;
            rptFoodData.Visible = false;
            rptSportData.Visible = false;
            rptBPData.Visible = false;
            rptUserData.Visible = true;
        }

        #endregion

        #region Refresh Token

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["code"]))
            {
                AccessTokenEntity temp = new AccessTokenEntity();
                ConnectToiHealthlabs cth = new ConnectToiHealthlabs();
                if (new ConnectToiHealthlabs().RefreshAccessToken(Request.QueryString["code"].Trim(), "", this.Context, out temp))
                {
                    rptWeightData.Visible = false;
                    rptBPData.Visible = false;
                    lOutput.Text = "Refreshed successfully." +
                        "<br/> url_authorization " + cth.url_authorization +
                        "<br/> client_id " + cth.client_id +
                        "<br/> client_secret  " + cth.client_secret +
                        "<br/> AccessToken " + temp.AccessToken + "<br/> APIName " + temp.APIName + "<br/> Expires " + temp.Expires + "<br/> RefreshToken " + temp.RefreshToken + "<br/> UserID " + temp.UserID;
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
        #endregion


        private string GetPagingString(int pageNumber, int recordcount, int pageLength)
        {
            int pagesNum = (int)((recordcount + pageLength - 1) / pageLength);
            return string.Format("Page {0} of {1}，Record Count {2}", pageNumber, pagesNum, recordcount);
        }

        //Create example json or xml data
        protected void btnProduce_Click(object sender, EventArgs e)
        {

            long epoch = (DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000;
            //BP
            if (dlDataType.SelectedValue == "BP")
            {
                //xml
                if (chxml.Checked == true)
                {
                    TextBox1.Text = Server.UrlEncode("<?xml version=\"1.0\" encoding=\"utf-8\"?><UploadBPEntity><HP>105</HP><HR>75</HR><LP>46</LP><Lat>93</Lat><Lon>147</Lon><MDate>\"" + epoch + "\"</MDate><TimeZone>+0800</TimeZone><Note>noteinfo</Note><BPUnit>0</BPUnit></UploadBPEntity>");
                }
                //json
                else
                {
                    TextBox1.Text = Server.UrlEncode("{\"HP\":105,\"HR\":60,\"LP\":70,\"Lat\":93,\"Lon\":147,\"MDate\":\"" + epoch + "\",\"TimeZone\":\"+0800\",\"Note\":\"bp\",\"BPUnit\":0}");
                }

            }
            //BG
            else if (dlDataType.SelectedValue == "BG")
            {
                //xml
                if (chxml.Checked == true)
                {
                    TextBox1.Text = Server.UrlEncode("<?xml version=\"1.0\" encoding=\"utf-8\"?><UploadBGEntity><BG>60</BG><DinnerSituation>Before_breakfast</DinnerSituation><DrugSituation>Before_taking_pills</DrugSituation><Lat>0</Lat><Lon>0</Lon><MDate>\"" + epoch + "\"</MDate><TimeZone>+0800</TimeZone><Note>bg</Note><BGUnit>0</BGUnit></UploadBGEntity>");
                }
                //json
                else
                {
                    TextBox1.Text = Server.UrlEncode("{\"BG\":60,\"DinnerSituation\":\"Before_breakfast\",\"DrugSituation\":\"Before_taking_pills\",\"Lat\":0,\"Lon\":0,\"MDate\":\"" + epoch + "\",\"TimeZone\":\"+0800\",\"Note\":\"bg\",\"BGUnit\":0}");
                }

            }
            //Weight
            else if (dlDataType.SelectedValue == "WEIGHT")
            {
                //xml
                if (chxml.Checked == true)
                {
                    TextBox1.Text = Server.UrlEncode("<?xml version=\"1.0\" encoding=\"utf-8\"?><UploadWeightEntity> <Lat>0</Lat><Lon>0</Lon><MDate>\"" + epoch + "\"</MDate><TimeZone>+0800</TimeZone><Note>test900000000000000000</Note><WeightValue>52.4</WeightValue><WeightUnit>0</WeightUnit><FatValue>25.4</FatValue><MuscaleValue>20.4</MuscaleValue><BoneValue>22.4</BoneValue><WaterValue>20</WaterValue><DCI>211</DCI><VFR>35</VFR></UploadWeightEntity>");
                }
                //json
                else
                {
                    TextBox1.Text = Server.UrlEncode("{\"Lat\":0,\"Lon\":0,\"MDate\":\"" + epoch + "\",\"TimeZone\":\"+0800\",\"Note\":\"test900000000000000000\",\"WeightValue\":52.4,\"WeightUnit\":0,\"FatValue\":25.4,\"MuscaleValue\":20.4,\"BoneValue\":22.4,\"WaterValue\":20,\"DCI\": 211, \"VFR\": 35}");
                }

            }
            //Spo2
            else if (dlDataType.SelectedValue == "BO")
            {
                //xml
                if (chxml.Checked == true)
                {
                    TextBox1.Text = Server.UrlEncode("<?xml version=\"1.0\" encoding=\"utf-8\"?><UploadBOEntity><BO>80</BO><HR>75</HR><Lat>0</Lat><Lon>0</Lon><MDate>\"" + epoch + "\"</MDate><TimeZone>+0800</TimeZone><Note>spo2</Note></UploadBOEntity>");
                }
                //json
                else
                {
                    TextBox1.Text = Server.UrlEncode("{\"BO\":80,\"HR\":75,\"Lat\":0,\"Lon\":0,\"MDate\":\"" + epoch + "\",\"TimeZone\":\"+0800\",\"Note\":\"spo2\"}");
                }

            }
            //Activity
            else if (dlDataType.SelectedValue == "AM")
            {
                //xml
                if (chxml.Checked == true)
                {
                    TextBox1.Text = Server.UrlEncode("<?xml version=\"1.0\" encoding=\"utf-8\"?><UploadAMEntity><Calories>80</Calories><DistanceTraveled>2</DistanceTraveled><StepLength>50</StepLength><Lat>0</Lat><Lon>0</Lon><MDate>\"" + epoch + "\"</MDate><TimeZone>+0800</TimeZone><Note>am</Note></UploadAMEntity>");
                }
                //json
                else
                {
                    TextBox1.Text = Server.UrlEncode("{\"Calories\":80,\"DistanceTraveled\":2,\"StepLength\":50,\"Lat\":0,\"Lon\":0,\"MDate\":\"" + epoch + "\",\"TimeZone\":\"+0800\",\"Note\":\"am\"}");
                }

            }
            //Sleep
            else if (dlDataType.SelectedValue == "SLEEP")
            {
                //xml
                if (chxml.Checked == true)
                {
                    TextBox1.Text = Server.UrlEncode("<?xml version=\"1.0\" encoding=\"utf-8\"?><UploadSleepEntity><StartTime>2014-04-22 07:00:00</StartTime><EndTime>2014-04-22 15:00:00</EndTime><FallSleep>0.5</FallSleep><SleepEfficiency>80</SleepEfficiency><Lat>0</Lat><Lon>0</Lon><MDate>\"" + epoch + "\"</MDate><TimeZone>+0800</TimeZone><Note>sleep</Note></UploadSleepEntity>");
                }
                //json
                else
                {
                    TextBox1.Text = Server.UrlEncode("{\"StartTime\":\"2014-04-22 07:00:00\",\"EndTime\":\"2014-04-22 15:00:00\",\"FallSleep\":0.5,\"SleepEfficiency\":80,\"Lat\":0,\"Lon\":0,\"MDate\":\"" + epoch + "\",\"TimeZone\":\"+0800\",\"Note\":\"sleep\"}");
                }

            }
        }
    }
}
