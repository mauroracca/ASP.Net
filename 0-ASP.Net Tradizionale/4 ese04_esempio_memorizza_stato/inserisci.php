<HTML>
	<head>
	</head>
<BODY>

<FORM NAME='frmInvia' METHOD='post' ACTION='inserisci.php'>
   	<TABLE border='0'>
   	  <tr>
    		<th/>
    		<th width='600px'/>
  		</tr>
   		<TR>
   			<TD style="font-weight:bold;" >Nome:</TD>
   			<TD><INPUT TYPE='text' NAME='txtNome' VALUE='' required="required"></TD></TR>
   		<TR>   			
   			<TD style="font-weight:bold;" >Cognome:</TD>
   			<TD><INPUT TYPE='text' NAME='txtCognome' VALUE='' required="required"></TD></TR>   			
   		<TR>
			<TD>Provincia:</TD>
			<TD><select name="CmbProvincia"> 
			  <option value="vuoto" selected="selected">---Selezionare----</option> 
			  
			  <option value="TO">Torino</option> 
			  <option value="CN">Cuneo</option> 
			  <option value="AT">Asti</option> 
			  <option value="AL">Alessandria</option>
			  <option value="VR">Verbania</option> 
			  <option value="BI">Biella</option> 			  
			</select></TD> 
		<TR>
   			<TD><INPUT TYPE='submit' NAME='sbmIns' VALUE='Inserisci'></TD>
   			<TD><INPUT TYPE='reset' NAME='sbmClear' VALUE='Annulla'></TD>
   		</TR>
   </TABLE>   
</FORM>

<?php
if(isset($_POST["sbmIns"])) // || isset($_POST["C1"]))
{
	$nome=$_POST['txtNome'];
	$cognome=$_POST['txtCognome'];	
	$provincia=$_POST['CmbProvincia'];
	echo"<h3>nome: ".$nome." cognome: ".$cognome." provincia: ".$provincia."</h3>";
}
?>

</BODY>
</HTML>
