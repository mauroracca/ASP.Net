using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ctrlValidator
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                // Required field Validator
                RFV.ControlToValidate = "txtUsername";
                RFV.SetFocusOnError=true;
                RFV.ErrorMessage = "Il campo username è obbligatorio";
                RFV.EnableClientScript = false;
                RFV.ForeColor=System.Drawing.Color.Red;

                // Range Validator
                RV.ControlToValidate = "txtRange";
                RV.MinimumValue = "13";
                RV.MaximumValue = "50";
                RV.SetFocusOnError = true;
                RV.ErrorMessage = "L'età deve essere compresa tra 13 e 50";
                RV.EnableClientScript = false;
                RV.ForeColor = System.Drawing.Color.Red;
                RV.Type = ValidationDataType.Integer;

                // Regular Expression Validator
                REV.ControlToValidate = "txtMail";
                REV.SetFocusOnError = true;
                REV.ErrorMessage = "Il campo mail non è corretto";
                REV.EnableClientScript = false;
                REV.ForeColor = System.Drawing.Color.Red;
                REV.ValidationExpression = @"(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|""(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*"")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9]))\.){3}(?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9])|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])";

            }
        }

        protected void btnInvia_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
                Response.Redirect("pagRegistrazione.aspx");
        }
    }
}