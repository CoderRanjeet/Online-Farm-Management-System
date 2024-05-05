<%@ Page Title="" Language="C#" MasterPageFile="~/Customer.Master" AutoEventWireup="true" CodeBehind="ContactUs.aspx.cs" Inherits="OnlineFarm.ContactUs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
      <div class="intro-section site-blocks-cover innerpage" style="background-image: url('images1/hero_1.jpg');">
        <div class="container">
          <div class="row align-items-center text-center">
            <div class="col-lg-12 mt-5" data-aos="fade-up">
              <h1>Contact Us</h1>
              <p class="text-white text-center">
                <a href="#">Home</a>
                <span class="mx-2">/</span>
                <span>Contact</span>
              </p>
            </div>
          </div>
        </div>
      </div>



      <div class="site-section">
        <div class="container">

          <div class="row">
            <div class="col-lg-6">
              <div class="row">
                <div class="col-md-6 form-group">
                  <label for="fname">First Name</label>
                  <input type="text" id="fname" class="form-control form-control-lg">
                </div>
                <div class="col-md-6 form-group">
                  <label for="lname">Last Name</label>
                  <input type="text" id="lname" class="form-control form-control-lg">
                </div>
              </div>
              <div class="row">
                <div class="col-md-6 form-group">
                  <label for="eaddress">Email Address</label>
                  <input type="text" id="eaddress" class="form-control form-control-lg">
                </div>
                <div class="col-md-6 form-group">
                  <label for="tel">Tel. Number</label>
                  <input type="text" id="tel" class="form-control form-control-lg">
                </div>
              </div>
              <div class="row">
                <div class="col-md-12 form-group">
                  <label for="message">Message</label>
                  <textarea name="" id="message" cols="30" rows="10" class="form-control"></textarea>
                </div>
              </div>

              <div class="row">
                <div class="col-12">
                  <input type="submit" value="Send Message" class="btn btn-primary rounded-0 px-3 px-5">
                </div>
              </div>
            </div>
            <div class="col-lg-6">



              <div class="row">
                <div class="col-md-6 mb-4 mb-md-0">
                  <div class="testimonial">
                    <img src="images1/person_3.jpg" alt="">
                    <blockquote>
                      <p>&ldquo;Lorem ipsum dolor sit, amet consectetur adipisicing elit. Provident deleniti iusto molestias, dolore vel fugiat ab placeat ea?&rdquo;</p>
                    </blockquote>
                    <p class="client-name">James Smith</p>
                  </div>
                </div>
                <div class="col-md-6 mb-4 mb-md-0">
                  <div class="testimonial">
                    <img src="images1/person_4.jpg" alt="">
                    <blockquote>
                      <p>&ldquo;Lorem ipsum dolor sit, amet consectetur adipisicing elit. Provident deleniti iusto molestias, dolore vel fugiat ab placeat ea?&rdquo;</p>
                    </blockquote>
                    <p class="client-name">Kate Smith</p>
                  </div>
                </div>
              </div>


            </div>
          </div>

        </div>
      </div>


      <div class="py-5 bg-primary block-4">
        <div class="container">
          <div class="row align-items-center">
            <div class="col-lg-6">
              <h3 class="text-white">Subscribe To Newsletter</h3>
              <p class="opacity-50">
"Stay in the loop and never miss out on fresh updates, exclusive offers, and seasonal delights! Subscribe to our newsletter for a direct line to the latest news, exciting promotions, and a first look at the best produce straight from the farm to your inbox."</p>
            </div>
            <div class="col-lg-6">
              <div action="#" class="form-subscribe d-flex align-items-stretch">
                <input type="email" class="form-control h-100" placeholder="Enter your e-mail">
                <input type="submit" class="btn btn-secondary px-4" value="Subcribe">
              </div>
            </div>
          </div>
        </div>
      </div>


</asp:Content>
