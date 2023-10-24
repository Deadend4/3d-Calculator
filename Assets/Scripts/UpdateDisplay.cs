using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using NCalc;

public class UpdateDisplay : MonoBehaviour
{
    [SerializeField] TextMeshPro textMesh;
    [HideInInspector] public bool isOperatorMarked;
    [HideInInspector] public int countOperators = 0;
    private string lastOperator;
    // Start is called before the first frame update
    void Start()
    {
        textMesh.text = "0";
    }

    private void Update()
    {
        if (countOperators == 2)
        {
            string tempExpression = new Expression(truncLastOperator(textMesh.text)).Evaluate().ToString().Replace(",", ".");
            if (lastOperator == "=")
            {
                textMesh.text = tempExpression;
                isOperatorMarked = false;
                countOperators = 0;
            }
            else
            {
                textMesh.text = tempExpression + lastOperator;
                isOperatorMarked = true;
                countOperators = 1;

            }
        }
    }
    public void updateText(string newValue)
    {
        if (textMesh.text == "0" && (newValue == "+" || newValue == "-" || newValue == "*" || newValue == "/"))
        {
            if (countOperators < 2)
            {
                textMesh.text += newValue;
            }
        }
        else if (newValue == "Backspace")
        {
            Backspace();
        }
        else
        {
            if (textMesh.text == "0")
            {
                if (!(newValue == "="))
                {
                    textMesh.text = newValue;
                }
            }
            else
            {
                if (countOperators < 2)
                {
                    textMesh.text += newValue;
                }

            }
        }
    }
    public void replaceOperator(string newOperator)
    {
        if (!newOperator.Equals("="))
            textMesh.text = textMesh.text.Substring(0, textMesh.text.Length - 1) + newOperator;
    }
    private string truncLastOperator(string newString)
    {
        lastOperator = newString.Substring(newString.Length - 1);
        return newString.Substring(0, newString.Length - 1);
    }
    public void clear()
    {
        textMesh.text = "0";
    }
    public void Backspace()
    {
        if (textMesh.text.Length > 1)
        {
            textMesh.text = textMesh.text.Substring(0, textMesh.text.Length - 1);
        }
        else
        {
            textMesh.text = "0";
        }

    }
}
