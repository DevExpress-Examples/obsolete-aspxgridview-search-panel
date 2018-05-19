<%@ Page Language="vb" AutoEventWireup="true" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
	Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
	Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>How to implement Filter Panel for ASPxGridView control as XtraGrid's Find Panel</title>
	<style type="text/css">
		.highlight {
			background-color: #99FF66;
		}
	</style>
	<script type="text/ecmascript">
		function OnClick(s, e) {
			if (s.GetText() == "Find")
				gv.PerformCallback("Find");
			else {
				cb.SetValue("");
				gv.ClearFilter();
			}
		}
	</script>
</head>
<body>
	<form id="form1" runat="server">
		<dx:ASPxGridView ID="gv" runat="server" AutoGenerateColumns="False" ClientInstanceName="gv"
			KeyFieldName="CategoryID" OnHtmlDataCellPrepared="gv_HtmlDataCellPrepared" OnCustomCallback="gv_CustomCallback">
			<Columns>
				<dx:GridViewCommandColumn>
					<EditButton Visible="true"></EditButton>
				</dx:GridViewCommandColumn>
				<dx:GridViewDataTextColumn FieldName="CategoryID" ReadOnly="True"
					VisibleIndex="1">
					<EditFormSettings Visible="False" />
				</dx:GridViewDataTextColumn>
				<dx:GridViewDataTextColumn FieldName="CategoryName" VisibleIndex="2">
				</dx:GridViewDataTextColumn>
				<dx:GridViewDataTextColumn FieldName="Description" VisibleIndex="3">
				</dx:GridViewDataTextColumn>
			</Columns>
			<Settings ShowFilterRow="true" ShowFilterBar="Visible" />
			<Templates>
				<FilterRow>
					<table>
						<tr>
							<td>
								<dx:ASPxComboBox ID="cb" runat="server" ValueType="System.String" ClientInstanceName="cb"
									DropDownStyle="DropDown" OnInit="cb_Init">
								</dx:ASPxComboBox>
							</td>
							<td>
								<dx:ASPxButton ID="btnFind" runat="server" Text="Find" AutoPostBack="false">
									<ClientSideEvents Click="OnClick" />
								</dx:ASPxButton>
							</td>
							<td>
								<dx:ASPxButton ID="btnClear" runat="server" AutoPostBack="false" Text="Clear">
									<ClientSideEvents Click="OnClick" />
								</dx:ASPxButton>
							</td>
						</tr>
					</table>
				</FilterRow>
			</Templates>
		</dx:ASPxGridView>
	</form>
</body>
</html>