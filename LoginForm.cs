﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace informationApp1._01
{
    public partial class LoginForm : Form
    {
        int UserId;
        string Password;


        public LoginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string input = textBox1.Text;
            string passWord = textBox2.Text;

            if(int.TryParse(input, out UserId))
            {

            }
            else
            {
                MessageBox.Show("4桁の数字を入力してください。");
            }




            if (UserId != null) //仮の仕様後で治す
            {
                MainForm form1 = new MainForm(UserId);
                form1.ShowDialog();

                this.Close();
            }
            
        }

        private void IsAlphaNumeric(string Password)
        {
            string pattern = @"[^\x00-\x7F]";

            if (Regex.IsMatch(Password, pattern))
            {

            }
        }


        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        
        private void IsValidCheck(UserId)
    }
}
