using UnityEngine;
using UnityEditor;

#if UNITY_EDITOR
public static class AlignInteractables
{
    static bool FilterSourceAndTargetFromSelection(out Transform sourceParent, out Transform sourceAttachment, out Transform targetAttachment)
    {
        var selected = Selection.instanceIDs;
        if (selected == null || selected.Length != 3)
        {
            sourceParent = sourceAttachment = targetAttachment = null;
            return false;
        }

        var srcParentGameObject = EditorUtility.InstanceIDToObject(selected[0]) as GameObject;
        var srcAttachmentGameObject = EditorUtility.InstanceIDToObject(selected[1]) as GameObject;
        var targetAttachmentGameObject = EditorUtility.InstanceIDToObject(selected[2]) as GameObject;

        if (srcParentGameObject == null || srcAttachmentGameObject == null || targetAttachmentGameObject == null)
        {
            sourceParent = sourceAttachment = targetAttachment = null;
            return false;
        }

        sourceParent = srcParentGameObject.transform;
        sourceAttachment = srcAttachmentGameObject.transform;
        targetAttachment = targetAttachmentGameObject.transform;

        return true;
    }

    [MenuItem("Tools/XR/Align To Attach Transform", false, 0)]
    static void AlignAttachTransforms()
    {
        if (FilterSourceAndTargetFromSelection(out Transform sourceParent, out Transform sourceAttachTransform, out Transform targetAttachTransform))
        {
            Undo.RecordObject(sourceParent, "Align attach transform " + sourceParent.name + " with " + targetAttachTransform.name);

            sourceParent.rotation = targetAttachTransform.rotation * Quaternion.Inverse(sourceAttachTransform.localRotation);
            sourceParent.position = targetAttachTransform.position + (sourceParent.position - sourceAttachTransform.position);
        }
    }
}

#endif
