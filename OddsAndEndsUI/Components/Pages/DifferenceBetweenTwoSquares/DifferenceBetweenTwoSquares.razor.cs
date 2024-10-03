namespace OddsAndEndsUI.Components.Pages.DifferenceBetweenTwoSquares;

public partial class DifferenceBetweenTwoSquares
{
    public class DifferenceValues
    {
        public int FirstNumber { get; set; }

        public int SecondNumber { get; set; }

        public int Result { get; set; }
    }

    private readonly DifferenceValues CurrentValues = new();

    protected override void OnInitialized()
    {
        CurrentValues.FirstNumber = 1;
        CurrentValues.SecondNumber = 1;
        CalculateDifference();
    }

    private void CalculateDifference()
    {
        // Cheat and use the greater of the two numbers
        var firstNumber = Math.Max(CurrentValues.FirstNumber, CurrentValues.SecondNumber);
        var secondNumber = Math.Min(CurrentValues.FirstNumber, CurrentValues.SecondNumber);
        CurrentValues.Result = (firstNumber + secondNumber) * (firstNumber - secondNumber);
    }
}
