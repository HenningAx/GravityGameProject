// Shader created with Shader Forge v1.13 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.13;sub:START;pass:START;ps:flbk:,lico:1,lgpr:1,nrmq:1,nrsp:0,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,rprd:False,enco:False,rmgx:True,rpth:0,hqsc:True,hqlp:False,tesm:0,bsrc:3,bdst:7,culm:0,dpts:2,wrdp:False,dith:0,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:1,x:33927,y:32750,varname:node_1,prsc:2|diff-95-RGB,spec-106-RGB,alpha-52-OUT;n:type:ShaderForge.SFN_FragmentPosition,id:2,x:31772,y:32850,varname:node_2,prsc:2;n:type:ShaderForge.SFN_Distance,id:3,x:32119,y:32909,varname:node_3,prsc:2|A-2-XYZ,B-28-XYZ;n:type:ShaderForge.SFN_RemapRangeAdvanced,id:5,x:32719,y:32962,varname:node_5,prsc:2|IN-55-OUT,IMIN-7-OUT,IMAX-66-OUT,OMIN-9-OUT,OMAX-11-OUT;n:type:ShaderForge.SFN_Vector1,id:7,x:32249,y:33010,varname:node_7,prsc:2,v1:0;n:type:ShaderForge.SFN_Vector1,id:9,x:32282,y:33208,varname:node_9,prsc:2,v1:-1;n:type:ShaderForge.SFN_Vector1,id:11,x:32271,y:33270,varname:node_11,prsc:2,v1:0;n:type:ShaderForge.SFN_Multiply,id:12,x:33090,y:32991,varname:node_12,prsc:2|A-5-OUT,B-13-OUT;n:type:ShaderForge.SFN_Vector1,id:13,x:32739,y:33145,varname:node_13,prsc:2,v1:-1;n:type:ShaderForge.SFN_Subtract,id:24,x:31762,y:33488,varname:node_24,prsc:2|A-2-XYZ,B-28-XYZ;n:type:ShaderForge.SFN_Dot,id:25,x:32089,y:33512,varname:node_25,prsc:2,dt:0|A-24-OUT,B-29-XYZ;n:type:ShaderForge.SFN_Vector4Property,id:28,x:31762,y:33088,ptovrint:False,ptlb:LightPosition,ptin:_LightPosition,varname:node_768,prsc:2,glob:False,v1:0,v2:0,v3:0,v4:0;n:type:ShaderForge.SFN_Vector4Property,id:29,x:31708,y:33672,ptovrint:False,ptlb:LightDirection,ptin:_LightDirection,varname:node_7615,prsc:2,glob:False,v1:0,v2:0,v3:0,v4:0;n:type:ShaderForge.SFN_Divide,id:30,x:32406,y:33459,varname:node_30,prsc:2|A-25-OUT,B-31-OUT;n:type:ShaderForge.SFN_Multiply,id:31,x:32299,y:33700,varname:node_31,prsc:2|A-32-OUT,B-33-OUT;n:type:ShaderForge.SFN_Length,id:32,x:32089,y:33653,varname:node_32,prsc:2|IN-29-XYZ;n:type:ShaderForge.SFN_Length,id:33,x:32089,y:33800,varname:node_33,prsc:2|IN-24-OUT;n:type:ShaderForge.SFN_Vector1,id:36,x:32457,y:33685,varname:node_36,prsc:2,v1:5;n:type:ShaderForge.SFN_Pi,id:37,x:32474,y:33841,varname:node_37,prsc:2;n:type:ShaderForge.SFN_Vector1,id:38,x:32457,y:33744,varname:node_38,prsc:2,v1:36;n:type:ShaderForge.SFN_Divide,id:39,x:32675,y:33685,varname:node_39,prsc:2|A-36-OUT,B-38-OUT;n:type:ShaderForge.SFN_Multiply,id:40,x:32891,y:33817,varname:node_40,prsc:2|A-39-OUT,B-37-OUT;n:type:ShaderForge.SFN_Vector1,id:41,x:32588,y:33510,varname:node_41,prsc:2,v1:0;n:type:ShaderForge.SFN_Vector1,id:42,x:32761,y:33094,varname:node_42,prsc:2,v1:1;n:type:ShaderForge.SFN_RemapRangeAdvanced,id:45,x:33144,y:33339,varname:node_45,prsc:2|IN-30-OUT,IMIN-50-OUT,IMAX-47-OUT,OMIN-48-OUT,OMAX-49-OUT;n:type:ShaderForge.SFN_Vector1,id:47,x:32926,y:33311,varname:node_47,prsc:2,v1:1;n:type:ShaderForge.SFN_Vector1,id:48,x:33090,y:33551,varname:node_48,prsc:2,v1:0;n:type:ShaderForge.SFN_Vector1,id:49,x:32947,y:33469,varname:node_49,prsc:2,v1:1;n:type:ShaderForge.SFN_Cos,id:50,x:32817,y:33425,varname:node_50,prsc:2|IN-40-OUT;n:type:ShaderForge.SFN_Multiply,id:52,x:33452,y:33049,varname:node_52,prsc:2|A-12-OUT,B-63-OUT;n:type:ShaderForge.SFN_Clamp,id:55,x:32495,y:32866,varname:node_55,prsc:2|IN-56-OUT,MIN-7-OUT,MAX-66-OUT;n:type:ShaderForge.SFN_Subtract,id:56,x:32312,y:32796,varname:node_56,prsc:2|A-3-OUT,B-66-OUT;n:type:ShaderForge.SFN_Multiply,id:59,x:32642,y:33220,varname:node_59,prsc:2|A-3-OUT,B-13-OUT;n:type:ShaderForge.SFN_Add,id:60,x:32794,y:33220,varname:node_60,prsc:2|A-59-OUT,B-61-OUT;n:type:ShaderForge.SFN_Vector1,id:61,x:32609,y:33357,varname:node_61,prsc:2,v1:4;n:type:ShaderForge.SFN_Clamp,id:62,x:33020,y:33157,varname:node_62,prsc:2|IN-60-OUT,MIN-42-OUT,MAX-61-OUT;n:type:ShaderForge.SFN_Multiply,id:63,x:33241,y:33118,varname:node_63,prsc:2|A-45-OUT,B-62-OUT;n:type:ShaderForge.SFN_ValueProperty,id:66,x:32271,y:33126,ptovrint:False,ptlb:LightRange,ptin:_LightRange,varname:node_5692,prsc:2,glob:False,v1:5;n:type:ShaderForge.SFN_Tex2d,id:95,x:33499,y:32593,ptovrint:False,ptlb:node_95,ptin:_node_95,varname:node_2013,prsc:2,ntxv:1,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:106,x:33290,y:32663,ptovrint:False,ptlb:node_106,ptin:_node_106,varname:node_3188,prsc:2,ntxv:0,isnm:False;proporder:28-29-66-95-106;pass:END;sub:END;*/

Shader "Shader Forge/AlphabyLight" {
    Properties {
        _LightPosition ("LightPosition", Vector) = (0,0,0,0)
        _LightDirection ("LightDirection", Vector) = (0,0,0,0)
        _LightRange ("LightRange", Float ) = 5
        _node_95 ("node_95", 2D) = "gray" {}
        _node_106 ("node_106", 2D) = "white" {}
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
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog
            #pragma exclude_renderers xbox360 ps3 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform float4 _LightPosition;
            uniform float4 _LightDirection;
            uniform float _LightRange;
            uniform sampler2D _node_95; uniform float4 _node_95_ST;
            uniform sampler2D _node_106; uniform float4 _node_106_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                UNITY_FOG_COORDS(3)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(_Object2World, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
/////// Vectors:
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = 1;
                float3 attenColor = attenuation * _LightColor0.xyz;
///////// Gloss:
                float gloss = 0.5;
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                float NdotL = max(0, dot( normalDirection, lightDirection ));
                float4 _node_106_var = tex2D(_node_106,TRANSFORM_TEX(i.uv0, _node_106));
                float3 specularColor = _node_106_var.rgb;
                float3 directSpecular = (floor(attenuation) * _LightColor0.xyz) * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularColor;
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                float4 _node_95_var = tex2D(_node_95,TRANSFORM_TEX(i.uv0, _node_95));
                float3 diffuseColor = _node_95_var.rgb;
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
                float node_3 = distance(i.posWorld.rgb,_LightPosition.rgb);
                float node_7 = 0.0;
                float node_9 = (-1.0);
                float node_13 = (-1.0);
                float3 node_24 = (i.posWorld.rgb-_LightPosition.rgb);
                float node_50 = cos(((5.0/36.0)*3.141592654));
                float node_48 = 0.0;
                float node_61 = 4.0;
                fixed4 finalRGBA = fixed4(finalColor,(((node_9 + ( (clamp((node_3-_LightRange),node_7,_LightRange) - node_7) * (0.0 - node_9) ) / (_LightRange - node_7))*node_13)*((node_48 + ( ((dot(node_24,_LightDirection.rgb)/(length(_LightDirection.rgb)*length(node_24))) - node_50) * (1.0 - node_48) ) / (1.0 - node_50))*clamp(((node_3*node_13)+node_61),1.0,node_61))));
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdadd
            #pragma multi_compile_fog
            #pragma exclude_renderers xbox360 ps3 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform float4 _LightPosition;
            uniform float4 _LightDirection;
            uniform float _LightRange;
            uniform sampler2D _node_95; uniform float4 _node_95_ST;
            uniform sampler2D _node_106; uniform float4 _node_106_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                LIGHTING_COORDS(3,4)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(_Object2World, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
/////// Vectors:
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
///////// Gloss:
                float gloss = 0.5;
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                float NdotL = max(0, dot( normalDirection, lightDirection ));
                float4 _node_106_var = tex2D(_node_106,TRANSFORM_TEX(i.uv0, _node_106));
                float3 specularColor = _node_106_var.rgb;
                float3 directSpecular = attenColor * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularColor;
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float4 _node_95_var = tex2D(_node_95,TRANSFORM_TEX(i.uv0, _node_95));
                float3 diffuseColor = _node_95_var.rgb;
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
                float node_3 = distance(i.posWorld.rgb,_LightPosition.rgb);
                float node_7 = 0.0;
                float node_9 = (-1.0);
                float node_13 = (-1.0);
                float3 node_24 = (i.posWorld.rgb-_LightPosition.rgb);
                float node_50 = cos(((5.0/36.0)*3.141592654));
                float node_48 = 0.0;
                float node_61 = 4.0;
                return fixed4(finalColor * (((node_9 + ( (clamp((node_3-_LightRange),node_7,_LightRange) - node_7) * (0.0 - node_9) ) / (_LightRange - node_7))*node_13)*((node_48 + ( ((dot(node_24,_LightDirection.rgb)/(length(_LightDirection.rgb)*length(node_24))) - node_50) * (1.0 - node_48) ) / (1.0 - node_50))*clamp(((node_3*node_13)+node_61),1.0,node_61))),0);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
