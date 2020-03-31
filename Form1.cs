using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Numerics;
namespace Phone_number_maker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox3.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog s = new SaveFileDialog();
            s.Title = "Save Numbers";
            s.Filter = "TXT File|*.txt";
            s.ShowDialog();
            button1.Hide();
            textBox3.Show();
            textBox3.Text = s.FileName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox3.Text == "")
            {
                MessageBox.Show("Specify the SaveFile location");
            }
            else
            {
                FileStream f = File.Create(textBox3.Text);
                f.Close();
            }
            if(textBox1.Text == "")
            {
                MessageBox.Show("Fill(Start)");
            }
            else if(textBox2.Text == "")
            {
                MessageBox.Show("Fill(Finish)");
            }
            else
            {
                    BigInteger Start = BigInteger.Parse(textBox1.Text);
                    BigInteger finish = BigInteger.Parse(textBox2.Text); ;
                    BigInteger av = finish - Start;
                    string a = av.ToString();
                    int number = Convert.ToInt32(a);
                    string[] s = new string[number + 3];
                    progressBar1.Maximum = s.Length - 4;
                    for (int i = 0; i <= s.Length - 4; i++)
                    {
                        Start = Start + 1;
                        s[i] = Start.ToString();
                        progressBar1.Value = i;
                    }
                    File.WriteAllLines(textBox3.Text, s);
                    MessageBox.Show("finish");
                    button2.Text = "Save";
            }
        }
    }
}
