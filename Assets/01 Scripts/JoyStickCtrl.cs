using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoyStickCtrl : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    [SerializeField] private RectTransform rect_Background;
    [SerializeField] private RectTransform rect_point;

    //백그라운드의 반지름의 범위를 저장시킬 변수
    private float radius;

    //화면에서 움직일 플레이어
    [SerializeField] private GameObject player;
    //움직일 속도
    [SerializeField] private float moveSpeed = 5.0f;

    //터치가 시작됐을 때 움직이거라
    private bool isTouch = false;
    //움직일 좌표
    private Vector3 movePosition;

    private Animator anim;
    //캐릭터 회전값을 만들기위해 value를 전역변수로 설정함
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
        //마우스 좌표에서 검은색 백그라운드 좌표값을 뺀 값만큼 조이스틱(흰 동그라미)를 움직일 거임
        value = eventData.position - (Vector2)rect_Background.position;
        value = Vector2.ClampMagnitude(value, radius); //크기 가두기
        //부모객체(백그라운드) 기준으로 떨어질 상대적인 좌표값을 넣어줌
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
