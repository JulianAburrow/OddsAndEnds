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

        // So now we have a valid four digit number.
        // The next thing to do is to arrange the digits
        // to create the largest and smallest possible
        // numbers out of them.

        const int KaprekarsConstant = 6174;
        var chars = KaprekarsInput.FourDigitNumber.ToString().ToCharArray();

        while (Difference != KaprekarsConstant)
        {
            SetLargestAndSmallestValues(LargestNumberAsInt == 0 ? chars : Difference.ToString().ToCharArray());
            KaprekarsInput.ResultsOutput += $"{LargestNumberAsInt} - {SmallestNumberAsInt} = {LargestNumberAsInt - SmallestNumberAsInt}\n";
            Difference = LargestNumberAsInt - SmallestNumberAsInt;
            KaprekarsInput.IterationCount += 1;
        }
    }

    private void SetLargestAndSmallestValues(char[] chars)
    {
        var smallestNumberArray = chars.OrderBy(x => x).ToArray();
        var smallestNumberAsString = string.Empty;
        for (var i = 0; i < smallestNumberArray.Length; i++)
        {
            smallestNumberAsString += smallestNumberArray[i];
        }
        SmallestNumberAsInt = Convert.ToInt32(smallestNumberAsString);

        var largestNumberArray = chars.OrderByDescending(x => x).ToArray();
        var largestNumberAsString = string.Empty;
        for (var i = 0; i < largestNumberArray.Length; i++)
        {
            largestNumberAsString += largestNumberArray[i];
        }
        LargestNumberAsInt = Convert.ToInt32(largestNumberAsString);
    }

    private bool ValuesValid()
    {
        var numberToWorkOn = KaprekarsInput.FourDigitNumber;

        // Easy one first...
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
