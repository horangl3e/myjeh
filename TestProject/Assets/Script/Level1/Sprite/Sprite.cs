using UnityEngine;
using System.Collections;

// 씬 뷰에서도 스프라이트가 보이도록 에디트 모드에서 실행
[ExecuteInEditMode]
public class Sprite : MonoBehaviour
{
    // 잘라낼 영역의 왼쪽 위 좌표
    public Vector2 spriteTopLeft;
    // 잘라낼 영역의 크기
    public Vector2 spriteSize;
    // 재질 설정
    public Material spriteMaterial;
    // 게임 뷰의 화면 높이 ( 1024x768 해상도 기준 )
    public float defCameraPixels = 768f;

    // 스프라이트의 정렬 방식
    public SpriteOrientation spriteOrientation;

    protected Mesh _mesh;
    protected MeshRenderer _renderer;

    void Awake()
    {
        // 시작하기 전에 재질이 설정되어 있는지 확인
        if (spriteMaterial == null || spriteMaterial.mainTexture == null)
        {
            Debug.LogError("재질이 설정되어 있어야 합니다");
            return;
        }

        // 메쉬필터 컴포넌트가 없으면 추가
        MeshFilter mf = gameObject.GetComponent<MeshFilter>();
        if (mf == null)
        {
            mf = gameObject.AddComponent<MeshFilter>();
        }

        // 메쉬렌더러 컴포넌트가 없으면 추가
        _renderer = gameObject.GetComponent<MeshRenderer>();
        if (_renderer == null)
        {
            _renderer = gameObject.AddComponent<MeshRenderer>();
        }
        _renderer.castShadows = false;
        _renderer.receiveShadows = false;
        _renderer.sharedMaterial = spriteMaterial;

        // 화면 사이즈에 맞는 스프라이트의 크기 지정을 위한 비율 계산
        float pixelPerWorldUnit = Camera.mainCamera.orthographicSize * 2 / defCameraPixels;

        // 메쉬 생성
        _mesh = new Mesh();
        _mesh.name = "SpriteMesh";

        // 정렬방식에 따른 메쉬의 정점 정보 생성
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

        // 정점 정보에 바탕으로 삼각면 지정
        _mesh.triangles = new int[] { 0, 1, 3, 0, 3, 2 };

        // 정점에 텍스쳐의 UV 지정
        float texWidth = _renderer.sharedMaterial.mainTexture.width;
        float texHeight = _renderer.sharedMaterial.mainTexture.height;

        _mesh.uv = new Vector2[] { 
			new Vector2(1f/texWidth * spriteTopLeft.x, 1f-1f/texHeight * (spriteTopLeft.y + spriteSize.y)),
			new Vector2(1f/texWidth * spriteTopLeft.x, 1f-1f/texHeight * spriteTopLeft.y),
			new Vector2(1f/texWidth * (spriteTopLeft.x + spriteSize.x), 1f-1f/texHeight * (spriteTopLeft.y + spriteSize.y)),
			new Vector2(1f/texWidth * (spriteTopLeft.x + spriteSize.x), 1f-1f/texHeight * spriteTopLeft.y)
		};

        // 최종 메쉬를 생성하고, 메쉬필터에 설정
        _mesh.Optimize();
        _mesh.RecalculateNormals();
        _mesh.RecalculateBounds();
        mf.sharedMesh = _mesh;
    }

    // 스프라이트의 정렬 지정을 위한 Enum
    public enum SpriteOrientation
    {
        TopLeft,
        MiddleCenter
    }
}

