@extends('layouts.app')

@section('content')
<link href="{{ asset('css/info.css') }}" rel="stylesheet">
<link href="https://fonts.googleapis.com/css?family=Lato" rel="stylesheet">
<link href="https://fonts.googleapis.com/css?family=VT323" rel="stylesheet">
<body background="/images/background.png">
	<img src="{{URL::asset('/images/logo_text.png')}}" class="center" style="width:20%; height=auto">
	<nav>
		<ul class="group">
		    <li class="item"><a href="/about">ABOUT</a></li>
		    <li class="item"><a href="/tutorial">TUTORIAL</a></li>
			<li class="item"><a href="/start">GETTING STARTED</a></li>
		</ul>
	</nav>
		</header>
        <div class="textbox">
		  <h1>About</h1>

		  <p>Programming can be challenging and boring, but it doesn't have to be. <i>Battlescripts</i> makes programming concepts easy to grasp by playing cards to execute code. Engage and interact with other users to develop new skills and enjoy coding!</p>

		  <p>Our game introduces coding concepts to players and sharpen their ability to build programs using blocks of logic without having to worry about syntax or typing errors. Players will have to think strategically through the use of various different features: data types, loops, conditions, memory, and execution time, while keeping an eye on their own and their opponent's life points.</p>

		  <p>All of this happens live on a 2-player network connected game channel!</p>

		  <p>Proud of your accomplishment? Make sure to share it on Facebook!</p>
		</div>

</body>

@endsection
