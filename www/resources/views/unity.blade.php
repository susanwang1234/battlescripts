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
		  var userId = {!! json_encode((string)Auth::user()->id) !!};
		  var userName = {!! json_encode(Auth::user()->name) !!};
		  var gameInstance = UnityLoader.instantiate("gameContainer", "game/Build/Build.json", {
		      onProgress: UnityProgress,
		      Module  : {
		          onRuntimeInitialized: function() {
		          setTimeout(function() {
			          gameInstance.SendMessage("Player Name","SetPlayerName", userName);
			          gameInstance.SendMessage("Launcher","SetUserId", userId);
			          gameInstance.SendMessage("Launcher","SetUserName", userName);
			        }, 2000);},
		    	},    
	    	});
		  
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
					<div class="home" style="float:left;"><a href="/">&nbsp;Home&nbsp;</a></div>
					<div class="about" style="float:left;"><a href="/about" target="_blank">&nbsp;About&nbsp;</a></div>
					<div class="tutorial" style="float:left;"><a href="/tutorial" target="_blank">&nbsp;Tutorial</a></div>
				</div>
			  </div>
		</div>
	</div>

	</body>
@endif