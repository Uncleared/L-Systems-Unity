using System.Collections;
using System.Collections.Generic;
[System.Serializable]
public class Rule
{
    public char selector;
    public string replacement;
    public Rule(char selector, string replacement)
    {
        this.selector = selector;
        this.replacement = replacement;
    }
}
