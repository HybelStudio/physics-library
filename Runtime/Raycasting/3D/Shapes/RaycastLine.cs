using UnityEngine;

namespace Hybel
{
    public partial class Raycast : RaycastAPI
    {
        public static bool Line(Vector3 start, Vector3 end) =>
            Physics.Linecast(start, end);

        public static bool Line(Vector3 start, Vector3 end, int layerMask) =>
            Physics.Linecast(start, end, layerMask);

        public static bool Line(Vector3 start, Vector3 end, int layerMask, QueryTriggerInteraction queryTriggerInteraction) =>
            Physics.Linecast(start, end, layerMask, queryTriggerInteraction);

        public static bool Line(Vector3 start, Vector3 end, out RaycastHit hitInfo) =>
            Physics.Linecast(start, end, out hitInfo);

        public static bool Line(Vector3 start, Vector3 end, int layerMask, out RaycastHit hitInfo) =>
            Physics.Linecast(start, end, out hitInfo, layerMask);

        public static bool Line(Vector3 start, Vector3 end, int layerMask, QueryTriggerInteraction queryTriggerInteraction, out RaycastHit hitInfo) =>
            Physics.Linecast(start, end, out hitInfo, layerMask, queryTriggerInteraction);
    }
}
