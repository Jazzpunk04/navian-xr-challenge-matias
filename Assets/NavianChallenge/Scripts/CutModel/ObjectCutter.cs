using UnityEngine;

public class ObjectCutter : MonoBehaviour
{
    [SerializeField] ObjectCut[] objectCuts;
    [Header("0 for X, 1 for Y, 2 for Z")]
    [SerializeField] int axis = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        foreach (var cut in objectCuts)
        {
            cut.SetCutPlaneAxis(axis, transform.position[axis]);
        }
    }

    public int GetAxis()
    {
        return axis;
    }
}
