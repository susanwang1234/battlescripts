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
</div>

</body>