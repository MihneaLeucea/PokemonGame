using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleDialogBox : MonoBehaviour
{
    [SerializeField] int lettersPerSecond;
    [SerializeField] Text dialogText;
    [SerializeField] Color highlightedColor;
    [SerializeField] int currentPP;

    [SerializeField] GameObject actionSelector;
    [SerializeField] GameObject moveSelector;
    [SerializeField] GameObject moveDetails;

    [SerializeField] List<Text> actionText;
    [SerializeField] List<Text> moveText;

    [SerializeField] Text ppText;
    [SerializeField] Text typeText;

    public void SetDialog(string dialog)
    {
        dialogText.text = dialog;
    }

    public IEnumerator TypeDialog(string dialog)
    {
        dialogText.text = "";
        foreach(var letter in dialog.ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(1f / lettersPerSecond);
        }
    }

    public void EnableDialogText(bool enabled)
    {
        dialogText.enabled = enabled;
    }

    public void EnableActionSelector(bool enabled)
    {
        actionSelector.SetActive(enabled);
    }

    public void EnableMoveSelector(bool enabled)
    {
        moveSelector.SetActive(enabled);
        moveDetails.SetActive(enabled);
    }

    public void UpdateActionSelector(int selectedAction)
    {
        for(int i=0; i < actionText.Count; ++i)
        {
            if (i == selectedAction)
            {
                actionText[i].color = highlightedColor;
            }
            else actionText[i].color = Color.black; 
        }
    }

    public void UpdateMoveSelection(int selectMove, Move move)
    {
        for(int i=0; i<moveText.Count; ++i)
        {
            if (i == selectMove)
            {
                moveText[i].color = highlightedColor;
            }
            else moveText[i].color = Color.black;
        }
        currentPP = move.Base.PP;
        ppText.text = $"PP {currentPP}/{move.Base.PP}";
        typeText.text = move.Base.Type.ToString();

    }

    public void SetMoveNames(List<Move> moves)
    {
        for(int i=0; i<moveText.Count; i++)
        {
            if (i < moves.Count) moveText[i].text = moves[i].Base.Name;
            else moveText[i].text = "-";
        }
    }
}
