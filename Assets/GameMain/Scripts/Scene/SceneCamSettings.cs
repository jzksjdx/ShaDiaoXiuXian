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
    public Vector3 m_Position;
    public Vector3 m_Rotation;

    protected override void PostPipelineStageCallback(
        CinemachineVirtualCameraBase vcam,
        CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        if (stage == CinemachineCore.Stage.Body)
        {
            //固定相机xyz轴
            state.RawPosition = m_Position;

            //固定相机角度
            Quaternion orientation = Quaternion.Euler(m_Rotation.x, m_Rotation.y, m_Rotation.z);
            state.RawOrientation = orientation;
        }
    }
}
