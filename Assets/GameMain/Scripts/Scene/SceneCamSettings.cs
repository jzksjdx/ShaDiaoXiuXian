using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;


/// <summary>
/// An add-on module for Cinemachine Virtual Camera
/// </summary>
[ExecuteInEditMode]
[SaveDuringPlay]
[AddComponentMenu("")] // Hide in menu
public class SceneCamSettings : CinemachineExtension
{
    //[Tooltip("Lock the camera's Z position to this value")]
    public float m_YPosition = 9.81f;
    public float m_ZPosition = -17.35251f;
    public Vector3 m_Rotation;

    protected override void PostPipelineStageCallback(
        CinemachineVirtualCameraBase vcam,
        CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        if (stage == CinemachineCore.Stage.Body)
        {
            //固定相机yz轴
            var pos = state.RawPosition;
            pos.z = m_ZPosition;
            pos.y = m_YPosition;
            state.RawPosition = pos;

            //固定相机角度
            Quaternion orientation = Quaternion.Euler(m_Rotation.x, m_Rotation.y, m_Rotation.z);
            state.RawOrientation = orientation;
        }
    }
}
