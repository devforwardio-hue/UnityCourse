using UnityEngine;

public class PerspectiveChange : MonoBehaviour
{
    public GameObject cam1;
    public GameObject cam2;
    public GameObject cam3;

    public float perspective = 0f;
    public float maxPerspective = 1f;

    private void Update()
    {
        if (Input.GetKeyDown("C"))
        {
            if (perspective == 0f)
            {
                cam1.SetActive(false);
                cam2.SetActive(true);
                perspective++;
            }

            //else if (maxPerspective == 1);
}

            {
                    cam1.SetActive(true);
                    cam2.SetActive(false);
                    perspective--;
                }
        }

}