using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RulesLoader : MonoBehaviour
{
    public List<RuleScriptableObject> rulesSO;

    // Update is called once per frame
    void Update()
    {

    }

    public List<Rule> LoadRules()
    {
        List<Rule> rules = new List<Rule>();
        foreach(RuleScriptableObject ruleSO in rulesSO)
        {
            rules.Add(ruleSO.rule);
        }
        return rules;
    }

   
}
