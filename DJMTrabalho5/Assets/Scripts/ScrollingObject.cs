using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class ScrollingObject : MonoBehaviour {

    public Vector3 scrollVelocity;
    public Vector3 size;

    public Bounds bounds;

    public virtual void Update()
    {
        transform.position += scrollVelocity * Time.deltaTime;

		if (transform.position.y > 11) {
			transform.rotation = new Quaternion (0f,0f,Random.Range(0f,360f),Random.Range(0f,360f));
			transform.position = new Vector3(Random.Range(-5f,5f), transform.position.y,transform.position.z);
		}
    }

    [ContextMenu("Update Size From Children")]
    public void UpdateSizeFromChildren()
    {
        bounds = new Bounds (transform.position, Vector3.one);
        Renderer[] renderers = GetComponentsInChildren<Renderer> ();
        foreach (Renderer renderer in renderers)
        {
            bounds.Encapsulate (renderer.bounds);
        }

        size = bounds.size;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawWireCube(bounds.center, bounds.size);
    }
}