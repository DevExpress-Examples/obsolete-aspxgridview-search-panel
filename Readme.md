<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/134059823/13.1.8%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E4991)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [Default.aspx](./CS/WebSite/Default.aspx) (VB: [Default.aspx](./VB/WebSite/Default.aspx))
* [Default.aspx.cs](./CS/WebSite/Default.aspx.cs) (VB: [Default.aspx.vb](./VB/WebSite/Default.aspx.vb))
<!-- default file list end -->
# OBSOLETE - How to implement Filter Panel for ASPxGridView control as XtraGrid's Find Panel
<!-- run online -->
**[[Run Online]](https://codecentral.devexpress.com/e4991)**
<!-- run online end -->


<p><strong>UPDATED:<br /></strong><br />Starting with version 14.2, GridView provides the built-in Search / Find Panel functionality with the capability to locate it outside grid boundaries. This allows accomplishing a similar task with less effort and does not require so much extra code. See the <a href="https://community.devexpress.com/blogs/aspnet/archive/2014/11/19/asp-net-data-grid-enhancements-coming-soon-in-v14-2.aspx">ASP.NET Data Grid: Enhancements</a> post to learn more about this new functionality.<br /><br />It's possible to implement a Filter Panel for the ASPxGridView control in the same manner as the XtraGrid's Find Panel is implemented. The main idea is to create a template, and build and apply the <a href="http://documentation.devexpress.com/#AspNet/DevExpressWebASPxGridViewASPxGridView_FilterExpressiontopic">ASPxGridView.FilterExpression</a> expression in the <a href="http://documentation.devexpress.com/#AspNet/DevExpressWebASPxGridViewASPxGridView_CustomCallbacktopic">ASPxGridView.CustomCallback</a> event handler.</p>

<br/>


