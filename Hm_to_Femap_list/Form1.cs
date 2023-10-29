using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hm_to_Femap_list
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            // Half width
            float half_width = (this.Width * 0.5f) - 5;

            // Adjust the location of text box
            textBox_hm.Location = new Point(12, 45);
            textBox_hm.Size = new Size((int)half_width - 25, textBox_hm.Height);

            label2.Location = new Point((int)half_width, 9);

            // Adjust location of text box femap
            textBox_femap.Location = new Point((int)half_width, 45);
            textBox_femap.Size = new Size((int)half_width - 25, textBox_femap.Height);

            // Location of button
            button_convert.Location = new Point((int)half_width - 40, this.Height - 75);

        }

        private void button_convert_Click(object sender, EventArgs e)
        {
            if(textBox_hm.Text == "")
            {
                // Empty input
                return;
            }

            // Convert the HM Text to Femap text
            string input_hm_str = textBox_hm.Text;

            // Split the input string
            string[] inpt_ranges = input_hm_str.Split(' ');

            // Output string
            string output_femap_str = "";

            // Loop through all the range
            foreach (var range in inpt_ranges)
            {

                if (range.Contains('-')) // 692-697
                {
                    string[] parts = range.Split('-'); // split the two part 692, 697
                    int start = int.Parse(parts[0]); // 692
                    int end = int.Parse(parts[1]); // 697

                    for (int i = start; i <= end; i++)
                    {
                        output_femap_str = output_femap_str + i.ToString() + Environment.NewLine;
                    }
                }
                else
                {
                    // 805 878 etc
                    int number = int.Parse(range);
                    output_femap_str = output_femap_str + number.ToString() + Environment.NewLine;
                }
            }

            // Print to the text box
            textBox_femap.Text = output_femap_str;  

        }
    }
}
