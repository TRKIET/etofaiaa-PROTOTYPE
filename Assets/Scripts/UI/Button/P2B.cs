using UnityEngine;
using UnityEngine.UI;

public class P2B : MonoBehaviour
{
    public Button showButton;       // �\������{�^��
    public GameObject prefabToSpawn;      // �\�������摜�iImage�R���|�[�l���g�j
    public Transform spawnPoint;

    public void Start()
    {

        // �{�^���ɃN���b�N�C�x���g��o�^
        showButton.onClick.AddListener(ShowPhoto);
    }

    void ShowPhoto()
    {
        GameObject newObj = Instantiate(prefabToSpawn, spawnPoint.position, spawnPoint.rotation);

        spawnPoint.gameObject.SetActive(false);//���selectmanager��check

        // �X�N���v�g�𖳌��ɂ���
        PlayerController script = newObj.GetComponent<PlayerController>();
        if (script != null)
        {
            script.enabled = false;
        }

        Rigidbody2D rb2d = newObj.GetComponent<Rigidbody2D>();
        if (rb2d != null)
        {
            rb2d.gravityScale = 0f; // �d�̓X�P�[����0�ɂ���
            rb2d.linearVelocity = Vector2.zero; // �O�̂��ߑ��x��0�ɂ���
        }
    }
}
