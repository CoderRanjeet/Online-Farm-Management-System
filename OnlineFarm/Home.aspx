<%@ Page Title="" Language="C#" MasterPageFile="~/Customer.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="OnlineFarm.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="hero-slide owl-carousel site-blocks-cover">
        <div class="intro-section" style="background-image: url('img/Banner1.png');">
            <div class="container">
                <div class="row align-items-center">
                    <div class="col-lg-7 justify-content-center mx-auto text-center" data-aos="fade-up">
                        <%--<h1>Farming is the best solution of worlds starvation</h1>--%>
                    </div>
                </div>
            </div>
        </div>

        <div class="intro-section" style="background-image: url('img/Banner2.jpg');">
            <div class="container">
                <div class="row align-items-center">
                    <div class="col-lg-7 justify-content-center mx-auto text-center" data-aos="fade-up">
                        <span class="d-block"></span>
                        <%--<h1>Organic vegetables is good for health</h1>--%>
                    </div>
                </div>
            </div>
        </div>

        <div class="intro-section" style="background-image: url('img/Banner3.png');">
            <div class="container">
                <div class="row align-items-center">
                    <div class="col-lg-7 justify-content-center mx-auto text-center" data-aos="fade-up">
                        <span class="d-block"></span>
                        <%--<h1>Providing Fresh Produce Every Single Day</h1>--%>
                    </div>
                </div>
            </div>
        </div>

        <div class="intro-section" style="background-image: url('images1/hero_4.jpg');">
            <div class="container">
                <div class="row align-items-center">
                    <div class="col-lg-7 justify-content-center mx-auto text-center" data-aos="fade-up">
                        <span class="d-block"></span>
                        <h1>Farming as a Passion</h1>
                    </div>
                </div>
            </div>
        </div>

        <div class="intro-section" style="background-image: url('images1/hero_5.jpg');">
            <div class="container">
                <div class="row align-items-center">
                    <div class="col-lg-7 justify-content-center mx-auto text-center" data-aos="fade-up">
                        <span class="d-block"></span>
                        <h1>Good Food For All</h1>
                    </div>
                </div>
            </div>
        </div>

        <div class="intro-section" style="background-image: url('images1/hero_6.jpg');">
            <div class="container">
                <div class="row align-items-center">
                    <div class="col-lg-7 justify-content-center mx-auto text-center" data-aos="fade-up">
                        <span class="d-block"></span>
                        <h1>Plants Make Life Better</h1>
                    </div>
                </div>
            </div>
        </div>

    </div>
    <!-- END slider -->

    <!-- Main Content -->
    <div class="container-fluid">
        <div class="jumbotron jumbotron-fluid" style="color: darkcyan;">
            <div class="container-fluid">
                <h2>Hello,
                        <label runat="server" id="lblname"></label>
                </h2>
                <h1 class="display-4">Welcome to our Farm Store !</h1>
                <h3 class="lead">Our Farm store has thousands of Fruits, Vegetables, grains ..etc. Browse our collection and find your new favorite product today!</h3>

                Note : <h4>1. Delivery Time will be 6 AM To 6 PM. <br />
                   2. Delivery For Grain Products will be 7 Days.
                </h4>
            </div>
        </div>
    </div>


    <div class="row mt-3">
        <asp:Repeater runat="server" ID="RptProducts" OnItemCommand="RptProducts_ItemCommand">
            <ItemTemplate>
                <div class="col-md-3 mb-4">
                    <div class="card h-100 border-0">
                        <img src='<%# Eval("ProductImg") %>' class="card-img-top mx-auto d-block" style="max-width: 225px; max-height: 260px;" />
                        <div class="card-body text-center">
                            <h5 class="card-title"><span style="display: none;"><%# Eval("ProductId") %></span> <%# Eval("Product") %></h5>
                            <h5 class="card-title"><span>Rs</span> <%# Eval("Price") %> <span>Per <%#Eval("Unit")%></span></h5>
                          <h5 class="card-title"><span>Avail. Qty : </span> <%# Eval("Qty") %> <span> <%#Eval("Unit")%></span></h5>

                            <p class="card-text" style="display: block; text-overflow: ellipsis; width: 300px; overflow: hidden; white-space: nowrap;"><%# Eval("Description") %></p>

                            <asp:LinkButton runat="server" class="btn btn-success" CommandArgument='<%# Eval("ProductId") %>' CommandName="View">View Details</asp:LinkButton>
                        </div>
                    </div>
                </div>

            </ItemTemplate>
        </asp:Repeater>
    </div>




    <div class="site-section services-1-wrap">
        <div class="container">
            <div class="row mb-5 justify-content-center text-center">
                <div class="col-lg-7">
                    <h3 class="section-subtitle font-weight-bold text-monospace">Buy Vegetables Online</h3>
                    <h2 class="section-title mb-4 text-muted">Providing Fresh Products Every Single Day</h2>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-4">
                    <img src="img/fruitsImage.jpg" width="300" class="rounded" />
                </div>
                <div class="col-lg-8">
                    <h2>OnlineFarm - Your Online Source for Fresh Vegetables and Fruits</h2>
                    <p class="lead">
                        In today's fast-paced world, it's increasingly challenging to find fresh vegetables in local
          supermarkets. ApnaSabji addresses this issue by providing a convenient online platform to order fresh produce
          from the comfort of your home.
                    </p>
                    <p>
                        We understand the importance of incorporating fresh vegetables into your daily meals. Whether it's amlas, green
          peas, broccoli, beetroot, potatoes, or tomatoes, ApnaSabji offers a diverse range of fresh and quality produce.
          Our platform simplifies the shopping process, ensuring a hassle-free experience.
                    </p>
                    <p>
                        We take pride in our efficient delivery system, guaranteeing that you receive your order by the next day. With
          a wide delivery network covering major cities like Delhi, Noida, Greater Noida, Ghaziabad, Gurugram, and
          Indirapuram, we bring the benefits of fresh and nutritious fruits and vegetables right to your doorstep.
                    </p>
                    <p>
                        Choose ApnaSabji for a top-class shopping experience that prioritizes the quality and freshness of your produce
          every time.
                    </p>
                </div>
            </div>
        </div>
    </div>
    <!-- END services -->

  
        <div class="block-2">
            <div class="container">
                <div class="row">
                    <div class="col-lg-6 mb-4 mb-lg-0">
                        <img src="images1/img_long_5.jpg" alt="Image " class="rounded">
                    </div>
                    <div class="col-lg-5 ml-auto">
                        <h3 class="section-subtitle text-white opacity-50">Why Choose Product from Us</h3>
                        <h2 class="section-title mb-4">More than <strong>50 year experience</strong> in agriculture industry</h2>
                        <p class="opacity-50">fresh vegetables should be a part of our daily meals, which play an important role in our daily diet.</p>

                        <div class="row my-5">
                            <div class="col-lg-12 d-flex align-items-start mb-4">
                                <span class="icon-leaf mr-4 display-4"></span>
                                <div>
                                    <h4 class="m-0 h5 text-white">Always Fresh Foods</h4>
                                    <p class="text-white opacity-50">committed to delivering premium, high-quality, and impeccably fresh food products.</p>
                                </div>
                            </div>
                            <div class="col-lg-12 d-flex align-items-start mb-4">
                                <span class="icon-lemon-o mr-4 display-4"></span>
                                <div>
                                    <h4 class="m-0 h5 text-white">Organic Foods</h4>
                                    <p class="text-white opacity-50">a commitment to pure, wholesome, and sustainable nutrition. Our products are cultivated without synthetic pesticides, herbicides, or genetically modified organisms, ensuring a natural and environmentally conscious approach to farming. </p>
                                </div>
                            </div>
                            <div class="col-lg-12 d-flex align-items-start">
                                <span class="icon-dashboard mr-4 display-4"></span>
                                <div>
                                    <h4 class="m-0 h5 text-white">Healtier Soil</h4>
                                    <p class="text-white opacity-50">dedicated to cultivating the foundation of sustainable agriculture. We focus on enhancing soil health through organic practices, cover cropping, and responsible land management.</p>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
 

    <div class="site-section">
        <div class="container">
            <div class="row justify-content-between align-items-center">
                <div class="col-lg-6 order-lg-2 mb-4 mb-lg-0">
                    <a data-fancybox href="https://www.youtube.com/watch?v=_sI_Ps7JSEk" class="video-1">
                        <span class="play"><span class=" icon-play"></span></span>
                        <img src="images1/img_sq_1.jpg" alt="Image" class="img-fluid">
                    </a>
                </div>
                <div class="col-lg-5 order-lg-1">
                    <h2 class="text-primary mb-4">Benefits of Fruits and Vegetables</h2>
                    <p class="mb-4">
                        Since our childhood, we have studied in our school that how essentials vegetables and fruits are in our life. 
                      However, we are not taking this seriously in our daily life and tend to ignore them. but you know fruits and vegetables 
                      are rich in diet which helps us to stay healthy and physically fit all the time. These are helping in maintaining the blood pressure, 
                      controls the sugar levels, and most important making our digestive system so strong. we can maintain our body proteins intake by
                      consuming varieties of fruits and vegetables which are available and it can be prepared in different ways. we can consume some vegetables raw,
                      while some need to be cooked properly before having it. Although it does not matter how we are consuming them, the most important part we should 
                      consume them in a good amount in our everyday meals.
                    </p>

                    <p><a href="#" class="btn btn-primary">Get in touch</a></p>
                </div>
            </div>
        </div>
    </div>


    <div class="site-section services-1-wrap">
        <div class="container">
            <div class="term-description">
                <h3><strong>FAQ</strong></h3>
                <h4><strong>Where can I buy vegetables online?</strong></h4>
                <p>Well, you can buy the vegetable online through a virtual world. Multiples option available over the internet however Apnasabji is the best store to buy farm-fresh green vegetables right to your doorstep with free delivery.</p>
                <h4><strong>How To Order Fresh Fruits And Vegetables Online?</strong></h4>
                <p>First, you have to signup for an account on Apnasabji website, then select the veggies and fruits which you want to order and add into the cart along with the required quantity then choose the payment method which suits your comfort. Then place the order after placing a unique order number will get generated and the next day your order will get delivered at your home.</p>
                <h4><strong>Which Is The Cheapest Place To Buy Vegetables And Fruits?</strong></h4>
                <p>ApnaSabji is the right choice to buy veggies online. Here you will find the cheaper price than the supermarket and local market to buy the freshest produce at discounted rates ever.</p>
                <h4><strong>Can I Order Vegetables Online?</strong></h4>
                <p>Yes, you can order vegetables online on Apnasabji. As we all know veggies and fruits are playing an important role to keep our body healthy and energetic to fulfill nutritional supplements on a regular basis. Buy fresh fruits and organic veggies from Apnasabji at the lowest price delivered to your doorstep.</p>
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
