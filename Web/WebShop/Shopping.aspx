<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Shopping.aspx.cs" Inherits="WebShop_Shopping" Title="Shopping" %>
<%@ MasterType TypeName="MasterPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <h1>Shopping</h1>

	<p>This is where users start shopping. They select items from a catalog 
      of products and add these to a shopping cart. The shopping cart is a fully functional
      e-commerce shopping cart that can be enhanced easily with sales tax, insurance, shipping and 
      other calculations. If desirable, you could also make the cart persistent by using a 
      combination of cookies on the client and a new 'Cart' table in the database.
	</p>
	
	<br />
	
	<ul>
	 <li><a href="Products.aspx">Click here</a> to start shopping <br /></li>
	 <li><a href="Search.aspx">Click here</a> to search for products <br /></li>
	 <li><a href="Cart.aspx">Click here</a> to view your shopping cart</li>
	</ul>
				
</asp:Content>

