// Shader created with Shader Forge v1.38 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:3138,x:33836,y:32699,varname:node_3138,prsc:2|emission-8112-OUT,alpha-7279-OUT;n:type:ShaderForge.SFN_Color,id:7241,x:32287,y:32544,ptovrint:False,ptlb:BottomColor,ptin:_BottomColor,varname:node_7241,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.9393788,c2:0.9433962,c3:0.6808473,c4:1;n:type:ShaderForge.SFN_TexCoord,id:4280,x:31144,y:32941,varname:node_4280,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Abs,id:6286,x:31617,y:32734,varname:node_6286,prsc:2|IN-4280-V;n:type:ShaderForge.SFN_Subtract,id:4822,x:32515,y:32929,varname:node_4822,prsc:2|A-7012-OUT,B-4591-OUT;n:type:ShaderForge.SFN_Clamp01,id:4591,x:32301,y:32945,varname:node_4591,prsc:2|IN-4916-OUT;n:type:ShaderForge.SFN_Power,id:4916,x:32115,y:32945,varname:node_4916,prsc:2|VAL-4280-V,EXP-5081-OUT;n:type:ShaderForge.SFN_Slider,id:5081,x:31699,y:33013,ptovrint:False,ptlb:Top_Fade,ptin:_Top_Fade,varname:node_5081,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:5,max:5;n:type:ShaderForge.SFN_OneMinus,id:8752,x:31593,y:33222,varname:node_8752,prsc:2|IN-4280-U;n:type:ShaderForge.SFN_Subtract,id:1979,x:31821,y:33244,varname:node_1979,prsc:2|A-8752-OUT,B-7397-OUT;n:type:ShaderForge.SFN_Vector1,id:7397,x:31593,y:33341,varname:node_7397,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Subtract,id:3976,x:31821,y:33119,varname:node_3976,prsc:2|A-4280-U,B-7397-OUT;n:type:ShaderForge.SFN_Add,id:5922,x:32169,y:33123,varname:node_5922,prsc:2|A-1806-OUT,B-850-OUT;n:type:ShaderForge.SFN_Clamp01,id:1806,x:31993,y:33123,varname:node_1806,prsc:2|IN-3976-OUT;n:type:ShaderForge.SFN_Clamp01,id:850,x:31993,y:33244,varname:node_850,prsc:2|IN-1979-OUT;n:type:ShaderForge.SFN_Subtract,id:7835,x:32694,y:32964,varname:node_7835,prsc:2|A-4822-OUT,B-9427-OUT;n:type:ShaderForge.SFN_Lerp,id:8112,x:32915,y:32571,varname:node_8112,prsc:2|A-7241-RGB,B-8779-RGB,T-190-OUT;n:type:ShaderForge.SFN_Color,id:8779,x:32455,y:32291,ptovrint:False,ptlb:TopColor,ptin:_TopColor,varname:node_8779,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Power,id:9427,x:32515,y:33056,varname:node_9427,prsc:2|VAL-8922-OUT,EXP-5616-OUT;n:type:ShaderForge.SFN_Vector1,id:4876,x:32169,y:33244,varname:node_4876,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Add,id:8922,x:32339,y:33123,varname:node_8922,prsc:2|A-5922-OUT,B-4876-OUT;n:type:ShaderForge.SFN_Power,id:5700,x:31943,y:32771,varname:node_5700,prsc:2|VAL-6286-OUT,EXP-4815-OUT;n:type:ShaderForge.SFN_Slider,id:4815,x:31617,y:32900,ptovrint:False,ptlb:BottomFade,ptin:_BottomFade,varname:node_4815,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1.7,max:5;n:type:ShaderForge.SFN_Slider,id:5616,x:32182,y:33324,ptovrint:False,ptlb:SideFade,ptin:_SideFade,varname:node_5616,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:12.08984,max:30;n:type:ShaderForge.SFN_OneMinus,id:4997,x:32896,y:33116,varname:node_4997,prsc:2|IN-7835-OUT;n:type:ShaderForge.SFN_Add,id:5058,x:32915,y:32964,varname:node_5058,prsc:2|A-7835-OUT,B-1618-OUT;n:type:ShaderForge.SFN_Vector1,id:1618,x:32694,y:33116,varname:node_1618,prsc:2,v1:1;n:type:ShaderForge.SFN_Subtract,id:3406,x:33093,y:32984,varname:node_3406,prsc:2|A-5058-OUT,B-4997-OUT;n:type:ShaderForge.SFN_Add,id:190,x:32655,y:32634,varname:node_190,prsc:2|A-5700-OUT,B-6624-OUT;n:type:ShaderForge.SFN_Slider,id:6624,x:32337,y:32734,ptovrint:False,ptlb:TopColorBlend,ptin:_TopColorBlend,varname:node_6624,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Sin,id:3399,x:30674,y:32445,varname:node_3399,prsc:2|IN-2768-OUT;n:type:ShaderForge.SFN_Time,id:475,x:30148,y:32530,varname:node_475,prsc:2;n:type:ShaderForge.SFN_Multiply,id:2314,x:31578,y:32521,varname:node_2314,prsc:2|A-7471-OUT,B-2626-OUT;n:type:ShaderForge.SFN_Slider,id:2626,x:30901,y:32698,ptovrint:False,ptlb:FadeInfluence,ptin:_FadeInfluence,varname:node_2626,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_Divide,id:183,x:31058,y:32485,varname:node_183,prsc:2|A-1841-OUT,B-3085-OUT;n:type:ShaderForge.SFN_Vector1,id:3085,x:30880,y:32547,varname:node_3085,prsc:2,v1:4;n:type:ShaderForge.SFN_Add,id:1195,x:31237,y:32485,varname:node_1195,prsc:2|A-183-OUT,B-2796-OUT;n:type:ShaderForge.SFN_Vector1,id:2796,x:31058,y:32608,varname:node_2796,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Subtract,id:7012,x:32140,y:32771,varname:node_7012,prsc:2|A-5700-OUT,B-2314-OUT;n:type:ShaderForge.SFN_FragmentPosition,id:9762,x:29602,y:32333,varname:node_9762,prsc:2;n:type:ShaderForge.SFN_Noise,id:945,x:30008,y:32189,varname:node_945,prsc:2|XY-3498-OUT;n:type:ShaderForge.SFN_Append,id:3498,x:29826,y:32189,varname:node_3498,prsc:2|A-4647-X,B-9762-Z;n:type:ShaderForge.SFN_ObjectScale,id:4647,x:29602,y:32189,varname:node_4647,prsc:2,rcp:False;n:type:ShaderForge.SFN_Clamp01,id:9735,x:30416,y:32189,varname:node_9735,prsc:2|IN-5659-OUT;n:type:ShaderForge.SFN_Noise,id:4935,x:30008,y:32333,varname:node_4935,prsc:2|XY-6085-OUT;n:type:ShaderForge.SFN_Append,id:6085,x:29826,y:32333,varname:node_6085,prsc:2|A-9762-Y,B-9762-X;n:type:ShaderForge.SFN_Subtract,id:5659,x:30231,y:32189,varname:node_5659,prsc:2|A-945-OUT,B-4935-OUT;n:type:ShaderForge.SFN_Add,id:2768,x:30518,y:32445,varname:node_2768,prsc:2|A-9056-OUT,B-9762-X;n:type:ShaderForge.SFN_Add,id:2475,x:30347,y:32684,varname:node_2475,prsc:2|A-475-TTR,B-9762-X;n:type:ShaderForge.SFN_Sin,id:3755,x:30674,y:32581,varname:node_3755,prsc:2|IN-2475-OUT;n:type:ShaderForge.SFN_OneMinus,id:9056,x:30347,y:32445,varname:node_9056,prsc:2|IN-475-T;n:type:ShaderForge.SFN_Add,id:1841,x:30880,y:32423,varname:node_1841,prsc:2|A-3399-OUT,B-3755-OUT;n:type:ShaderForge.SFN_Multiply,id:580,x:30761,y:32287,varname:node_580,prsc:2|A-9735-OUT,B-8273-OUT;n:type:ShaderForge.SFN_Slider,id:8273,x:30395,y:32349,ptovrint:False,ptlb:NoiseInfluence,ptin:_NoiseInfluence,varname:node_8273,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Subtract,id:7471,x:31398,y:32420,varname:node_7471,prsc:2|A-1195-OUT,B-580-OUT;n:type:ShaderForge.SFN_Slider,id:7566,x:33078,y:33278,ptovrint:False,ptlb:OverallTransparencyAdjustment,ptin:_OverallTransparencyAdjustment,varname:node_7566,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_Clamp,id:7279,x:33405,y:32970,varname:node_7279,prsc:2|IN-3406-OUT,MIN-7943-OUT,MAX-7566-OUT;n:type:ShaderForge.SFN_Vector1,id:7943,x:33126,y:33150,varname:node_7943,prsc:2,v1:0;proporder:8779-7241-5081-4815-5616-6624-2626-8273-7566;pass:END;sub:END;*/

Shader "Shader Forge/LightShafts" {
    Properties {
        _TopColor ("TopColor", Color) = (1,1,1,1)
        _BottomColor ("BottomColor", Color) = (0.9393788,0.9433962,0.6808473,1)
        _Top_Fade ("Top_Fade", Range(0, 5)) = 5
        _BottomFade ("BottomFade", Range(0, 5)) = 1.7
        _SideFade ("SideFade", Range(0, 30)) = 12.08984
        _TopColorBlend ("TopColorBlend", Range(0, 1)) = 0
        _FadeInfluence ("FadeInfluence", Range(0, 1)) = 1
        _NoiseInfluence ("NoiseInfluence", Range(0, 1)) = 0
        _OverallTransparencyAdjustment ("OverallTransparencyAdjustment", Range(0, 1)) = 1
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float4 _BottomColor;
            uniform float _Top_Fade;
            uniform float4 _TopColor;
            uniform float _BottomFade;
            uniform float _SideFade;
            uniform float _TopColorBlend;
            uniform float _FadeInfluence;
            uniform float _NoiseInfluence;
            uniform float _OverallTransparencyAdjustment;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                float3 recipObjScale = float3( length(unity_WorldToObject[0].xyz), length(unity_WorldToObject[1].xyz), length(unity_WorldToObject[2].xyz) );
                float3 objScale = 1.0/recipObjScale;
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float3 recipObjScale = float3( length(unity_WorldToObject[0].xyz), length(unity_WorldToObject[1].xyz), length(unity_WorldToObject[2].xyz) );
                float3 objScale = 1.0/recipObjScale;
////// Lighting:
////// Emissive:
                float node_5700 = pow(abs(i.uv0.g),_BottomFade);
                float3 emissive = lerp(_BottomColor.rgb,_TopColor.rgb,(node_5700+_TopColorBlend));
                float3 finalColor = emissive;
                float4 node_475 = _Time;
                float node_9056 = (1.0 - node_475.g);
                float node_2768 = (node_9056+i.posWorld.r);
                float node_3399 = sin(node_2768);
                float node_2475 = (node_475.a+i.posWorld.r);
                float2 node_3498 = float2(objScale.r,i.posWorld.b);
                float2 node_945_skew = node_3498 + 0.2127+node_3498.x*0.3713*node_3498.y;
                float2 node_945_rnd = 4.789*sin(489.123*(node_945_skew));
                float node_945 = frac(node_945_rnd.x*node_945_rnd.y*(1+node_945_skew.x));
                float2 node_6085 = float2(i.posWorld.g,i.posWorld.r);
                float2 node_4935_skew = node_6085 + 0.2127+node_6085.x*0.3713*node_6085.y;
                float2 node_4935_rnd = 4.789*sin(489.123*(node_4935_skew));
                float node_4935 = frac(node_4935_rnd.x*node_4935_rnd.y*(1+node_4935_skew.x));
                float node_9735 = saturate((node_945-node_4935));
                float node_7397 = 0.5;
                float node_7835 = (((node_5700-(((((node_3399+sin(node_2475))/4.0)+0.5)-(node_9735*_NoiseInfluence))*_FadeInfluence))-saturate(pow(i.uv0.g,_Top_Fade)))-pow(((saturate((i.uv0.r-node_7397))+saturate(((1.0 - i.uv0.r)-node_7397)))+0.5),_SideFade));
                float node_3406 = ((node_7835+1.0)-(1.0 - node_7835));
                float node_7279 = clamp(node_3406,0.0,_OverallTransparencyAdjustment);
                return fixed4(finalColor,node_7279);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
