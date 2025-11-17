		SqlConnection sqlConnection;
        SqlCommand mycommand;

        //disconnessa
        SqlDataAdapter dt;
        DataTable t;
        //in alternativa connessa
        SqlDataReader dr;


        public Form1()
        {
            sqlConnection.ConnectionString = "";
            sqlConnection.Open();
            sqlConnection.Close();



            InitializeComponent();
        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            String nomeDB = @"C:\Users\Utente\Documents\scuola\informatica ITI\quinta\scuola.mdf";
            String strConn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename="+ nomeDB +";Integrated Security=True;Connect Timeout=30";
            sqlConnection = new SqlConnection(strConn);
            sqlConnection.Open();

            mycommand = new SqlCommand();
			mycommand.Connection = sqlConnection; 
			
            mycommand.CommandType = CommandType.Text;
            mycommand.CommandText = "INSERT into.....";
            //DDL o DML
            mycommand.ExecuteNonQuery();
            //QL restistuiscono uno scalare
            mycommand.CommandText = "SELECT COUNT(*) FROM alunno where classe='4D'";
            object obj1=mycommand.ExecuteScalar();
            int ns = Convert.ToInt32(obj1);


            // QL
            mycommand.CommandText = "select * from alunno";
            dt = new SqlDataAdapter(mycommand);
			t = new DataTable();
            dt.Fill(t);

            String Cognome=t.Rows[4]["Cognome"].ToString();

            dataGridView1.DataSource = t;
            sqlConnection.Close();
			
			cmbcognome.DataSource=t;
			cmbcognome.ValueMember="matricola";
			cmbcognome.DisplayMember="Cognome";
			
			int matr=cmbcognome.SelectValue;
			
			//connessa
            dr=mycommand.ExecuteReader();
			while(dr.read())
			{
				cognome=dr["Cognome"].ToString();
				lstc.Itemes.Add(cognome);
			}
			
        }
		