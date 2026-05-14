using TMPro;
using UnityEngine;

public class life : MonoBehaviour
{
    public TMP_Text lifeText;
    private void Start()
    {
        UpdateUI(3);
    }
    public void UpdateUI(int life)
    {
        lifeText.text = life + " / 3";
    }
}
