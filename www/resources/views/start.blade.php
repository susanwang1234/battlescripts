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
          <li class="item"><a class="active" href="/start">GETTING STARTED</a></li>
      </ul>
    </nav>
		</header>
        <div class="tips">
		  <h1>Sounds hard, eh? Here are some tips to get you started.</h1>
		  <ul class="list">
	          <li>Try to keep your points in the middle to be safe, not too low, not to high, to avoid being overflown by your opponent.</li>
	          <li>Only have some small combos? You don't have to execute right away; build onto it for a couple turns, and attack your opponent all at once!</li>
	          <li>Sometimes it is important to boost your own life, rather then decrement your opponents. Be careful!</li>
	          <li>Take advantage of your memory. Store good card blocks inside memory to use later.</li>
	          <li>Calculations matter: overflow your opponents or make your score exactly to zero.</li>
	      </ul>

		</div>

</body>

@endsection
