<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="addaccident.aspx.cs" Inherits="Accident.addaccident" %>
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
                           <h4>Edit Accident</h4>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <center>
                           <img id="imgview" width="100px" height="150px" src="accident_pic/istockphoto-451333971-612x612.jpg" />
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
                        <asp:FileUpload onchange="readURL(this)" class="form-control" ID="FileUpload1" runat="server" />
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-3">
                        <label>Accident Id</label>
                        <div class="form-group">
                           <div class="input-group">
                              <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="ID"></asp:TextBox>
                              
                           </div>
                        </div>
                     </div>
                     <div class="col-md-9">
                        <label>Location</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Location"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-4">
                        <label>Reporter Full Name</label>
                        <div class="form-group">
                          <asp:TextBox CssClass="form-control" ID="TextBox12" runat="server" placeholder="Full Name" ReadOnly="True"  ></asp:TextBox>
                        </div>
                        <label>Member Id</label>
                        <div class="form-group">
                           
                           <asp:TextBox CssClass="form-control" ID="TextBox8" runat="server" placeholder="Member_id" ReadOnly="True"  ></asp:TextBox>
                        
                        </div>
                     </div>
                     <div class="col-md-4">
                        <label>Type of Accident</label>
                        <div class="form-group">
                           <asp:DropDownList class="form-control" ID="DropDownList3" runat="server"  >
                                <asp:ListItem Text="Select" Value="a0" />
                              <asp:ListItem Text="Rear-End Collisions" Value="Rear-End Collisions" />
                              <asp:ListItem Text="Head-On Collisions" Value="Head-On Collisions" />
                                <asp:ListItem Text="Single-Vehicle Accidents" Value="Single-Vehicle Accidents" />
                               <asp:ListItem Text="Multi-Vehicle Accidents" Value="Multi-Vehicle Accidents" />
                               <asp:ListItem Text="Rollover Accidents" Value="Rollover Accidents" />
                               <asp:ListItem Text="Others" Value="Others" />
                           </asp:DropDownList>
                        </div>
                        <label>Date </label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="Date" TextMode="Date"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-4">
                        <label>Reson Of Accident</label>
                        <div class="form-group">
                           <asp:ListBox CssClass="form-control" ID="ListBox1" runat="server" SelectionMode="Multiple" Rows="5">
                              <asp:ListItem Text="Bad Weather" Value="Bad Weather" />
                              <asp:ListItem Text="Distractions" Value="Distractions" />
                              <asp:ListItem Text="Speeding" Value="Speeding " />
                              <asp:ListItem Text="Drunk Driving" Value="Drunk Driving" />
                              
                              <asp:ListItem Text="Other" Value="Other" />
                              
                           </asp:ListBox>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-4">
                        <label>Vehicle Involvement 1</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox9" runat="server" placeholder="Vehicle Involvement 1"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-4">
                        <label>Vehical Owner's name</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox10" runat="server" placeholder="Vehical Owner's name" ></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-4">
                        <label>Vehical Number</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox11" runat="server" placeholder="Vehical Number" ></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-4">
                        <label>Vehicle Involvement 2</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="Vehicle Involvement 2" ></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-4">
                        <label>Vehical Owner's name</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox5" runat="server" placeholder="Vehical Owner's name" ></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-4">
                        <label>Vehical Number</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox7" runat="server" placeholder="Vehical Number" ></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-12">
                        <label>Description</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox6" runat="server" placeholder=" Description" TextMode="MultiLine" Rows="2"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                   <br />
                  <div class="row">
                    
                     <div class="col-4">
                     </div>
                      <div class="col-4">
                        <asp:Button ID="Button1" class="btn btn-lg btn-block btn-success" runat="server" Text="Add" OnClick="Button1_Click" Width="580px"  />
                     </div>
                     <div class="col-4">
                     </div>
                  </div>
               </div>
            </div>
            <a href="userhome.aspx"><< Back to Home</a><br>
            <br>
         </div>
         <div class="col-md-7">
            <div class="card">
               <div class="card-body">
                  <div class="row">
                     <div class="col">
                        <center>
                           <h4>Accident List</h4>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                  <div class="row">
                     <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Rode_CoverConnectionString2 %>" SelectCommand="SELECT * FROM [accident1]"></asp:SqlDataSource>
                     <div class="col">
                                <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server"  AutoGenerateColumns="False">
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
                                                           <span>Statuse - </span>
                                                   <asp:Label ID="Label13" runat="server" Font-Bold="True" ForeColor="Red" Text='<%# Eval("acc_statuse") %>'></asp:Label>
                                                         &nbsp;   <span>Location - </span>
                                                   <asp:Label ID="Label2" runat="server" Font-Bold="True" Text='<%# Eval("Location") %>'></asp:Label>
&nbsp;| <span><span>&nbsp;</span>Reson- </span>
                                                   <asp:Label ID="Label4" runat="server" Font-Bold="True" Text='<%# Eval("Reson") %>'></asp:Label>
                                                   &nbsp;| 
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
               </div>
            </div>
         </div>
      </div>
   </div>
</asp:Content>
