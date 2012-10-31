using UnityEngine;
using System.Collections;

// �� �信���� ��������Ʈ�� ���̵��� ����Ʈ ��忡�� ����
[ExecuteInEditMode]
public class Sprite : MonoBehaviour
{
    // �߶� ������ ���� �� ��ǥ
    public Vector2 spriteTopLeft;
    // �߶� ������ ũ��
    public Vector2 spriteSize;
    // ���� ����
    public Material spriteMaterial;
    // ���� ���� ȭ�� ���� ( 1024x768 �ػ� ���� )
    public float defCameraPixels = 768f;

    // ��������Ʈ�� ���� ���
    public SpriteOrientation spriteOrientation;

    protected Mesh _mesh;
    protected MeshRenderer _renderer;

    void Awake()
    {
        // �����ϱ� ���� ������ �����Ǿ� �ִ��� Ȯ��
        if (spriteMaterial == null || spriteMaterial.mainTexture == null)
        {
            Debug.LogError("������ �����Ǿ� �־�� �մϴ�");
            return;
        }

        // �޽����� ������Ʈ�� ������ �߰�
        MeshFilter mf = gameObject.GetComponent<MeshFilter>();
        if (mf == null)
        {
            mf = gameObject.AddComponent<MeshFilter>();
        }

        // �޽������� ������Ʈ�� ������ �߰�
        _renderer = gameObject.GetComponent<MeshRenderer>();
        if (_renderer == null)
        {
            _renderer = gameObject.AddComponent<MeshRenderer>();
        }
        _renderer.castShadows = false;
        _renderer.receiveShadows = false;
        _renderer.sharedMaterial = spriteMaterial;

        // ȭ�� ����� �´� ��������Ʈ�� ũ�� ������ ���� ���� ���
        float pixelPerWorldUnit = Camera.mainCamera.orthographicSize * 2 / defCameraPixels;

        // �޽� ����
        _mesh = new Mesh();
        _mesh.name = "SpriteMesh";

        // ���Ĺ�Ŀ� ���� �޽��� ���� ���� ����
        if (spriteOrientation == SpriteOrientation.MiddleCenter)
        {
            _mesh.vertices = new Vector3[] {
				new Vector3(-spriteSize.x, -spriteSize.y) * pixelPerWorldUnit * 0.5f,
				new Vector3(-spriteSize.x, spriteSize.y) * pixelPerWorldUnit * 0.5f,
				new Vector3(spriteSize.x, -spriteSize.y) * pixelPerWorldUnit * 0.5f,
				new Vector3(spriteSize.x, spriteSize.y) * pixelPerWorldUnit * 0.5f
			};
        }
        else if (spriteOrientation == SpriteOrientation.TopLeft)
        {
            _mesh.vertices = new Vector3[] {
				new Vector3(0, -spriteSize.y) * pixelPerWorldUnit,
				new Vector3(0, 0) * pixelPerWorldUnit,
				new Vector3(spriteSize.x, -spriteSize.y) * pixelPerWorldUnit,
				new Vector3(spriteSize.x, 0) * pixelPerWorldUnit
			};
        }

        // ���� ������ �������� �ﰢ�� ����
        _mesh.triangles = new int[] { 0, 1, 3, 0, 3, 2 };

        // ������ �ؽ����� UV ����
        float texWidth = _renderer.sharedMaterial.mainTexture.width;
        float texHeight = _renderer.sharedMaterial.mainTexture.height;

        _mesh.uv = new Vector2[] { 
			new Vector2(1f/texWidth * spriteTopLeft.x, 1f-1f/texHeight * (spriteTopLeft.y + spriteSize.y)),
			new Vector2(1f/texWidth * spriteTopLeft.x, 1f-1f/texHeight * spriteTopLeft.y),
			new Vector2(1f/texWidth * (spriteTopLeft.x + spriteSize.x), 1f-1f/texHeight * (spriteTopLeft.y + spriteSize.y)),
			new Vector2(1f/texWidth * (spriteTopLeft.x + spriteSize.x), 1f-1f/texHeight * spriteTopLeft.y)
		};

        // ���� �޽��� �����ϰ�, �޽����Ϳ� ����
        _mesh.Optimize();
        _mesh.RecalculateNormals();
        _mesh.RecalculateBounds();
        mf.sharedMesh = _mesh;
    }

    // ��������Ʈ�� ���� ������ ���� Enum
    public enum SpriteOrientation
    {
        TopLeft,
        MiddleCenter
    }
}

