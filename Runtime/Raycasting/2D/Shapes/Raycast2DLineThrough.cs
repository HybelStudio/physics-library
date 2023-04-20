using UnityEngine;

namespace Hybel
{
    public partial class Raycast2D : RaycastAPI
    {
        public static RaycastHit2D[] LineThrough(Vector2 start, Vector2 end) =>
            Physics2D.LinecastAll(start, end);

        public static RaycastHit2D[] LineThrough(Vector2 start, Vector2 end, int layerMask) =>
            Physics2D.LinecastAll(start, end, layerMask);

        public static RaycastHit2D[] LineThrough(Vector2 start, Vector2 end, int layerMask, float minDepth) =>
            Physics2D.LinecastAll(start, end, layerMask, minDepth);

        public static RaycastHit2D[] LineThrough(Vector2 start, Vector2 end, int layerMask, float minDepth, float maxDepth) =>
            Physics2D.LinecastAll(start, end, layerMask, minDepth, maxDepth);
    }
}
