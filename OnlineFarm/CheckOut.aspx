<%@ Page Title="" Language="C#" MasterPageFile="~/Customer.Master" AutoEventWireup="true" CodeBehind="CheckOut.aspx.cs" Inherits="OnlineFarm.CheckOut" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="container">
        <div class="col-md-8 offset-3">
            <div class="card  mb-5">
                <div class="card-header bg-info text-white text-center">
                    <h2>Fill Below Details</h2>
                </div>

                <div class="card-body">
                    <div class="container">
                        <div class="row">
                            <div class="col-md-10">
                                <h4 class="Form-Group mb-3">Contact Information</h4>
                                <div class="form-group row">
                                    <asp:Label ID="Label3" CssClass="col-md-4" runat="server" Text="Name"></asp:Label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtname" placeholder="Enter your name" CssClass="form-control" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ForeColor="Red" ErrorMessage="RequiredFieldValidator"
                                            ControlToValidate="txtname">Name is Required </asp:RequiredFieldValidator>
                                    </div>
                                </div>

                                <div class="form-group row">
                                    <asp:Label ID="Label1" CssClass="col-md-4" runat="server" Text="Email Address "></asp:Label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtemail" placeholder="Enter Email" CssClass="form-control" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ForeColor="Red" ErrorMessage="RequiredFieldValidator"
                                            ControlToValidate="txtemail"> Email is Required </asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ForeColor="Red" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtemail" ErrorMessage="Invalid Email Format"></asp:RegularExpressionValidator>
                                    </div>
                                </div>

                                <div class="form-group row">
                                    <asp:Label ID="Label5" CssClass="col-md-4" runat="server" Text="Phone Number "></asp:Label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtphone" placeholder="Enter phone number" CssClass="form-control" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ForeColor="Red" ErrorMessage="RequiredFieldValidator"
                                            ControlToValidate="txtphone">Phone Number is Required </asp:RequiredFieldValidator>

                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server"
                                            ControlToValidate="txtphone" ForeColor="Red" ErrorMessage="Phone number is not valid format"
                                            ValidationExpression="[0-9]{10}"></asp:RegularExpressionValidator>
                                    </div>
                                </div>

                                <div class="form-group row">
                                    <asp:Label ID="Label2" CssClass="col-md-4" runat="server" Text="Alternate Phone Number "></asp:Label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtAltMobileNo" placeholder="Enter Alternate phone number" CssClass="form-control" runat="server"></asp:TextBox>

                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                                            ControlToValidate="txtAltMobileNo" ForeColor="Red" ErrorMessage="Phone number is not valid format"
                                            ValidationExpression="[0-9]{10}"></asp:RegularExpressionValidator>
                                    </div>
                                </div>

                                <h4 class="mb-3">Billing Address</h4>
                                <div class="Form-Group row">
                                    <asp:Label ID="lbladdress" CssClass="col-md-4" runat="server" Text="Address "></asp:Label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtaddress" placeholder="Enter address" CssClass="form-control" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ForeColor="Red" ErrorMessage="RequiredFieldValidator"
                                            ControlToValidate="txtaddress">Address is Required </asp:RequiredFieldValidator>
                                    </div>
                                </div>

                                <div class="Form-Group row">
                                    <asp:Label ID="lblcity" CssClass="col-md-4" runat="server" Text="City "></asp:Label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtcity" placeholder="Enter city" CssClass="form-control" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ForeColor="Red" ErrorMessage="RequiredFieldValidator"
                                            ControlToValidate="txtcity">City is Required </asp:RequiredFieldValidator>
                                    </div>
                                </div>

                                <div class="Form-Group row">
                                    <asp:Label ID="Label4" CssClass="col-md-4" runat="server" Text="House No, Building Name"></asp:Label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtHouse" placeholder="Enter address Details" CssClass="form-control" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red" ErrorMessage="RequiredFieldValidator"
                                            ControlToValidate="txtHouse">This is Required Field </asp:RequiredFieldValidator>
                                    </div>
                                </div>

                                <div class="Form-Group row">
                                    <asp:Label ID="lblstate" CssClass="col-md-4" runat="server" Text="State "></asp:Label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtstate" placeholder="Enter state" CssClass="form-control" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ForeColor="Red" ErrorMessage="RequiredFieldValidator"
                                            ControlToValidate="txtstate"> State is Required </asp:RequiredFieldValidator>
                                    </div>
                                </div>

                                <div class="Form-Group row">
                                    <asp:Label ID="lblzipcode" CssClass="col-md-4" runat="server" Text="Zip Code "></asp:Label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtzipcode" placeholder="Enter Zip code" CssClass="form-control" runat="server"></asp:TextBox>

                                        <%--<asp:RequiredFieldValidator ID="ValidZipCode" runat="server" ControlToValidate="txtzipcode" InitialValue="" Display="Dynamic" ErrorMessage="Zip Code is required." ForeColor="Red" ValidationGroup="ZipCodeValidation" />

                                        <asp:RegularExpressionValidator ID="revZipCode" runat="server" ControlToValidate="txtzipcode" ValidationExpression="^(?=.*[0-9])(?=.*[a-zA-Z])[a-zA-Z0-9]{6}$" Display="Dynamic" ErrorMessage="Invalid Zip Code format (e.g., W1A0AX)." ForeColor="Red" ValidationGroup="ZipCodeValidation" />--%>
                                    </div>
                                </div>

                                <h4 class="Form-Group mb-3">Billing Details</h4>
                                <div class="form-group row">
                                    <label class="form-label col-md-4">Payment Option </label>
                                    <br />
                                    <asp:CheckBox ID="CheckBox1" CssClass="ml-3" runat="server" Text=" On Cash" />
                                    <asp:CheckBox ID="CheckBox2" CssClass="ml-3" runat="server" Text=" UPI" AutoPostBack="true" OnCheckedChanged="CheckBox2_CheckedChanged" />
                                    <asp:CheckBox ID="CheckBox3" CssClass="ml-3" runat="server" Text=" Credit/Debit Card" AutoPostBack="true" OnCheckedChanged="CheckBox3_CheckedChanged" />
                                </div>

                                <div id="divupi" runat="server" class="row" visible="false">
                                    <div class="col-6 form-group">
                                        <label>Enter UPI here</label>
                                        <input type="text" runat="server" id="txtUPI" class="form-control" />
                                    </div>
                                    <div class="col-6">
                                        <button runat="server" class="btn btn-success btn-lg mt-4" id="BtnUpiPayment" onserverclick="BtnUpiPayment_ServerClick">Pay</button>
                                    </div>
                                </div>

                                <div id="divpaymentcard" runat="server" visible="false">
                                           <div class="row mb-3">
                                <label>Bank Name :  </label>
                                <asp:DropDownList runat="server" ID="ddlbanks" CssClass="form-control w-50">
                                    <asp:ListItem>-- select Bank --</asp:ListItem>
                                    <asp:ListItem>Hdfc Bank</asp:ListItem>
                                    <asp:ListItem>SBI Bank</asp:ListItem>
                                    <asp:ListItem>Union Bank</asp:ListItem>
                                    <asp:ListItem>BOI Bank</asp:ListItem>
                                    <asp:ListItem>Kotak Bank</asp:ListItem>
                                    <asp:ListItem>Maharashtra Bank</asp:ListItem>
                                    <asp:ListItem>CBI Bank</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                                    <div class="form-group row">
                                        <asp:Label ID="lblcardnumber" CssClass="col-md-4" runat="server" Text="Card Number"></asp:Label>
                                        <div class="col-md-8">
                                            <asp:TextBox ID="txtCardNumber" runat="server" placeholder="Enter card number" CssClass="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvCardNumber" runat="server" ControlToValidate="txtCardNumber"
                                                ErrorMessage="Card Number is required." ForeColor="Red" />

                                            <asp:RegularExpressionValidator ID="revCardNumber" runat="server" ControlToValidate="txtCardNumber" ValidationExpression="^[1-9][0-9]{3}[1-3]{4}[0-9]{4}[0-9]{4}$" Display="Dynamic"
                                                ErrorMessage="Invalid card number format. Ex. 1234111112345678" ForeColor="Red" />
                                        </div>
                                    </div>

                                    <div class="form-group row">
                                        <asp:Label ID="Label6" CssClass="col-md-4" runat="server" Text="Card Holder Name"></asp:Label>
                                        <div class="col-md-8">
                                            <asp:TextBox ID="txtCardholder" placeholder="Enter your name" CssClass="form-control" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ForeColor="Red" ErrorMessage="RequiredFieldValidator"
                                                ControlToValidate="txtCardholder">Card Holder Name is Required </asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="col-6">
                                        <button runat="server" class="btn btn-success btn-lg mt-4" id="BtnCardPayment" onserverclick="BtnCardPayment_ServerClick">Pay</button>
                                    </div>
                                </div>
                                <div class="mt-5 text-center">
                                    <asp:Button ID="BtnOrder" runat="server" CssClass="btn btn-success btn-lg" Text="Order Now" OnClick="BtnOrder_Click1" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
