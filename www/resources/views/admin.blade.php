@extends('layouts.app')
@section('content')

<script src="//maxcdn.bootstrapcdn.com/bootstrap/3.3.0/js/bootstrap.min.js"></script>
<script src="//code.jquery.com/jquery-1.11.1.min.js"></script>
<!------ Include the above in your HEAD tag ---------->

<script src="http://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>
<script src="http://getbootstrap.com/dist/js/bootstrap.min.js"></script>
<link href="{{ asset('css/admin.css') }}" rel="stylesheet">
<div class="container">
  <div class="row">    
      <div class="col-md-12">
        <h4>All Registered Users</h4>
        <div class="table-responsive">
          <table id="mytable" class="table table-bordred table-striped">
          <thead>       
            <th>Id</th>
            <th>Name</th>
            <th>Email</th>
            <th>Email Verified At</th>
            <th>Is Administrator</th>
          </thead>
          <tbody>
            @foreach ($userlist as $r)
              <tr>
                <td>{{ $r->id }}</td>
                <td>{{ $r->name }}</td>
                <td>{{ $r->email }}</td>
                <td>{{ $r->email_verified_at }}</td>
                <td>{{ $r->isAdmin }}</td>
              </tr>
            @endforeach
          </tbody>
        </table>
        </div>
    </div>
  </div>
</div>

<div class="container">
  <div class="row">    
      <div class="col-md-12">
        <h4>All Match History</h4>
        <div class="table-responsive">
          <table id="mytable" class="table table-bordred table-striped">
          <thead>       
            <th>Id</th>
            <th>Player ID</th>
            <th>Player Name</th>
            <th>Result</th>
            <th>Recorded At</th>
          </thead>
          <tbody>
            @foreach ($match_history as $r)
              <tr>
                <td>{{ $r->id }}</td>
                <td>{{ $r->player_id }}</td>
                <td>{{ DB::table('users')->where('id', $r->player_id)->value('name') }} </td>
                <td>{{ $r->result }}</td>
                <td>{{ $r->created_at }}</td>
              </tr>
            @endforeach
          </tbody>
        </table>
        </div>
    </div>
  </div>
</div>

@endsection