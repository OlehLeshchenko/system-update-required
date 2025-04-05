
using UnityEngine;
using UnityEngine.Rendering;

[ExecuteAlways]
[RequireComponent(typeof(Camera))]
public class UniversalGlitchEffect : MonoBehaviour
{
    public Shader glitchShader;
    private Material _material;
    private CommandBuffer _commandBuffer;
    private Camera _camera;

    void OnEnable()
    {
        _camera = GetComponent<Camera>();
        if (glitchShader != null)
        {
            _material = new Material(glitchShader);
            _commandBuffer = new CommandBuffer { name = "Glitch Effect" };
            _camera.AddCommandBuffer(CameraEvent.AfterImageEffects, _commandBuffer);
        }
    }

    void OnDisable()
    {
        if (_camera != null && _commandBuffer != null)
            _camera.RemoveCommandBuffer(CameraEvent.AfterImageEffects, _commandBuffer);
        if (_material != null) DestroyImmediate(_material);
    }

    void LateUpdate()
    {
        if (_material == null || _commandBuffer == null) return;

        _commandBuffer.Clear();

        int tempRT = Shader.PropertyToID("_TempRT");
        _commandBuffer.GetTemporaryRT(tempRT, -1, -1, 0, FilterMode.Bilinear);
        _commandBuffer.Blit(BuiltinRenderTextureType.CurrentActive, tempRT);

        // Прибрано SetTexture повністю

        _commandBuffer.Blit(tempRT, BuiltinRenderTextureType.CameraTarget, _material);
        _commandBuffer.ReleaseTemporaryRT(tempRT);
    }

}
