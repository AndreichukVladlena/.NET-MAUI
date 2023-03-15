namespace Andreichuk_153505_lab1;

public partial class MainPage : ContentPage
{
    int currentState = 1;
    string currentEntry;
    string mathOperation;
    double firstNumber, secondNumber;

    public MainPage()
    {
        InitializeComponent();
        OnClear(this, null);
    }

    void OnClear(object sender, EventArgs e)
    {
        firstNumber = 0;
        secondNumber = 0;
        currentState = 1;
        currentEntry = string.Empty;
        this.Result.Text = "0";
    }

    void OnABS(object sender, EventArgs e)
    {
        if (currentState == 1 && firstNumber < 0)
        {
            secondNumber = -1;
            mathOperation = "x";
            currentState = 2;
            OnResult(this, null);
        }
    }

    void OnSelectNumber(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        string pressedBtn = button.Text;


        if (this.Result.Text == "0")
        {
            this.Result.Text = string.Empty;
            currentEntry += pressedBtn;
            this.Result.Text = currentEntry;
            NumberValue(this.Result.Text);
        }
        else if (this.Result.Text.Contains(",") && pressedBtn == ",")
        {
            return;
        }
        else{
            currentEntry += pressedBtn;
            this.Result.Text = currentEntry;
            NumberValue(this.Result.Text);
        }
    }

    void OnSelectOperation(object sender, EventArgs e)
    {
        if (currentState == 1)
        {
            currentState = 2;
            Button button = (Button)sender;
            string pressedBtn = button.Text;
            mathOperation = pressedBtn;
        }
        else if (currentState == 2)
        {
            OnResult(this, null);
        }
        currentEntry = string.Empty;
    }

    private void NumberValue(string text)
    {
        double number;
        if (double.TryParse(text, out number))
        {
            if (currentState == 1)
            {
                firstNumber = number;
            }
            else
            {
                secondNumber = number;
            }

        }
    }
    void OnResult(object sender, EventArgs e)
    {
        if (currentState == 2)
        {
            double result = Calculate.Calculation(firstNumber, secondNumber, mathOperation);
            this.Result.Text = result.ToString();
            currentState = 1;
            firstNumber = result;
            secondNumber = 0;
            currentEntry = string.Empty;
        }
    }
    void OnChangeSign(object sender, EventArgs e)
    {
        NumberValue(this.Result.Text);
        firstNumber *= -1;
        this.Result.Text = firstNumber.ToString();
    }
}

