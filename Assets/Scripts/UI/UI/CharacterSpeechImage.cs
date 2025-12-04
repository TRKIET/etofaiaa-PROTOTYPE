using UnityEngine;
using UnityEngine.UI;

public class CharacterSpeechImage : MonoBehaviour
{
    public Image dialogueImage;       // セリフ画像を表示するUI
    public GameObject dialogueBox;    // 吹き出しの枠
    public Sprite[] lineSprites;      // セリフ画像の配列
    public float autoCloseTime = 3f;  // 最後のクリックから閉じるまでの秒数

    private int currentLine = 0;

    void Start()
    {
        dialogueBox.SetActive(false); // ゲーム開始時は非表示
    }

    public void OnCharacterButtonClicked()
    {
        if (lineSprites.Length == 0) return;

        // 吹き出しを表示してセリフをセット
        dialogueBox.SetActive(true);
        dialogueImage.sprite = lineSprites[currentLine];

        // 次のセリフへ
        currentLine++;
        if (currentLine >= lineSprites.Length)
        {
            currentLine = 0; // 最後まで行ったらリセット
        }

        // タイマーをリセットして再スタート
        CancelInvoke(nameof(CloseDialogueBox));
        Invoke(nameof(CloseDialogueBox), autoCloseTime);
    }

    private void CloseDialogueBox()
    {
        dialogueBox.SetActive(false);
    }
}