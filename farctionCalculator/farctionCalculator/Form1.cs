using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace farctionCalculator
{
    public partial class Form1 : Form
    {
        public double firstNumeratorValue, secondNumeratorValue, resultNumeratorValue  = 0;
        public double firstDenominatorValue, secondDenominatorValue, resultDenominatorValue, middleResultDenominator  = 1;
        bool firstNumberIsDone = false;
        string operationSign = "";

        static double GCD(double a, double b)
        {
            double Remainder;

            while (b != 0)
            {
                Remainder = a % b;
                a = b;
                b = Remainder;
            }

            return a;
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            textBox1.Text += b.Text;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            //equal/result btn
            
            if (firstNumberIsDone)
            {
                secondDenominatorValue = Double.Parse(textBox1.Text);
                switch (operationSign)
                {
                    case "+":
                        middleResultDenominator = firstDenominatorValue * secondDenominatorValue;
                        resultNumeratorValue = (secondDenominatorValue * firstNumeratorValue) +
                            (firstDenominatorValue * secondNumeratorValue);
                        resultDenominatorValue = middleResultDenominator;
                        break;
                    case "-":
                        middleResultDenominator = firstDenominatorValue * secondDenominatorValue;
                        resultNumeratorValue = (secondDenominatorValue * firstNumeratorValue) -
                            (firstDenominatorValue * secondNumeratorValue);
                        resultDenominatorValue = middleResultDenominator;
                        break;
                    case "*":
                        resultNumeratorValue = firstNumeratorValue * secondNumeratorValue;
                        resultDenominatorValue = firstDenominatorValue * secondDenominatorValue;
                        break;
                    case "/":
                        resultNumeratorValue = firstNumeratorValue / secondNumeratorValue;
                        resultDenominatorValue = firstDenominatorValue / secondDenominatorValue;
                        break;
                    case "Pow":
                        resultNumeratorValue = Math.Pow(firstNumeratorValue, secondNumeratorValue);
                        resultDenominatorValue = Math.Pow(firstDenominatorValue, secondDenominatorValue);
                        break;
                }
            }

            textBox1.Text = "(" + (resultNumeratorValue/GCD(resultNumeratorValue,resultDenominatorValue)).ToString() 
                + "/" + (resultDenominatorValue/GCD(resultNumeratorValue, resultDenominatorValue)).ToString() + ")";
            firstNumeratorValue = resultNumeratorValue;
            firstDenominatorValue = resultDenominatorValue;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            //clear btn 
            firstNumeratorValue = 0;
            secondNumeratorValue = 0;
            firstDenominatorValue = 1;
            secondDenominatorValue = 1;
            firstNumberIsDone = false;
            textBox1.Text = "";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Button o = (Button)sender;
            //any operator btn
            if (firstNumberIsDone == false)
                firstDenominatorValue = Double.Parse(textBox1.Text);
            else 
                secondDenominatorValue = Double.Parse(textBox1.Text);
            operationSign = o.Text;
            //Radikal
            if (operationSign == "Rad")
            {
                resultNumeratorValue = Math.Pow(firstNumeratorValue, 0.5);
                resultDenominatorValue = Math.Pow(firstDenominatorValue, 0.5);
                textBox1.Text = "(" + (resultNumeratorValue / GCD(resultNumeratorValue, resultDenominatorValue)).ToString()
                + "/" + (resultDenominatorValue / GCD(resultNumeratorValue, resultDenominatorValue)).ToString() + ")";
                firstNumeratorValue = resultNumeratorValue;
                firstDenominatorValue = resultDenominatorValue;
            }
            else
            {
                textBox1.Text = "";
            }
            firstNumberIsDone = true;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            //CE btn
            textBox1.Text = "";
        }

        private void button19_Click(object sender, EventArgs e)
        {
            //Fr btn
            if (firstNumberIsDone == true)
                secondNumeratorValue = Double.Parse(textBox1.Text);
            if (firstNumberIsDone == false)
                firstNumeratorValue = Double.Parse(textBox1.Text);
            textBox1.Text = "";
            
        }
    }
}
