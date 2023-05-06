using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ScrollManager : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Scrollbar _scrollbar;
    const int _imgSize = 4; //��ũ�� �� ������ ���� �̹��� ����
    float[] _imgPosArr = new float[_imgSize];
    float _imgDistance, _targetPos;

    //�̹��� ���� value���� �迭�� ����
    void Start()
    {
        _imgDistance = 1f / (_imgSize - 1);
        for (int i = 0; i < _imgSize; i++) _imgPosArr[i] = _imgDistance * i;

    }
    public void OnBeginDrag(PointerEventData eventData)
    {

    }

    public void OnDrag(PointerEventData eventData)
    {
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        for(int i = 0; i < _imgSize; i++)
        {
            if (_scrollbar.value < _imgPosArr[i] + _imgDistance * 0.5 && _scrollbar.value > _imgPosArr[i] - _imgDistance * 0.5)
                _targetPos = _imgPosArr[i];
        }
    }

    void Update()
    {
        
    }
}
