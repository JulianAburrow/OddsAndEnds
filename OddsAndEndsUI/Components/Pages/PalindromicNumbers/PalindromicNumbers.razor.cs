namespace OddsAndEndsUI.Components.Pages.PalindromicNumbers;

public partial class PalindromicNumbers
{
    protected string Output = string.Empty;

    protected override void OnInitialized()
    {
        var previousNumber = 0;
        for (var i = 10; i <= 10000; i++)
        {
            var numberAsString = i.ToString();
            var reversedNumberString = ReverseString(numberAsString);
            if (numberAsString == reversedNumberString)
            {
                var reversedNumberAsInt = Convert.ToInt32(reversedNumberString);
                Output += numberAsString;
                if (previousNumber > 0)
                {
                    Output += $": Difference from previous palindrome is {i - previousNumber}";
                }                    
                Output += "\n";
                previousNumber = i;
            }
        }
    }

    private string ReverseString(string str)
    {
        char[] chars = str.ToCharArray();
        Array.Reverse(chars);
        return new string(chars);
    }
}
