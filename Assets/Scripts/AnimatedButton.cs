using UnityEngine;
using UnityEngine.EventSystems;

public class AnimatedButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        animator.SetBool("clicked", true);

        animator.Play("drag-animation", 0);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        animator.SetBool("clicked", false);
    }
}