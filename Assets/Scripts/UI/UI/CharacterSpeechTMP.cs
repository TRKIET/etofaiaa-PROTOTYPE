using UnityEngine;
using TMPro;

public class CharacterSpeechTMP : MonoBehaviour
{
    public TextMeshProUGUI dialogueText; // TMP用のセリフ表示
    public GameObject dialogueBox;       // 吹き出しなどのUI（必要なら）
    public string[] lines;               // セリフの配列
    private int currentLine = 0;

    public void OnCharacterButtonClicked()
    {
        if (lines.Length == 0) return;

        dialogueBox.SetActive(true); // 吹き出し表示（任意）
        dialogueText.text = lines[currentLine];
        currentLine = (currentLine + 1) % lines.Length;
    }
}