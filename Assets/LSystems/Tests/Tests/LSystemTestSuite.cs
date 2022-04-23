using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System;

public class LSystemTestSuite
{
    [UnityTest]
    public IEnumerator TestAlgaeStringGeneration1()
    {
        GameObject LSystemGO = new GameObject();
        LSystem LSystem = LSystemGO.AddComponent<LSystem>();
        LSystem.axiom = 'A';
        LSystem.AddRule(new Rule('A', "AB"));
        LSystem.AddRule(new Rule('B', "A"));

        yield return null;

        Assert.AreEqual(LSystem.GenerateString(1), "AB");
        Assert.AreEqual(LSystem.GenerateString(2), "ABA");
        Assert.AreEqual(LSystem.GenerateString(3), "ABAAB");
        Assert.AreEqual(LSystem.GenerateString(4), "ABAABABA");
        Assert.AreEqual(LSystem.GenerateString(5), "ABAABABAABAAB");
        Assert.AreEqual(LSystem.GenerateString(6), "ABAABABAABAABABAABABA");
    }

    [UnityTest]
    public IEnumerator TestFractalTreeStringGeneration1()
    {
        GameObject LSystemGO = new GameObject();
        LSystem LSystem = LSystemGO.AddComponent<LSystem>();
        LSystem.axiom = '0';
        LSystem.AddRule(new Rule('1', "11"));
        LSystem.AddRule(new Rule('0', "1[0]0"));

        yield return null;

        Assert.AreEqual(LSystem.GenerateString(1), "1[0]0");
        Assert.AreEqual(LSystem.GenerateString(2), "11[1[0]0]1[0]0");
        Assert.AreEqual(LSystem.GenerateString(3), "1111[11[1[0]0]1[0]0]11[1[0]0]1[0]0");
    }

    [UnityTest]
    public IEnumerator TestThrowsExceptionWhenEmpty()
    {
        GameObject LSystemGO = new GameObject();
        LSystem LSystem = LSystemGO.AddComponent<LSystem>();
        LSystem.axiom = 'A';

        yield return null;
        Assert.That(() => LSystem.GenerateString(0),
                          Throws.TypeOf<Exception>());
    }
}
