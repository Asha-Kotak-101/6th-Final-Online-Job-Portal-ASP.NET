using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;

namespace OJP_AshaKotak.User
{
    public partial class Register : Page
    {
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = @"INSERT INTO OJPUser (Username, Password, Name, Address, Mobile, Email, Country) 
                 VALUES (@Username, @Password, @Name, @Address, @Mobile, @Email, @Country)";


                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Username", txtUserName.Text.Trim());
                        cmd.Parameters.AddWithValue("@Password", txtConfirmPassword.Text.Trim());
                        cmd.Parameters.AddWithValue("@Name", txtfullname.Text.Trim());
                        cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());
                        cmd.Parameters.AddWithValue("@Mobile", txtMobile.Text.Trim());
                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                        cmd.Parameters.AddWithValue("@Country", ddlCountry.SelectedValue);

                        con.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            lblMsg.Visible = true;
                            lblMsg.Text = "Registered Successfully..!!";
                            lblMsg.CssClass = "alert alert-success";
                            ClearFields();
                        }
                        else
                        {
                            lblMsg.Visible = true;
                            lblMsg.Text = "Registration failed, please try again later.";
                            lblMsg.CssClass = "alert alert-danger";
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("Violation of UNIQUE KEY constraint"))
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "<b>" + txtUserName.Text.Trim() + "</b> username already exists, try a new one...!!";
                    lblMsg.CssClass = "alert alert-danger";
                }
                else
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "An error occurred: " + ex.Message;
                    lblMsg.CssClass = "alert alert-danger";
                }
            }
            catch (Exception ex)
            {
                lblMsg.Visible = true;
                lblMsg.Text = "An error occurred: " + ex.Message;
                lblMsg.CssClass = "alert alert-danger";
            }
        }

        private void ClearFields()
        {
            txtUserName.Text = string.Empty;
            txtpassword.Text = string.Empty;
            txtConfirmPassword.Text = string.Empty;
            txtfullname.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtMobile.Text = string.Empty;
            txtEmail.Text = string.Empty;
            ddlCountry.ClearSelection();
        }
    }
}
