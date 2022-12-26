Shader "Custom/dissolve"
{
    Properties
    {
        _MainTex("Main Texture", 2D) = "white" {}
    _BumpMap("Normal Map", 2D) = "bump" {}
    _Specular("Specular", Color) = (1, 1, 1, 1)
    _BumpScale("Bump Scale", Float) = 1.0
    _Gloss("Gloss", Range(8.0, 256)) = 20

    _NoiseMap("Noise Map", 2D) = "white" {}
    _DissolveThreshold("Dissolve Threshold", Range(0.0, 1.0)) = 0.0
    _LineWidth("Dissolve Line Width", Range(0.0, 0.2)) = 0.1
    _DissolveColor("Dissolve First Color", Color) = (0, 0, 1, 1)
    }
        SubShader
    {
        Tags
    {
        "RenderType" = "Opaque"
        "Queue" = "AlphaTest"
    }
        Pass{

Tags {"LightMode" = "ForwardBase"}
    Name "lighting"

        //��Ҫ�ü�����
        Cull Off

        CGPROGRAM
#pragma vertex vert
#pragma fragment frag
#include "Lighting.cginc"
      

        sampler2D _MainTex;
    float4 _MainTex_ST;
    sampler2D _BumpMap;
    float4 _BumpMap_ST;
    fixed4 _Specular;
    float _BumpScale;
    float _Gloss;
    sampler2D _NoiseMap;
    float4 _NoiseMap_ST;
    float _DissolveThreshold;
    float _LineWidth;
    fixed4 _DissolveColor;

struct a2v
{
    float4 vertex : POSITION;
    float3 normal : NORMAL;
    float4 tangent : TANGENT;
    float4 texcoord : TEXCOORD0;
};

struct v2f
{
    float4 pos : SV_POSITION;
    float2 uv0 : TEXCOORD0;
    float2 uv1 : TEXCOORD1;
    float2 uv2 : TEXCOORD2;
    float4 tbnp0 : TEXCOORD3;
    float4 tbnp1 : TEXCOORD4;
    float4 tbnp2 : TEXCOORD5;
};

v2f vert(a2v v)
{
    v2f o;
    //ģ�Ϳռ�-->�ü��ռ�
    o.pos = UnityObjectToClipPos(v.vertex);
    //�������ź�ƫ�Ƽ���diffuse��normal��noise��������
    o.uv0 = TRANSFORM_TEX(v.texcoord, _MainTex);
    o.uv1 = TRANSFORM_TEX(v.texcoord, _BumpMap);
    o.uv2 = TRANSFORM_TEX(v.texcoord, _NoiseMap);

    //normal��tangent��bitangent��ģ�Ϳռ�-->����ռ䣬����tbn+position����
    fixed3 worldNormal = normalize(UnityObjectToWorldNormal(v.normal));
    fixed3 worldTangent = normalize(UnityObjectToWorldDir(v.tangent.xyz));
    fixed3 worldBitangent = normalize(cross(worldNormal, worldTangent) * v.tangent.w);
    float3 worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
    o.tbnp0 = float4(worldTangent.x, worldBitangent.x, worldNormal.x, worldPos.x);
    o.tbnp1 = float4(worldTangent.y, worldBitangent.y, worldNormal.y, worldPos.y);
    o.tbnp2 = float4(worldTangent.z, worldBitangent.z, worldNormal.z, worldPos.z);
    

    return o;
}

float4 frag(v2f i) : SV_TARGET
{
    //����noise,����ֵ�ȽϽ���clip
    fixed3 noise = tex2D(_NoiseMap, i.uv2).rgb;
    clip(noise.r - _DissolveThreshold);

    //ƴ��ƬԪ��������
    float3 worldPos = float3(i.tbnp0.w, i.tbnp1.w, i.tbnp2.w);
    //����������������ɫ����ò��ʷ�����
    fixed3 albedo = tex2D(_MainTex, i.uv0).rgb;
    //�����ⲿ��
    fixed3 ambient = UNITY_LIGHTMODEL_AMBIENT.xyz * albedo;
    //��������ģ�ͼ���diffuse��Blinn-Phongģ�ͼ���specular
    fixed3 worldLightDir = normalize(UnityWorldSpaceLightDir(worldPos));
    fixed3 worldViewDir = normalize(UnityWorldSpaceViewDir(worldPos));
    fixed3 bump = UnpackNormal(tex2D(_BumpMap, i.uv1));
    bump.xy *= _BumpScale;
    bump.z = sqrt(1.0 - saturate(dot(bump.xy, bump.xy)));
    bump = normalize(half3(dot(i.tbnp0.xyz, bump), dot(i.tbnp1.xyz, bump), dot(i.tbnp2.xyz, bump)));
    fixed halfLambert = dot(bump, worldLightDir) * 0.5 + 0.5;
    fixed3 diffuse = _LightColor0.rgb * albedo * halfLambert;
    fixed3 hDir = normalize(worldLightDir + worldViewDir);
    fixed3 specular = _LightColor0.rgb * _Specular.rgb * pow(max(0, dot(bump, hDir)), _Gloss);

    

    //_LineWidth����������ɫ���õķ�Χ���������ɫ����lerp
    fixed t = 1 - smoothstep(0.0, _LineWidth, noise.r - _DissolveThreshold);
    fixed3 finalColor = lerp(albedo , _DissolveColor, t * step(0.001, _DissolveThreshold));

    return float4(finalColor, 1.0);
}
        ENDCG}
    }
    FallBack "Diffuse"
}
