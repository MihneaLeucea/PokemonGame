using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BattleUnit : MonoBehaviour
{
    [SerializeField] PokemonBase _base;
    [SerializeField] int level;
    [SerializeField] bool isPlayerUnit;

    public Pokemon Pokemon {  get; set; }

    Image Image;
    Vector3 originalPos;
    Color originalColor;

    private void Awake()
    {
        Image = GetComponent<Image>();
        originalPos = Image.transform.localPosition;
        originalColor = Image.color;
    }

    public void Setup()
    {
        Pokemon = new Pokemon(_base, level);
        if (isPlayerUnit)
        {
            Image.sprite = Pokemon.Base.BackSprite;
        }
        else
        {
            Image.sprite = Pokemon.Base.FrontSprite;
        }

        PlayEnterAnimation();
    }

    public void PlayEnterAnimation()
    {
        if (isPlayerUnit)
        {
            Image.transform.localPosition = new Vector3(-500f, originalPos.y);
        }
        else
        {
            Image.transform.localPosition = new Vector3(500f, originalPos.y);
        }

        Image.transform.DOLocalMoveX(originalPos.x, 1f);
    }

    public void PlayAttackAnimation()
    {
        var sequence = DOTween.Sequence();
        if(isPlayerUnit)
        {
            sequence.Append(Image.transform.DOLocalMoveX(originalPos.x + 50f, 0.25f));
        }
        else
        {
            sequence.Append(Image.transform.DOLocalMoveX(originalPos.x - 50f, 0.25f));
        }

        sequence.Append(Image.transform.DOLocalMoveX(originalPos.x, 0.25f));
    }

    public void PlayHitAnimation()
    {
        var sequence = DOTween.Sequence();
        sequence.Append(Image.DOColor(Color.gray, 0.1f));
        sequence.Append(Image.DOColor(originalColor, 0.1f));
    }

    public void PlayDeathAnimation()
    {
        var sequence = DOTween.Sequence();
        sequence.Append(Image.transform.DOLocalMoveY(originalPos.y - 150f, 0.5f));
        sequence.Join(Image.DOFade(0f, 0.5f));
    }
}
