using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PointManager : MonoBehaviour
{
    public int pointCount;
    public TextMeshProUGUI pointText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pointText.text = "Points: " + pointCount.ToString();
    }
}
