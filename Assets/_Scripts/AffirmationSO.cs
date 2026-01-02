using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu()]
public class AffirmationSO : ScriptableObject
{
    [TextArea(3,6)]
    public List<string> AffirmationList;
}
