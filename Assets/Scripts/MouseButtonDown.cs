using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class MouseButtonDown : MonoBehaviour
{
    [SerializeField] float animationSpeed = 0.5f;
    private Vector3 startPoint, endPoint;
    [HideInInspector] public bool isButtonPressed = false;
    private ButtonValue buttonValue;
    [SerializeField] UpdateDisplay updateDisplay;
    private bool isOperator;

    void Start()
    {
        startPoint = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z);
        endPoint = new Vector3(transform.localPosition.x + 0.17f, transform.localPosition.y, transform.localPosition.z);
        buttonValue = transform.GetComponent<ButtonValue>();
        isOperator = transform.TryGetComponent<Operator>(out Operator oprator);
    }
    private void Update()
    {
        if (!isButtonPressed && Input.GetKeyDown(buttonValue.buttonCode))
        {
            OnMouseDown();
        }
        if (isButtonPressed && Input.GetKeyUp(buttonValue.buttonCode))
        {
            OnMouseUp();
        }
    }
    void FixedUpdate()
    {
        if (isButtonPressed)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, endPoint, animationSpeed * Time.fixedDeltaTime);
        }
        else
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, startPoint, animationSpeed * Time.fixedDeltaTime);
        }
    }

    private void setPressed()
    {
        isButtonPressed = !isButtonPressed;
    }

    public void OnMouseDown()
    {
        if (!updateDisplay.isOperatorMarked || (updateDisplay.isOperatorMarked && !isOperator))
        {
            updateDisplay.updateText(buttonValue.value);
            isButtonPressed = true;
        }
        else if (updateDisplay.isOperatorMarked && isOperator)
        {
            updateDisplay.replaceOperator(buttonValue.value);
        }
        else if (updateDisplay.countOperators > 0)
        {
            if (!updateDisplay.isOperatorMarked || (updateDisplay.isOperatorMarked && !isOperator))
            {
                updateDisplay.updateText(buttonValue.value);
                isButtonPressed = true;
            }
        }

    }
    public void OnMouseUp()
    {
        isButtonPressed = false;
        if (updateDisplay.isOperatorMarked && !isOperator)
        {
            updateDisplay.isOperatorMarked = false;
        }
        else if (isOperator && !updateDisplay.isOperatorMarked)
        {
            updateDisplay.isOperatorMarked = true;
            updateDisplay.countOperators++;

        }
        if (buttonValue.value == "Clear")
        {
            updateDisplay.clear();
            updateDisplay.countOperators = 0;
        }
    }
}
