using UnityEngine;

public class ObjectCut : MonoBehaviour
{
    private MeshRenderer mesh;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mesh = gameObject.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    public void SetCutPlaneAxis(float axis, float position)
    {
        switch (axis)
        {
            case 0: // X-axis
                mesh.material.SetFloat("_CutX", position);
                break;
            case 1: // Y-axis
                mesh.material.SetFloat("_CutY", position);
                break;
            case 2: // Z-axis
                mesh.material.SetFloat("_CutZ", position);
                break;
        }
    }
}
