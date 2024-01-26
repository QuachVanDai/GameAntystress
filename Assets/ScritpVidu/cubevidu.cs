using UnityEngine;

public class cubevidu : MonoBehaviour
{
    // Tốc độ quay của hình tròn
    public float rotationSpeed = 5.0f;
    public GameObject h;
    void Update()
    {
        // Kiểm tra sự kiện chuột trái được nhấn
        if (Input.GetMouseButtonDown(0))
        {
           
        }
    }
    private void OnMouseDrag()
    {
        // Lấy vị trí chuột trên màn hình
        Vector3 mousePosition = Input.mousePosition;

        // Chuyển đổi vị trí chuột từ màn hình sang tọa độ thế giới
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            // Lấy hướng từ đối tượng đến vị trí chuột
            Vector3 targetDirection = hit.point - transform.position;

            // Chuyển đổi hướng thành góc nghiêng và áp dụng nghiêng cho hình tròn
            float targetTilt = Mathf.Atan2(targetDirection.z, targetDirection.x) * Mathf.Rad2Deg;
            Quaternion newRotation = Quaternion.Euler(70, targetTilt, 0);
            h.transform.rotation = Quaternion.Slerp(h.transform.rotation, newRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
