using UnityEngine;
using System.Collections;

public class UIFilledSpriteSubClass : UIFilledSprite
{

    override public void OnFill(BetterList<Vector3> verts, BetterList<Vector2> uvs, BetterList<Color> cols)
    {
        float x0 = 0f;
        float y0 = 0f;
        float x1 = 1f;
        float y1 = -1f;

        float u0 = mOuterUV.xMin;
        float v0 = mOuterUV.yMin;
        float u1 = mOuterUV.xMax;
        float v1 = mOuterUV.yMax;

        // Starting quad for the sprite
        Vector2[] xy = new Vector2[4];
        Vector2[] uv = new Vector2[4];

        //사각형하나 순서는 
        //        3           0
        //        2           1
        xy[0] = new Vector2(x1, y0);
        xy[1] = new Vector2(x1, y1);
        xy[2] = new Vector2(x0, y1);
        xy[3] = new Vector2(x0, y0);

        //이것도 동일하다
        //       3            0
        //       2            1
        uv[0] = new Vector2(u1, v1);
        uv[1] = new Vector2(u1, v0);
        uv[2] = new Vector2(u0, v0);
        uv[3] = new Vector2(u0, v1);

        if (fillDirection == FillDirection.Radial360)
        {
            float[] matrix = new float[]
         			{
         				// x0 y0  x1   y1
         				0.5f, 1f, 0f, 0.5f, // quadrant 0
         				0.5f, 1f, 0.5f, 1f, // quadrant 1
         				0f, 0.5f, 0.5f, 1f, // quadrant 2
         				0f, 0.5f, 0f, 0.5f, // quadrant 3
         			};

            Vector2[] oxy = new Vector2[4];
            Vector2[] ouv = new Vector2[4];

            for (int i = 0; i < 4; ++i)
            {
                oxy[0] = new Vector2(0f, 0f);
                oxy[1] = new Vector2(0f, 1f);
                oxy[2] = new Vector2(1f, 1f);
                oxy[3] = new Vector2(1f, 0f);

                ouv[0] = new Vector2(0f, 0f);
                ouv[1] = new Vector2(0f, 1f);
                ouv[2] = new Vector2(1f, 1f);
                ouv[3] = new Vector2(1f, 0f);

                if (i < 3)
                {
                    Rotate(oxy, 3 - i);
                    Rotate(ouv, 3 - i);
                }

                // Each quadrant must fill in only a quarter of the space
                for (int b = 0; b < 4; ++b)
                {
                    int index = i * 4;

                    float fx0 = matrix[index];
                    float fy0 = matrix[index + 1];
                    float fx1 = matrix[index + 2];
                    float fy1 = matrix[index + 3];

                    oxy[b].x = Mathf.Lerp(fx0, fy0, oxy[b].x);
                    oxy[b].y = Mathf.Lerp(fx1, fy1, oxy[b].y);
                    ouv[b].x = Mathf.Lerp(fx0, fy0, ouv[b].x);
                    ouv[b].y = Mathf.Lerp(fx1, fy1, ouv[b].y);
                }

                float amount = (fillAmount) * 4 - i;
                bool odd = (i % 2) == 1;

                if (AdjustRadial(oxy, ouv, amount, !odd))
                {
                    // Add every other side in reverse order so they don't come out backface-culled due to rotation
                    if (odd)
                    {
                        for (int b = 0; b < 4; ++b)
                        {
                            float x = Mathf.Lerp(xy[0].x, xy[2].x, oxy[b].x);
                            float y = Mathf.Lerp(xy[0].y, xy[2].y, oxy[b].y);
                            float u = Mathf.Lerp(uv[0].x, uv[2].x, ouv[b].x);
                            float v = Mathf.Lerp(uv[0].y, uv[2].y, ouv[b].y);

                            verts.Add(new Vector3(x, y, 0f));
                            uvs.Add(new Vector2(u, v));
                            cols.Add(color);
                        }
                    }
                    else
                    {
                        for (int b = 3; b > -1; --b)
                        {
                            float x = Mathf.Lerp(xy[0].x, xy[2].x, oxy[b].x);
                            float y = Mathf.Lerp(xy[0].y, xy[2].y, oxy[b].y);
                            float u = Mathf.Lerp(uv[0].x, uv[2].x, ouv[b].x);
                            float v = Mathf.Lerp(uv[0].y, uv[2].y, ouv[b].y);

                            verts.Add(new Vector3(x, y, 0f));
                            uvs.Add(new Vector2(u, v));
                            cols.Add(color);
                        }
                    }
                }
            }
            return;

        }
    }
}
