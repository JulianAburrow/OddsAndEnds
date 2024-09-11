namespace OddsAndEndsUI.Components.Pages.FibonacciSequence;

public partial class FibonacciSequence
{
    private string Output { get; set; } = string.Empty!;

    protected override void OnInitialized()
    {
        var firstValue = 0;
        var secondValue = 1;
        var result = 0;

        Output = $"{firstValue}\n";
        Output += $"{secondValue}\n";

        while(secondValue <= 100000)
        {
            result = firstValue + secondValue;
            Output += $"{result}\n";
            firstValue = secondValue;
            secondValue = result;
        }
    }
}
