using System;
using System.Configuration;
using System.Data.SqlClient;

namespace OJP_AshaKotak.User
{
    public partial class ResumeBuild : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader sdr;
        string str = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
        string query;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    showUserInfo();
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }

        private void showUserInfo()
        {
            try
            {
                con = new SqlConnection(str);
                string query = "SELECT * FROM OJPUser WHERE UserId = @userId";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@userId", Request.QueryString["id"]);
                con.Open();
                sdr = cmd.ExecuteReader();
                if (sdr.HasRows)
                {
                    if (sdr.Read())
                    {
                        txtUserName.Text = sdr["Username"].ToString();
                        txtfullname.Text = sdr["Name"].ToString();
                        txtEmail.Text = sdr["Email"].ToString();
                        txtMobile.Text = sdr["Mobile"].ToString();
                        txt10th.Text = sdr["10thGrade"].ToString();
                        txt12th.Text = sdr["12thGrade"].ToString();
                        txtGraduation.Text = sdr["GraduationGrade"].ToString();
                        txtPostGraduation.Text = sdr["PostGraduationGrade"].ToString();
                        txtPHD.Text = sdr["PHD"].ToString();
                        txtWork.Text = sdr["WorksOn"].ToString();
                        txtExperience.Text = sdr["Experience"].ToString();
                        txtAddress.Text = sdr["Address"].ToString();
                        ddlCountry.SelectedValue = sdr["Country"].ToString();
                    }
                }
                else
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "User Not Found...!!";
                    lblMsg.CssClass = "alert alert-danger";

                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
            finally
            {
                con.Close();
            }
        }



        protected void btnUpdate_Click1(object sender, EventArgs e)
        {

            try
            {
                if (Request.QueryString["id"] != null)
                {
                    string concatQuery = string.Empty;
                    string filePath = string.Empty;
                    bool IsValid = false;

                    con = new SqlConnection(str);

                    // Check if a file is uploaded
                    if (fuResume.HasFile)
                    {
                        if (Utils.isValidExtensionResume(fuResume.FileName))
                        {
                            concatQuery = "Resume=@resume";
                            IsValid = true;
                        }
                        else
                        {
                            lblMsg.Visible = true;
                            lblMsg.Text = "Please Select The .doc, .docx, .pdf File Only...!!";
                            lblMsg.CssClass = "alert alert-danger";
                            return; // Exit the method if the file extension is invalid
                        }
                    }

                    // Construct the query
                    query = @"Update OJPUser set Username=@Username, Name=@Name, Email=@Email, Mobile=@Mobile, TenthGrade=@TenthGrade, TwelthGrade=@TwelthGrade, GraduationGrade=@GraduationGrade, PostGraduationGrade=@PostGraduationGrade, phd=@phd, WorksOn=@WorksOn,Experience=@Experience, Address=@Address, Country=@Country" + (string.IsNullOrEmpty(concatQuery) ? "" : ", " + concatQuery) + " where UserId=@UserId";

                    cmd = new SqlCommand(query, con);

                    // Add parameters
                    cmd.Parameters.AddWithValue("@Username", txtUserName.Text.Trim());
                    cmd.Parameters.AddWithValue("@Name", txtfullname.Text.Trim());
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@Mobile", txtMobile.Text.Trim());
                    cmd.Parameters.AddWithValue("@TenthGrade", txt10th.Text.Trim());
                    cmd.Parameters.AddWithValue("@TwelthGrade", txt12th.Text.Trim());
                    cmd.Parameters.AddWithValue("@GraduationGrade", txtGraduation.Text.Trim());
                    cmd.Parameters.AddWithValue("@PostGraduationGrade", txtPostGraduation.Text.Trim());
                    cmd.Parameters.AddWithValue("@phd", txtPHD.Text.Trim());
                    cmd.Parameters.AddWithValue("@WorksOn", txtWork.Text.Trim());
                    cmd.Parameters.AddWithValue("@Experience", txtExperience.Text.Trim());
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());
                    cmd.Parameters.AddWithValue("@Country", ddlCountry.SelectedValue);
                    cmd.Parameters.AddWithValue("@UserId", Request.QueryString["id"]);

                    if (IsValid)
                    {
                        Guid obj = Guid.NewGuid();
                        filePath = "Resume/" + obj.ToString() + fuResume.FileName;
                        fuResume.PostedFile.SaveAs(Server.MapPath("~/Resume/") + obj.ToString() + fuResume.FileName);

                        cmd.Parameters.AddWithValue("@resume", filePath);
                    }

                    // Debugging: Log the query
                    Response.Write("<script>console.log('Query: " + query.Replace("'", "\\'") + "');</script>");

                    // Execute the query
                    con.Open();
                    int r = cmd.ExecuteNonQuery();
                    if (r > 0)
                    {
                        lblMsg.Visible = true;
                        lblMsg.Text = "Resume Details Updated Successfully...!!";
                        lblMsg.CssClass = "alert alert-success";
                    }
                    else
                    {
                        lblMsg.Visible = true;
                        lblMsg.Text = "Cannot Update The Records, Please Try Again Later...!!";
                        lblMsg.CssClass = "alert alert-danger";
                    }
                }
                else
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "Cannot Update The Records, Please Try <b>ReLogin</b>";
                    lblMsg.CssClass = "alert alert-danger";
                }
            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("Violation of UNIQUE KEY constraint"))
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "<b>" + txtUserName.Text.Trim() + "</b> Username already exists, try a new one...!!";
                    lblMsg.CssClass = "alert alert-danger";
                }
                else
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
            finally
            {
                con.Close();
            }
        }
    }
}