using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

//Realizado por: Mariana Alejandra Pimienta Hernandez - Ingeniería de Software 12a
public class Guia4 : MonoBehaviour
{
    Texture2D tex;
    float Height = 280, Width = 280;

    static readonly Stopwatch timer = new Stopwatch();

    void Start()
    {
        float l1 = Width / 8;
        float l2 = Width / 8;
        float l3 = Width / 12;

        Color BackColor = new Color(0,0,0,1);
        Setup (Height, Width, BackColor);
        Color color1 = new Color(0,0,1,1);
        Color color2 = new Color(0,1,0,1);
        Color color3 = new Color(1,0,0,1);

        // Método 1 --> Triángulo Azul
        
        int x1t = 5, x2t = 20, x3t = 35;
        int y1t = 5, y2t = 30, y3t = 5;

        for (int i = 1; i <= 2; i++) {

            Triangulo1(x1t, y1t, x2t, y2t, x3t, y3t, color1);

            if (i > 1){
                x1t += 45;
                x2t += 45;
                x3t += 45;
            }
        }

        pinta(15.0f, 17.0f, color1, color2);

        // Método 1 --> Rectangulo Azul

        int x1c = 5, x2c = 5, x3c = 25, x4c = 25;
        int y1c = 105, y2c = 125, y3c = 105, y4c = 125;

        for(int i = 1; i <= 2; i++){

            Rectangulo1(x1c, y1c, x2c, y2c, x3c, y3c, x4c, y4c, color1);

            if (i > 1){
                x1c += 25;
                x2c += 25;
                x3c += 25; 
                x4c += 25;
            }
        }

        pinta(6.0f, 106.0f, color1, color2);

        // Método 1 --> Pentágono

        int x1p = 15, x2p = 5, x3p = 25, x4p = 20, x5p = 10;
        int y1p = 200, y2p = 190, y3p = 190, y4p = 180, y5p = 180;
        
        for(int i = 1; i <= 2; i++){

            Pentagono1(x1p, y1p, x2p, y2p, x3p, y3p, x4p, y4p, x5p, y5p, color1);
            
            if (i > 1){
                x1p += 30;
                x2p += 30;
                x3p += 30;
                x4p += 30;
                x5p += 30;
            }
        }

        pinta(11.0f, 181.0f, color1, color2);

        // Método 1 --> Hexágono

        int x1h = 30, x2h = 20, x3h = 40, x4h = 20, x5h = 40, x6h = 30;
        int y1h = 245, y2h = 240, y3h = 240, y4h = 230, y5h = 230, y6h = 225;

        for(int i = 1; i <= 2; i++){
        
            Hexagono1(x1h, y1h, x2h, y2h, x3h, y3h, x4h, y4h, x5h, y5h, x6h, y6h, color1);

            if (i > 1){
                x1h += 30;
                x2h += 30;
                x3h += 30;
                x4h += 30; 
                x5h += 30;
                x6h += 30;
            }
        }

        pinta(30.0f, 235.0f, color1, color2);

        // Método Circunferencia

        Circunferencia(Height / 2.0f, Width / 1.3f, l1, color1);
        
        pinta((int)(Height / 2.0f), (int)(Width / 1.3f), color1, color2);

        // Método Elipse

        Elipse(Height / 2.0f, (Width - 45) / 2.0f, l2, l3, color1);

        //pinta(155, 84, color1, color2);
        pinta_eclipse(140, 117, color1, color2);


        tex.Apply();
       
    }

    void Setup(float H, float W, Color Back){
        tex = new Texture2D((int)H, (int)W);
        tex.filterMode = FilterMode.Point;
        
        GetComponent<Renderer>().material.mainTexture = tex;
        for (int y = 0; y < tex.height; y++)
        {
            for (int x = 0; x < tex.width; x++)
            {
                tex.SetPixel(x, y, Back); 
            }
        }
    }   
    
    void Abressenham(float x0, float y0, float x1, float y1, Color Line){   
        float w = x1-x0;
        float h = y1-y0;
        int dx1 = 0, dy1 = 0, dx2 = 0, dy2 = 0;
        if (w < 0) dx1 = -1;else if (w > 0) dx1 = 1;
        if (h < 0) dy1 = -1;else if (h > 0) dy1 = 1;
        if (w < 0) dx2 = -1;else if (w > 0) dx2 = 1;
        int longest = Mathf.Abs((int)w);
        int shortest = Mathf.Abs((int)h);
        if (!(longest > shortest))
        {   
            longest = Mathf.Abs((int)h);
            shortest = Mathf.Abs((int)w);
            if (h < 0) dy2 = -1;else if (h > 0) dy2 = 1;
            dx2 = 0;
        }
        
        int numerator = longest >> 1;
        float x = x0;
        float y = y0;
        for (int i = 0; i <= longest; i++)
        {
            tex.SetPixel((int)x, (int)y, Line);
            numerator += shortest;
            if (!(numerator < longest))
            {
                numerator -= longest;
                x += dx1;
                y += dy1;
            }else{
                x += dx2;
                y += dy2;
            }
        }
        
    }

    void Triangulo1(float x3, float y3,float x1, float y1, float x2, float y2, Color Line){
        Abressenham(x1, y1, x2, y2, Line);
        Abressenham(x2, y2, x3, y3, Line);
        Abressenham(x3, y3, x1, y1, Line);
    }
    
    void Rectangulo1(float x1, float y1, float x2, float y2,float x3, float y3, float x4, float y4, Color Line1){
       
        Abressenham(x1, y1, x2, y2, Line1);
        Abressenham(x2, y2, x4, y4, Line1);
        Abressenham(x4, y4, x3, y3, Line1);
        Abressenham(x1, y1, x3, y3, Line1);
    }
    
    void Pentagono1(float x1, float y1, float x2, float y2,float x3, float y3, float x4, float y4, float x5, float y5, Color Line1){
       
        Abressenham(x1, y1, x2, y2, Line1);
        Abressenham(x1, y1, x3, y3, Line1);
        Abressenham(x2, y2, x5, y5, Line1);
        Abressenham(x3, y3, x4, y4, Line1);
        Abressenham(x5, y5, x4, y4, Line1);

    }
    
    void Hexagono1(float x1, float y1, float x2, float y2,float x3, float y3, float x4, float y4, float x5, float y5,float x6, float y6, Color Line1){
       
        Abressenham(x1, y1, x2, y2, Line1);
        Abressenham(x1, y1, x3, y3, Line1);
        Abressenham(x2, y2, x4, y4, Line1);
        Abressenham(x3, y3, x5, y5, Line1);
        Abressenham(x4, y4, x6, y6, Line1);
        Abressenham(x5, y5, x6, y6, Line1);

    }

    void Circunferencia(float x0, float y0, float r, Color Line){
        // Y2 = r2 - X2

        float yb = 0, yc = 0;

        for(int x = 0; x <= r ; x++){
            
            float y = Mathf.Sqrt(Mathf.Pow(r,2) - Mathf.Pow(x,2));

            tex.SetPixel((int)(x0 + x), (int)(y0 + y), Line);

            tex.SetPixel((int)(x0 - x), (int)(y0 + y), Line);

            tex.SetPixel((int)(x0 + x), (int)(y0 - y), Line);

            tex.SetPixel((int)(x0 - x), (int)(y0 - y), Line);

            yc = y - yb;

            if(Mathf.Abs(yc) > 1 && x > 0){

                Abressenham((x0 + x), yb + y0, (x0 + x), y + y0, Line);

                Abressenham((x0 - x), yb + y0, (x0 - x), y + y0, Line);

                Abressenham((x0 + x), y0 - yb, (x0 + x), y0 - y, Line);

                Abressenham((x0 - x), y0 - yb, (x0 - x), y0 - y, Line);

            }

            yb = y; 
        }
    }

    void Elipse(float x0, float y0, float rx, float ry, Color Line){

        float xb = 0, yb = 0;
        for(float x = 0.5f; x < 360.0f; x+=0.5f){
            xb = x0 + (rx * Mathf.Cos(x * Mathf.Deg2Rad));
            yb = y0 + (ry * Mathf.Sin(x * Mathf.Deg2Rad));

            print(xb + " - " + yb);

            tex.SetPixel((int)(xb), (int)(yb), Line);
        }

    }
    
    void pinta(float x, float y, Color rellenoColor, Color lineaColor) {
        if (x < 0.0f || y < 0.0f || x >= tex.width || y >= tex.height) {
            return;
        }
        if (tex.GetPixel((int)x, (int)y) == lineaColor || tex.GetPixel((int)x, (int)y) == rellenoColor ) {
            return;
        }
        
        tex.SetPixel((int)x, (int)y, lineaColor);
        pinta((x - 1), y, rellenoColor, lineaColor);
        pinta((x + 1), y, rellenoColor, lineaColor);
        pinta(x, (y - 1), rellenoColor, lineaColor);
        pinta(x, (y + 1), rellenoColor, lineaColor);
        tex.Apply();
    }

    void pinta_eclipse(int x, int y, Color rellenoColor, Color lineaColor) {
        if (x < 0 || y < 0 || x >= tex.width || y >= tex.height) {
            return;
        }
        if (tex.GetPixel(x, y) == lineaColor || tex.GetPixel(x, y) == rellenoColor ) {
            return;
        }
        else if(y >= 215 ){
            tex.SetPixel(x, y, lineaColor);
        }

        print (x + "-" + y);

        pinta((x - 1), y, rellenoColor, lineaColor);
        pinta((x + 1), y, rellenoColor, lineaColor);
        pinta(x, (y - 1), rellenoColor, lineaColor);
        pinta(x, (y + 1), rellenoColor, lineaColor);
        tex.Apply();
    }
}
