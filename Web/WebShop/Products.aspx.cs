using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using DoFactory.BusinessLayer.Facade;

public partial class WebShop_Products : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Set the selected menu item to Master page.
            Master.TheMenuInMasterPage.SelectedItem = "products";

            // Default sort order
            SortColumn = "ProductId";
            SortDirection = "ASC";

            Bind();
        }
    }

    /// <summary>
    /// Sets datasources and bind data to controls.
    /// </summary>
    private void Bind()
    {
        // Validate selected CategoryId
        int categoryId;
        if (!int.TryParse(DropDownListCategories.SelectedValue, out categoryId))
            categoryId = 1;

        // Gets list of products via Product Facade.
        ProductFacade facade = new ProductFacade();

        GridViewProducts.DataSource = facade.GetProductsByCategory(categoryId, SortExpression);
        GridViewProducts.DataBind();
    }

    /// <summary>
    /// Sets sort order and re-binds page.
    /// </summary>
    protected void GridViewProducts_Sorting(object sender, GridViewSortEventArgs e)
    {
        SortDirection = (SortDirection == "ASC") ? "DESC" : "ASC";
        SortColumn = e.SortExpression;

        Bind();
    }

    /// <summary>
    /// Adds glyph to header according to current sort settings.
    /// </summary>
    protected void GridViewProducts_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            AddGlyph(this.GridViewProducts, e.Row);
        }
    }

    /// <summary>
    /// Rebinds page following category change.
    /// </summary>
    protected void DropDownListCategories_SelectedIndexChanged(object sender, EventArgs e)
    {
        Bind();
    }
}
