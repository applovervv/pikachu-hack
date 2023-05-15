using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Memory;

namespace hacktest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }


        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
             Mem memory = new Mem();
            int PID = memory.GetProcIdFromName("pika.exe"); //프로세스 아이디

            if (PID > 0)
            {
                memory.OpenProcess(PID); 

                if (checkBox2.Checked) 
                {
                    memory.WriteMemory("pika.exe+3C27", "bytes", "0xEB 0x76");
                }
                else
                {
                    memory.WriteMemory("pika.exe+3C27", "bytes", "0x75 0x76");
                }
            }
            else
            {
                MessageBox.Show("Run the pika.exe");
            }
        }

   

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            Mem memory = new Mem();
            int PID = memory.GetProcIdFromName("pika.exe"); //프로세스 아이디

            if (PID > 0)
            {
                memory.OpenProcess(PID);

                if (checkBox4.Checked)
                {
                    comboBox1.Enabled = true;
                    memory.WriteMemory("pika.exe+3C58", "bytes", "0x90 0x90 0x90");
                    memory.WriteMemory("pika.exe+3C5B", "bytes", "0xEB 0x10");  
                }
                else
                {
                    comboBox1.Enabled = false;
                    memory.WriteMemory("pika.exe+3C58", "bytes", "0x39 0x46 0x40");
                    memory.WriteMemory("pika.exe+3C5B", "bytes", "0x7D 0x10");

                    memory.WriteMemory("pika.exe+3C7D", "bytes", "0x7C 0x0D"); //P2 trigger off (Default)
                }
            }
            else
            {
                MessageBox.Show("Run the pika.exe");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            Mem memory = new Mem();
            int PID = memory.GetProcIdFromName("pika.exe"); //프로세스 아이디

            if (PID > 0)
            {
                memory.OpenProcess(PID);

                if (comboBox1.SelectedIndex == 0) //Player 1
                {
                    memory.WriteMemory("pika.exe+3C7D", "bytes", "0xEB 0x00");//P1 trigger on
                }

                if (comboBox1.SelectedIndex == 1) //Player 2
                {
                    memory.WriteMemory("pika.exe+3C7D", "bytes", "0xEB 0x0D");//P2 trigger on
                }
            }
            else
            {
                MessageBox.Show("Run the pika.exe");
            }
        }
    }
}
