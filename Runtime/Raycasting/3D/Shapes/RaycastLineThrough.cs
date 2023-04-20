using UnityEngine;

namespace Hybel
{
    public partial class Raycast : RaycastAPI
    {
        public static RaycastHit[] LineThrough(Vector3 start, Vector3 end) =>
            Physics.RaycastAll(start, end - start, Vector3.Distance(start, end));

        public static RaycastHit[] LineThrough(Vector3 start, Vector3 end, int layerMask) =>
            Physics.RaycastAll(start, end - start, Vector3.Distance(start, end), layerMask);

        public static RaycastHit[] LineThrough(Vector3 start, Vector3 end, int layerMask, QueryTriggerInteraction queryTriggerInteraction) =>
            Physics.RaycastAll(start, end - start, Vector3.Distance(start, end), layerMask, queryTriggerInteraction);
    }
}
