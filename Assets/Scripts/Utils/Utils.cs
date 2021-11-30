using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public static class Utils
{
    public static bool Vector3Equal(Vector3 v1, Vector3 v2, float allowedError = 0.001f)
    {
        float dist = Vector3.Distance(v1, v2);
        if (dist < allowedError)
        {
            return true;
        }
        return false;
    }

    public static bool Vector2Equal(Vector2 v1, Vector2 v2, float allowedError = 0.001f)
    {
        float dist = Vector2.Distance(v1, v2);
        if (dist < allowedError)
        {
            return true;
        }
        return false;
    }

    public static bool FloatEquals(float f1, float f2, float allowedError = 0.001f)
    {
        float diff = Mathf.Abs(f2 - f2);
        if (diff < allowedError)
        {
            return true;
        }
        return false;
    }


    public static List<int> CopyIntList(List<int> orig)
    {
        List<int> newList = new List<int>();
        foreach (int i in orig)
        {
            newList.Add(i);
        }

        return newList;
    }


    public static int IntMax(int n1, int n2)
    {
        if (n1 >= n2)
        {
            return n1;
        }
        else 
        {
            return n2;
        }
    }
    public static float FloatMax(float n1, float n2)
    {
        if (n1 >= n2)
        {
            return n1;
        }
        else 
        {
            return n2;
        }
    }

    public static bool GetRandBool()
    {
        int randNum = Random.Range(0, 2);

        if (randNum == 0)
        {
            return true;
        }
        else 
        {
            return false;
        }
    }
    public static Vector3 GetDirBetween(Vector3 dir1, Vector3 dir2)
    { //Dir between right angle formed by dir1 and dir2
        Vector3 newDir = Vector3.zero;
        newDir += dir1/2;
        newDir += dir2/2;

        return newDir;
    }

    public static Vector3 GetPerpendicularVector(Vector3 orig)
    {
        Vector2 tmp = Utils.Vector3_to_vector2(orig, "y");
        tmp = Vector2.Perpendicular(tmp);
        return Utils.Vector2_to_vector3(tmp, "y", 0.0f);
    }

    public static Vector2 Vector3_to_vector2(Vector3 orig, string dropAxis)
    {
        if (dropAxis == "y"){
            return new Vector2(orig.x, orig.z);
        }
        if (dropAxis== "x"){
            return new Vector2(orig.y, orig.z);
        }
        else {
            return new Vector2(orig.x, orig.y);
        }
    }

    public static Vector3 Vector2_to_vector3(Vector2 orig, string addAxis, float fillWith)
    {
        if (addAxis == "y"){
            return new Vector3(orig.x, fillWith, orig.y);
        }
        if (addAxis== "x"){
            return new Vector3(fillWith, orig.x, orig.y);
        }
        else {
            return new Vector3(orig.x, orig.y, fillWith);
        }
    }


    public static void PrintFloatList(List<float> l)
    {
        string concat = "";
        for (int i = 0; i < l.Count; i++){
            concat += l[i] + ", ";
        }
        Debug.Log(concat);
    }

    public static Vector3 vect(float val)
    {
        return new Vector3(val, val, val);
    }

    public static Color GetColor(string hex, double alpha = 1)
    {

        Color newCol;
        ColorUtility.TryParseHtmlString("#"+hex, out newCol);

        newCol.a = (float)alpha;

        return newCol;
    }


    public static void MirrorRef(GameObject _obj, GameObject _ref)
    {
        _obj.transform.parent = _ref.transform.parent;
        _obj.transform.localScale = _ref.transform.localScale;
        _obj.transform.localEulerAngles = _ref.transform.localEulerAngles;
        _obj.transform.localPosition = _ref.transform.localPosition;
    }

    public static int FlipACoin()    
    {         
        return UnityEngine.Random.Range(0, 2);
    }
    public static int StringToInt(string str)
    {
        int num = 0;
        bool success = System.Int32.TryParse(str, out num);
        if (!success)
        {
            Debug.LogError("Failed to convert string to int. Returning 0");
        }

        return num;
    }

    public static string IntToString(int num)
    {
        return num.ToString();
    }

    public static string FloatToString(float num)
    {
        return num.ToString();
    }

    public static IEnumerator C_ScaleOutGameObject(GameObject go, float scaleRate)
    {
        while (go.transform.localScale.x > 0)
        {
            go.transform.localScale -= new Vector3(scaleRate * Time.deltaTime, scaleRate * Time.deltaTime, scaleRate * Time.deltaTime);
            yield return null;
        }
    }

    public static IEnumerator C_FadeCanvasGroup(CanvasGroup canvasGroup, float fadeRate, bool fadeOut)
    {
        if (fadeOut)
        {
            while (canvasGroup.alpha > 0)
            {
                canvasGroup.alpha -= (fadeRate * Time.deltaTime);
                yield return null;
            }
            canvasGroup.gameObject.SetActive(false);
        }
        else 
        {
            canvasGroup.gameObject.SetActive(true);
            while (canvasGroup.alpha < 1)
            {
                canvasGroup.alpha += (fadeRate * Time.deltaTime);
                yield return null;
            }
        }
    }

    public static IEnumerator C_PulseGameObject(GameObject element, float expandRate, float shrinkRate, float popSize, Vector3 originalScale)
    {
        bool expanding = true;
        element.transform.localScale = originalScale;
        bool finished = false;
        // Debug.Log("Pop rate: " + expandRate);
        while (!finished)
        {
            if (expanding)
            {
                element.transform.localScale += new Vector3(expandRate * Time.deltaTime, expandRate * Time.deltaTime, expandRate * Time.deltaTime);
                if (element.transform.localScale.x >= popSize)
                {
                    element.transform.localScale = new Vector3(popSize, popSize, popSize);
                    expanding = false;
                }
            }
            else 
            {
                element.transform.localScale -= new Vector3(shrinkRate * Time.deltaTime, shrinkRate * Time.deltaTime, shrinkRate * Time.deltaTime);
                if (element.transform.localScale.x <= originalScale.x)
                {
                    finished = true;
                    expanding = true;
                    element.transform.localScale = originalScale;
                }
            }
            // Debug.Log("Target: " + popSize + " current: " + element.transform.localScale.x);
            yield return null;
        }
    }

    public static IEnumerator C_ReversePulseGameObject(GameObject element, float shrinkRate, float expandRate, float targetScale, Vector3 originalScale)
    {
        bool shrinking = true;
        element.transform.localScale = originalScale;
        bool finished = false;
        // Debug.Log("Pop rate: " + expandRate);
        while (!finished)
        {
            if (shrinking)
            {
                element.transform.localScale -= new Vector3(shrinkRate, shrinkRate, shrinkRate);
                if (element.transform.localScale.x <= targetScale)
                {
                    element.transform.localScale = new Vector3(targetScale, targetScale, targetScale);
                    shrinking = false;
                }
            }
            else 
            {
                element.transform.localScale += new Vector3(expandRate, expandRate, expandRate);
                if (element.transform.localScale.x >= originalScale.x)
                {
                    finished = true;
                    shrinking = true;
                    element.transform.localScale = originalScale;
                }
            }
            // Debug.Log("Target: " + popSize + " current: " + element.transform.localScale.x);
            yield return null;
        }
    }

    public static float GetVector3Value(Vector3 v, string axis)
    {
        if (axis == "x")
        {
            return v.x;
        }
        else if (axis == "y")
        {
            return v.y;
        }
        else 
        {
            return v.z;
        }
    }

    public static void MatchChildrenMaterial(GameObject parent, Material mat)
    {
        for (int i = 0; i < parent.transform.childCount; i++)
        {
            GameObject child = parent.transform.GetChild(i).gameObject;
            Renderer rend = child.GetComponent<Renderer>();
            rend.material = mat;
        }
    }

    public static void ChangeParticleSystemColor(ParticleSystem ps, Color c) //Change all particle systems (children too) color
    {
        var main = ps.main;
        main.startColor = new Color(c.r, c.g, c.b, 1);

        for (int i = 0; i < ps.transform.childCount; i++)
        {
            ParticleSystem childPS = ps.transform.GetChild(i).GetComponent<ParticleSystem>();
            if (childPS)
            {
                var childMain = childPS.main;
                childMain.startColor = new Color(c.r, c.g, c.b, 1);
            }
        }
    }

    public static void ChangeColorOfChildRecursively(GameObject parent, Color c) //Recurse through all children and change color
    {
        Renderer rend = parent.GetComponent<Renderer>();
        if (rend)
        {
            rend.material.color = c;
        }

        for (int i = 0; i < parent.transform.childCount; i++)
        {
            ChangeColorOfChildRecursively(parent.transform.GetChild(i).gameObject, c);
        }

    }

    public static Color GetMaterialColor(GameObject go) //Only main material
    {
        Renderer rend = go.GetComponent<Renderer>();
        if (rend)
        {
            return rend.material.color;
        }

        Debug.LogError("Failed to Grab Material Color. Returning White.");
        return Color.white;
    }

    public static void MatchColors(GameObject go1, GameObject go2)
    {
        Renderer rend1 = go1.GetComponent<Renderer>();
        Color color = rend1.material.color;

        Renderer rend2 = go2.GetComponent<Renderer>();
        rend2.material.color = color;
    }

    public static Vector2 GetScreenXBounds(float atZ)
    {
        Vector3 otherPoint = Camera.main.transform.position;
        otherPoint.z = atZ;
        float camDistance = Vector3.Distance(otherPoint, Camera.main.transform.position);

        Vector2 bottomCorner = Camera.main.ViewportToWorldPoint(new Vector3(0,0, camDistance));
        Vector2 topCorner = Camera.main.ViewportToWorldPoint(new Vector3(1,1, camDistance));

        return new Vector2(bottomCorner.x, topCorner.x);
    }

    public static Vector2 GetScreenYBounds(float atZ)
    {
        Vector3 otherPoint = Camera.main.transform.position;
        otherPoint.z = atZ;
        float camDistance = Vector3.Distance(otherPoint, Camera.main.transform.position);

        Vector2 bottomCorner = Camera.main.ViewportToWorldPoint(new Vector3(0,0, camDistance));
        Vector2 topCorner = Camera.main.ViewportToWorldPoint(new Vector3(1,1, camDistance));

        return new Vector2(bottomCorner.y, topCorner.y);
    }
    public static IEnumerator C_AlphaPulseUIInfinite(CanvasGroup cg, float rate, float minAlpha)
    {
        float currentIncriment = -rate;
        while (true)
        {
            if (cg.alpha < minAlpha && currentIncriment < 0)
            {
                currentIncriment = rate;
            }
            if (cg.alpha >= 1 && currentIncriment > 0)
            {
                currentIncriment = -rate;
            }

            cg.alpha += currentIncriment;
            yield return null;
        }
    }

    public static IEnumerator C_SizePulseInfinite(GameObject element, float rate, float minScale, float maxScale)
    {
        if (!element.activeInHierarchy){ yield return null; }
        float currentIncriment = rate;
        Transform t = element.transform;
        Debug.Log("Entering with scale: " + t.localScale);
        Debug.Log("Entering incriment: " + currentIncriment);
        while (true)
        {
            if (t.localScale.x < minScale && currentIncriment < 0)
            {
                currentIncriment = rate;
            }
            if (t.localScale.x >= maxScale && currentIncriment > 0)
            {
                currentIncriment = -rate;
            }
            t.localScale += new Vector3(currentIncriment, currentIncriment, currentIncriment);
            yield return null;
        }
    }

    public static void ToOpaqueMode(this Material material)
    {
        material.SetOverrideTag("RenderType", "");
        material.SetInt("_SrcBlend", (int) UnityEngine.Rendering.BlendMode.One);
        material.SetInt("_DstBlend", (int) UnityEngine.Rendering.BlendMode.Zero);
        material.SetInt("_ZWrite", 1);
        material.DisableKeyword("_ALPHATEST_ON");
        material.DisableKeyword("_ALPHABLEND_ON");
        material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
        material.renderQueue = -1;
    }
   
    public static void ToFadeMode(this Material material)
    {
        material.SetOverrideTag("RenderType", "Transparent");
        material.SetInt("_SrcBlend", (int) UnityEngine.Rendering.BlendMode.SrcAlpha);
        material.SetInt("_DstBlend", (int) UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
        material.SetInt("_ZWrite", 0);
        material.DisableKeyword("_ALPHATEST_ON");
        material.EnableKeyword("_ALPHABLEND_ON");
        material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
        material.renderQueue = (int) UnityEngine.Rendering.RenderQueue.Transparent;
    }

    //Appends material to renderer that tints the original material
    public static void ApplyTintOverlay(Renderer rend, Color color)
    {
        Material tintMat = new Material(Shader.Find("Transparent/Diffuse"));
        tintMat.color = color;
        List<Material> origMats = rend.materials.ToList();
        origMats.Add(tintMat);
        rend.materials = origMats.ToArray();
    }

    public static IEnumerator C_FadeOutTintOverlay(Renderer rend, float rate)
    {
        Material tintMat = rend.materials[rend.materials.Length-1];
        while (tintMat.color.a > 0)
        {
            tintMat.color = new Color(tintMat.color.r, tintMat.color.g, tintMat.color.b, tintMat.color.a - (rate * Time.deltaTime));
            yield return null;
        }
        List<Material> mats = rend.materials.ToList();
        mats.RemoveAt(mats.Count-1);
        rend.materials = mats.ToArray();

    }

    public static Vector2 CenterOfTwoPoints(Vector2 p1, Vector2 p2)
    {
        return new Vector2 ((p1.x + p2.x)/2, (p1.y + p2.y)/2);
    }

    public static bool IsPointInCameraView(Vector3 point)
    {
		Vector3 viewPortPoint = Camera.main.WorldToViewportPoint(point);
        return viewPortPoint.x > 0 && viewPortPoint.x < 1 && viewPortPoint.y > 0 && viewPortPoint.y < 1;
    }

    public static GameObject PlaceDebugBlock(Vector3 atPos)
    {
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.position = atPos;
        return cube;
    }
}