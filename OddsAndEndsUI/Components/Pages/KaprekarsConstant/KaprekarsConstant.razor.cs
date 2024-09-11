using System.Collections.Immutable;
using System.ComponentModel.DataAnnotations;

namespace OddsAndEndsUI.Components.Pages.KaprekarsConstant;

public partial class KaprekarsConstant
{
    public class KaprekarsValues
    {
        [Required(ErrorMessage = "{0} is required")]
        [Range(1001, 9999, ErrorMessage = "{0} must be between {1} and {2}")]
        [Length(4, 4)]
        [Display(Name = "Four Digit Number")]
        public int FourDigitNumber { get; set; }

        public int IterationCount { get; set; }

        public string ResultsOutput { get; set; } = string.Empty!;
    }

    private string ErrorMessage { get; set; } = string.Empty!;

    private KaprekarsValues KaprekarsInput = new();

    private int SmallestNumberAsInt { get; set; }

    private int LargestNumberAsInt { get; set; }

    private int Difference { get; set; }

    private void DoCalculations()
    {
        KaprekarsInput.ResultsOutput = string.Empty;
        KaprekarsInput.IterationCount = 0;
        ErrorMessage = string.Empty!;
        SmallestNumberAsInt = 0;
        LargestNumberAsInt = 0;
        Difference = 0;

        if (!ValuesValid())
        {
            return;
        }

        const int KaprekarsConstant = 6174;

        if (KaprekarsInput.FourDigitNumber == KaprekarsConstant)
        {
            KaprekarsInput.ResultsOutput = "That IS Kaprekar's Constant!";
            return;
        }

        // So now we have a valid four digit number.
        // The next thing to do is to arrange the digits
        // to create the largest and smallest possible
        // numbers out of them.

        var chars = KaprekarsInput.FourDigitNumber.ToString().ToCharArray();

        while (Difference != KaprekarsConstant)
        {
            SetLargestAndSmallestValues(LargestNumberAsInt == 0 ? KaprekarsInput.FourDigitNumber : Difference);
            KaprekarsInput.ResultsOutput += $"{LargestNumberAsInt} - {SmallestNumberAsInt} = {LargestNumberAsInt - SmallestNumberAsInt}\n";
            Difference = LargestNumberAsInt - SmallestNumberAsInt;
            KaprekarsInput.IterationCount += 1;
        }
    }

    private void SetLargestAndSmallestValues(int number)
    {
        var numberAsList = number.ToString().Order();
        SmallestNumberAsInt = int.Parse(string.Join(",", numberAsList).Replace(",", ""));
        LargestNumberAsInt = int.Parse(string.Join(",", numberAsList.Reverse()).Replace(",", ""));
    }

    private bool ValuesValid()
    {
        var numberToWorkOn = KaprekarsInput.FourDigitNumber;

        if (numberToWorkOn < 1001 ||
            numberToWorkOn > 9999)
        {
            ErrorMessage = "Must be a number between 1001 and 9999";
            return false;
        }

        if (HasMoreThanTwoIdenticalDigits(numberToWorkOn))
        {
            ErrorMessage = "One of the digits occurs more than twice.";
            return false;
        }

        return true;
    }

    private bool HasMoreThanTwoIdenticalDigits(int number)
    {
        var numberAsString = number.ToString();
        return numberAsString
            .GroupBy(x => x)
            .Any(g =>
                g.Count() > 2);
    }
}
