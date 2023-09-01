using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    private Animator anim;

    public int Id;

    private Vector3 startPos;

    public GameObject vfx;

    private void Awake()
    {
        startPos = transform.position;

        anim = GetComponent<Animator>();
        anim.SetTrigger("Intro");
    }

    private void Start()
    {
        
    }

    private void OnMouseDown()
    {
        GameManager.Instance.ListTargets.Add(this);
    }

    public void Return()
    {
        transform.position = startPos;
    }

    public void DesTroyGameObject()
    {
        StartCoroutine(Wait(1));
    }

    IEnumerator Wait(int delay)
    {
        yield return new WaitForSeconds(delay);

        GameObject vfxDestroy = Instantiate(vfx, transform.position, Quaternion.identity);
        Destroy(vfxDestroy, 1f);
        gameObject.SetActive(false);

        GameManager.Instance.levels[GameManager.Instance.GetCurrentIndex()].allBlocks.Remove(this);
    }
}
