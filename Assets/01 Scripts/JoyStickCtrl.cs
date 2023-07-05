using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoyStickCtrl : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    [SerializeField] private RectTransform rect_Background;
    [SerializeField] private RectTransform rect_point;

    //��׶����� �������� ������ �����ų ����
    private float radius;

    //ȭ�鿡�� ������ �÷��̾�
    [SerializeField] private GameObject player;
    //������ �ӵ�
    [SerializeField] private float moveSpeed = 5.0f;

    //��ġ�� ���۵��� �� �����̰Ŷ�
    private bool isTouch = false;
    //������ ��ǥ
    private Vector3 movePosition;

    private Animator anim;
    //ĳ���� ȸ������ ��������� value�� ���������� ������
    private Vector2 value;
    private void Awake()
    {
        radius = rect_Background.rect.width * 0.5f;
        anim = player.GetComponent<Animator>();
    }

    void Update()
    {
        if(isTouch == true)
        {
            player.transform.position += this.movePosition;
            if(value != null)
            {
                player.transform.rotation = Quaternion.Euler(0f, Mathf.Atan2(value.x, value.y) * Mathf.Rad2Deg, 0f);
            }
        }
    }
    void OnTouch(Vector2 mm_vecTouch)
    {
     
    }
    public void OnDrag(PointerEventData eventData)
    {
       // anim.ResetTrigger("ani_Idle");
        //���콺 ��ǥ���� ������ ��׶��� ��ǥ���� �� ����ŭ ���̽�ƽ(�� ���׶��)�� ������ ����
        value = eventData.position - (Vector2)rect_Background.position;
        value = Vector2.ClampMagnitude(value, radius); //ũ�� ���α�
        //�θ�ü(��׶���) �������� ������ ������� ��ǥ���� �־���
        rect_point.localPosition = value;
        value = value.normalized;
        movePosition = new Vector3(value.x * moveSpeed * Time.deltaTime, 0f, value.y * moveSpeed * Time.deltaTime);
        anim.SetTrigger("ani_Run");
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        isTouch = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        rect_point.localPosition = Vector3.zero;
        isTouch = false;
        movePosition = Vector3.zero;
        anim.ResetTrigger("ani_Run");
        anim.SetTrigger("ani_Idle");
    }
}
