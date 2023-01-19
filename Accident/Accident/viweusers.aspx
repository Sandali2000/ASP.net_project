<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="viweusers.aspx.cs" Inherits="Accident.viweusers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
        });

        function readURL(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();

                reader.onload = function (e) {
                    $('#imgview').attr('src', e.target.result);
                };

                reader.readAsDataURL(input.files[0]);
            }
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="container-fluid">
      <div class="row">
         <div class="col-md-5">
            <div class="card">
              <div class="card-body">
                  <div class="row">
                     <div class="col">
                        <center>
                           <img width="150px" src="images/user3.png" />
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <center>
                           <h4>Your Profile</h4>
                           <span>Account Status - </span>
                           <asp:Label  ID="Label1" runat="server" cssclass="bg-primary" Text="Your status" ForeColor="White" ></asp:Label>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-6">
                        <label>Full Name</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Full Name"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-6">
                        <label>User Id</label>
                         <div class="form-group">
                             <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Use Id" ></asp:TextBox>
                         </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-6">
                        <label>Contact No</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="Contact No" TextMode="Number"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-6">
                        <label>Email </label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="Email " TextMode="Email"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-4">
                        <label>Position</label>
                        <div class="form-group">
                           <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control">
                                
                                 <asp:ListItem Text="Driver" Value="Driver" />
                             
                               </asp:DropDownList>
                        </div>
                     </div>
                     <div class="col-md-4">
                        <label>Address</label>
                        <div class="form-group">
                           <asp:TextBox class="form-control" ID="TextBox6" runat="server" placeholder="City"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-4">
                        <label>Pincode</label>
                        <div class="form-group">
                           <asp:TextBox class="form-control" ID="TextBox7" runat="server" placeholder="Pincode" TextMode="Number"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  
                  <div class="row">
                     <div class="col">
                        <center>
                           <span class="badge badge-pill badge-info">Login Credentials</span>
                        </center>
                     </div>
                  </div>
                 
                     <div class="col-md-4">
                        <label> Password</label>
                        <div class="form-group">
                           <asp:TextBox class="form-control" ID="TextBox9" runat="server" placeholder="Password"  ></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-4">
                         Vehical Number<div class="form-group">
                           <asp:TextBox class="form-control" ID="TextBox10" runat="server" placeholder="Confirm Password" ></asp:TextBox>
                        </div>
                     </div>
                  </div>
                   <br />
                  <div class="row">
                     <div class="col-8 mx-auto">
                        <center>
                           <div class="form-group">
                              <asp:Button class="btn btn-primary btn-block btn-lg" ID="Button1" runat="server" Text="Update" OnClick="Button1_Click" />
                           </div>
                        </center>
                     </div>
                  </div>
               </div>
             <a href="userhome.aspx"><< Back to Home</a><br><br />
            </div>
          
            
         
         <div class="col-md-7">
            <div class="card">
               <div class="card-body">
                  <div class="row">
                     <div class="col">
                        <center>
                           
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <center>
                           <h4></h4>
                           <asp:Label class="badge badge-pill badge-info" ID="Label2" runat="server" Text=""></asp:Label>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" OnRowDataBound="GridView1_RowDataBound" AutoGenerateColumns="False">
                            <Columns>
                              
                               <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" ReadOnly="True" />
                               
                               <asp:TemplateField>

                                   <ItemTemplate>
                                       <div class="container-fluid">
                                           <div class="row">
                                               <div class="col-lg-10">
                                                   <div class="row">
                                                       <div class="col-12">
                                                           <asp:Label ID="Label1" runat="server" Text='<%# Eval("Eyewittness") %>' Font-Bold="True" Font-Size="X-Large"></asp:Label>
                                                       </div>
                                                   </div>
                                                    <div class="row">
                                                       <div class="col-12">
                                                           <span>Location - </span>
                                                   <asp:Label ID="Label2" runat="server" Font-Bold="True" Text='<%# Eval("Location") %>'></asp:Label>
                                                   &nbsp;| <span><span>&nbsp;</span>Member Id- </span>
                                                   <asp:Label ID="Label8" runat="server" Font-Bold="True" Text='<%# Eval("user_id") %>'></asp:Label>
                                                   &nbsp;| 
                                                   <span>
                                                    Date -<span>&nbsp;</span>
                                                      <asp:Label ID="Label111" runat="server" Font-Bold="True" Text='<%# Eval("Date") %>'></asp:Label>
                                                   </span>
                                                       </div>
                                                   </div>
                                                    <div class="row">
                                                       <div class="col-12">
                                                          Vehicle Involvement (01) -
                                                   <asp:Label ID="Label3" runat="server" Font-Bold="True" Text='<%# Eval("Vehical_invol1") %>'></asp:Label>
                                                   &nbsp;| Owners Name(01) -
                                                   <asp:Label ID="Label6" runat="server" Font-Bold="True" Text='<%# Eval("Name1") %>'></asp:Label>
                                                   &nbsp;| Vehical Number -
                                                   <asp:Label ID="Label7" runat="server" Font-Bold="True" Text='<%# Eval("Vehical_num1") %>'></asp:Label>
                                                   &nbsp;|  Type of Accident-
                                                     <asp:Label ID="Label5" runat="server" Font-Bold="True" Text='<%# Eval("Accident_type") %>'></asp:Label>
                                                       </div>
                                                   </div>
                                                    <div class="row">
                                                       <div class="col-12">
                                                       Vehicle Involvement (02)  -
                                                   <asp:Label ID="Label9" runat="server" Font-Bold="True" Text='<%# Eval("Vehical_invol2") %>'></asp:Label>
                                                   &nbsp;| Owners Name(02) -
                                                   <asp:Label ID="Label10" runat="server" Font-Bold="True" Text='<%# Eval("Name2") %>'></asp:Label>
                                                   &nbsp;| Vehical Number -
                                                   <asp:Label ID="Label11" runat="server" Font-Bold="True" Text='<%# Eval("Vehical_num2") %>'></asp:Label>
                                                       </div>
                                                   </div>
                                                    <div class="row">
                                                       <div class="col-12">
                                                           Description -
                                                   <asp:Label ID="Label12" runat="server" Font-Bold="True" Font-Italic="True" Font-Size="Smaller" Text='<%# Eval("Description") %>'></asp:Label>
                                                       </div>
                                                   </div>
                                                    <div class="row">
                                                       <div class="col-12">

                                                       </div>
                                                   </div>
                                           </div>
                                               <div class="col-lg-2">
                                                   <asp:Image CssClass="img-fluid" Width="300" Height="150" ID="Image1" runat="server" ImageUrl='<%# Eval("Image") %>' />
                                           </div>
                                           </div>
                                       </div>
                                   </ItemTemplate>

                               </asp:TemplateField>
                               
                           </Columns>
                        </asp:GridView>
                     </div>
                  </div>
                   <div class="col-8 mx-auto">
                        <center>
                           <div class="form-group">
                           
                           </div>
                        </center>
                     </div>
               </div>
            </div>
         </div>
          </div>
      </div>
 
</asp:Content>
