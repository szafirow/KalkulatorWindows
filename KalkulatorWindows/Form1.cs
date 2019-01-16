using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KalkulatorWindows
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent(); 
        }
        
        Double value = 0;
        String operation = "";
        bool operation_pressed = false;


        private void button_Click(object sender, EventArgs e)
        {
            if((result.Text == "0") || operation_pressed)
            {
                result.Clear();
            }

            operation_pressed = false;
            Button b = (Button)sender;
            if(b.Text == ",")
            {
                if (!result.Text.Contains(","))
                {

                    if (result.Text != null && !string.IsNullOrWhiteSpace(result.Text))
                    {
                         result.Text = result.Text + b.Text;
                    }
                    else
                    {
                       result.Text = result.Text + "0" + b.Text;
                    }
                }
            }
            else
            {
                 result.Text = result.Text + b.Text;
            }

        }

        private void btnCE_Click(object sender, EventArgs e)
        {
            result.Text = "0";
        }

        private void operator_click(object sender, EventArgs e)
        {
            Button b = (Button)sender;

            if (value != 0)
            {
                if(b.Text == "sqrt")
                {
                    //result.Text = Math.Sqrt(Double.Parse(result.Text)).ToString();
                    result.Text = Operators.sqrt(Double.Parse(result.Text)).ToString();
                }

                btnWynik.PerformClick();
                operation_pressed = true;
                operation = b.Text;
                equation.Text = value + " " + operation;
            }
            else if (b.Text == "sqrt")
            {
                //result.Text = Math.Sqrt(Double.Parse(result.Text)).ToString();
                result.Text = Operators.sqrt(Double.Parse(result.Text)).ToString();

                value = Math.Sqrt(Double.Parse(result.Text));
            }
            else
            {
                operation = b.Text;
                value = Double.Parse(result.Text);
                operation_pressed = true;
                equation.Text = value + " " + operation;
            }
          
        }

        private void btnWynik_Click(object sender, EventArgs e)
        {
            equation.Text = "";
            switch (operation)
            {
                case "+":
                    //result.Text = (value + Double.Parse(result.Text)).ToString();
                    result.Text = Operators.Add(value, Double.Parse(result.Text)).ToString();
                    break;
                case "-":
                    //result.Text = (value - Double.Parse(result.Text)).ToString();
                    result.Text = Operators.Sub(value, Double.Parse(result.Text)).ToString();
                    break;
                case "*":
                    //result.Text = (value * Double.Parse(result.Text)).ToString();
                    result.Text = Operators.Mult(value, Double.Parse(result.Text)).ToString();
                    break;
                case "/":
                    //result.Text = (value / Double.Parse(result.Text)).ToString();
                    result.Text = Operators.Div(value, Double.Parse(result.Text)).ToString();
                    break;
            }
            value = Double.Parse(result.Text);
            operation = "";
            operation_pressed = true;
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            result.Clear();
            value = 0;
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            btnWynik.Focus();
            switch (e.KeyChar.ToString())
            {
                case "0":
                    btn0.PerformClick();
                    break;
                case "1":
                    btn1.PerformClick();
                    break;
                case "2":
                    btn2.PerformClick();
                    break;
                case "3":
                    btn3.PerformClick();
                    break;
                case "4":
                    btn4.PerformClick();
                    break;
                case "5":
                    btn5.PerformClick();
                    break;
                case "6":
                    btn6.PerformClick();
                    break;
                case "7":
                    btn7.PerformClick();
                    break;
                case "8":
                    btn8.PerformClick();
                    break;
                case "+":
                    btnPlus.PerformClick();
                    break;
                case "-":
                    btnMinus.PerformClick();
                    break;
                case "/":
                    btnPodziel.PerformClick();
                    break;
                case "*":
                    btnRazy.PerformClick();
                    break;
                case "=":
                    btnWynik.PerformClick();
                    break;
                case "ENTER":
                    btnWynik.PerformClick();
                    break;
                default:
                    break;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
