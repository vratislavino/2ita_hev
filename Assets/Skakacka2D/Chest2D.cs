using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Chest2D : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private string sceneToLoad;

    [SerializeField]
    private GameObject canvas;

    [SerializeField]
    private Sprite openedChest;

    private bool isPlayerPresent = false;



    [SerializeField]
    private Sprite closedChest;

    private void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D col) {
        var player = col.GetComponentInParent<PlayerMovement2D>();
        if(player) {
            spriteRenderer.sprite = openedChest;
            isPlayerPresent = true;
            canvas.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D col) {
        var player = col.GetComponentInParent<PlayerMovement2D>();
        if (player) {
            spriteRenderer.sprite = closedChest;
            isPlayerPresent = false;
            canvas.SetActive(false);
        }
    }

    private void Update() {
        if (isPlayerPresent && Input.GetKeyDown(KeyCode.E)) {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
