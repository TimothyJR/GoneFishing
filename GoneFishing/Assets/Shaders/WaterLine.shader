// Shader created with Shader Forge v1.38 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:3138,x:32719,y:32712,varname:node_3138,prsc:2|emission-2907-RGB,alpha-8143-OUT,clip-2907-A;n:type:ShaderForge.SFN_Tex2d,id:2907,x:32047,y:32715,ptovrint:False,ptlb:WaterFoam,ptin:_WaterFoam,varname:node_2907,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:7de916ce2b05f8144b6f9a97a6b07ea2,ntxv:0,isnm:False;n:type:ShaderForge.SFN_TexCoord,id:169,x:31220,y:32930,varname:node_169,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Abs,id:7591,x:31396,y:32972,varname:node_7591,prsc:2|IN-169-V;n:type:ShaderForge.SFN_Clamp01,id:8143,x:32212,y:32973,varname:node_8143,prsc:2|IN-1062-OUT;n:type:ShaderForge.SFN_Multiply,id:1062,x:32026,y:32973,varname:node_1062,prsc:2|A-3064-OUT,B-9736-OUT;n:type:ShaderForge.SFN_Slider,id:9736,x:31496,y:33233,ptovrint:False,ptlb:OpacityLevel,ptin:_OpacityLevel,varname:node_9736,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:2.083062,max:5;n:type:ShaderForge.SFN_Subtract,id:3064,x:31795,y:32963,varname:node_3064,prsc:2|A-816-OUT,B-5760-OUT;n:type:ShaderForge.SFN_Vector1,id:5760,x:31653,y:33109,varname:node_5760,prsc:2,v1:0.1;n:type:ShaderForge.SFN_Power,id:9164,x:32166,y:33138,varname:node_9164,prsc:2|VAL-1062-OUT,EXP-4564-OUT;n:type:ShaderForge.SFN_Vector1,id:4564,x:31933,y:33251,varname:node_4564,prsc:2,v1:3;n:type:ShaderForge.SFN_OneMinus,id:816,x:31594,y:32963,varname:node_816,prsc:2|IN-7591-OUT;proporder:2907-9736;pass:END;sub:END;*/

Shader "Shader Forge/WaterLine" {
    Properties {
        _WaterFoam ("WaterFoam", 2D) = "white" {}
        _OpacityLevel ("OpacityLevel", Range(0, 5)) = 2.083062
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
            uniform sampler2D _WaterFoam; uniform float4 _WaterFoam_ST;
            uniform float _OpacityLevel;
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
                float4 _WaterFoam_var = tex2D(_WaterFoam,TRANSFORM_TEX(i.uv0, _WaterFoam));
                clip(_WaterFoam_var.a - 0.5);
////// Lighting:
////// Emissive:
                float3 emissive = _WaterFoam_var.rgb;
                float3 finalColor = emissive;
                float node_7591 = abs(i.uv0.g);
                float node_1062 = (((1.0 - node_7591)-0.1)*_OpacityLevel);
                return fixed4(finalColor,saturate(node_1062));
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            Cull Back
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D _WaterFoam; uniform float4 _WaterFoam_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float2 uv0 : TEXCOORD1;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float4 _WaterFoam_var = tex2D(_WaterFoam,TRANSFORM_TEX(i.uv0, _WaterFoam));
                clip(_WaterFoam_var.a - 0.5);
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
