using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Spire.Doc.Documents;
using Spire.Doc;
using System.IO;

namespace Resume_Filter
{
    public partial class Form1 : Form
    {
        string line;
        string java, Csharp, php;
        string[] store_names;
        string filenames;
        string path;
        OpenFileDialog File_Dia = new OpenFileDialog();
        public string strFilePath;
        string[] year = { "2000", "2001", "2002", "2003", "2004", "2005", "2006", "2007", "2008", "2009", "2010", "2011", "2012", "2013", "2014" };
        int header = 0, pointer = 0;
        Boolean bol = false;
        int yr = 0;
        int exp1, exp2, exp3;

        public Form1()
        {
            InitializeComponent();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            File_Dia.Multiselect = true;
            File_Dia.Filter = "Microsoft Word Document|*.docx";
            if (File_Dia.ShowDialog() == DialogResult.OK)
            {
                // i have use system.io.fileinfo just to get only file path
                FileInfo fInfo = new FileInfo(File_Dia.FileName);
                strFilePath = fInfo.DirectoryName;

                foreach (string myfiles in File_Dia.SafeFileNames)
                {
                    filenames = myfiles;
                    listBox1.Items.Add(filenames);
                    label2.Text = listBox1.Items.Count.ToString();
                    button1.Enabled = false;
                    textBox1.Text = strFilePath;
                    textBox1.Enabled = false;
                    checkBox1.Enabled = true;
                    checkBox2.Enabled = true;
                    checkBox3.Enabled = true;
                }
            }
        }

        private void checkBox1_CheckedChanged_2(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox2.Enabled = true;
                java = "java";
            }
        }

        private void checkBox2_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                textBox3.Enabled = true;
                Csharp = "c#";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            store_names = new string[listBox1.Items.Count];
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                store_names[i] = listBox1.Items[i].ToString();
            }


            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                //Create word document
                Document document = new Document();
                //document.LoadFromFile(@"D:\my CV.docx");
                document.LoadFromFile(@"" + strFilePath + "\\" + store_names[i]);

                //Save doc file.
                document.SaveToFile(store_names[i] + ".txt", FileFormat.Txt);
                //document.SaveToFile("" + store_names[i] + "", FileFormat.Txt);
            }
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                StreamReader file = new StreamReader(@"" + strFilePath + "\\" + store_names[i]);
                if (checkBox1.Checked == true && checkBox2.Checked == false && checkBox3.Checked == false)
                {
                    while ((line = file.ReadLine()) != null)
                    {
                        if (line.Contains(java) && line.Contains(textBox2.Text))
                        {
                            //listBox2.Visible = true;
                            listBox2.Items.Add(store_names[i]);
                            break;
                        }
                        else if (checkBox1.Checked == true && textBox2.Text != null)
                        {
                            while ((line = file.ReadLine()) != null)
                            {
                                line = line.Replace("-", " ");
                                for (int k = 0; k < year.Length - 1; k++)
                                {
                                    if (line.Contains(year[k]) && line.Contains(java) && bol == false)
                                    {
                                        bol = true;
                                        header = k;
                                    }
                                    else if (bol == true)
                                    {
                                        if (line.Contains(year[k + 1]) && line.Contains(java))
                                        {
                                            pointer = k;
                                        }

                                    }
                                }
                                for (int l = header; l < pointer; l++)
                                {
                                    yr++;
                                }
                                if (exp1 < yr)
                                {
                                    listBox2.Items.Add(store_names[i]);
                                }
                                {

                                }
                            }
                        }
                    }
                }
                else if (checkBox2.Checked == true && checkBox1.Checked == false && checkBox3.Checked == false)
                {
                    while ((line = file.ReadLine()) != null)
                    {
                        if (line.Contains(Csharp) && line.Contains(textBox3.Text))
                        {
                            //listBox2.Visible = true;
                            listBox2.Items.Add(store_names[i]);
                            break;
                        }
                        else if (checkBox2.Checked == true && textBox3.Text != null)
                        {
                            while ((line = file.ReadLine()) != null)
                            {
                                line = line.Replace("-", " ");
                                for (int k = 0; k < year.Length - 1; k++)
                                {
                                    if (line.Contains(year[k]) && line.Contains(Csharp) && bol == false)
                                    {
                                        bol = true;
                                        header = k;
                                    }
                                    else if (bol == true)
                                    {
                                        if (line.Contains(year[k + 1]) && line.Contains(Csharp))
                                        {
                                            pointer = k;
                                        }

                                    }
                                }
                                for (int l = header; l < pointer; l++)
                                {
                                    yr++;
                                }
                                if (exp2 < yr)
                                {
                                    listBox2.Items.Add(store_names[i]);
                                }
                                {

                                }
                            }
                        }
                    }
                }
                else if (checkBox3.Checked == true && checkBox1.Checked == false && checkBox2.Checked == false)
                {
                    while ((line = file.ReadLine()) != null)
                    {
                        if (line.Contains(php) && line.Contains(textBox4.Text))
                        {
                            //listBox2.Visible = true;
                            listBox2.Items.Add(store_names[i]);
                            break;
                        }
                        else if (checkBox3.Checked == true && textBox4.Text != null)
                        {
                            while ((line = file.ReadLine()) != null)
                            {
                                line = line.Replace("-", " ");
                                for (int k = 0; k < year.Length - 1; k++)
                                {
                                    if (line.Contains(year[k]) && line.Contains(php) && bol == false)
                                    {
                                        bol = true;
                                        header = k;
                                    }
                                    else if (bol == true)
                                    {
                                        if (line.Contains(year[k + 1]) && line.Contains(php))
                                        {
                                            pointer = k;
                                        }

                                    }
                                }
                                for (int l = header; l < pointer; l++)
                                {
                                    yr++;
                                }
                                if (exp3 < yr)
                                {
                                    listBox2.Items.Add(store_names[i]);
                                }
                                {

                                }
                            }
                        }
                    }
                }
                else if (checkBox1.Checked == true && checkBox2.Checked == true && checkBox3.Checked == false)
                {
                    while ((line = file.ReadLine()) != null)
                    {
                        if (line.Contains(java) && line.Contains(textBox2.Text))
                        {
                            while ((line = file.ReadLine()) != null)
                            {
                                if (line.Contains(Csharp) && line.Contains(textBox3.Text))
                                {
                                    listBox2.Items.Add(store_names[i]);
                                    break;
                                }
                            }
                            break;
                        }
                        else if (checkBox1.Checked == true && textBox2.Text != null && checkBox2.Checked == true && textBox3.Text != null)
                        {
                            while ((line = file.ReadLine()) != null)
                            {
                                line = line.Replace("-", " ");
                                for (int k = 0; k < year.Length - 1; k++)
                                {
                                    if (line.Contains(year[k]) && line.Contains(java) && bol == false)
                                    {
                                        bol = true;
                                        header = k;
                                    }
                                    else if (bol == true)
                                    {
                                        if (line.Contains(year[k + 1]) && line.Contains(java))
                                        {
                                            pointer = k;
                                        }

                                    }
                                }
                                for (int l = header; l < pointer; l++)
                                {
                                    yr++;
                                }
                                if (exp1 < yr)
                                {
                                    //listBox2.Items.Add(store_names[i]);
                                    while ((line = file.ReadLine()) != null)
                                    {
                                        line = line.Replace("-", " ");
                                        for (int k = 0; k < year.Length - 1; k++)
                                        {
                                            if (line.Contains(year[k]) && line.Contains(Csharp) && bol == false)
                                            {
                                                bol = true;
                                                header = k;
                                            }
                                            else if (bol == true)
                                            {
                                                if (line.Contains(year[k + 1]) && line.Contains(Csharp))
                                                {
                                                    pointer = k;
                                                }

                                            }
                                        }
                                        for (int l = header; l < pointer; l++)
                                        {
                                            yr++;
                                        }
                                        if (exp2 < yr)
                                        {
                                            listBox2.Items.Add(store_names[i]);
                                        }
                                        {

                                        }
                                    }
                                }
                                {

                                }
                            }
                        }
                    }

                }
                else if (checkBox1.Checked == true && checkBox3.Checked == true && checkBox2.Checked == false)
                {
                    while ((line = file.ReadLine()) != null)
                    {
                        if (line.Contains(java) && line.Contains(textBox2.Text))
                        {
                            while ((line = file.ReadLine()) != null)
                            {
                                if (line.Contains(php) && line.Contains(textBox4.Text))
                                {
                                    listBox2.Items.Add(store_names[i]);
                                    break;
                                }
                            }
                            break;
                        }
                        else if (checkBox1.Checked == true && textBox2.Text != null && checkBox3.Checked == true && textBox4.Text != null)
                        {
                            while ((line = file.ReadLine()) != null)
                            {
                                line = line.Replace("-", " ");
                                for (int k = 0; k < year.Length - 1; k++)
                                {
                                    if (line.Contains(year[k]) && line.Contains(java) && bol == false)
                                    {
                                        bol = true;
                                        header = k;
                                    }
                                    else if (bol == true)
                                    {
                                        if (line.Contains(year[k + 1]) && line.Contains(java))
                                        {
                                            pointer = k;
                                        }

                                    }
                                }
                                for (int l = header; l < pointer; l++)
                                {
                                    yr++;
                                }
                                if (exp1 < yr)
                                {
                                    //listBox2.Items.Add(store_names[i]);
                                    while ((line = file.ReadLine()) != null)
                                    {
                                        line = line.Replace("-", " ");
                                        for (int k = 0; k < year.Length - 1; k++)
                                        {
                                            if (line.Contains(year[k]) && line.Contains(php) && bol == false)
                                            {
                                                bol = true;
                                                header = k;
                                            }
                                            else if (bol == true)
                                            {
                                                if (line.Contains(year[k + 1]) && line.Contains(php))
                                                {
                                                    pointer = k;
                                                }

                                            }
                                        }
                                        for (int l = header; l < pointer; l++)
                                        {
                                            yr++;
                                        }
                                        if (exp3 < yr)
                                        {
                                            listBox2.Items.Add(store_names[i]);
                                        }
                                        {

                                        }
                                    }
                                }
                                {

                                }
                            }
                        }
                    }
                }
                else if (checkBox2.Checked == true && checkBox3.Checked == true && checkBox1.Checked == false)
                {
                    while ((line = file.ReadLine()) != null)
                    {
                        if (line.Contains(Csharp) && line.Contains(textBox3.Text))
                        {
                            while ((line = file.ReadLine()) != null)
                            {
                                if (line.Contains(php) && line.Contains(textBox4.Text))
                                {
                                    listBox2.Items.Add(store_names[i]);
                                    break;
                                }
                            }
                            break;
                        }
                        else if (checkBox2.Checked == true && textBox3.Text != null && checkBox3.Checked == true && textBox4.Text != null)
                        {
                            while ((line = file.ReadLine()) != null)
                            {
                                line = line.Replace("-", " ");
                                for (int k = 0; k < year.Length - 1; k++)
                                {
                                    if (line.Contains(year[k]) && line.Contains(Csharp) && bol == false)
                                    {
                                        bol = true;
                                        header = k;
                                    }
                                    else if (bol == true)
                                    {
                                        if (line.Contains(year[k + 1]) && line.Contains(Csharp))
                                        {
                                            pointer = k;
                                        }

                                    }
                                }
                                for (int l = header; l < pointer; l++)
                                {
                                    yr++;
                                }
                                if (exp2 < yr)
                                {
                                    //listBox2.Items.Add(store_names[i]);
                                    while ((line = file.ReadLine()) != null)
                                    {
                                        line = line.Replace("-", " ");
                                        for (int k = 0; k < year.Length - 1; k++)
                                        {
                                            if (line.Contains(year[k]) && line.Contains(php) && bol == false)
                                            {
                                                bol = true;
                                                header = k;
                                            }
                                            else if (bol == true)
                                            {
                                                if (line.Contains(year[k + 1]) && line.Contains(php))
                                                {
                                                    pointer = k;
                                                }

                                            }
                                        }
                                        for (int l = header; l < pointer; l++)
                                        {
                                            yr++;
                                        }
                                        if (exp3 < yr)
                                        {
                                            listBox2.Items.Add(store_names[i]);
                                        }
                                        {

                                        }
                                    }
                                }
                                {

                                }
                            }
                        }
                    }
                }

            }
        }

        private void textBox4_TextChanged_1(object sender, EventArgs e)
        {
            exp3 = Convert.ToInt32(textBox4.Text);
            exp3 = int.Parse(textBox4.Text);
            button2.Enabled = true;
        }

        private void textBox3_TextChanged_1(object sender, EventArgs e)
        {
            exp2 = Convert.ToInt32(textBox3.Text);
            exp2 = int.Parse(textBox3.Text);
            button2.Enabled = true;
        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {
            exp1 = Convert.ToInt32(textBox2.Text);
            exp1 = int.Parse(textBox2.Text);

            button2.Enabled = true;
        }

        private void checkBox3_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                textBox4.Enabled = true;
                php = "php";
            }
        }

        private void listBox2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            path = Path.Combine(Directory.GetCurrentDirectory(), listBox2.Text);
            System.Diagnostics.Process.Start(path);
        }

        //private void textBox2_TextChanged(object sender, EventArgs e)
        //{

        //}

        //private void textBox3_TextChanged(object sender, EventArgs e)
        //{

        //}

        //    private void textBox4_TextChanged(object sender, EventArgs e)
        //    {

        //    }
        //}
    }
}
