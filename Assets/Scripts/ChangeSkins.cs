using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSkins : MonoBehaviour
{
    private int index = 0;
    [SerializeField] Material boardMat;
    [SerializeField] Material buttonMat;
    [SerializeField] Material operatorButtonMat;
    [SerializeField] Material textOpButtonMat;
    [SerializeField] Color[] boardColors;
    [SerializeField] Color[] buttonColors;
    [SerializeField] Color[] opButtonColors;
    private bool doOnce = true;
    // Start is called before the first frame update
    private void Start()
    {
        boardMat.SetColor("_Color", boardColors[boardColors.Length - 1]);
        buttonMat.SetColor("_Color", buttonColors[boardColors.Length - 1]);
        operatorButtonMat.SetColor("_Color", opButtonColors[boardColors.Length - 1]);
        textOpButtonMat.SetColor("_FaceColor", new Color(buttonColors[boardColors.Length - 1].r,
        buttonColors[boardColors.Length - 1].g, buttonColors[boardColors.Length - 1].b, 1));
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && doOnce)
        {
            reskin();
            doOnce = false;
        }
        if (Input.GetKeyUp(KeyCode.R))
        {
            doOnce = true;
        }
    }
    public void reskin()
    {
        if (index <= boardColors.Length)
        {
            boardMat.SetColor("_Color", boardColors[index]);
            buttonMat.SetColor("_Color", buttonColors[index]);
            operatorButtonMat.SetColor("_Color", opButtonColors[index]);
            textOpButtonMat.SetColor("_FaceColor", new Color(buttonColors[index].r, buttonColors[index].g, buttonColors[index].b, 1));
            index++;
        }
        if (index == boardColors.Length)
        {
            index = 0;
        }
    }
}
