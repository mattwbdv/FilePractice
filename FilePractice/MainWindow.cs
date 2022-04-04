using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FilePractice
{

    public partial class MainWindow : Form
    {
        String fileContent = string.Empty;
        String filePath = string.Empty;
        List<string> list = new List<string>();

        public MainWindow()

        {
            InitializeComponent();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            //Get the path of specified file
            filePath = openFileDialog1.FileName;

            //Read the contents of the file into a stream
            var fileStream = openFileDialog1.OpenFile();

            using (System.IO.StreamReader reader = new System.IO.StreamReader(fileStream))
            {
                while (reader.Peek() >= 0)
                {
                    String newString = reader.ReadLine();
                    list.Add(newString);
                    
                }
                foreach (var word in list)
                {
                    Console.WriteLine(word.ToString());
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();

        }

        private void findStrings()
        {
            ListBox mylist = new ListBox();
            String[] str = list.ToArray();
            int position = 1;

                foreach (var stringToCheck in str)
                {
                    if (stringToCheck.Contains(textBox1.Text))
                    {
                        mylist.Items.Add(position);
                    }
                    position++;
                    }
                Results.Controls.Add(mylist);

            }

        private void button2_Click(object sender, EventArgs e)
        {
            Results.Controls.Clear();
            findStrings();
        }
    }
}
