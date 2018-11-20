<<<<<<< HEAD
{{-- old code: <<<<<<< HEAD
@if (empty(Auth::user()->email_verified_at))
	<script type="text/javascript">
          window.location = "{{ url('/email/verify') }}";
    </script>
@else
	@extends('layouts.app')

    @section('content')
	<head>
		<title>Unity WebGL Player | BattleScripts</title>
		<link rel="shortcut icon" href="{{ asset('game/TemplateData/favicon.ico')}}">
		<link rel="stylesheet" href="{{asset('game/TemplateData/style.css')}}">
		<script src="{{ URL::asset('game/TemplateData/UnityProgress.js')}}"></script>
		<script src="{{ URL::asset('game/Build/UnityLoader.js')}}"></script>
		<script>
		  var gameInstance = UnityLoader.instantiate("gameContainer", "game/Build/Build.json", {onProgress: UnityProgress});
		</script>
		<link href="{{ asset('css/home.css') }}" rel="stylesheet">
		<link href="https://fonts.googleapis.com/css?family=Lato" rel="stylesheet">
		<link href="https://fonts.googleapis.com/css?family=VT323" rel="stylesheet">
	</head>

	<body>

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
@endif

=======--}}
@if (empty(Auth::user()->email_verified_at))
	<script type="text/javascript">
          window.location = "{{ url('/email/verify') }}";
    </script>
@else
	<head>
		<title>BattleScript</title>
		<link rel="shortcut icon" href="{{ asset('game/TemplateData/battlescript.ico')}}">
		<link rel="stylesheet" href="{{asset('game/TemplateData/style.css')}}">
		<script src="{{ URL::asset('game/TemplateData/UnityProgress.js')}}"></script>
		<script src="{{ URL::asset('game/Build/UnityLoader.js')}}"></script>
		<script>
		  var gameInstance = UnityLoader.instantiate("gameContainer", "game/Build/Build.json", {onProgress: UnityProgress});
		</script>
		<link href="{{ asset('css/home.css') }}" rel="stylesheet">
	</head>

	<body style="background-color: rgb(26, 26, 26);">


	<div>
		<div class="webgl-content" style="box-shadow: 0px 0px 50px rgb(245, 137, 142);">
			  <div id="gameContainer" style="width: 1260px; height: 780px"></div>
			  <div class="footer" style="margin-top:0">
				<div class="webgl-logo"></div>
				<div class="title" style="color:white;">Team 404 &copy; 2018</div>
				<div class="gameNav">
					<div class="home" style="float:left;"><a href="/">Home</a></div>
					<div class="about" style="float:left;"><a href="/about" target="_blank">About</a></div>
					<div class="tutorial" style="float:left;"><a href="/tutorial" target="_blank">Tutorial</a></div>
				</div>
			  </div>
		</div>
=======
<head>
	<title>BattleScript</title>
	<link rel="shortcut icon" href="{{ asset('game/TemplateData/battlescript.ico')}}">
	<link rel="stylesheet" href="{{asset('game/TemplateData/style.css')}}">
	<script src="{{ URL::asset('game/TemplateData/UnityProgress.js')}}"></script>
	<script src="{{ URL::asset('game/Build/UnityLoader.js')}}"></script>
	<script>
	  var gameInstance = UnityLoader.instantiate("gameContainer", "game/Build/Build.json", {onProgress: UnityProgress});
	</script>
	<link href="{{ asset('css/home.css') }}" rel="stylesheet">
</head>

<body style="background-color: rgb(26, 26, 26);">


<div>
	<div class="webgl-content" style="box-shadow: 0px 0px 50px rgb(245, 137, 142);">
		  <div id="gameContainer" style="width: 1260px; height: 780px"></div>
		  <div class="footer" style="margin-top:0">
			<div class="webgl-logo"></div>
			<div class="title" style="color:white;">Team 404 &copy; 2018</div>
			<div class="gameNav">
				<div class="home" style="float:left;"><a href="/">Home</a></div>
				<div class="about" style="float:left;"><a href="/about" target="_blank">About</a></div>
				<div class="tutorial" style="float:left;"><a href="/tutorial" target="_blank">Tutorial</a></div>
			</div>
		  </div>
>>>>>>> c12fdf749cb840a9b150fe0751cbd1f032017fe3
	</div>

<<<<<<< HEAD
	</body>
@endif
>>>>>>> 17c8212942818421e3a27404cc6b067b39681082
=======
</body>
>>>>>>> c12fdf749cb840a9b150fe0751cbd1f032017fe3
