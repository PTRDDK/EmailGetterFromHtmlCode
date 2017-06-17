using EmailGetterFromWebPage.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmailGetterFromWebPage
{
    public partial class Form1 : Form
    {
        WebCodeGetter webCodeGetter = new WebCodeGetter();
        FindEmail findEmail = new FindEmail();

        string resultGet;
        string emails;
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string url = textBox1.Text;
            await GetSourceCode(url);
            await FindEmails(resultGet);
            await Progress();
            if(emails.Equals(""))
            {
                label2.Text = "NO EMAIL ADRESSESS ON THIS PAGE!";
            }
            else
            {
                textBox2.Text = emails;
            }
        }

        async Task Progress()
        {
            var progress = new Progress<int>(value => progressBar1.Value = value);
            await Task.Run(() =>
            {
                for (int i = 0; i <= 100; i++)
                {
                    ((IProgress<int>)progress).Report(i);
                }
            });
        }

        async Task GetSourceCode(string url)
        {
            await Task.Run(() =>
            {
                resultGet = webCodeGetter.getHTMLCode(url);
            }
            );
        }

        async Task FindEmails(string input)
        {
            await Task.Run(() =>
            {
                emails = findEmail.FindEmailByRegex(input);
            }
            );
        }
    }
}
