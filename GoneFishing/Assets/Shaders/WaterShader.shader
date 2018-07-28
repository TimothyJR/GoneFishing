// Shader created with Shader Forge v1.38 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:1,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:3138,x:35178,y:32836,varname:node_3138,prsc:2|emission-2162-OUT,alpha-6980-OUT;n:type:ShaderForge.SFN_Color,id:7241,x:32023,y:32528,ptovrint:False,ptlb:WaterColor,ptin:_WaterColor,varname:node_7241,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.6829388,c2:0.8112763,c3:0.9716981,c4:1;n:type:ShaderForge.SFN_Color,id:4229,x:32023,y:32692,ptovrint:False,ptlb:DeepWaterColor,ptin:_DeepWaterColor,varname:node_4229,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.1455144,c2:0.1683492,c3:0.2830189,c4:1;n:type:ShaderForge.SFN_Abs,id:8777,x:32019,y:32859,varname:node_8777,prsc:2|IN-5489-V;n:type:ShaderForge.SFN_Lerp,id:6942,x:32647,y:32628,varname:node_6942,prsc:2|A-4229-RGB,B-7241-RGB,T-8881-OUT;n:type:ShaderForge.SFN_TexCoord,id:5489,x:31836,y:32849,varname:node_5489,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Clamp01,id:8881,x:32461,y:32708,varname:node_8881,prsc:2|IN-7069-OUT;n:type:ShaderForge.SFN_Multiply,id:7069,x:32234,y:32767,varname:node_7069,prsc:2|A-8777-OUT,B-7475-OUT;n:type:ShaderForge.SFN_Slider,id:7475,x:31862,y:33040,ptovrint:False,ptlb:DepthColor,ptin:_DepthColor,varname:node_7475,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:2,max:2;n:type:ShaderForge.SFN_Subtract,id:3474,x:32615,y:33010,varname:node_3474,prsc:2|A-2358-OUT,B-5391-OUT;n:type:ShaderForge.SFN_Slider,id:5391,x:32260,y:33097,ptovrint:False,ptlb:ShoreColor,ptin:_ShoreColor,varname:node_5391,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1.11009,max:2;n:type:ShaderForge.SFN_Lerp,id:3585,x:32904,y:32689,varname:node_3585,prsc:2|A-6942-OUT,B-3349-RGB,T-9703-OUT;n:type:ShaderForge.SFN_Color,id:3349,x:32623,y:32790,ptovrint:False,ptlb:WaterShoreColor,ptin:_WaterShoreColor,varname:node_3349,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.6944642,c2:0.9622642,c3:0.8602265,c4:1;n:type:ShaderForge.SFN_Clamp01,id:9703,x:32790,y:32892,varname:node_9703,prsc:2|IN-3474-OUT;n:type:ShaderForge.SFN_Multiply,id:2358,x:32417,y:32940,varname:node_2358,prsc:2|A-8777-OUT,B-2621-OUT;n:type:ShaderForge.SFN_Vector1,id:2621,x:32234,y:32974,varname:node_2621,prsc:2,v1:2;n:type:ShaderForge.SFN_Multiply,id:6732,x:32615,y:33148,varname:node_6732,prsc:2|A-8777-OUT,B-9353-OUT;n:type:ShaderForge.SFN_Vector1,id:9353,x:32417,y:33194,varname:node_9353,prsc:2,v1:100;n:type:ShaderForge.SFN_Subtract,id:2456,x:32818,y:33161,varname:node_2456,prsc:2|A-6732-OUT,B-2712-OUT;n:type:ShaderForge.SFN_Clamp01,id:2389,x:33010,y:33081,varname:node_2389,prsc:2|IN-2456-OUT;n:type:ShaderForge.SFN_Slider,id:2712,x:32458,y:33296,ptovrint:False,ptlb:WaterLineWidth,ptin:_WaterLineWidth,varname:node_2712,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:96.14884,max:100;n:type:ShaderForge.SFN_Lerp,id:5090,x:33232,y:32807,varname:node_5090,prsc:2|A-3585-OUT,B-8751-RGB,T-2389-OUT;n:type:ShaderForge.SFN_Color,id:8751,x:32992,y:32852,ptovrint:False,ptlb:WaterLineColor,ptin:_WaterLineColor,varname:node_8751,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.873754,c2:0.9844766,c3:0.990566,c4:1;n:type:ShaderForge.SFN_Slider,id:6980,x:34358,y:33212,ptovrint:False,ptlb:WaterOpacity,ptin:_WaterOpacity,varname:node_6980,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_Tex2d,id:4789,x:33277,y:32238,ptovrint:False,ptlb:WaterDetail1,ptin:_WaterDetail1,varname:node_4789,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:eace40c19d707e049b66bdad7cf1fb30,ntxv:0,isnm:False|UVIN-2918-UVOUT;n:type:ShaderForge.SFN_Tex2d,id:2680,x:33601,y:33048,ptovrint:False,ptlb:WaterDetail2,ptin:_WaterDetail2,varname:node_2680,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:27b884b2fc4f17e46b454d0b455fe1fb,ntxv:0,isnm:False|UVIN-2111-UVOUT;n:type:ShaderForge.SFN_Lerp,id:8939,x:33935,y:32694,varname:node_8939,prsc:2|A-5090-OUT,B-8436-RGB,T-5162-OUT;n:type:ShaderForge.SFN_Color,id:8436,x:33457,y:32873,ptovrint:False,ptlb:WaterDetail1Color,ptin:_WaterDetail1Color,varname:node_8436,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:0.9669811,c3:0.9669811,c4:1;n:type:ShaderForge.SFN_Lerp,id:2162,x:34369,y:32915,varname:node_2162,prsc:2|A-8939-OUT,B-5888-RGB,T-3215-OUT;n:type:ShaderForge.SFN_Color,id:5888,x:33709,y:32908,ptovrint:False,ptlb:WaterDetail2Color,ptin:_WaterDetail2Color,varname:node_5888,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.08993414,c2:0.2183222,c3:0.4433962,c4:1;n:type:ShaderForge.SFN_Subtract,id:5194,x:33593,y:32554,varname:node_5194,prsc:2|A-7994-OUT,B-9687-OUT;n:type:ShaderForge.SFN_Slider,id:5002,x:33112,y:32587,ptovrint:False,ptlb:WaterDetail1Intensity,ptin:_WaterDetail1Intensity,varname:node_5002,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_Clamp01,id:5162,x:33747,y:32554,varname:node_5162,prsc:2|IN-5194-OUT;n:type:ShaderForge.SFN_Slider,id:3047,x:33485,y:33305,ptovrint:False,ptlb:WaterDetail2Intensity,ptin:_WaterDetail2Intensity,varname:node_3047,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_Subtract,id:6711,x:34001,y:33087,varname:node_6711,prsc:2|A-4563-OUT,B-7317-OUT;n:type:ShaderForge.SFN_Clamp01,id:3215,x:34156,y:32971,varname:node_3215,prsc:2|IN-6711-OUT;n:type:ShaderForge.SFN_Panner,id:2111,x:33396,y:33038,varname:node_2111,prsc:2,spu:0.7,spv:0.1|UVIN-2996-UVOUT,DIST-1856-OUT;n:type:ShaderForge.SFN_TexCoord,id:2996,x:33207,y:33038,varname:node_2996,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Time,id:318,x:32981,y:33215,varname:node_318,prsc:2;n:type:ShaderForge.SFN_Slider,id:7977,x:32824,y:33372,ptovrint:False,ptlb:WaterDetail2Speed,ptin:_WaterDetail2Speed,varname:node_7977,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_Multiply,id:1856,x:33220,y:33215,varname:node_1856,prsc:2|A-318-T,B-7977-OUT;n:type:ShaderForge.SFN_TexCoord,id:9412,x:32825,y:32122,varname:node_9412,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Panner,id:2918,x:33067,y:32238,varname:node_2918,prsc:2,spu:0.5,spv:0.3|UVIN-9412-UVOUT,DIST-9826-OUT;n:type:ShaderForge.SFN_Multiply,id:9826,x:32825,y:32280,varname:node_9826,prsc:2|A-1746-T,B-8782-OUT;n:type:ShaderForge.SFN_Time,id:1746,x:32616,y:32269,varname:node_1746,prsc:2;n:type:ShaderForge.SFN_Slider,id:8782,x:32669,y:32457,ptovrint:False,ptlb:WaterDetail1Speed,ptin:_WaterDetail1Speed,varname:node_8782,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Subtract,id:6037,x:32647,y:32517,varname:node_6037,prsc:2|A-8881-OUT,B-9846-OUT;n:type:ShaderForge.SFN_Vector1,id:9846,x:32443,y:32536,varname:node_9846,prsc:2,v1:0.1;n:type:ShaderForge.SFN_Clamp01,id:818,x:32852,y:32517,varname:node_818,prsc:2|IN-6037-OUT;n:type:ShaderForge.SFN_Subtract,id:7994,x:33440,y:32398,varname:node_7994,prsc:2|A-4789-RGB,B-818-OUT;n:type:ShaderForge.SFN_Subtract,id:4563,x:33811,y:33048,varname:node_4563,prsc:2|A-2680-RGB,B-818-OUT;n:type:ShaderForge.SFN_OneMinus,id:7317,x:33808,y:33189,varname:node_7317,prsc:2|IN-3047-OUT;n:type:ShaderForge.SFN_OneMinus,id:9687,x:33440,y:32587,varname:node_9687,prsc:2|IN-5002-OUT;proporder:7241-4229-3349-8751-7475-5391-2712-6980-4789-2680-8436-5888-5002-3047-7977-8782;pass:END;sub:END;*/

Shader "Shader Forge/WaterShader" {
    Properties {
        _WaterColor ("WaterColor", Color) = (0.6829388,0.8112763,0.9716981,1)
        _DeepWaterColor ("DeepWaterColor", Color) = (0.1455144,0.1683492,0.2830189,1)
        _WaterShoreColor ("WaterShoreColor", Color) = (0.6944642,0.9622642,0.8602265,1)
        _WaterLineColor ("WaterLineColor", Color) = (0.873754,0.9844766,0.990566,1)
        _DepthColor ("DepthColor", Range(0, 2)) = 2
        _ShoreColor ("ShoreColor", Range(0, 2)) = 1.11009
        _WaterLineWidth ("WaterLineWidth", Range(0, 100)) = 96.14884
        _WaterOpacity ("WaterOpacity", Range(0, 1)) = 1
        _WaterDetail1 ("WaterDetail1", 2D) = "white" {}
        _WaterDetail2 ("WaterDetail2", 2D) = "white" {}
        _WaterDetail1Color ("WaterDetail1Color", Color) = (1,0.9669811,0.9669811,1)
        _WaterDetail2Color ("WaterDetail2Color", Color) = (0.08993414,0.2183222,0.4433962,1)
        _WaterDetail1Intensity ("WaterDetail1Intensity", Range(0, 1)) = 1
        _WaterDetail2Intensity ("WaterDetail2Intensity", Range(0, 1)) = 1
        _WaterDetail2Speed ("WaterDetail2Speed", Range(0, 1)) = 1
        _WaterDetail1Speed ("WaterDetail1Speed", Range(0, 1)) = 0
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
            uniform float4 _WaterColor;
            uniform float4 _DeepWaterColor;
            uniform float _DepthColor;
            uniform float _ShoreColor;
            uniform float4 _WaterShoreColor;
            uniform float _WaterLineWidth;
            uniform float4 _WaterLineColor;
            uniform float _WaterOpacity;
            uniform sampler2D _WaterDetail1; uniform float4 _WaterDetail1_ST;
            uniform sampler2D _WaterDetail2; uniform float4 _WaterDetail2_ST;
            uniform float4 _WaterDetail1Color;
            uniform float4 _WaterDetail2Color;
            uniform float _WaterDetail1Intensity;
            uniform float _WaterDetail2Intensity;
            uniform float _WaterDetail2Speed;
            uniform float _WaterDetail1Speed;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = UnityObjectToClipPos( v.vertex );
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
////// Lighting:
////// Emissive:
                float node_8777 = abs(i.uv0.g);
                float node_8881 = saturate((node_8777*_DepthColor));
                float4 node_1746 = _Time;
                float2 node_2918 = (i.uv0+(node_1746.g*_WaterDetail1Speed)*float2(0.5,0.3));
                float4 _WaterDetail1_var = tex2D(_WaterDetail1,TRANSFORM_TEX(node_2918, _WaterDetail1));
                float node_818 = saturate((node_8881-0.1));
                float4 node_318 = _Time;
                float2 node_2111 = (i.uv0+(node_318.g*_WaterDetail2Speed)*float2(0.7,0.1));
                float4 _WaterDetail2_var = tex2D(_WaterDetail2,TRANSFORM_TEX(node_2111, _WaterDetail2));
                float3 emissive = lerp(lerp(lerp(lerp(lerp(_DeepWaterColor.rgb,_WaterColor.rgb,node_8881),_WaterShoreColor.rgb,saturate(((node_8777*2.0)-_ShoreColor))),_WaterLineColor.rgb,saturate(((node_8777*100.0)-_WaterLineWidth))),_WaterDetail1Color.rgb,saturate(((_WaterDetail1_var.rgb-node_818)-(1.0 - _WaterDetail1Intensity)))),_WaterDetail2Color.rgb,saturate(((_WaterDetail2_var.rgb-node_818)-(1.0 - _WaterDetail2Intensity))));
                float3 finalColor = emissive;
                return fixed4(finalColor,_WaterOpacity);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
