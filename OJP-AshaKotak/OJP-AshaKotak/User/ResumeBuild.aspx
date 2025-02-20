<%@ Page Title="" Language="C#" MasterPageFile="~/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="ResumeBuild.aspx.cs" Inherits="OJP_AshaKotak.User.ResumeBuild" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section>
        <div class="container pt-50 pb-40">
                 <div class="row">
                    <div class="col-12 pb-20">
                       <asp:Label ID="lblMsg" runat="server" Visible="false"></asp:Label>
                    </div>
                    <div class="col-12">
                        <h2 class="contact-title text-center">Build Your Resume</h2>
                    </div>
                    <div class="col-lg-12">
                        <div class="form-contact contact_form">
                            <div class="row">
                                <div class="col-12">
                                   <h6>Personal Information</h6>
                                </div>

                                <div class="col-md-6 col-sm-12">
                                    <div class="form-group">
                                         <label>Full Name</label>
                                        <asp:TextBox ID="txtfullname" runat="server" CssClass="form-control" placeholder="Enter Your Full Name" required></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Name must be in Characters" ForeColor="Red" Display="Dynamic" SetFocusOnError="true" Font-Size="Small" ValidationExpression="^[a-zA-Z\s]+$" ControlToValidate="txtfullname"></asp:RegularExpressionValidator>
                                    </div>
                                </div>

                                <div class="col-md-6 col-sm-12">
                                    <div class="form-group">
                                        <label>Username</label>
                                        <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control" placeholder="Enter Your Username" required></asp:TextBox>
                                    </div>
                                </div>

                                 <div class="col-md-6 col-sm-12">
                                    <div class="form-group">
                                         <label>Address</label>
                                        <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" placeholder="Enter Your Address"  required></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-md-6 col-sm-12">
                                    <div class="form-group">
                                         <label>Mobile Number</label>
                                        <asp:TextBox ID="txtMobile" runat="server" CssClass="form-control" placeholder="Enter Your Mobile Number" required></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Mobile No. must have 10 digits" ForeColor="Red" Display="Dynamic" SetFocusOnError="true" Font-Size="Small" ValidationExpression="^[0-9]{10}$" ControlToValidate="txtMobile"></asp:RegularExpressionValidator>
                                    </div>
                                </div>

                                <div class="col-md-6 col-sm-12">
                                    <div class="form-group">
                                         <label>Email</label>
                                        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Enter Your Email" TextMode="Email" required></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-md-6 col-sm-12">
                                    <div class="form-group">
                                         <label>Country</label>
                                        <asp:DropDownList ID="ddlCountry" runat="server" DataSourceID="SqlDataSource1" CssClass="form-control w-100" AppendDataBoundItems="true" DataTextField="CountryName" DataValueField="CountryName">
                                            <asp:ListItem Value="0">Select Country</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Country is Required" ForeColor="Red" Display="Dynamic" SetFocusOnError="true" Font-Size="Small" InitialValue="0" ControlToValidate="ddlCountry"></asp:RequiredFieldValidator>
                                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:cs %>" SelectCommand="SELECT [CountryName] FROM [Country]"></asp:SqlDataSource>
                                    </div>
                                </div>

                                <div class="col-12 pt-4">
                                    <h6>Educational Information</h6>
                                </div>
                                
                                 <div class="col-md-6 col-sm-12">
                                    <div class="form-group">
                                         <label>10th Percentage</label>
                                        <asp:TextBox ID="txt10th" runat="server" CssClass="form-control" placeholder="Ex. 70%" required></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-md-6 col-sm-12">
                                    <div class="form-group">
                                         <label>12th Percentage</label>
                                        <asp:TextBox ID="txt12th" runat="server" CssClass="form-control" placeholder="Ex. 70%" required></asp:TextBox>
                                    </div>
                                </div>
                               
                                <div class="col-md-6 col-sm-12">
                                    <div class="form-group">
                                         <label>Graduation Grade</label>
                                        <asp:TextBox ID="txtGraduation" runat="server" CssClass="form-control" placeholder="Ex. B.Tech with 9.27 CGPA" required></asp:TextBox>
                                    </div>
                                </div>

                                 <div class="col-md-6 col-sm-12">
                                    <div class="form-group">
                                         <label>Post-Graduation Grade</label>
                                        <asp:TextBox ID="txtPostGraduation" runat="server" CssClass="form-control" placeholder="Ex. B.Tech with 9.27 CGPA" required></asp:TextBox>
                                    </div>
                                </div>

                                 <div class="col-md-6 col-sm-12">
                                    <div class="form-group">
                                         <label>PHD Grade</label>
                                        <asp:TextBox ID="txtPHD" runat="server" CssClass="form-control" placeholder="PHD with Grade" required></asp:TextBox>
                                    </div>
                                </div>

                                 <div class="col-md-6 col-sm-12">
                                    <div class="form-group">
                                         <label>Job Profile/Works On</label>
                                        <asp:TextBox ID="txtWork" runat="server" CssClass="form-control" placeholder="Job Profile" required></asp:TextBox>
                                    </div>
                                </div>

                                 <div class="col-md-6 col-sm-12">
                                    <div class="form-group">
                                         <label>Works Experience</label>
                                        <asp:TextBox ID="txtExperience" runat="server" CssClass="form-control" placeholder="Work Experience" required></asp:TextBox>
                                    </div>
                                </div>

                                 <div class="col-md-6 col-sm-12">
                                    <div class="form-group">
                                         <label>Upload Your Resume</label>
                                        <asp:FileUpload ID="fuResume" runat="server" CssClass="form-control pt-2" ToolTip=".doc, .docx, .pdf File Extension Only"/>
                                    </div>
                                </div>

                            </div>
                            <div class="form-group mt-3">
                                  <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="button button-contactForm boxed-btn mr-150" OnClick="btnUpdate_Click1" />
                            </div>
                        </div>
                    </div>
                </div>
        </div>
    </section>

</asp:Content>
