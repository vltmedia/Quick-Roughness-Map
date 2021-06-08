# Quick Roughness Map

<a href="https://github.com/vltmedia/Quick-Roughness-Map"><img alt="GitHub" src="https://img.shields.io/badge/github-%23121011.svg?style=flat&logo=github&logoColor=white"/></a><img alt="C#" src="https://img.shields.io/badge/c%23-%23239120.svg?style=flat&logo=c-sharp&logoColor=white"/><img alt=".Net" src="https://img.shields.io/badge/.NET-5C2D91?style=flat&logo=.net&logoColor=white"/>

[![GitHub release](https://img.shields.io/github/release/vltmedia/Quick-Roughness-Map.svg)](https://GitHub.com/vltmedia/Quick-Roughness-Map/releases/)

Using this small  Win64 tool, an artist can pass in a color photo they would want to create a greyscale Roughness map for. For more info on Roughness maps please look up PBR rendering. 

The maps are created from either a single channel of the image (R,G,B), or averaging the pixels together. The result will be a greyscale image.

# Usage

```shell
GenerateRoughnessMap.exe input.png output.png (R,G,B,Average)
```

```
GenerateRoughnessMap.exe input.png output.png R
```

