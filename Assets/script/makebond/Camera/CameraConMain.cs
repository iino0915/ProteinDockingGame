namespace camera.Main
{
    using UnityEngine;


    /// <summary>
    /// The camera added this script will follow the specified object.
    /// The camera can be moved by left mouse drag and mouse wheel.
    /// </summary>
    [ExecuteInEditMode, DisallowMultipleComponent]
    public class CameraConMain : MonoBehaviour
    {
        public GameObject target; // an object to follow
        public Vector3 offset; // offset form the target object
        private bool flag = true;
        private bool offsetflag = true;

        public static bool flag2 = false;//UIを動かしているかのチェック


        [SerializeField] private float distance = 50.0f; // distance from following object
        [SerializeField] private float polarAngle = 90.0f; // angle with y-axis
        [SerializeField] private float azimuthalAngle = 45.0f; // angle with x-axis

        [SerializeField] private float minDistance = 0.001f;
        [SerializeField] private float maxDistance = 100.0f;
        [SerializeField] private float minPolarAngle = 1.0f;
        [SerializeField] private float maxPolarAngle = 179.0f;
        [SerializeField] private float mouseXSensitivity = 5.0f;
        [SerializeField] private float mouseYSensitivity = 5.0f;
        [SerializeField] private float scrollSensitivity = 5.0f;
        [SerializeField, Range(0.1f, 10f)] private float moveSpeed = 0.3f;
        private Vector3 preMousePos;

        void Start()
        {
            //this.transform.position = new Vector3(-50, 62.3f, 98);
            this.transform.rotation = Quaternion.Euler(0, -165, 0);
        }

        void LateUpdate()
        {
            //if (offsetflag)
            //{
            //    this.transform.position = new Vector3(-50, 62.3f, 98);
            //    this.transform.rotation = Quaternion.Euler(0, -165, 0);
            //    offsetflag = false;
            //}
            //if ((0.3 < (Camera.main.WorldToViewportPoint(Input.mousePosition)).x))
            //{
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit = new RaycastHit();
                flag = Physics.Raycast(ray, out hit, 1000.0f);
            }

            if ((Input.GetMouseButton(0) == true) && (flag == false) && (flag2 == false))
            {
                updateAngle(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
            }

            if (Input.GetMouseButtonUp(0))
            {
                if (flag2) flag2 = false;

            }

            if (Input.GetMouseButtonDown(2))
            {
                preMousePos = Input.mousePosition;

                MouseDrag(Input.mousePosition);
            }


            updateDistance(Input.GetAxis("Mouse ScrollWheel"));

            var lookAtPos = target.transform.position + offset;
            updatePosition(lookAtPos);
            transform.LookAt(lookAtPos);
            //}
        }

        private void MouseDrag(Vector3 mousePos)
        {
            Vector3 diff = mousePos - preMousePos;


            if (Input.GetMouseButton(2))
                transform.Translate(-diff * Time.deltaTime * moveSpeed);

        }

        void updateAngle(float x, float y)
        {
            x = azimuthalAngle - x * mouseXSensitivity;
            azimuthalAngle = Mathf.Repeat(x, 360);

            y = polarAngle + y * mouseYSensitivity;
            polarAngle = Mathf.Clamp(y, minPolarAngle, maxPolarAngle);
        }

        void updateDistance(float scroll)
        {
            scroll = distance - scroll * scrollSensitivity;
            distance = Mathf.Clamp(scroll, minDistance, maxDistance);
        }

        void updatePosition(Vector3 lookAtPos)
        {
            var da = azimuthalAngle * Mathf.Deg2Rad;
            var dp = polarAngle * Mathf.Deg2Rad;
            transform.position = new Vector3(
                lookAtPos.x + distance * Mathf.Sin(dp) * Mathf.Cos(da),
                lookAtPos.y + distance * Mathf.Cos(dp),
                lookAtPos.z + distance * Mathf.Sin(dp) * Mathf.Sin(da));
        }
    }
}