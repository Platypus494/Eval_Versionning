using UnityEngine;
using UnityEngine.UI;

public class UI_ShowHealth : MonoBehaviour
{
    [SerializeField] ManageCollision _col;
    [SerializeField] Slider _slider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _col.OnTouchGround += UpdateUI;
        _slider.maxValue = 5;
        
    }

    void UpdateUI()
    {
        _slider.value = _col.Health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
