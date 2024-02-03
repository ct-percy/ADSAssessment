using System.Linq;
using System.Net.WebSockets;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;

namespace Assessment
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }


        public string sum(List<string> list)
        {
            List<BigInteger> bigIntList = new List<BigInteger>();

            //Turns string into Big Integers
            for (int i = 0; i < list.Count; i++)
            {
                bigIntList.Add(BigInteger.Parse(list.ElementAt(i)));
                
            }

            //Adds elements together and casts as string
            string total = bigIntList.Aggregate(BigInteger.Add).ToString();


            //RETURN ONLY LAST 10 DIGITS OR LESS
            return total.Substring(Math.Max(0, total.Length - 10));

        }



        private void button1_Click(object sender, EventArgs e)
        {

            OpenFileDialog file = new OpenFileDialog();

            if (file.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var fileStream = file.OpenFile();

                    using (StreamReader streamReader = new StreamReader(fileStream))
                    {
                        string fileContent = streamReader.ReadToEnd();

                        //CHANGE DELIMITER HERE
                        char[] delimiter = [',', '\''];

                        string[] content = fileContent.Trim().Split(delimiter);

                        var list = new List<String>(content);

                        //THIS FOR LOOP REMOVES EMPTY OR WHITESPACE ELEMENTS'
                        for (int i = 0; i < list.Count; i++)
                        {
                            if (string.IsNullOrWhiteSpace(list.ElementAt(i)) || string.IsNullOrEmpty(list.ElementAt(i)))
                            {
                                list.Remove(list.ElementAt(i));
                            }

                            
                        }

                        //Pass the list into the function, returns string
                        string total = sum(list);

                        textBox1.Text = total;

                        
                    }

                }

                //Exception controls for common errors
                catch
                {
                    MessageBox.Show("Error" + "\n" + "Ensure File type is .CSV" + "\n" + "Ensure data is only numerical values" + "\n" + "Ensure delimiter type = '");
                    return;

                }
            }

        }






        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

