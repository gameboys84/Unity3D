﻿Shader "Unlit/004-Shadow1"
{
    Properties
    {
		_Diffuse("Diffuse",Color) = (1,1,1,1)
		_Specular("Specular", Color) = (1,1,1,1)
		_Gloss("Gloss", Range(8.0, 256)) = 20
    }
    SubShader
    {
        Tags { "RenderType" = "Opaque" }
		LOD 100

		Pass
		{
			Tags{"LightMode" = "ForwardBase"}
			CGPROGRAM
			#pragma multi_compile_fwdbase
			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"
			#include "Lighting.cginc"
			#include "AutoLight.cginc"

			fixed4 _Diffuse;
			fixed4 _Specular;
			float _Gloss;

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
				float3 normal:NORMAL;
            };

            struct v2f
            {
                float4 pos : SV_POSITION;
				float3 worldNormal : TEXCOORD0;
				float3 worldPos:TEXCOORD1;
				float3 vertexLight : TEXCOORD2;
				SHADOW_COORDS(3) //仅仅是阴影
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
				o.worldNormal = UnityObjectToWorldNormal(v.normal);
				o.worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
#ifdef LIGHTMAP_OFF
				float3 shLight = ShadeSH9(float4(v.normal,1.0));
				o.vertexLight = shLight;
#ifdef VERTEXLIGHT_ON
				float3 vertexLight = Shade4PointLights(unity_4LightPosX0,unity_4LightPosY0,unity_4LightPosZ0,
				unity_LightColor[0].rgb,unity_LightColor[1].rgb,unity_LightColor[2].rgb,unity_LightColor[3].rgb,
				unity_4LightAtten0, o.worldPos, o.worldNormal);
				o.vertexLight += vertexLight;
#endif
#endif
				//仅仅是阴影
				TRANSFER_SHADOW(o);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
				fixed3 worldNormal = normalize(i.worldNormal);
				fixed3 worldLightDir = normalize(UnityWorldSpaceLightDir(i.worldPos));
				fixed3 ambient = UNITY_LIGHTMODEL_AMBIENT.xyz;
				fixed3 diffuse = _LightColor0.rgb * _Diffuse.rgb * max(0, dot(worldNormal,worldLightDir));

				fixed3 viewDir = normalize(_WorldSpaceCameraPos.xyz - i.worldPos.xyz);
				fixed3 halfDir = normalize(worldLightDir + viewDir);
				fixed3 specular = _LightColor0.rgb * _Specular.rgb * pow(max(0,dot(worldNormal,halfDir)),_Gloss);

				//fixed shadow = SHADOW_ATTENUATION(i);

				//这个函数计算包含了光照衰减已经阴影,因为ForwardBase逐像素光源一般是方向光，衰减为1，atten在这里实际是阴影值
				UNITY_LIGHT_ATTENUATION(atten, i, i.worldPos);

                return fixed4((ambient + (diffuse + specular) * atten + i.vertexLight), 1);
            }
            ENDCG
        }

		Pass
		{
			Tags{"LightMode" = "ForwardAdd"}

			Blend One One

			CGPROGRAM
			#pragma multi_compile_fwdadd_fullshadows
			#pragma vertex vert
			#pragma fragment frag

			#include "Lighting.cginc"
			#include "AutoLight.cginc"

			fixed4 _Diffuse;
			fixed4 _Specular;
			float _Gloss;

			struct a2v
			{
				float4 vertex:POSITION;
				float3 normal :NORMAL;
			};

			struct v2f
			{
				float4 pos :SV_POSITION;
				float3 worldNormal : TEXCOORD0;
				float3 worldPos : TEXCOORD1;
				LIGHTING_COORDS(2,3) //包含光照衰减以及阴影
			};

			v2f vert(a2v v)
			{
				v2f o;
				o.pos = UnityObjectToClipPos(v.vertex);
				o.worldNormal = UnityObjectToWorldNormal(v.normal);
				o.worldPos = mul(unity_ObjectToWorld,v.vertex).xyz;
				//包含光照衰减以及阴影
				TRANSFER_VERTEX_TO_FRAGMENT(o);
				return o;
			}

			fixed4 frag(v2f i):SV_Target
			{
				fixed3 worldNormal = normalize(i.worldNormal);
				fixed3 worldLightDir = normalize(UnityWorldSpaceLightDir(i.worldPos));

				fixed3 diffuse = _LightColor0.rgb * _Diffuse.rgb * max(0,dot(worldNormal,worldLightDir));

				fixed3 viewDir = normalize(UnityWorldSpaceViewDir(i.worldPos));
				fixed3 halfDir = normalize(worldLightDir + viewDir);
				fixed3 specular = _LightColor0.rgb * _Specular.rgb * pow(max(0,dot(viewDir,halfDir)),_Gloss);

				//fixed atten = LIGHT_ATTENUATION(i);
				////包含光照衰减以及阴影
				UNITY_LIGHT_ATTENUATION(atten, i, i.worldPos);

				return fixed4((diffuse+ specular)*atten,1.0);
			}

			ENDCG
		}

		Pass 
		{
			Tags { "LightMode" = "ShadowCaster" }

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma target 2.0
			#pragma multi_compile_shadowcaster
			#pragma multi_compile_instancing // allow instanced shadow pass for most of the shaders
			#include "UnityCG.cginc"

			struct v2f {
				V2F_SHADOW_CASTER;
				UNITY_VERTEX_OUTPUT_STEREO
			};

			v2f vert( appdata_base v )
			{
				v2f o;
				UNITY_SETUP_INSTANCE_ID(v);
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);
				TRANSFER_SHADOW_CASTER_NORMALOFFSET(o)
				return o;
			}

			float4 frag( v2f i ) : SV_Target
			{
				SHADOW_CASTER_FRAGMENT(i)
			}
			ENDCG

		}
    }
	//FallBack "Diffuse"
}
