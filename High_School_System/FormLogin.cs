using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace High_School_System
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }


        private void FormLogin_Load(object sender, EventArgs e)
        {

        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            if(comboUserType.Text=="")
            {
                MessageBox.Show("Please Select User Type", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboUserType.Focus();
                return;
            }
             if(txtusername.Text=="")
                {
                MessageBox.Show("Please Enter User Name ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtusername.Focus();
                return;
            }
             if(txtpassword.Text=="")
            {
                MessageBox.Show("Please Enter Password", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtpassword.Focus();
                return;

            }
            try
            {
                string con = DBConnection.DB_Connection();
                SqlConnection myConnection = default(SqlConnection);
                myConnection = new SqlConnection(con);
                SqlCommand myCommand = default(SqlCommand);
                myCommand = new SqlCommand("SELECT userLevel,userID,password FROM users WHERE userLevel = @userlevel AND userID = @username AND password = @UserPassword",myConnection);

                SqlParameter uType = new SqlParameter("@userlevel", SqlDbType.NChar);

                SqlParameter uName = new SqlParameter("@username", SqlDbType.NChar);

                SqlParameter uPassword = new SqlParameter("@UserPassword", SqlDbType.NChar);

                uType.Value = comboUserType.Text;
                uName.Value = txtusername.Text;
                uPassword.Value = txtpassword.Text;

                myCommand.Parameters.Add(uType);
                myCommand.Parameters.Add(uName);
                myCommand.Parameters.Add(uPassword);

                myCommand.Connection.Open();

                SqlDataReader myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);

                if (myReader.Read() == true)
                {
                    int i;
                    ProgressBar1.Visible = true;
                    ProgressBar1.Maximum = 5000;
                    ProgressBar1.Minimum = 0;
                    ProgressBar1.Value = 4;
                    ProgressBar1.Step = 1;

                    for (i = 0; i <= 5000; i++)
                    {
                        ProgressBar1.PerformStep();
                    }


                    MessageBox.Show("Login Login successfull", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


                else
                {
                    MessageBox.Show("Login Failed...Try again !", "Login Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    txtusername.Clear();
                    txtpassword.Clear();
                    txtusername.Focus();

                }
                if (myConnection.State == ConnectionState.Open)
                {
                    myConnection.Dispose();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
