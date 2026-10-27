using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            RFVprova.SetFocusOnError = true;
            RFVprova.ErrorMessage = "Campo prova obbligatorio";
            RFVprova.EnableClientScript = false; //altrimenti errore perchè si aspetta uno script jQuery lato client
            RFVprova.ForeColor = System.Drawing.Color.Red;
            //RequiredFieldValidator
            RFV.ControlToValidate = "txtRequired";
            RFV.SetFocusOnError = true;
            RFV.ErrorMessage = "Il campo Nome è Obbligatorio";
            RFV.EnableClientScript = false; //altrimenti errore perchè si aspetta uno script jQuery lato client
            RFV.ForeColor = System.Drawing.Color.Red;
            //RangeValidator
            //RV.ControlToValidate = "txtRange";
            RV.MinimumValue = "7";
            RV.MaximumValue = "77";
            RV.SetFocusOnError = true;
            RV.ErrorMessage = "Valori compresi tra 7 e 77";
            RV.Type = ValidationDataType.Integer;
            RV.EnableClientScript = false;
            RV.ForeColor = System.Drawing.Color.Red;
            //RegularExpressionValidator
            REV.ControlToValidate = "txtRegular";
            REV.SetFocusOnError = true;
            REV.ErrorMessage = "Indirizzo mail non valido";
            REV.ValidationExpression = @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"; //uso l'autocomposizione di aspnet
            REV.EnableClientScript = false;
            REV.ForeColor = System.Drawing.Color.Red;
            //CompareValidator
            CV.ControlToValidate = "txtCompare";
            //posso scegliere se compararlo con un altro controllo od una mio valore
            CV.ControlToCompare = "cmbCompare";
            CV.ValueToCompare = "";
            CV.Operator = ValidationCompareOperator.Equal;
            CV.SetFocusOnError = true;
            CV.ErrorMessage = "Valore non valido";
            CV.Type = ValidationDataType.String;
            CV.EnableClientScript = false;
            CV.ForeColor = System.Drawing.Color.Red;    
            //Secondo cmpare validator: compara con una stringa impostata
            CV2.ControlToValidate = "txtCompare";
            //CV2.ControlToCompare = "cmbCompare";
            CV2.ValueToCompare = "ciao";
            CV2.Operator = ValidationCompareOperator.Equal;
            CV2.SetFocusOnError = true;
            CV2.ErrorMessage = "Il valore inserito non è uguale a quello richiesto ('ciao')";
            CV2.Type = ValidationDataType.String;
            CV2.EnableClientScript = false;
            CV2.BackColor = System.Drawing.Color.Red;
            //CustomValidator
            CustV.ControlToValidate = "txtCustom";
            CustV.SetFocusOnError = true;
            CustV.ErrorMessage = "La lunghezza deve essere 8 char";
            CustV.ValidateEmptyText = true; //esegue il controllo anche se campo vuoto
            CustV.EnableClientScript = false;
            CustV.ForeColor = System.Drawing.Color.Red;
            //ValidationSummary
            VS.HeaderText = "Sono un ValidationSummary";
            VS.DisplayMode = ValidationSummaryDisplayMode.BulletList;
            VS.ShowMessageBox = false; //errori tramite msgbox
            VS.ForeColor = System.Drawing.Color.Red;
            //Validator summary 2 con sfondo blu
            ValidationSummary1.HeaderText = "VS 2";
            ValidationSummary1.DisplayMode = ValidationSummaryDisplayMode.BulletList;
            ValidationSummary1.ShowMessageBox = false;
            ValidationSummary1.ForeColor = System.Drawing.Color.White;
            ValidationSummary1.BackColor = System.Drawing.Color.DarkBlue;
        }
    }
    protected void CustV_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (args.Value.Length == 8)
            args.IsValid = true; //ok
        else
            args.IsValid = false;//ko
    }
    protected void btnInvia_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
            Response.Redirect("http://www.vallauri.edu");
    }
    
}