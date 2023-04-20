using System.Collections.Generic;
using UnityEngine;

namespace Hybel
{
    public partial class Overlap2D : OverlapAPI
    {
        public static List<Collider2D> Collider(Collider2D collider, ContactFilter2D contactFilter, out int returnedSize)
        {
            List<Collider2D> results = new List<Collider2D>();
            returnedSize = Physics2D.OverlapCollider(collider, contactFilter, results);
            return results;
        }

        public static Collider2D[] Collider(Collider2D collider, ContactFilter2D contactFilter, int maxArraySize)
        {
            Collider2D[] results = new Collider2D[maxArraySize];
            Physics2D.OverlapCollider(collider, contactFilter, results);
            return results;
        }

        public static Collider2D[] Collider(Collider2D collider, ContactFilter2D contactFilter, int maxArraySize, out int returnedSize)
        {
            Collider2D[] results = new Collider2D[maxArraySize];
            returnedSize = Physics2D.OverlapCollider(collider, contactFilter, results);
            return results;
        }
    }
}