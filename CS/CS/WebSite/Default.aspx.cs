using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxGridView;
using DevExpress.Web.ASPxEditors;
using DevExpress.Data.Filtering;
using System.Windows.Forms;

public partial class _Default : System.Web.UI.Page {
    private string spanOpen = "<span class='highlight'>";
    private string spanClose = "</span>";

    protected void Page_Init(object sender, EventArgs e) {
        gv.DataSource = Enumerable.Range(0, 9).Select(i => new {
            CategoryID = i,
            CategoryName = "CategoryName" + (i + 1),
            Description = "Description" + (i + 2)
        });
        gv.DataBind();
    }

    protected void gv_HtmlDataCellPrepared(object sender, ASPxGridViewTableDataCellEventArgs e) {
        e.Cell.Text = GetCellText(e.CellValue.ToString());
        ASPxGridView gv = sender as ASPxGridView;
    }

    protected string GetCellText(string cell_text) {
        ASPxComboBox cb = gv.FindFilterRowTemplateControl("cb") as ASPxComboBox;
        string serchText = cb.Text;

        if (serchText.Length > cell_text.Length) return cell_text;

        if (!String.IsNullOrEmpty(serchText)) {
            string cell_text_lower = cell_text.ToLower();
            string serchText_lower = serchText.ToLower();
            int start_pos = cell_text_lower.IndexOf(serchText_lower);
            int span_length = spanOpen.Length;
            if (start_pos >= 0) {
                cell_text = cell_text.Insert(start_pos, spanOpen);
                cell_text = cell_text.Insert(start_pos + span_length + serchText_lower.Length, spanClose);
            }
        }

        return cell_text;
    }

    protected void gv_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e) {
        ASPxComboBox cb = gv.FindFilterRowTemplateControl("cb") as ASPxComboBox;
        if (String.IsNullOrEmpty(cb.Text) || e.Parameters.ToLower() != "find") return;
        PopulateComboBoxDataSource(cb);
        SetGridViewFilterExpression(cb);
    }

    private void SetGridViewFilterExpression(ASPxComboBox cb) {
        string expression = String.Empty;
        BinaryOperator b = new BinaryOperator();
        b.OperatorType = BinaryOperatorType.Like;
        GroupOperator op = new GroupOperator() { OperatorType = GroupOperatorType.Or };
        foreach (GridViewDataColumn column in gv.DataColumns) {
            FunctionOperator co = new FunctionOperator(FunctionOperatorType.Contains,
                new OperandProperty(column.FieldName), new OperandValue(cb.Text));
            op.Operands.Add(co);
        }
        gv.FilterExpression = op.ToString();
    }

    private void PopulateComboBoxDataSource(ASPxComboBox cb) {
        List<string> values;
        if (Session["cbDataSource"] == null)
            values = new List<string>(new string[] { cb.Text });
        else
            values = Session["cbDataSource"] as List<string>;

        if (!values.Contains(cb.Text))
            values.Add(cb.Text);

        Session["cbDataSource"] = values;
    }

    protected void cb_Init(object sender, EventArgs e) {
        if (Session["cbDataSource"] != null) {
            ASPxComboBox cb = sender as ASPxComboBox;
            cb.DataSource = Session["cbDataSource"] as List<string>;
            cb.DataBind();
        }
    }
}