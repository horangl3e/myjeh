using UnityEngine;
using System.Collections;

// Spite 클래스를 상속받아 기능을 확장
public class AnimatedSprite : Sprite {

	// 애니메이션 재생속도. 초당프레임수
	public float fps = 24f;
	// 애니메이션의 총 프레임 수
	public int totalFrames = 1;


    public int xTileCount = 4;
    public int yTileCount = 4;


	// 반복 여부
	public bool loop = true;
    // 초기 시작 Delay
    public float startDelay = 0f;

	void Start () 
	{
		// ChangeUV 함수를 코루틴으로 실행
		StartCoroutine(ChangeUV());

        totalFrames = xTileCount + yTileCount;
	}

	// 재생속도 단위로 UV를 변경하여 애니메이션 수행
	IEnumerator ChangeUV()
	{
		// 텍스쳐의 크기 정보
		float texWidth = _renderer.sharedMaterial.mainTexture.width;
		float texHeight = _renderer.sharedMaterial.mainTexture.height;

		// 현재 프레임 저장 변수
		int currentFrame = 0;

        // 초기에 지정한 Delay 만큼 대기
        yield return new WaitForSeconds(startDelay);

		while (true)
		{
			// 한 프레임 간격 대기
			yield return new WaitForSeconds(1.0f / fps);

			// 모든 프레임의 애니메이션이 완료되면 처음으로 돌아가거나 종료.
			if (currentFrame > (totalFrames -1))
			{
				if (loop)
					currentFrame = 0;
				else
					break;
			}

			// 현재 프레임에 해당되는 UV 설정
			_mesh.uv = new Vector2[] { 
			    new Vector2(1f/texWidth * (spriteTopLeft.x + spriteSize.x * currentFrame), 1f-1f/texHeight * (spriteTopLeft.y + spriteSize.y)),
			    new Vector2(1f/texWidth * (spriteTopLeft.x + spriteSize.x * currentFrame), 1f-1f/texHeight * spriteTopLeft.y),
			    new Vector2(1f/texWidth * (spriteTopLeft.x + spriteSize.x * (currentFrame + 1)), 1f-1f/texHeight * (spriteTopLeft.y + spriteSize.y)),
			    new Vector2(1f/texWidth * (spriteTopLeft.x + spriteSize.x * (currentFrame + 1)), 1f-1f/texHeight * spriteTopLeft.y)
			};

			// UV가 변경되면 다음 프레임으로 증가
			currentFrame++;
		}
	}
}
