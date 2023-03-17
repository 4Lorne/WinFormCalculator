using System.Diagnostics;

namespace Calculator
{
    public partial class Form1 : Form
    {
        private string currentInput; //The numbers being sent to the text box
        private string singleLetter; //One letter at a time, used for checking for operations
        private string history; //For debugging purposes, shows the history on the bottom for me to visually see whats happening
        private double leftSide = 0;
        private double rightSide = 0;
        private bool hasFired = false; //Made true if any operation that makes leftSide equal something
        private string latestOperation; //Assigned the char for the most recent operation

        public Form1()
        {
            InitializeComponent();
        }

        private void button_click(object sender, EventArgs e)
        {

            
            //Assigns the value of the button clicked to the String currentCalc
            currentInput += ((Button)sender).Text;
            history += ((Button)sender).Text;
            singleLetter = ((Button)sender).Text;

            Debug.WriteLine("Button clicked");
            //Checks for multiple decimals, removes any decimals beyond one
            if (textBox.Text.Contains(".") && singleLetter.Contains("."))
            {
                currentInput =currentInput.Substring(0, currentInput.Length - 1);
                return;
            }
            //Appends the currentCalc string to the textBox string
            textBox.Text = currentInput;

            operationHistory.Text = history;

        }

        //Handles the delete function
        private void delete(object sender, EventArgs e)
        {
            if (textBox.TextLength > 1)
            {
                textBox.Text = textBox.Text.Substring(0, textBox.Text.Length - 1);
                currentInput = currentInput.Substring(0, currentInput.Length - 1);
            } else
            {
                textBox.Text = "0";
                currentInput = "";
            }
        }

        //Resets the entire calculator
        private void clear(object sender, EventArgs e)
        {
            textBox.Text = "0";
            currentInput = "";
            history = "";
            hasFired = false;
            leftSide= 0;
            rightSide= 0;
        }

        //Clears just the recent text box
        private void clearTextBox(object sender, EventArgs e)
        {
            textBox.Text = "0";
            currentInput = "";
        }

        //Parses text to double, multiplies by -1 and returns back to string
        private void negative(object sender, EventArgs e)
        {
            double num = double.Parse(currentInput);
            num = num * -1;
            currentInput = num.ToString();
            textBox.Text = currentInput;
        }

       
       
        //TODO: Refactor later
        private void operation(object sender, EventArgs e)
        {
            singleLetter = ((Button)sender).Text;
            Debug.WriteLine(singleLetter);
            if (hasFired)
            {
                switch (singleLetter)
                {
                    case "X":
                        rightSide = double.Parse(textBox.Text);
                        leftSide = leftSide * rightSide;
                        textBox.Text = leftSide.ToString();
                
                        Debug.WriteLine("Multiply fired");
                        break;
                    case "/":
                        rightSide = double.Parse(textBox.Text);
                        leftSide = leftSide / rightSide;
                        textBox.Text = leftSide.ToString();
                        currentInput = "";
                        Debug.WriteLine("Divide fired");
                        break;
                    case "-":
                        rightSide = double.Parse(textBox.Text);
                        leftSide = leftSide - rightSide;
                        textBox.Text = leftSide.ToString();
                        currentInput = "";
                        Debug.WriteLine("Subtract fired");
                        break;
                    case "+":
                        rightSide = double.Parse(textBox.Text);
                        leftSide = leftSide + rightSide;
                        textBox.Text = leftSide.ToString();
                        currentInput = "";
                        Debug.WriteLine("Addition fired");
                        break;
                    case "=":
                        equal(latestOperation);
                        Debug.WriteLine("Equals fired");
                        break;
                }
            }
            else if (!hasFired)
            {
                switch (singleLetter)
                {
                    case "X":
                        leftSide = double.Parse(textBox.Text);
                        textBox.Text = "0";
                        currentInput = "";
                        latestOperation = "X";
                        Debug.WriteLine("Multiply fired");
                        break;
                    case "/":
                        leftSide = double.Parse(textBox.Text);
                        textBox.Text = "0";
                        currentInput = "";
                        latestOperation = "/";
                        Debug.WriteLine("Divide fired");
                        break;
                    case "-":
                        leftSide = double.Parse(textBox.Text);
                        textBox.Text = "0";
                        currentInput = "";
                        latestOperation = "-";
                        Debug.WriteLine("Subtract fired");
                        break;
                    case "+":
                        leftSide = double.Parse(textBox.Text);
                        textBox.Text = "0";
                        currentInput = "";
                        latestOperation = "+";
                        Debug.WriteLine("Addition fired");
                        break;
                    case "=":
                        leftSide = double.Parse(textBox.Text);
                        textBox.Text = "0";
                        currentInput = "";
                        Debug.WriteLine("Equals fired");
                        break;
                }
                hasFired= true;
            }
        }

        private void equal(String latestOperation)
        {
            switch (latestOperation)
            {
                case "X":
                    rightSide = double.Parse(textBox.Text);
                    leftSide = leftSide * rightSide;
                    textBox.Text = leftSide.ToString();
                    currentInput = leftSide.ToString();
                    break;
                case "/":
                    rightSide = double.Parse(textBox.Text);
                    leftSide = leftSide / rightSide;
                    textBox.Text = leftSide.ToString();
                    currentInput = leftSide.ToString();
                    Debug.WriteLine("Divide fired");
                    break;
                case "-":
                    rightSide = double.Parse(textBox.Text);
                    leftSide = leftSide - rightSide;
                    textBox.Text = leftSide.ToString();
                    currentInput = leftSide.ToString();
                    Debug.WriteLine("Subtract fired");
                    break;
                case "+":
                    rightSide = double.Parse(textBox.Text);
                    leftSide = leftSide + rightSide;
                    textBox.Text = leftSide.ToString();
                    currentInput = leftSide.ToString();
                    Debug.WriteLine("Addition fired");
                    break;
            }
 
        }
    }
}