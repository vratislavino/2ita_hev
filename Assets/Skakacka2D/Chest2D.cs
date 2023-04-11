using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Chest2D : MonoBehaviour
{
    [SerializeField]
    private string sceneToLoad;

    [SerializeField]
    private GameObject canvas;

    private bool isPlayerPresent = false;

    private Animator chestAnimator;

    private void Start() {
        chestAnimator = GetComponentInChildren<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D col) {
        var player = col.GetComponentInParent<PlayerMovement2D>();
        if(player) {
            chestAnimator.SetBool("Opening", true);
            isPlayerPresent = true;
            canvas.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D col) {
        var player = col.GetComponentInParent<PlayerMovement2D>();
        if (player) {
            chestAnimator.SetBool("Opening", false);
            isPlayerPresent = false;
            canvas.SetActive(false);
        }
    }

    private void Update() {
        if (isPlayerPresent && Input.GetKeyDown(KeyCode.E)) {
            //SceneManager.LoadScene(sceneToLoad);
            chestAnimator.SetTrigger("Destroy");
            Destroy(gameObject, 1f);
        }
    }
}
