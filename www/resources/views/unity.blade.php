@extends('layouts.app')

@section('content')
<title>Unity WebGL Player | BattleScripts</title>
<link rel="shortcut icon" href="{{ asset('game/TemplateData/favicon.ico')}}">
<link rel="stylesheet" href="{{asset('game/TemplateData/style.css')}}">
<script src="{{ URL::asset('game/TemplateData/UnityProgress.js')}}"></script>
<script src="{{ URL::asset('game/Build/UnityLoader.js')}}"></script>
<script>
  var gameInstance = UnityLoader.instantiate("gameContainer", "game/Build/game.json", {onProgress: UnityProgress});
</script>
</head>
<body>
<div class="webgl-content">
  <div id="gameContainer" style="width: 960px; height: 600px"></div>
  <div class="footer">
    <div class="webgl-logo"></div>
    <div class="fullscreen" onclick="gameInstance.SetFullscreen(1)"></div>
    <div class="title">BattleScripts</div>
  </div>
</div>
</body>
@endsection
