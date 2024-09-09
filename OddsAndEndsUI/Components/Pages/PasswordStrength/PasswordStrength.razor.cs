namespace OddsAndEndsUI.Components.Pages.PasswordStrength;

public partial class PasswordStrength
{
    public class PasswordProperties
    {
        public bool RequireLowerCase { get; set; } = true;

        public bool RequireUpperCase { get; set; }

        public bool RequireNumbers { get; set; }

        public int NumberOfCharacters { get; set; } = 5;
    }

    private ulong NumberOfPermutations { get; set; }

    private readonly PasswordProperties PasswordPropertiesSelected = new();

    protected override void OnInitialized()
    {
        ShowPasswordCombinations();
    }

    protected void ShowPasswordCombinations()
    {
        // Always going to have lower case characters so we have 26 to choose from already
        var possibleCharSet = 26;
        if (PasswordPropertiesSelected.RequireUpperCase)
        {
            possibleCharSet += 26;
        }
        if (PasswordPropertiesSelected.RequireNumbers)
        {
            possibleCharSet += 10;
        }
        NumberOfPermutations = (ulong) Math.Pow(possibleCharSet, PasswordPropertiesSelected.NumberOfCharacters);
    }
    

}
