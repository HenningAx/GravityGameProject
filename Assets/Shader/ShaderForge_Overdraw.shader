// Shader created with Shader Forge v1.13 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.13;sub:START;pass:START;ps:flbk:,lico:1,lgpr:1,nrmq:1,nrsp:0,limd:0,spmd:0,trmd:0,grmd:0,uamb:False,mssp:True,bkdf:False,rprd:False,enco:False,rmgx:True,rpth:0,hqsc:True,hqlp:False,tesm:0,bsrc:0,bdst:1,culm:0,dpts:6,wrdp:False,dith:0,ufog:True,aust:False,igpj:True,qofs:0,qpre:4,rntp:5,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.02,fgrn:0,fgrf:300,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:7048,x:32740,y:32728,varname:node_7048,prsc:2|diff-2324-OUT,normal-6438-RGB,emission-1289-OUT,olwid-3144-OUT;n:type:ShaderForge.SFN_Color,id:9766,x:31986,y:32651,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_9766,prsc:2,glob:False,c1:0.8235294,c2:0.02422148,c3:0.02422148,c4:1;n:type:ShaderForge.SFN_If,id:2324,x:32439,y:32617,varname:node_2324,prsc:2|A-1850-RGB,B-6319-OUT,GT-9766-RGB,EQ-9766-RGB,LT-1850-RGB;n:type:ShaderForge.SFN_Tex2d,id:1850,x:31986,y:32354,ptovrint:False,ptlb:Diffuse,ptin:_Diffuse,varname:node_1850,prsc:2,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Slider,id:7681,x:31829,y:33117,ptovrint:False,ptlb:Self Illumination Multiply,ptin:_SelfIlluminationMultiply,varname:node_7681,prsc:2,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Vector4,id:6319,x:31986,y:32522,varname:node_6319,prsc:2,v1:1,v2:1,v3:1,v4:1;n:type:ShaderForge.SFN_Multiply,id:1289,x:32238,y:32893,varname:node_1289,prsc:2|A-2915-OUT,B-7681-OUT;n:type:ShaderForge.SFN_Tex2d,id:9414,x:31701,y:32731,ptovrint:False,ptlb:Self Illumination,ptin:_SelfIllumination,varname:node_9414,prsc:2,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:6438,x:31953,y:33244,ptovrint:False,ptlb:Normal,ptin:_Normal,varname:node_6438,prsc:2,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Color,id:7061,x:31701,y:32932,ptovrint:False,ptlb:Self Illumination Color,ptin:_SelfIlluminationColor,varname:node_7061,prsc:2,glob:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Multiply,id:2915,x:31944,y:32820,varname:node_2915,prsc:2|A-9414-RGB,B-7061-RGB;n:type:ShaderForge.SFN_Slider,id:3144,x:31821,y:33455,ptovrint:False,ptlb:Outline,ptin:_Outline,varname:node_3144,prsc:2,min:0,cur:0,max:1;proporder:9766-1850-7681-9414-6438-7061-3144;pass:END;sub:END;*/

Shader "Shader Forge/ShaderForge_Overdraw" {
    Properties {
        _Color ("Color", Color) = (0.8235294,0.02422148,0.02422148,1)
        _Diffuse ("Diffuse", 2D) = "white" {}
        _SelfIlluminationMultiply ("Self Illumination Multiply", Range(0, 1)) = 0
        _SelfIllumination ("Self Illumination", 2D) = "white" {}
        _Normal ("Normal", 2D) = "white" {}
        _SelfIlluminationColor ("Self Illumination Color", Color) = (0.5,0.5,0.5,1)
        _Outline ("Outline", Range(0, 1)) = 0
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Overlay"
            "RenderType"="Overlay"
        }
        Pass {
            Name "Outline"
            Tags {
            }
            Cull Front
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float _Outline;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                UNITY_FOG_COORDS(0)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.pos = mul(UNITY_MATRIX_MVP, float4(v.vertex.xyz + v.normal*_Outline,1));
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
/////// Vectors:
                return fixed4(float3(0,0,0),0);
            }
            ENDCG
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            ZTest Always
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _Color;
            uniform sampler2D _Diffuse; uniform float4 _Diffuse_ST;
            uniform float _SelfIlluminationMultiply;
            uniform sampler2D _SelfIllumination; uniform float4 _SelfIllumination_ST;
            uniform sampler2D _Normal; uniform float4 _Normal_ST;
            uniform float4 _SelfIlluminationColor;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float3 normalDir : TEXCOORD1;
                float3 tangentDir : TEXCOORD2;
                float3 bitangentDir : TEXCOORD3;
                UNITY_FOG_COORDS(4)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( _Object2World, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
/////// Vectors:
                float4 _Normal_var = tex2D(_Normal,TRANSFORM_TEX(i.uv0, _Normal));
                float3 normalLocal = _Normal_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
////// Lighting:
////// Emissive:
                float4 _SelfIllumination_var = tex2D(_SelfIllumination,TRANSFORM_TEX(i.uv0, _SelfIllumination));
                float3 emissive = ((_SelfIllumination_var.rgb*_SelfIlluminationColor.rgb)*_SelfIlluminationMultiply);
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
