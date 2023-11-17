namespace Avto.Services;

public static class ViewService
{
    public static List<string> PluralizePhraze(string modelDescription)
    {
        var modelDescriptionWords = modelDescription.Split(" ").ToList();
        var modelDescriptionPlural = new List<string>();

        foreach (var word in modelDescriptionWords)
            modelDescriptionPlural.Add(PluralizeBulgarian(word));

        return modelDescriptionPlural;
    }

    public static string PluralizeBulgarian(string word)
    {
        if (string.IsNullOrWhiteSpace(word))
            return word;

        if (word.EndsWith("а") || word.EndsWith("я")) // Feminine nouns
            return word.Substring(0, word.Length - 1) + "и";

        if (word.EndsWith("ен")) // Masculine nouns
            return word.Substring(0, word.Length - 2) + "ни";

        if (word.EndsWith("о") || word.EndsWith("е")) // Neutral nouns
            return word.Substring(0, word.Length - 1) + "а";

        if (word.EndsWith("ът") || word.EndsWith("ят")) // Definite article endings
        {
            // Handle definite article endings by pluralizing the base word
            string baseWord = word.Substring(0, word.Length - 2);
            return PluralizeBulgarian(baseWord) + "те";
        }

        if (word.EndsWith("че") || word.EndsWith("ще")) // Some irregular cases
            return word + "та";

        if (word.EndsWith("ко") || word.EndsWith("го")) // Neutral nouns
            return word.Substring(0, word.Length - 2) + "та";

        if (word.EndsWith("о") || word.EndsWith("е")) // Neutral nouns
            return word.Substring(0, word.Length - 1) + "а";

        if (word.EndsWith("ец")) // Masculine nouns
            return word.Substring(0, word.Length - 2) + "ци";

        if (word.EndsWith("ка")) // Feminine nouns
            return word.Substring(0, word.Length - 2) + "ки";

        // For all other cases, simply add "и" to the end
        return word + "и";
    }

    public static DateTime ToNullableDateTime(DateOnly? dateOnly)
    {
        if (dateOnly == null)
            return DateTime.MinValue;

        return new DateTime((int)dateOnly?.Year, (int)dateOnly?.Month, (int)dateOnly?.Day);
    }
}
