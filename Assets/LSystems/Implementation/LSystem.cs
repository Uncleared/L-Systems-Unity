using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LSystem : MonoBehaviour
{
    string currentString = "";

    public char axiom;
    private List<Rule> rules;
    public RulesLoader rulesLoader;
    

    private void Start()
    {
   
    }

    public void AddRule(Rule rule)
    {
        if (rules != null)
        {
            rules.Add(rule);
        }
        else
        {
            rules = new List<Rule>();
            rules.Add(rule);
        }
    }

    // Consider string builder
    public string GenerateString(int n)
    {
        if(rulesLoader != null)
        {
            rules = rulesLoader.LoadRules();
        }

        if(rules == null || (rules != null && rules.Count == 0))
        {
            throw new Exception("No rules specified in L System");
        }
        currentString = axiom.ToString();

        string output = "";

        for(int i = 0; i < n; i++)
        {
            string tempOutput = "";
            for(int j = 0; j < currentString.Length; j++)
            {
                bool ruleMatched = false;
                foreach(Rule rule in rules)
                {
                    // if equal to the selector
                    if(currentString[j].Equals(rule.selector))
                    {
                        tempOutput += rule.replacement;
                        // break out, we don't want to apply two rules on one character
                        ruleMatched = true; 
                        break;
                    }
                }
                if(!ruleMatched)
                {
                    tempOutput += currentString[j];
                }
            }
            currentString = tempOutput;
        }
        output = currentString;

        return output;
    }
}
