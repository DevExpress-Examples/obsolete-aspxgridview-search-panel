<!-- default file list -->
*Files to look at*:

* [Default.aspx](./CS/WebSite/Default.aspx) (VB: [Default.aspx](./VB/WebSite/Default.aspx))
* [Default.aspx.cs](./CS/WebSite/Default.aspx.cs) (VB: [Default.aspx.vb](./VB/WebSite/Default.aspx.vb))
<!-- default file list end -->
# OBSOLETE - How to implement Filter Panel for ASPxGridView control as XtraGrid's Find Panel


<p><strong>UPDATED:<br /></strong><br />Starting with version 14.2, GridView provides the built-in Search / Find Panel functionality with the capability to locate it outside grid boundaries. This allows accomplishing a similar task with less effort and does not require so much extra code. See the <a href="https://community.devexpress.com/blogs/aspnet/archive/2014/11/19/asp-net-data-grid-enhancements-coming-soon-in-v14-2.aspx">ASP.NET Data Grid: Enhancements</a> post to learn more about this new functionality.<br /><br />It's possible to implement a Filter Panel for the ASPxGridView control in the same manner as the XtraGrid's Find Panel is implemented. The main idea is to create a template, and build and apply the <a href="http://documentation.devexpress.com/#AspNet/DevExpressWebASPxGridViewASPxGridView_FilterExpressiontopic">ASPxGridView.FilterExpression</a> expression in the <a href="http://documentation.devexpress.com/#AspNet/DevExpressWebASPxGridViewASPxGridView_CustomCallbacktopic">ASPxGridView.CustomCallback</a> event handler.</p>

<br/>


