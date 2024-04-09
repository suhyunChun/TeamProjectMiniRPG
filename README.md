 # UNITY ADVANCED PROEJCT - Mini RPG

## 🎪 프로젝트 소개
- 3D Dungeon RPG
***
### 📺 [시연영상](https://www.youtube.com/watch?v=ZzmL-MVHuPk)
***
### ⏰ 개발 기간
- 24.01.02 ~ 24.01.08
***
### 🛠 개발 환경
<a><img src="https://img.shields.io/badge/csharp-512BD4?style=flat-square&logo=csharp&logoColor=white"/></a>
<a><img src="https://img.shields.io/badge/visualstudio-5C2D91?style=flat-square&logo=visualstudio&logoColor=white"/></a>
<a><img src="https://img.shields.io/badge/unity-000000?style=flat-square&logo=unity&logoColor=white"/></a>

***
### 🎮 플레이 방법

이동 : 마우스 우클릭

공격 : 마우스 좌클릭

상호작용 : F
  
인벤토리 : I

***
### 🤝 팀원 및 주요 구현 기능
#### 김동현 - 팀장 | Quest, NPC System / UI / Village / Interaction

#### 송희성 - 팀원 | Player (Input, FSM, Data Module)

#### 전수현 - 팀원 | Async (Resource, Loading Scene)

#### 권오태 - 팀원 | Enemy (NavMeshAgent, Spawn System) / Dungeon

#### 송하겸 - 팀원 | UI System (Inventory, UI Binding)

#### 이정훈 - 유령 | 미니맵 시스템, 각종 지원

***
### 🛠 구현 기능

##### 로딩씬 - Addressable을 이용한 리소스 에셋 비동기 로드
- ResourceManager.cs => 각 씬에 필요한 에셋 및 데이터를 비동기 로드. 
- 씬이 다양하고 필요한 에셋들의 숫자가 생각보다 커서 Addressable을 활용해보기로 결정.
- 각 에셋에 필요한 태그를 추가 후 (Preload, StartScene  등) Addressable를 이용해 비동기 로드. 로드를 하는 도중에는 유저에게 로딩페이지를 보여줌으로 완벽하게 로드 된 상태에서 게임을 플레이 할 수 있도록 환경 조성. 





---

## In Game Screenshot

![](https://i.imgur.com/VnCspNs.gif)
![](https://i.imgur.com/0XBBJo9.gif)
![](https://i.imgur.com/CjNdNh4.gif)
![](https://i.imgur.com/UqEdyHD.gif)
