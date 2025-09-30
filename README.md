# Unity3D
[TOC]

## Tools

### l2 Localization 2.8.22 f6

### Odin 3.3.1.7

### Optimized ScrollView Adapter 7.2.1

### Text Animator

### vHierarchy2 2.1.3

### vInspector2 2.0.13

### Optimized ScrollView Adapter (OSA) 7.2.1

### DOTweenPro 1.0.381

### Mobile Controller System 2.1



### 关于字体的说明

[一次性搞定！思源字体安装、使用及常见问题解答 - 知乎](https://zhuanlan.zhihu.com/p/688363772)

- VF ([Variable fonts](https://zhida.zhihu.com/search?content_id=241100069&content_type=Article&match_order=1&q=Variable+fonts&zd_token=eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJ6aGlkYV9zZXJ2ZXIiLCJleHAiOjE3NTg5ODQ1OTksInEiOiJWYXJpYWJsZSBmb250cyIsInpoaWRhX3NvdXJjZSI6ImVudGl0eSIsImNvbnRlbnRfaWQiOjI0MTEwMDA2OSwiY29udGVudF90eXBlIjoiQXJ0aWNsZSIsIm1hdGNoX29yZGVyIjoxLCJ6ZF90b2tlbiI6bnVsbH0.CApCPrMyKJ4bGnuk-vpI_EChPC2Am7bKUGhWA8j9Zrg&zhida_source=entity)): 可变字体，可以无级的调整字体的粗细
- HW 表示半宽，即可能包含半宽字符（英文，数字）
- SC, TC, HC, J, K: 简中，繁中（台），繁中（港），日文，韩文（全部为**完整**字符集，默认为日文写法）
- CN, TW, HK, JP, KR：中国大陆，中国台湾，中国香港，日本，韩国（**非**完整字符集，仅包含该地区的字符集）

不同地区虽然有相同的汉字，但是不同地区的写法可能存在差异，思源字体在 `SourceHanSerifReadMe` 文档中整理了关于 SC, TC, HC, J, K 同字不同型的文字，其中完全不同的有 63 个。



每种字体会根据字重(weight)不同，分成了不同字体文件，比如思源字体的定义如下：

| 数值 | 字重英文   | 中文 |
| ---- | ---------- | ---- |
| 0    | ExtraLight | 特细 |
| 160  | Light      | 细   |
| 320  | Normal     | 常规 |
| 420  | Regular    | 一般 |
| 560  | Medium     | 中等 |
| 780  | Bold       | 粗   |
| 1000 | Heavy      | 极粗 |

以下是CSS定义标准

| CSS数值 | 权重英文       | 中文       |
| ------- | -------------- | ---------- |
| 100     | Thin           | 极细、超细 |
| 200     | ExtraLight     | 特细       |
| 300     | Light          | 细         |
| 400     | Normal/Regular | 常规       |
| 500     | Medium         | 中等       |
| 600     | SemiBold       | 半粗       |
| 700     | Bold           | 粗体       |
| 800     | ExtraBold      | 特粗       |
| 900     | Black/Heavy    | 极粗、重   |



## SnappyTest
Snappy在C#下的实现

同时解决引入Unity工程后，在安卓环境下，使用IL2CPP会崩溃的问题

## 外部工程
以下目录来自作者`Erik Ross`开发: ``AnimationEditorPose, DeterministicRNG, MeshCombineAndOccluder, Outlines, PerformanHealthBars, SfxPool, Singleton``
来源: https://github.com/fholm/unityassets.git
旧版本记录: https://github.com/fholm/unityassets/tree/old



