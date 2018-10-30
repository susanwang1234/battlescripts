@extends('layouts.app')

@section('content')
<head>
	<title>Unity WebGL Player | BattleScripts</title>
	<link rel="shortcut icon" href="{{ asset('game/TemplateData/favicon.ico')}}">
	<link rel="stylesheet" href="{{asset('game/TemplateData/style.css')}}">
	<script src="{{ URL::asset('game/TemplateData/UnityProgress.js')}}"></script>
	<script src="{{ URL::asset('game/Build/UnityLoader.js')}}"></script>
	<script>
	  var gameInstance = UnityLoader.instantiate("gameContainer", "game/Build/game.json", {onProgress: UnityProgress});
	</script>
	<link href="{{ asset('css/home.css') }}" rel="stylesheet">
	<link href="https://fonts.googleapis.com/css?family=Lato" rel="stylesheet">
	<link href="https://fonts.googleapis.com/css?family=VT323" rel="stylesheet">
</head>

<body>
{{--<div class="bg">
	<div class="container">
	    <div class="row justify-content-center">
	        <div class="col-md-8">
	        	<img src="{{URL::asset('/images/logo_text.png')}}" class="center-block" style="width:100%; height=auto">
	        </div>
	    </div>
	</div>
</div>--}}

<div class="content-bg">
<div class=categories>
	<ul>
	    <li><a href="/index.php">HOME</a></li>
		<li><a href="/about">ABOUT</a></li>
		<li><a href="/tutorial">TUTORIAL</a></li>
		<li><a href="/start">GETTING STARTED</a></li>
		<li><a id="activeplay" href="/unity">PLAY NOW</a></li>
	</ul>
</div>

<div class="webgl-content" style="margin-top:5%; box-shadow: 0px 0px 50px lime;">
	  <div id="gameContainer" style="width: 960px; height: 600px"></div>
	  <div class="footer" style="margin-top:0">
		<div class="webgl-logo"></div>
		<div class="fullscreen" onclick="gameInstance.SetFullscreen(1)"></div>
		<div class="title" style="color:white;">BattleScript || Team 404 &copy; 2018</div>
	  </div>
</div>

<div class="footer" style="margin-top:50%">
	<div id="footertext">Team 404 &copy; 2018</div>
</div>

</div>

</body>
@endsection







{{--@extends('layouts.app')

@section('content')
<head>
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
@endsection--}}
