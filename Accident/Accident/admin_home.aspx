<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="admin_home.aspx.cs" Inherits="Accident.admin_home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section>
  <div class="container-fluid h-custom">
    <div class="row d-flex justify-content-center align-items-center h-100">
      <div class="col-md-9 col-lg-6 col-xl-5">
          
          <img src="images/istockphoto-858917796-612x612.jpg" 
          class="img-fluid" alt="Sample image">
      </div>
      <div class="col-md-8 col-lg-6 col-xl-4 offset-xl-1">
        <form>
          <div class="d-flex flex-row align-items-center justify-content-center justify-content-lg-start">
            <p class="lead fw-normal mb-0 me-3">Welcome Rode Cover</p>
            <button type="button" class="btn btn-primary btn-floating mx-1">
              <i class="fab fa-facebook-f"></i>
            </button>

            <button type="button" class="btn btn-primary btn-floating mx-1">
              <i class="fab fa-twitter"></i>
            </button>

            <button type="button" class="btn btn-primary btn-floating mx-1">
              <i class="fab fa-linkedin-in"></i>
            </button>
          </div>

          <div class="divider d-flex align-items-center my-4">
            <p class="text-center fw-bold mx-3 mb-0">&nbsp;</p>
          </div>

          <!-- Email input -->
          

          <div class="d-flex justify-content-between align-items-center">
            <!-- Checkbox -->
            <div class="form-check mb-0">
            </div>
          </div>
             <div class="text-center text-lg-start mt-4 pt-2">
          <a href="admin_update.aspx">  <button type="button" class="btn btn-danger btn-lg"
              style="padding-left: 2.5rem; padding-right: 2.5rem;">Driver Accounts</button></a>
           
          </div>

            <div class="text-center text-lg-start mt-4 pt-2">
          <a href="addstaff.aspx">  <button type="button" class="btn btn-danger btn-lg"
              style="padding-left: 2.5rem; padding-right: 2.5rem;">Police/Insurance Member Accounts</button></a>
           
          </div>

            <div class="text-center text-lg-start mt-4 pt-2">
          <a href="po_register.aspx">  <button type="button" class="btn btn-danger btn-lg"
              style="padding-left: 2.5rem; padding-right: 2.5rem;">Add Police/Insurance Members</button></a>
           
          </div>

          <div class="text-center text-lg-start mt-4 pt-2">
           <a href="addmin_viweaccident.aspx"> <button type="button" class="btn btn-danger btn-lg"
              style="padding-left: 2.5rem; padding-right: 2.5rem;">Viwe&nbsp; Accident</button></a>
           
                
          </div>

        </form>
      </div>
    </div>
  </div>
  <div
   
    <!-- Copyright -->
    
    <!-- Copyright -->

    <!-- Right -->
    <div>
      <a href="#!" class="text-white me-4">
        <i class="fab fa-facebook-f"></i>
      </a>
      <a href="#!" class="text-white me-4">
        <i class="fab fa-twitter"></i>
      </a>
      <a href="#!" class="text-white me-4">
        <i class="fab fa-google"></i>
      </a>
      <a href="#!" class="text-white">
        <i class="fab fa-linkedin-in"></i>
      </a>
    </div>
    <!-- Right -->
  </div>
</section>

</asp:Content>
